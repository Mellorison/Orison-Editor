using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using OrisonEditor.LevelEditors.Actions.TileActions;

namespace OrisonEditor.LevelEditors.Tools.TileTools
{
    public class TileRectangleTool : TileTool
    {
        private bool drawing;
        private bool drawMode;
        private Point drawStart;
        private Point drawTo;
        private SolidBrush eraseBrush;

        public TileRectangleTool()
            : base("Rectangle", "rectangle.png")
        {
            drawing = false;
            eraseBrush = new SolidBrush(Color.FromArgb(255 / 2, Color.Red));
        }

        public override void Draw(Graphics graphics)
        {
            if (drawing)
            {
                Rectangle draw = GetRect();
                if (LevelEditor.Level.Bounds.IntersectsWith(draw))
                {
                    if (!drawMode || !Orison.TilePaletteWindow.Tiles.HasValue)
                        graphics.FillRectangle(eraseBrush, draw);
                    else
                    {
                        Rectangle selection = Orison.TilePaletteWindow.Tiles.Value;
                        for (int i = 0; i < draw.Width / LayerEditor.Layer.Definition.Grid.Width; i++)
                        {
                            for (int j = 0; j < draw.Height / LayerEditor.Layer.Definition.Grid.Height; j++)
                            {
                                int id = LayerEditor.Layer.Tileset.GetIDFromSelectionRectPoint(selection, new Point(draw.X / LayerEditor.Layer.Definition.Grid.Width, draw.Y / LayerEditor.Layer.Definition.Grid.Height), new Point(draw.X / LayerEditor.Layer.Definition.Grid.Width + i, draw.Y / LayerEditor.Layer.Definition.Grid.Height + j));
                                Rectangle tileRect = LayerEditor.Layer.Tileset.TileRects[id];
                                Point drawAt = new Point(draw.X + i * LayerEditor.Layer.Definition.Grid.Width, draw.Y + j * LayerEditor.Layer.Definition.Grid.Height);

                                graphics.DrawImage(LayerEditor.Layer.Tileset.Bitmap, new Rectangle(drawAt.X, drawAt.Y, LayerEditor.Layer.Definition.Grid.Width, LayerEditor.Layer.Definition.Grid.Height), tileRect.X, tileRect.Y, tileRect.Width, tileRect.Height, GraphicsUnit.Pixel, Util.HalfAlphaAttributes);
                            }
                        }
                    }
                }
            }
        }

        public override void OnMouseLeftDown(System.Drawing.Point location)
        {
            drawTo = drawStart = LayerEditor.MouseSnapPosition;
            drawing = true;
            drawMode = true;
        }

        public override void OnMouseLeftUp(Point location)
        {
            if (drawing && drawMode)
                DrawRect();
        }

        public override void OnMouseRightDown(Point location)
        {
            drawTo = drawStart = LayerEditor.MouseSnapPosition;
            drawing = true;
            drawMode = false;
        }

        public override void OnMouseRightUp(Point location)
        {
            if (drawing && !drawMode)
                DrawRect();
        }

        public override void OnMouseMove(Point location)
        {
            if (drawing)
                drawTo = LayerEditor.MouseSnapPosition;
        }

        /*
         *  Helpers
         */
        private void DrawRect()
        {
            drawing = false;
            Rectangle draw = GetRect();
            if (LevelEditor.Level.Bounds.IntersectsWith(draw))
            {
                draw = LayerEditor.Layer.Definition.ConvertToGrid(draw);
                LevelEditor.Perform(new TileRectangleAction(LayerEditor.Layer, draw, drawMode ? Orison.TilePaletteWindow.Tiles : null));
            }
        }

        private Rectangle GetRect()
        {
            Rectangle r = new Rectangle();

            //Get the rectangle
            r.X = Math.Min(drawStart.X, drawTo.X);
            r.Y = Math.Min(drawStart.Y, drawTo.Y);
            r.Width = Math.Abs(drawTo.X - drawStart.X) + LayerEditor.Layer.Definition.Grid.Width;
            r.Height = Math.Abs(drawTo.Y - drawStart.Y) + LayerEditor.Layer.Definition.Grid.Height;

            //Enforce Bounds
            if (r.X < 0)
            {
                r.Width += r.X;
                r.X = 0;
            }

            if (r.Y < 0)
            {
                r.Height += r.Y;
                r.Y = 0;
            }

            int width = LayerEditor.Layer.TileCellsX * LayerEditor.Layer.Definition.Grid.Width;
            int height = LayerEditor.Layer.TileCellsY * LayerEditor.Layer.Definition.Grid.Height;

            if (r.X + r.Width > width)
                r.Width = width - r.X;

            if (r.Y + r.Height > height)
                r.Height = height - r.Y;

            return r;
        }
    }
}
