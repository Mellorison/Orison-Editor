using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.LevelData.Layers;

namespace OrisonEditor.LevelEditors.Actions.TileActions
{
    public class TileClearSelectionAction : TileAction
    {
        private TileSelection oldSelection;

        public TileClearSelectionAction(TileLayer tileLayer)
            : base(tileLayer)
        {

        }

        public override void Do()
        {
            base.Do();

            oldSelection = TileLayer.Selection;
            TileLayer.Selection = null;
        }

        public override void Undo()
        {
            base.Undo();

            TileLayer.Selection = oldSelection;
        }
    }
}
