using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.LevelData.Layers;

namespace OrisonEditor.LevelEditors.Actions.GridActions
{
    public abstract class GridAction : OrisonAction
    {
        public GridLayer GridLayer { get; private set; }

        public GridAction(GridLayer gridLayer)
        {
            GridLayer = gridLayer;
        }
    }
}
