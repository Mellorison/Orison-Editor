using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.LevelData.Layers;
using System.Drawing;

namespace OrisonEditor.LevelEditors.Actions.GridActions
{
    public class GridPasteSelectionAction : GridAction
    {
        private Rectangle area;
        private bool[,] newBits;

        private GridSelection oldSelection;

        public GridPasteSelectionAction(GridLayer gridLayer, Rectangle area, bool[,] bits)
            : base(gridLayer)
        {
            newBits = bits;
            this.area = area;

            this.area.X = Math.Min(area.X, gridLayer.GridCellsX - area.Width);
            this.area.Y = Math.Min(area.Y, gridLayer.GridCellsY - area.Height);
        }

        public override void Do()
        {
            base.Do();

            oldSelection = GridLayer.Selection;
            GridLayer.Selection = new GridSelection(GridLayer, area);
            GridLayer.Selection.SetUnderFromGrid();

            for (int i = 0; i < area.Width; i++)
                for (int j = 0; j < area.Height; j++)
                    GridLayer.Grid[i + area.X, j + area.Y] = newBits[i, j];
        }

        public override void Undo()
        {
            base.Undo();

            for (int i = 0; i < area.Width; i++)
                for (int j = 0; j < area.Height; j++)
                    GridLayer.Grid[i + area.X, j + area.Y] = GridLayer.Selection.Under[i, j];

            GridLayer.Selection = oldSelection;
        }
    }
}
