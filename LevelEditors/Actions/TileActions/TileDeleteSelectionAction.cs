using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.LevelData.Layers;

namespace OrisonEditor.LevelEditors.Actions.TileActions
{
    public class TileDeleteSelectionAction : TileAction
    {
        private TileSelection oldSelection;
        private int[,] oldData;

        public TileDeleteSelectionAction(TileLayer tileLayer)
            : base(tileLayer)
        {

        }

        public override void Do()
        {
            base.Do();

            oldSelection = TileLayer.Selection;
            TileLayer.Selection = null;

            oldData = new int[oldSelection.Area.Width, oldSelection.Area.Height];
            for (int i = 0; i < oldSelection.Area.Width; i++)
            {
                for (int j = 0; j < oldSelection.Area.Height; j++)
                {
                    oldData[i, j] = TileLayer[i + oldSelection.Area.X, j + oldSelection.Area.Y];
                    TileLayer[i + oldSelection.Area.X, j + oldSelection.Area.Y] = oldSelection.Under[i, j];
                }
            }
        }

        public override void Undo()
        {
            base.Undo();

            TileLayer.Selection = oldSelection;
            for (int i = 0; i < oldSelection.Area.Width; i++)
            {
                for (int j = 0; j < oldSelection.Area.Height; j++)
                    TileLayer[i + oldSelection.Area.X, j + oldSelection.Area.Y] = oldData[i, j];
            }
        }
    }
}
