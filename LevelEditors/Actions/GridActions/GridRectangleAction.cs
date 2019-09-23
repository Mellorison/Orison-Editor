using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.LevelData.Layers;
using System.Drawing;

namespace OrisonEditor.LevelEditors.Actions.GridActions
{
    public class GridRectangleAction : GridAction
    {
        public int CellX { get; private set; }
        public int CellY { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public bool SetTo { get; private set; }

        private bool[,] was;

        public GridRectangleAction(GridLayer gridLayer, int cellX, int cellY, int width, int height, bool setTo)
            : base(gridLayer)
        {
            CellX = cellX;
            CellY = cellY;
            Width = width;
            Height = height;
            SetTo = setTo;
        }

        public GridRectangleAction(GridLayer gridLayer, Rectangle rect, bool setTo)
            : this(gridLayer, rect.X, rect.Y, rect.Width, rect.Height, setTo)
        {

        }

        public override void Do()
        {
            base.Do();

            was = new bool[Width, Height];
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    was[i, j] = GridLayer.Grid[CellX + i, CellY + j];
                    GridLayer.Grid[CellX + i, CellY + j] = SetTo;
                }
            }
        }

        public override void Undo()
        {
            base.Undo();

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    GridLayer.Grid[CellX + i, CellY + j] = was[i, j];
                }
            }
        }
    }
}
