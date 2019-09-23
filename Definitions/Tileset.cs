using System.Drawing;
using System.IO;

namespace OrisonEditor.Definitions
{
    public class Tileset
    {
        public string Name;
        public string FilePath;
        public Size TileSize;
        public int TileSep;

        private Bitmap bitmap;
        private Rectangle[] tileRects;
        private Bitmap[] tileBitmaps;

        public Tileset()
        {
            TileSize = new Size(16, 16);
            FilePath = "";
            TileSep = 0;
        }

        public Tileset Clone()
        {
            Tileset set = new Tileset();
            set.Name = Name;
            set.FilePath = FilePath;
            set.TileSize = TileSize;
            set.TileSep = TileSep;
            return set;
        }

        public void SetFilePath(string to)
        {
            FilePath = to;
            GenerateBitmap();
        }

        public Rectangle GetRectFromID(int id)
        {
            int y = id / TilesAcross;
            int x = id % TilesAcross;

            return new Rectangle(x * (TileSize.Width + TileSep), y * (TileSize.Height + TileSep), TileSize.Width, TileSize.Height);
        }

        public Bitmap GetBitmapFromID(int id)
        {
            return tileBitmaps[id];
        }

        public Rectangle GetVisualRectFromSelection(Rectangle selection)
        {
            return new Rectangle(selection.X * (TileSize.Width + TileSep), selection.Y * (TileSize.Height + TileSep), selection.Width * TileSize.Width + (selection.Width - 1) * TileSep, selection.Height * TileSize.Height + (selection.Height - 1) * TileSep);
        }

        public int GetIDFromSelectionRectPoint(Rectangle selection, Point startCell, Point currentCell)
        {
            return GetIDFromCell(new Point(selection.X + Util.Wrap(currentCell.X - startCell.X, selection.Width), selection.Y + Util.Wrap(currentCell.Y - startCell.Y, selection.Height)));
        }

        public int GetTileHit(Point at)
        {
            for (int i = 0; i < tileRects.Length; i++)
            {
                Rectangle hit = tileRects[i];
                hit.Width += TileSep;
                hit.Height += TileSep;
                if (hit.Contains(at))
                    return i;

            }
            return -1;
        }

        public int TilesAcross
        {
            get
            {
                int across = 0;
                for (int i = 0; i + TileSize.Width <= Size.Width; i += TileSize.Width + TileSep)
                    across++;
                return across;
            }
        }

        public int TilesDown
        {
            get
            {
                int down = 0;
                for (int i = 0; i + TileSize.Height <= Size.Height; i += TileSize.Height + TileSep)
                    down++;
                return down;
            }
        }

        public int TilesTotal
        {
            get
            {
                return TilesAcross * TilesDown;
            }
        }

        public void GenerateBitmap()
        {
            if (!File.Exists(Path.Combine(Orison.Project.SavedDirectory, FilePath)))
            {
                bitmap = null;
                tileRects = null;
            }
            else
            {
                bitmap = new Bitmap(Path.Combine(Orison.Project.SavedDirectory, FilePath));
                
                tileRects = new Rectangle[TilesTotal];
                tileBitmaps = new Bitmap[TilesTotal];
                for (int i = 0; i < TilesTotal; i++)
                {
                    tileRects[i] = GetRectFromID(i);

                    // Create bitmap for tile
                    Bitmap copy = new Bitmap(tileRects[i].Width, tileRects[i].Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
                    
                    using (Graphics g = Graphics.FromImage(copy)) 
                    {
                        g.DrawImage(bitmap,
                            new Rectangle(0, 0, tileRects[i].Width, tileRects[i].Height),
                            tileRects[i],
                            GraphicsUnit.Pixel);
                    }
                    tileBitmaps[i] = copy;
                }
            }
        }

        public Rectangle Bounds
        {
            get
            {
                if (bitmap == null)
                    return Rectangle.Empty;
                else
                    return new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            }
        }

        public Size Size
        {
            get
            {
                if (bitmap == null)
                    return Size.Empty;
                else
                    return bitmap.Size;
            }
        }

        public Bitmap Bitmap { get { return bitmap; } }
        public Rectangle[] TileRects { get { return tileRects; } }

        public Bitmap GetBitmap()
        {
            if (bitmap == null)
                return null;
            else
                return (Bitmap)bitmap.Clone();
        }

        public override string ToString()
        {
            return Name;
        }

        public bool ContainsTile(Point tile)
        {
            return tile.X >= 0 && tile.Y >= 0 && tile.X < TilesAcross && tile.Y < TilesDown;
        }

        public bool ContainsTile(int id)
        {
            return id >= 0 && id < TilesTotal;
        }

        public int GetIDFromCell(Point cell)
        {
            if (cell.X >= TilesAcross)
                return -1;
            if (cell.Y >= TilesDown)
                return -1;

            return cell.X + cell.Y * TilesAcross;
        }

        public int GetIDFromCell(int cellX, int cellY)
        {
            if (cellX >= TilesAcross)
                return -1;
            if (cellY >= TilesDown)
                return -1;

            return cellX + cellY * TilesAcross;
        }

        public Point GetCellFromID(int id)
        {
            return new Point(id % TilesAcross, id / TilesAcross);
        }

        public int TransformID(Tileset from, int id)
        {
            if (id == -1)
                return -1;

            return GetIDFromCell(from.GetCellFromID(id));
        }

        public int[,] TransformMap(Tileset from, int[,] ids)
        {
            int[,] transformed = new int[ids.GetLength(0), ids.GetLength(1)];
            for (int i = 0; i < ids.GetLength(0); i++)
                for (int j = 0; j < ids.GetLength(1); j++)
                    transformed[i, j] = TransformID(from, ids[i, j]);
            return transformed;
        }
    }
}
