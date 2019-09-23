using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.LevelData.Layers;
using System.Drawing;

namespace OrisonEditor.LevelEditors.Actions.TileActions
{
    public class TileRectangleAction : TileAction
    {
        private Rectangle rect;
        private Rectangle? setTo;
        private int[,] was;

        public TileRectangleAction(TileLayer tileLayer, Rectangle rect, Rectangle? setTo)
            : base(tileLayer)
        {
            this.rect = rect;
            this.setTo = setTo;
        }

        public override void Do()
        {
            base.Do();

            was = new int[rect.Width, rect.Height];
            for (int i = 0; i < rect.Width; i++)
            {
                for (int j = 0; j < rect.Height; j++)
                {
                    was[i, j] = TileLayer[i + rect.X, j + rect.Y];
                    if (setTo.HasValue)
                        TileLayer[i + rect.X, j + rect.Y] = TileLayer.Tileset.GetIDFromSelectionRectPoint(setTo.Value, rect.Location, new Point(rect.X + i, rect.Y + j));
                    else
                        TileLayer[i + rect.X, j + rect.Y] = -1;
                }
            }
        }

        public override void Undo()
        {
            base.Undo();

            for (int i = rect.X; i < rect.X + rect.Width; i++)
                for (int j = rect.Y; j < rect.Y + rect.Height; j++)
                    TileLayer[i, j] = was[i - rect.X, j - rect.Y];

            was = null;
        }
    }
}
