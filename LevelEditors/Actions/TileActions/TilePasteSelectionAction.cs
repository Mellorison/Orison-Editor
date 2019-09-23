using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using OrisonEditor.LevelData.Layers;

namespace OrisonEditor.LevelEditors.Actions.TileActions
{
    public class TilePasteSelectionAction : TileAction
    {
        private Rectangle area;
        private int[,] newData;

        private TileSelection oldSelection;

        public TilePasteSelectionAction(TileLayer tileLayer, Rectangle area, int[,] data)
            : base(tileLayer)
        {
            newData = data;
            this.area = area;

            this.area.X = Math.Min(area.X, tileLayer.TileCellsX - area.Width);
            this.area.Y = Math.Min(area.Y, tileLayer.TileCellsY - area.Height);
        }

        public override void Do()
        {
            base.Do();

            oldSelection = TileLayer.Selection;
            TileLayer.Selection = new TileSelection(TileLayer, area);
            TileLayer.Selection.SetUnderFromTiles();

            for (int i = 0; i < area.Width; i++)
                for (int j = 0; j < area.Height; j++)
                    TileLayer[i + area.X, j + area.Y] = newData[i, j];
        }

        public override void Undo()
        {
            base.Undo();

            for (int i = 0; i < area.Width; i++)
                for (int j = 0; j < area.Height; j++)
                    TileLayer[i + area.X, j + area.Y] = TileLayer.Selection.Under[i, j];

            TileLayer.Selection = oldSelection;
        }
    }
}
