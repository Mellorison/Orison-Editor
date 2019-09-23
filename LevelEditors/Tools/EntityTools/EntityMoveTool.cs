using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using OrisonEditor.LevelEditors.Actions.EntityActions;

namespace OrisonEditor.LevelEditors.Tools.EntityTools
{
    public class EntityMoveTool : EntityTool
    {
        private bool moving;
        private EntityMoveAction moveAction;
        private Point mouseStart;
        private Point moved;

        public EntityMoveTool()
            : base("Move", "move.png")
        {
            moving = false;
            moveAction = null;
        }

        public override void OnMouseLeftDown(Point location)
        {
            if (Orison.EntitySelectionWindow.Selected.Count > 0)
            {
                moving = true;
                mouseStart = location;
                moved = Point.Empty;
            }
        }

        public override void OnMouseMove(Point location)
        {
            if (moving)
            {
                Point move = new Point(location.X - mouseStart.X, location.Y - mouseStart.Y);
                if (!Util.Ctrl)
                    move = LayerEditor.Layer.Definition.SnapToGrid(move);

                move = new Point(move.X - moved.X, move.Y - moved.Y);
                if (move.X != 0 || move.Y != 0)
                {
                    if (moveAction != null)
                        moveAction.DoAgain(move);
                    else
                        LevelEditor.Perform(moveAction = new EntityMoveAction(LayerEditor.Layer, Orison.EntitySelectionWindow.Selected, move));
                    moved = new Point(move.X + moved.X, move.Y + moved.Y);
                    Orison.EntitySelectionWindow.RefreshPosition();
                }
            }
        }

        public override void OnMouseLeftUp(Point location)
        {
            if (moving)
            {
                moving = false;
                moveAction = null;
            }
        }
    }
}
