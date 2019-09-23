using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.LevelData.Layers;
using System.Drawing;

namespace OrisonEditor.LevelEditors.Actions.GridActions
{
    public class GridDrawAction : GridAction
    {
        private bool setTo;
        private List<Point> draw;

        public GridDrawAction(GridLayer gridLayer, Point at, bool setTo)
            : base(gridLayer)
        {
            draw = new List<Point>();
            draw.Add(at);
            this.setTo = setTo;
        }

        public override void Do()
        {
            base.Do();

            foreach (Point p in draw)
                GridLayer.Grid[p.X, p.Y] = setTo;
        }

        public override void Undo()
        {
            base.Undo();

            foreach (Point p in draw)
                GridLayer.Grid[p.X, p.Y] = !setTo;
        }

        public void DoAgain(Point add)
        {
            GridLayer.Grid[add.X, add.Y] = setTo;
            draw.Add(add);
        }
    }
}
