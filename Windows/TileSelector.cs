using System;
using System.Drawing;
using System.Windows.Forms;
using OrisonEditor.Definitions;
using System.Drawing.Drawing2D;

namespace OrisonEditor.Windows
{
    public partial class TileSelector : UserControl
    {
        private const int BUFFER = 20;

        private Tileset tileset;
        private Bitmap bitmap;
        private Matrix inverseMatrix;
        private Rectangle? selection;

        private Pen tileSelectPenA;
        private Pen tileSelectPenB;

        private bool selecting;
        private Point selectingStart;

        public TileSelector()
        {
            InitializeComponent();

            tileSelectPenA = new Pen(Color.Yellow, 4);

            tileSelectPenB = new Pen(Color.Black, 2);
            tileSelectPenB.DashPattern = new float[] { 4, 2 };
        }

        public Rectangle? Selection
        {
            get { return selection; }
            set
            {
                selection = value;
                pictureBox.Refresh();
            }
        }

        public Tileset Tileset
        {
            get { return tileset; }
            set
            {
                if (tileset != null)
                {
                    selection = null;
                    bitmap.Dispose();
                }
                tileset = value;
                if (Tileset != null)
                    bitmap = Tileset.GetBitmap();                
                else
                    bitmap = null;
                pictureBox.Refresh();
            }
        }

        #region Changing the Selection

        public void MoveSelectionLeft()
        {
            if (selection.HasValue)
            {
                if (selection.Value.X <= 0)
                    selection = new Rectangle(Tileset.TilesAcross - selection.Value.Width, selection.Value.Y, selection.Value.Width, selection.Value.Height);
                else
                    selection = new Rectangle(selection.Value.X - 1, selection.Value.Y, selection.Value.Width, selection.Value.Height);
                pictureBox.Refresh();
            }
        }

        public void MoveSelectionRight()
        {
            if (selection.HasValue)
            {
                if (selection.Value.X + selection.Value.Width >= Tileset.TilesAcross)
                    selection = new Rectangle(0, selection.Value.Y, selection.Value.Width, selection.Value.Height);
                else
                    selection = new Rectangle(selection.Value.X + 1, selection.Value.Y, selection.Value.Width, selection.Value.Height);
                pictureBox.Refresh();
            }
        }

        public void MoveSelectionUp()
        {
            if (selection.HasValue)
            {
                if (selection.Value.Y <= 0)
                    selection = new Rectangle(selection.Value.X, Tileset.TilesDown - selection.Value.Height, selection.Value.Width, selection.Value.Height);
                else
                    selection = new Rectangle(selection.Value.X, selection.Value.Y - 1, selection.Value.Width, selection.Value.Height);
                pictureBox.Refresh();
            }
        }

        public void MoveSelectionDown()
        {
            if (selection.HasValue)
            {
                if (selection.Value.Y + selection.Value.Height >= Tileset.TilesDown)
                    selection = new Rectangle(selection.Value.X, 0, selection.Value.Width, selection.Value.Height);
                else
                    selection = new Rectangle(selection.Value.X, selection.Value.Y + 1, selection.Value.Width, selection.Value.Height);
                pictureBox.Refresh();
            }
        }

        public void SetSelectionID(int id)
        {
            if (id == -1)
                selection = null;
            else
            {
                Point at = tileset.GetCellFromID(id);
                selection = new Rectangle(at.X, at.Y, 1, 1);
            }
            pictureBox.Refresh();
        }

        #endregion

        #region Events

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (bitmap != null)
            {
                Graphics g = e.Graphics;

                float scale = Math.Min((pictureBox.ClientSize.Width - BUFFER) / (float)Tileset.Bitmap.Width, (pictureBox.ClientSize.Height - BUFFER) / (float)Tileset.Bitmap.Height);

                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

                g.ResetTransform();
                g.TranslateTransform(pictureBox.ClientSize.Width / 2f, pictureBox.ClientSize.Height / 2f);
                g.ScaleTransform(scale, scale);
                g.TranslateTransform(-Tileset.Bitmap.Width / 2f, -Tileset.Bitmap.Height / 2f);
                
                g.DrawImage(Tileset.Bitmap, 0, 0, Tileset.Bitmap.Width, Tileset.Bitmap.Height);

                if (selection.HasValue)
                {
                    tileSelectPenA.Width = 4 / scale;
                    tileSelectPenB.Width = 2 / scale;
                    Rectangle r = tileset.GetVisualRectFromSelection(selection.Value);

                    g.DrawRectangle(tileSelectPenA, r);
                    g.DrawRectangle(tileSelectPenB, r);
                }

                inverseMatrix = g.Transform.Clone();
                inverseMatrix.Invert();
            }
        }

        private void pictureBox_Resize(object sender, EventArgs e)
        {
            if (Tileset != null)
                pictureBox.Refresh();
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (tileset == null)
                return;

            Point at = ResolveTilePoint(e.Location);
            if (tileset.ContainsTile(at))
            {
                selecting = true;
                selectingStart = at;
                selection = new Rectangle(at.X, at.Y, 1, 1);
                pictureBox.Refresh();
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!selecting)
                return;

            Point at = ResolveTilePoint(e.Location);
            if (tileset.ContainsTile(at))
            {
                Point start = new Point(Math.Min(at.X, selectingStart.X), Math.Min(at.Y, selectingStart.Y));
                Point end = new Point(Math.Max(at.X, selectingStart.X), Math.Max(at.Y, selectingStart.Y));

                selection = new Rectangle(start.X, start.Y, end.X - start.X + 1, end.Y - start.Y + 1);
                pictureBox.Refresh();
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            selecting = false;
            Orison.MainWindow.FocusEditor();
        }

        #endregion

        #region Utilities

        private Point ResolveTilePoint(Point p)
        {
            p = inverseMatrix.TransformPoint(p);
            return tileset.GetCellFromID(tileset.GetTileHit(p));
        }

        private Point SnapPoint(Point point, Rectangle to)
        {
            Point pt = new Point(point.X, point.Y);
            if (pt.X < to.X)
                pt.X = to.X;
            if (pt.Y < to.Y)
                pt.Y = to.Y;
            if (pt.X >= to.X + to.Width)
                pt.X = to.X + to.Width;
            if (pt.Y >= to.Y + to.Height)
                pt.Y = to.Y + to.Height;
            return pt;
        }

        #endregion
    }
}
