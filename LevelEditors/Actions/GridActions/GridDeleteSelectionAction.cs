using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.LevelData.Layers;

namespace OrisonEditor.LevelEditors.Actions.GridActions
{
    public class GridDeleteSelectionAction : GridAction
    {
        private GridSelection oldSelection;
        private bool[,] oldBits;

        public GridDeleteSelectionAction(GridLayer gridLayer)
            : base(gridLayer)
        {

        }

        public override void Do()
        {
            base.Do();

            oldSelection = GridLayer.Selection;
            GridLayer.Selection = null;

            oldBits = new bool[oldSelection.Area.Width, oldSelection.Area.Height];
            for (int i = 0; i < oldSelection.Area.Width; i++)
            {
                for (int j = 0; j < oldSelection.Area.Height; j++)
                {
                    oldBits[i, j] = GridLayer.Grid[i + oldSelection.Area.X, j + oldSelection.Area.Y];
                    GridLayer.Grid[i + oldSelection.Area.X, j + oldSelection.Area.Y] = oldSelection.Under[i, j];
                }
            }
        }

        public override void Undo()
        {
            base.Undo();

            GridLayer.Selection = oldSelection;
            for (int i = 0; i < oldSelection.Area.Width; i++)
            {
                for (int j = 0; j < oldSelection.Area.Height; j++)
                    GridLayer.Grid[i + oldSelection.Area.X, j + oldSelection.Area.Y] = oldBits[i, j];
            }
        }
    }
}
