using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.LevelData.Layers;
using System.Drawing;
using System.Diagnostics;

namespace OrisonEditor.LevelEditors.Actions.TileActions
{
    public class TileFloodAction : TileAction
    {
        private Rectangle? setTo;
        private int was;
        private Point startCell;

        private List<Point> changes;

        public TileFloodAction(TileLayer tileLayer, Point cell, Rectangle? setTo)
            : base(tileLayer)
        {
            this.startCell = cell;
            this.setTo = setTo;
        }

        public override void Do()
        {
            base.Do();

            was = TileLayer[startCell.X, startCell.Y];
            changes = new List<Point>();

            //Do the flood
            {
                Stack<Point> points = new Stack<Point>();
                points.Push(startCell);

                do
                {
                    Point current = points.Pop();
                    if (FloodCell(current))
                    {
                        points.Push(new Point(current.X - 1, current.Y));
                        points.Push(new Point(current.X + 1, current.Y));
                        points.Push(new Point(current.X, current.Y - 1));
                        points.Push(new Point(current.X, current.Y + 1));
                    }
                }
                while (points.Count > 0);
            }
        }

        public override void Undo()
        {
            base.Undo();

            foreach (var p in changes)
                TileLayer[p.X, p.Y] = was;
        }

        private bool FloodCell(Point cell)
        {
            if (cell.X < 0 || cell.Y < 0 || cell.X > TileLayer.TileCellsX - 1 || cell.Y > TileLayer.TileCellsY - 1 || TileLayer[cell.X, cell.Y] != was)
                return false;

            changes.Add(new Point(cell.X, cell.Y));
            if (setTo.HasValue)
                TileLayer[cell.X, cell.Y] = TileLayer.Tileset.GetIDFromSelectionRectPoint(setTo.Value, startCell, cell);
            else
                TileLayer[cell.X, cell.Y] = -1;

            return true;
        }
    }
}
