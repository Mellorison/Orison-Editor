using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using OrisonEditor.LevelEditors.Actions.GridActions;

namespace OrisonEditor.LevelEditors.Tools.GridTools
{
    public class GridMoveSelectionTool : GridTool
    {
        private bool moving;
        private Point mouseStart;
        private Point moved;

        public GridMoveSelectionTool()
            : base("Move Selection", "move.png")
        {
            moving = false;
        }

        public override void OnMouseLeftDown(Point location)
        {
            if (LayerEditor.Layer.Selection != null)
            {
                moving = true;
                mouseStart = location;
                moved = Point.Empty;
                LevelEditor.StartBatch();
            }
        }

        public override void OnMouseMove(Point location)
        {
            if (moving)
            {
                Point move = new Point(location.X - mouseStart.X, location.Y - mouseStart.Y);
                move = LayerEditor.Layer.Definition.ConvertToGrid(move);
                move.X -= moved.X;
                move.Y -= moved.Y;

                if (move.X != 0 || move.Y != 0)
                {
                    LevelEditor.BatchPerform(LayerEditor.Layer.Selection.GetMoveAction(move));
                    moved = new Point(move.X + moved.X, move.Y + moved.Y);
                }
            }
        }

        public override void OnMouseLeftUp(Point location)
        { 
            if (moving)
            {
                moving = false;
                LevelEditor.EndBatch();
            }
        }
    }
}
