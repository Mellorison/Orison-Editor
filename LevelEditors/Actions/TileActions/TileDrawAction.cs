using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.LevelData.Layers;
using System.Drawing;

namespace OrisonEditor.LevelEditors.Actions.TileActions
{
    public class TileDrawAction : TileAction
    {
        private int setTo;
        private List<Point> draw;
        private List<int> was;

        public TileDrawAction(TileLayer tileLayer, Point at, int setTo)
            : base(tileLayer)
        {
            this.setTo = setTo;

            draw = new List<Point>();
            draw.Add(at);

            was = new List<int>();
        }

        public override void Do()
        {
            foreach (var at in draw)
            {
                if (at.X < TileLayer.TileCellsX && at.Y < TileLayer.TileCellsY)
                {
                    was.Add(TileLayer[at.X, at.Y]);
                    TileLayer[at.X, at.Y] = setTo;
                }
                else
                    was.Add(-1);
                
            }
        }

        public override void Undo()
        {
            for (int i = 0; i < draw.Count; i++)
                if (draw[i].X < TileLayer.TileCellsX && draw[i].Y < TileLayer.TileCellsY)
                    TileLayer[draw[i].X, draw[i].Y] = was[i];
        }

        public void DoAgain(Point add, int setTo)
        {
            if (!draw.Contains(add))
            {
                draw.Add(add);
                was.Add(TileLayer[add.X, add.Y]);
            }
            TileLayer[add.X, add.Y] = setTo;
        }
    }
}
