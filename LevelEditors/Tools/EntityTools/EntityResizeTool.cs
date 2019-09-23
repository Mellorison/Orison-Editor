using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using OrisonEditor.LevelEditors.Actions.EntityActions;

namespace OrisonEditor.LevelEditors.Tools.EntityTools
{
    public class EntityResizeTool : EntityTool
    {
        private bool moving;
        private EntityResizeAction resizeAction;
        private Point mouseStart;
        private Point moved;

        public EntityResizeTool()
            : base("Resize", "resize.png")
        {
            moving = false;
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
                    if (resizeAction == null)
                        LevelEditor.Perform(resizeAction = new EntityResizeAction(LayerEditor.Layer, Orison.EntitySelectionWindow.Selected, new Size(move.X, move.Y)));
                    else
                        resizeAction.DoAgain(new Size(move.X, move.Y));

                    moved = new Point(move.X + moved.X, move.Y + moved.Y);
                    Orison.EntitySelectionWindow.RefreshSize();
                }
            }
        }

        public override void OnMouseLeftUp(Point location)
        {
            if (moving)
            {
                resizeAction = null;
                moving = false;
            }
        }
    }
}
