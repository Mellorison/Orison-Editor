using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.Definitions.LayerDefinitions;
using System.Xml;
using OrisonEditor.LevelEditors.LayerEditors;
using OrisonEditor.LevelEditors.Resizers;
using System.Drawing;
using OrisonEditor.Definitions;
using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace OrisonEditor.LevelData.Layers
{
    public class TileLayer : Layer
    {
        public const int CHUNK_SIZE = 512;
        
        public new TileLayerDefinition Definition { get; private set; }       
        public TileSelection Selection;

        public Tileset Tileset;
        private int[,] tiles;
        private Bitmap[,] canvasChunks;
        private Bitmap[,] canvasChunksAlpha;
        private Graphics[,] canvasGraphics;
        private Graphics[,] canvasGraphicsAlpha;
        
        private Point DrawOffset = new Point(0,0);

        public TileLayer(Level level, TileLayerDefinition definition)
            : base(level, definition)
        {
            Definition = definition;
            Tileset = Orison.Project.Tilesets[0];

            int tileWidth = Level.Size.Width / definition.Grid.Width + (Level.Size.Width % definition.Grid.Width != 0 ? 1 : 0);
            int tileHeight = Level.Size.Height / definition.Grid.Height + (Level.Size.Height % definition.Grid.Height != 0 ? 1 : 0);
            tiles = new int[tileWidth, tileHeight];
            Clear();

            ResetBitmaps();
        }

        public void UpdateDrawOffset(PointF offset)
        {
            DrawOffset = new Point((int)offset.X, (int)offset.Y);
        }

        public override XmlElement GetXML(XmlDocument doc)
        {
            XmlElement xml = doc.CreateElement(Definition.Name);

            //Save which tileset is being used for this layer
            XmlAttribute tileset = doc.CreateAttribute("tileset");
            tileset.InnerText = Tileset.Name;
            xml.Attributes.Append(tileset);

            //Save the export mode
            XmlAttribute export = doc.CreateAttribute("exportMode");
            export.InnerText = Definition.ExportMode.ToString();
            xml.Attributes.Append(export);

            if (Definition.ExportMode == TileLayerDefinition.TileExportMode.CSV || Definition.ExportMode == TileLayerDefinition.TileExportMode.TrimmedCSV)
            {
                //Convert all tile values to CSV
                string[] rows = new string[TileCellsY];
                for (int i = 0; i < TileCellsY; i++)
                {
                    string[] tileStrs = new string[TileCellsX];
                    for (int j = 0; j < tileStrs.GetLength(0); j++)
                    {
                        tileStrs[j] = tiles[j, i].ToString();
                    }
                    rows[i] = string.Join(",", tileStrs);
                }

                //Trim off trailing empties
                if (Definition.ExportMode == TileLayerDefinition.TileExportMode.TrimmedCSV)
                {
                    for (int i = 0; i < rows.Length; i++)
                    {
                        int index = rows[i].LastIndexOf(",-1");
                        while (index != -1 && index == rows[i].Length - 3)
                        {
                            rows[i] = rows[i].Substring(0, rows[i].Length - 3);
                            index = rows[i].LastIndexOf(",-1");
                        }
                        if (rows[i] == "-1")
                            rows[i] = "";
                    }
                }

                //Throw it in the xml text
                xml.InnerText = string.Join("\n", rows);
            }
            else if (Definition.ExportMode == TileLayerDefinition.TileExportMode.XML || Definition.ExportMode == TileLayerDefinition.TileExportMode.XMLCoords)
            {
                //XML Export
                XmlElement tile;
                XmlAttribute a;
                for (int i = 0; i < tiles.GetLength(0); i++)
                {
                    for (int j = 0; j < tiles.GetLength(1); j++)
                    {
                        if (tiles[i, j] != -1)
                        {
                            tile = doc.CreateElement("tile");

                            a = doc.CreateAttribute("x");
                            a.InnerText = i.ToString();
                            tile.Attributes.Append(a);

                            a = doc.CreateAttribute("y");
                            a.InnerText = j.ToString();
                            tile.Attributes.Append(a);

                            if (Definition.ExportMode == TileLayerDefinition.TileExportMode.XML)
                            {
                                a = doc.CreateAttribute("id");
                                a.InnerText = tiles[i, j].ToString();
                                tile.Attributes.Append(a);
                            }
                            else
                            {
                                Point p = Tileset.GetCellFromID(tiles[i, j]);

                                a = doc.CreateAttribute("tx");
                                a.InnerText = p.X.ToString();
                                tile.Attributes.Append(a);

                                a = doc.CreateAttribute("ty");
                                a.InnerText = p.Y.ToString();
                                tile.Attributes.Append(a);
                            }

                            xml.AppendChild(tile);
                        }
                    }
                }              
            }

            return xml;
        }

        public override bool SetXML(XmlElement xml)
        {
            Clear();

            bool cleanXML = true;

            //Load the tileset
            string tilesetName = xml.Attributes["tileset"].InnerText;
            Tileset = Orison.Project.Tilesets.Find(t => t.Name == tilesetName);

            //Get the export mode
            TileLayerDefinition.TileExportMode exportMode;
            if (xml.Attributes["exportMode"] != null)
                exportMode = (TileLayerDefinition.TileExportMode)Enum.Parse(typeof(TileLayerDefinition.TileExportMode), xml.Attributes["exportMode"].InnerText);
            else
                exportMode = Definition.ExportMode;

            if (exportMode == TileLayerDefinition.TileExportMode.CSV || exportMode == TileLayerDefinition.TileExportMode.TrimmedCSV)
            {
                //CSV Import
                string s = xml.InnerText;

                string[] rows = s.Split('\n');
                if (rows.Length > tiles.GetLength(1))
                {
                    Array.Resize(ref rows, tiles.GetLength(1));
                    cleanXML = false;
                }
                for (int i = 0; i < rows.Length; i++)
                {
                    string[] tileStrs = rows[i].Split(',');
                    if (tileStrs.Length > TileCellsX)
                    {
                        Array.Resize(ref tileStrs, TileCellsX);
                        cleanXML = false;
                    }
                    if (tileStrs[0] != "")
                        for (int j = 0; j < tileStrs.Length; j++)
                            tiles[j, i] = Convert.ToInt32(tileStrs[j]);
                }
            }
            else if (exportMode == TileLayerDefinition.TileExportMode.XML || exportMode == TileLayerDefinition.TileExportMode.XMLCoords)
            {
                //XML Import
                foreach (XmlElement tile in xml)
                {
                    int x = Convert.ToInt32(tile.Attributes["x"].InnerText);
                    int y = Convert.ToInt32(tile.Attributes["y"].InnerText);

                    if (x >= Tiles.GetLength(0) || y >= Tiles.GetLength(1))
                    {
                        cleanXML = false;
                        continue;
                    }

                    if (tile.Attributes["id"] != null)
                    {
                        int id = Convert.ToInt32(tile.Attributes["id"].InnerText);
                        tiles[x, y] = id;
                    }
                    else if (tile.Attributes["tx"] != null && tile.Attributes["ty"] != null)
                    {
                        int tx = Convert.ToInt32(tile.Attributes["tx"].InnerText);
                        int ty = Convert.ToInt32(tile.Attributes["ty"].InnerText);
                        tiles[x, y] = Tileset.GetIDFromCell(new Point(tx, ty));
                    }
                }
            }

            ResetBitmaps();
            return cleanXML;
        }

        public int this[int tx, int ty]
        {
            get
            {
                return tiles[tx, ty];
            }

            set
            {
                if (tiles[tx, ty] != value)
                {
                    tiles[tx, ty] = value;
                    UpdateTile(tx, ty);
                }
            }
        }

        public int[,] Tiles
        {
            get
            {
                return tiles;
            }

            set
            {
                tiles = value;
                ResetBitmaps();
            }
        }

        public Rectangle GetTilesRectangle(Point start, Point end)
        {
            Rectangle r = new Rectangle();

            //Get the rectangle
            r.X = Math.Min(start.X, end.X);
            r.Y = Math.Min(start.Y, end.Y);
            r.Width = Math.Abs(end.X - start.X) + Definition.Grid.Width;
            r.Height = Math.Abs(end.Y - start.Y) + Definition.Grid.Height;

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

            int width = tiles.GetLength(0) * Definition.Grid.Width;
            int height = tiles.GetLength(1) * Definition.Grid.Height;

            if (r.X + r.Width > width)
                r.Width = width - r.X;

            if (r.Y + r.Height > height)
                r.Height = height - r.Y;

            return r;
        }

        public void Clear()
        {
            for (int i = 0; i < tiles.GetLength(0); i++)
                for (int j = 0; j < tiles.GetLength(1); j++)
                    tiles[i, j] = -1;

            ResetBitmaps();
        }

        public override LayerEditor GetEditor(LevelEditors.LevelEditor editor)
        {
            return new TileLayerEditor(editor, this);
        }

        public int TileCellsX
        {
            get { return tiles.GetLength(0); }
        }

        public int TileCellsY
        {
            get { return tiles.GetLength(1); }
        }

        #region Update the Cache

        private void ResetBitmaps()
        {
            ClearAllBitmaps();

            int chunkW = (Level.Size.Width / CHUNK_SIZE) + 1;
            int chunkH = (Level.Size.Height / CHUNK_SIZE) + 1;
            canvasChunks = new Bitmap[chunkW, chunkH];
            canvasChunksAlpha = new Bitmap[chunkW, chunkH];
            canvasGraphics = new Graphics[chunkW, chunkH];
            canvasGraphicsAlpha = new Graphics[chunkW, chunkH];
            for (int i = 0; i < chunkW; i++)
            {
                for (int j = 0; j < chunkH; j++)
                {
                    canvasChunks[i, j] = null;
                    canvasChunksAlpha[i, j] = null;
                    canvasGraphics[i, j] = null;
                    canvasGraphicsAlpha[i, j] = null;
                }
            }

        }

        public Bitmap GetChunkBitmap(int x, int y, bool alpha)
        {
            Bitmap[,] chunks = alpha ? canvasChunksAlpha : canvasChunks;

            if (chunks == null) return null;
            if (x < 0 || y < 0 || x / CHUNK_SIZE >= chunks.GetLength(0) || y / CHUNK_SIZE >= chunks.GetLength(1)) return null;
            Bitmap bitmap = chunks[x / CHUNK_SIZE, y / CHUNK_SIZE];
            if (bitmap == null)
            {
                bitmap = GenerateChunk(x / CHUNK_SIZE, y / CHUNK_SIZE);
            }
            return bitmap;
        }


        private Graphics GetChunkGraphics(int x, int y, bool alpha)
        {
            Graphics[,] graphics = alpha ? canvasGraphicsAlpha : canvasGraphics;

            if (graphics == null) return null;
            if (x < 0 || y < 0 || x / CHUNK_SIZE >= graphics.GetLength(0) || y / CHUNK_SIZE >= graphics.GetLength(1)) return null;
            Graphics g = graphics[x / CHUNK_SIZE, y / CHUNK_SIZE];
            if (g == null)
            {
                GenerateChunk(x / CHUNK_SIZE, y / CHUNK_SIZE);
                g = canvasGraphics[x / CHUNK_SIZE, y / CHUNK_SIZE];
            }
            return g;
        }

        // Removes all bitmaps from memory
        private void ClearAllBitmaps()
        {
            if (canvasChunks != null)
            {
                for (int i = 0; i < canvasChunks.GetLength(0); i++)
                {
                    for (int j = 0; j < canvasChunks.GetLength(1); j++)
                    {
                        if (canvasChunks[i, j] != null)
                        {
                            canvasChunks[i, j].Dispose();
                            canvasChunks[i, j] = null;
                        }
                        if (canvasChunksAlpha[i, j] != null)
                        {
                            canvasChunksAlpha[i, j].Dispose();
                            canvasChunksAlpha[i, j] = null;
                        }
                    }
                }
            }
            if (canvasGraphics != null)
            {
                for (int i = 0; i < canvasGraphics.GetLength(0); i++)
                {
                    for (int j = 0; j < canvasGraphics.GetLength(1); j++)
                    {
                        if (canvasGraphics[i, j] != null)
                        {
                            canvasGraphics[i, j].Dispose();
                            canvasGraphics[i, j] = null;
                        }
                        if (canvasGraphicsAlpha[i, j] != null)
                        {
                            canvasGraphicsAlpha[i, j].Dispose();
                            canvasGraphicsAlpha[i, j] = null;
                        }
                    }
                }
            }
        }

        // Generates a chunk of graphics from the tile layer
        private Bitmap GenerateChunk(int chunkX, int chunkY)
        {
            Bitmap bitmap;

            // Regular and alpha chunks
            try
            {
                bitmap = new Bitmap(CHUNK_SIZE, CHUNK_SIZE, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            }
            catch (Exception e)
            {
                ClearAllBitmaps();
                return null;
            }
            canvasChunks[chunkX, chunkY] = bitmap;
            canvasGraphics[chunkX, chunkY] = Graphics.FromImage(bitmap);
            canvasGraphics[chunkX, chunkY].CompositingMode = CompositingMode.SourceCopy;
            canvasGraphics[chunkX, chunkY].CompositingQuality = CompositingQuality.HighSpeed;
            canvasGraphics[chunkX, chunkY].SmoothingMode = SmoothingMode.HighSpeed;
            canvasGraphics[chunkX, chunkY].InterpolationMode = InterpolationMode.NearestNeighbor;


            try
            {
                bitmap = new Bitmap(CHUNK_SIZE, CHUNK_SIZE, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            }
            catch (Exception e)
            {
                ClearAllBitmaps();
                return null;
            }
            canvasChunksAlpha[chunkX, chunkY] = bitmap;
            canvasGraphicsAlpha[chunkX, chunkY] = Graphics.FromImage(bitmap);
            canvasGraphicsAlpha[chunkX, chunkY].CompositingMode = CompositingMode.SourceCopy;
            canvasGraphicsAlpha[chunkX, chunkY].CompositingQuality = CompositingQuality.HighSpeed;
            canvasGraphicsAlpha[chunkX, chunkY].SmoothingMode = SmoothingMode.HighSpeed;
            canvasGraphicsAlpha[chunkX, chunkY].InterpolationMode = InterpolationMode.NearestNeighbor;

            
            int left = Math.Max((chunkX * CHUNK_SIZE) / Definition.Grid.Width, 0);
            int top = Math.Max((chunkY * CHUNK_SIZE) / Definition.Grid.Height, 0);
            int right = Math.Min((chunkX * CHUNK_SIZE + CHUNK_SIZE) / Definition.Grid.Width, TileCellsX);
            int bottom = Math.Min((chunkY * CHUNK_SIZE + CHUNK_SIZE) / Definition.Grid.Height, TileCellsY);
            for (int i = left; i < right; i++)
            {
                for (int j = top; j < bottom; j++)
                {
                    if (tiles[i, j] != -1)
                    {
                        UpdateTile(i, j);
                    }
                }
            }

            return bitmap;
        }

        private Point GetChunkOffset(int x, int y)
        {
            return new Point((x / CHUNK_SIZE) * CHUNK_SIZE, (y / CHUNK_SIZE) * CHUNK_SIZE);
        }

        private void UpdateTile(int tx, int ty)
        {
            if (tx >= 0 && ty >= 0 && tx < tiles.GetLength(0) && ty < tiles.GetLength(1))
            {
                int tile = tiles[tx, ty];
                if (tile != -1)
                {
                    int dx = tx * Definition.Grid.Width;
                    int dy = ty * Definition.Grid.Height;
                    Point offset = GetChunkOffset(dx, dy);

                    // Non-transparent rendering
                    Graphics g = GetChunkGraphics(dx, dy, false);
                    g.DrawImage(Tileset.GetBitmapFromID(tiles[tx, ty]), dx - offset.X, dy - offset.Y);

                    // 50% transparency rendering
                    g = GetChunkGraphics(dx, dy, true);
                    g.DrawImage(Tileset.GetBitmapFromID(tiles[tx, ty]),
                            new Rectangle(dx - offset.X, dy - offset.Y, Definition.Grid.Width, Definition.Grid.Height),
                            0, 0, Definition.Grid.Width, Definition.Grid.Height,
                            GraphicsUnit.Pixel, Util.HalfAlphaAttributes);
                }
                else
                {
                    int dx = tx * Definition.Grid.Width;
                    int dy = ty * Definition.Grid.Height;
                    Point offset = GetChunkOffset(dx, dy);
                    Brush brush = System.Drawing.Brushes.Transparent;

                    Graphics g = GetChunkGraphics(dx, dy, false);
                    g.FillRectangle(brush, new Rectangle(dx - offset.X, dy - offset.Y, Definition.Grid.Width, Definition.Grid.Height));
                    g = GetChunkGraphics(dx, dy, true);
                    g.FillRectangle(brush, new Rectangle(dx - offset.X, dy - offset.Y, Definition.Grid.Width, Definition.Grid.Height));
                }
                // TODO: Update adjacent chunks
            }

            
        }

        #endregion
    }
}
