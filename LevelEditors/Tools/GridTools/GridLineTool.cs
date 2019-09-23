using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using OrisonEditor.LevelEditors.Actions.GridActions;

namespace OrisonEditor.LevelEditors.Tools.GridTools
{
    public class GridLineTool : GridTool
    {
        private bool drawing;
        private bool drawMode;
        private Point drawStart;
        private Point mouse;
        private SolidBrush fillBrush;

        public GridLineTool()
            : base("Line", "line.png")
        {
            drawing = false;
            fillBrush = new SolidBrush(Color.Black);
        }

        public override void OnMouseLeftDown(System.Drawing.Point location)
        {
            drawStart = LayerEditor.Layer.Definition.ConvertToGrid(location);
            drawing = true;
            drawMode = true;
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
                    if (!LayerEditor.Layer.Grid[p.X, p.Y])
                        LevelEditor.BatchPerform(new GridDrawAction(LayerEditor.Layer, p, true));
                }
                LevelEditor.EndBatch();
            }
        }

        public override void OnMouseRightDown(Point location)
        {
            drawStart = LayerEditor.Layer.Definition.ConvertToGrid(location);
            drawing = true;
            drawMode = false;
        }

        public override void OnMouseRightUp(Point location)
        {
            if (drawing && !drawMode)
            {
                drawing = false;

                LevelEditor.StartBatch();
                List<Point> pts = getPoints(drawStart, LayerEditor.Layer.Definition.ConvertToGrid(location));
                foreach (var p in pts)
                {
                    if (LayerEditor.Layer.Grid[p.X, p.Y])
                        LevelEditor.BatchPerform(new GridDrawAction(LayerEditor.Layer, p, false));
                }
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
                foreach (var p in pts)
                {
                    fillBrush.Color = Color.FromArgb(130, drawMode ? LayerEditor.Layer.Definition.Color : LayerEditor.Layer.Definition.Color.Invert());
                    graphics.FillRectangle(fillBrush, new Rectangle(p.X * LayerEditor.Layer.Definition.Grid.Width, p.Y * LayerEditor.Layer.Definition.Grid.Height, LayerEditor.Layer.Definition.Grid.Width, LayerEditor.Layer.Definition.Grid.Height));
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
                        if (IsValidGridCell(p))
                            points.Add(p);
                    }
                    else
                    {
                        Point p = new Point(x, y);
                        if (IsValidGridCell(p))
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
