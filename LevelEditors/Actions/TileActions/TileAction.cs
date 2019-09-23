using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.LevelData.Layers;

namespace OrisonEditor.LevelEditors.Actions.TileActions
{
    public abstract class TileAction : OrisonAction
    {
        public TileLayer TileLayer { get; private set; }

        public TileAction(TileLayer tileLayer)
        {
            TileLayer = tileLayer;
        }
    }
}
