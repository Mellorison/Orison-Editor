using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.LevelData.Layers;
using System.Drawing;

namespace OrisonEditor.LevelEditors.Actions.GridActions
{
    public class GridFloodAction : GridAction
    {
        public int CellX { get; private set; }
        public int CellY { get; private set; }
        public bool SetTo { get; private set; }

        private List<Point> changes;

        public GridFloodAction(GridLayer gridLayer, int cellX, int cellY, bool setTo)
            : base(gridLayer)
        {
            CellX = cellX;
            CellY = cellY;
            SetTo = setTo;
        }

        public override void Do()
        {
            base.Do();

            changes = new List<Point>();
            flood(CellX, CellY);
        }

        private void flood(int cellX, int cellY)
        {
            if (cellX < 0 || cellY < 0 || cellX > GridLayer.Grid.GetLength(0) - 1 || cellY > GridLayer.Grid.GetLength(1) - 1 || GridLayer.Grid[cellX, cellY] == SetTo)
                return;

            changes.Add(new Point(cellX, cellY));
            GridLayer.Grid[cellX, cellY] = SetTo;

            flood(cellX - 1, cellY);
            flood(cellX + 1, cellY);
            flood(cellX, cellY - 1);
            flood(cellX, cellY + 1);
        }

        public override void Undo()
        {
            base.Undo();

            foreach (Point p in changes)
                GridLayer.Grid[p.X, p.Y] = !SetTo;
        }
    }
}
