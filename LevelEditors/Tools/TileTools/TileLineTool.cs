using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using OrisonEditor.LevelEditors.Actions.TileActions;

namespace OrisonEditor.LevelEditors.Tools.TileTools
{
    public class TileLineTool : TileTool
    {
        private bool drawing;
        private bool drawMode;
        private Point drawStart;
        private Point mouse;
        private Rectangle? selection;
        private SolidBrush eraseBrush;

        public TileLineTool()
            : base("Line", "line.png")
        {
            drawing = false;
            eraseBrush = new SolidBrush(Color.FromArgb(255/2, Color.Red));
        }

        public override void OnMouseLeftDown(Point location)
        {
            drawStart = LayerEditor.Layer.Definition.ConvertToGrid(location);
            drawing = true;
            drawMode = true;

            selection = Orison.TilePaletteWindow.Tiles;
        }

        public override void OnMouseLeftUp(Point location)
        {
            if (drawing && drawMode)
            {
                drawing = false;

                LevelEditor.StartBatch();
                List<Point> pts = getPoints(drawStart, LayerEditor.Layer.Definition.ConvertToGrid(location));
                foreach (var p in pts)
                {
                    int id = -1;
                    if (selection.HasValue)
                        id = LayerEditor.Layer.Tileset.GetIDFromSelectionRectPoint(selection.Value, drawStart, p);
                    LevelEditor.BatchPerform(new TileDrawAction(LayerEditor.Layer, p, id));
                }
                LevelEditor.EndBatch();
            }
        }

        public override void OnMouseRightDown(Point location)
        {
            drawStart = LayerEditor.Layer.Definition.ConvertToGrid(location);
            drawing = true;
            drawMode = false;
            selection = null;
        }

        public override void OnMouseRightUp(Point location)
        {
            if (drawing && !drawMode)
            {
                drawing = false;

                LevelEditor.StartBatch();
                List<Point> pts = getPoints(drawStart, LayerEditor.Layer.Definition.ConvertToGrid(location));
                foreach (var p in pts)
                    LevelEditor.BatchPerform(new TileDrawAction(LayerEditor.Layer, p, -1));
                LevelEditor.EndBatch();
            }
        }

        public override void OnMouseMove(Point location)
        {
            mouse = LayerEditor.Layer.Definition.ConvertToGrid(location);
        }

        public override void Draw(Graphics graphics)
        {
            if (drawing)
            {
                List<Point> pts = getPoints(drawStart, mouse);
                if (!selection.HasValue)
                {
                    foreach (var p in pts)
                        graphics.FillRectangle(eraseBrush, p.X * LayerEditor.Layer.Definition.Grid.Width, p.Y * LayerEditor.Layer.Definition.Grid.Height, LayerEditor.Layer.Definition.Grid.Width, LayerEditor.Layer.Definition.Grid.Height);
                }
                else
                {
                    foreach (var p in pts)
                    {
                        int id = LayerEditor.Layer.Tileset.GetIDFromSelectionRectPoint(selection.Value, drawStart, p);
                        Rectangle tileRect = LayerEditor.Layer.Tileset.TileRects[id];

                        graphics.DrawImage(LayerEditor.Layer.Tileset.Bitmap, new Rectangle(p.X * LayerEditor.Layer.Definition.Grid.Width, p.Y * LayerEditor.Layer.Definition.Grid.Height, LayerEditor.Layer.Definition.Grid.Width, LayerEditor.Layer.Definition.Grid.Height), tileRect.X, tileRect.Y, tileRect.Width, tileRect.Height, GraphicsUnit.Pixel, Util.HalfAlphaAttributes);
                    }
                }
            }
        }

        private List<Point> getPoints(Point start, Point end)
        {
            int aX = start.X;
            int aY = start.Y;
            int bX = end.X;
            int bY = end.Y;
            List<Point> points = new List<Point>();

            bool steep = Math.Abs(bY - aY) > Math.Abs(bX - aX);

            if (steep)
            {
                Util.Swap(ref aX, ref aY);
                Util.Swap(ref bX, ref bY);
            }

            if (aX > bX)
            {
                Util.Swap(ref aX, ref bX);
                Util.Swap(ref aY, ref bY);
            }

            int deltaX = bX - aX;
            int deltaY = Math.Abs(bY - aY);
            float error = 0;
            float deltaErr = deltaY / (float)deltaX;
            int yStep = (aY < bY) ? 1 : -1;
            int y = aY;

            for (int x = aX; x <= bX; x++)
            {
                if (x >= 0 && y >= 0)
                {
                    if (steep)
                    {
                        Point p = new Point(y, x);
                        if (IsValidTileCell(p))
                            points.Add(p);
                    }
                    else
                    {
                        Point p = new Point(x, y);
                        if (IsValidTileCell(p))
                            points.Add(p);
                    }
                }

                error += deltaErr;
                if (error >= .5f)
                {
                    y += yStep;
                    error--;
                }
            }

            return points;
        }
    }
}
