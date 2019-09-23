using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using OrisonEditor.LevelData.Layers;

namespace OrisonEditor.LevelEditors.Actions.TileActions
{
    public class TileMoveSelectionAction : TileAction
    {
        private Point move;

        public TileMoveSelectionAction(TileLayer tileLayer, Point move)
            : base(tileLayer)
        {
            this.move = move;
        }

        public override void Do()
        {
            base.Do();

            int[,] data = TileLayer.Selection.GetDataFromTiles();

            for (int i = 0; i < TileLayer.Selection.Area.Width; i++)
                for (int j = 0; j < TileLayer.Selection.Area.Height; j++)
                    TileLayer[i + TileLayer.Selection.Area.X, j + TileLayer.Selection.Area.Y] = TileLayer.Selection.Under[i, j];

            TileLayer.Selection.Area.X += move.X;
            TileLayer.Selection.Area.Y += move.Y;
            TileLayer.Selection.SetUnderFromTiles();

            for (int i = 0; i < TileLayer.Selection.Area.Width; i++)
                for (int j = 0; j < TileLayer.Selection.Area.Height; j++)
                    TileLayer[i + TileLayer.Selection.Area.X, j + TileLayer.Selection.Area.Y] = data[i, j];
        }

        public override void Undo()
        {
            base.Undo();

            int[,] data = TileLayer.Selection.GetDataFromTiles();

            for (int i = 0; i < TileLayer.Selection.Area.Width; i++)
                for (int j = 0; j < TileLayer.Selection.Area.Height; j++)
                    TileLayer[i + TileLayer.Selection.Area.X, j + TileLayer.Selection.Area.Y] = TileLayer.Selection.Under[i, j];

            TileLayer.Selection.Area.X -= move.X;
            TileLayer.Selection.Area.Y -= move.Y;
            TileLayer.Selection.SetUnderFromTiles();

            for (int i = 0; i < TileLayer.Selection.Area.Width; i++)
                for (int j = 0; j < TileLayer.Selection.Area.Height; j++)
                    TileLayer[i + TileLayer.Selection.Area.X, j + TileLayer.Selection.Area.Y] = data[i, j];
        }
    }
}
