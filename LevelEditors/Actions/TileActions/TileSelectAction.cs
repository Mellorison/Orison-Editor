using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.LevelData.Layers;
using System.Drawing;

namespace OrisonEditor.LevelEditors.Actions.TileActions
{
    public class TileSelectAction : TileAction
    {
        private TileSelection oldSelection;
        private Rectangle selectArea;

        public TileSelectAction(TileLayer tileLayer, Rectangle selectArea)
            : base(tileLayer)
        {
            this.selectArea = selectArea;
        }

        public override void Do()
        {
            base.Do();

            oldSelection = TileLayer.Selection;
            TileLayer.Selection = new TileSelection(TileLayer, selectArea);
        }

        public override void Undo()
        {
            base.Undo();

            TileLayer.Selection = oldSelection;
        }
    }
}
