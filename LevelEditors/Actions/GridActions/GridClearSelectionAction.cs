using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.LevelData.Layers;

namespace OrisonEditor.LevelEditors.Actions.GridActions
{
    public class GridClearSelectionAction : GridAction
    {
        private GridSelection oldSelection;

        public GridClearSelectionAction(GridLayer gridLayer)
            : base(gridLayer)
        {

        }

        public override void Do()
        {
            base.Do();

            oldSelection = GridLayer.Selection;
            GridLayer.Selection = null;
        }

        public override void Undo()
        {
            base.Undo();

            GridLayer.Selection = oldSelection;
        }
    }
}
