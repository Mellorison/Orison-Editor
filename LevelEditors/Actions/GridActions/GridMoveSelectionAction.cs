using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.LevelData.Layers;
using System.Drawing;

namespace OrisonEditor.LevelEditors.Actions.GridActions
{
    public class GridMoveSelectionAction : GridAction
    {
        private Point move;

        public GridMoveSelectionAction(GridLayer gridLayer, Point move)
            : base(gridLayer)
        {
            this.move = move;
        }

        public override void Do()
        {
            base.Do();

            bool[,] bits = GridLayer.Selection.GetBitsFromGrid();

            for (int i = 0; i < GridLayer.Selection.Area.Width; i++)
                for (int j = 0; j < GridLayer.Selection.Area.Height; j++)
                    GridLayer.Grid[i + GridLayer.Selection.Area.X, j + GridLayer.Selection.Area.Y] = GridLayer.Selection.Under[i, j];

            GridLayer.Selection.Area.X += move.X;
            GridLayer.Selection.Area.Y += move.Y;
            GridLayer.Selection.SetUnderFromGrid();

            for (int i = 0; i < GridLayer.Selection.Area.Width; i++)
                for (int j = 0; j < GridLayer.Selection.Area.Height; j++)
                    GridLayer.Grid[i + GridLayer.Selection.Area.X, j + GridLayer.Selection.Area.Y] = bits[i, j];
        }

        public override void Undo()
        {
            base.Undo();

            bool[,] bits = GridLayer.Selection.GetBitsFromGrid();

            for (int i = 0; i < GridLayer.Selection.Area.Width; i++)
                for (int j = 0; j < GridLayer.Selection.Area.Height; j++)
                    GridLayer.Grid[i + GridLayer.Selection.Area.X, j + GridLayer.Selection.Area.Y] = GridLayer.Selection.Under[i, j];

            GridLayer.Selection.Area.X -= move.X;
            GridLayer.Selection.Area.Y -= move.Y;
            GridLayer.Selection.SetUnderFromGrid();

            for (int i = 0; i < GridLayer.Selection.Area.Width; i++)
                for (int j = 0; j < GridLayer.Selection.Area.Height; j++)
                    GridLayer.Grid[i + GridLayer.Selection.Area.X, j + GridLayer.Selection.Area.Y] = bits[i, j];
        }
    }
}
