using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.LevelData.Layers;
using System.Drawing;

namespace OrisonEditor.LevelEditors.Actions.GridActions
{
    public class GridSelectAction : GridAction
    {
        private GridSelection oldSelection;
        private Rectangle selectArea;

        public GridSelectAction(GridLayer gridLayer, Rectangle selectArea)
            : base(gridLayer)
        {
            this.selectArea = selectArea;
        }

        public override void Do()
        {
            base.Do();

            oldSelection = GridLayer.Selection;
            GridLayer.Selection = new GridSelection(GridLayer, selectArea);
        }

        public override void Undo()
        {
            base.Undo();

            GridLayer.Selection = oldSelection;
        }
    }
}
