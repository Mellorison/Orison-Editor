using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.LevelEditors.Actions.GridActions;
using System.Diagnostics;

namespace OrisonEditor.LevelEditors.Tools.GridTools
{
    public class GridPencilTool : GridTool
    {
        private bool drawing;
        private bool drawMode;
        private GridDrawAction drawAction;

        public GridPencilTool()
            : base("Pencil", "pencil.png")
        {
            drawing = false;
        }

        public override void OnMouseLeftDown(System.Drawing.Point location)
        {
            if (!drawing)
            {
                drawing = true;
                drawMode = true;
                setCell(location, true);
            }
        }

        public override void OnMouseRightDown(System.Drawing.Point location)
        {
            if (!drawing)
            {
                drawing = true;
                drawMode = false;
                setCell(location, false);
            }
        }

        public override void OnMouseLeftUp(System.Drawing.Point location)
        {
            if (drawing && drawMode)
            {
                drawing = false;
                drawAction = null;
            }
        }

        public override void OnMouseRightUp(System.Drawing.Point location)
        {
            if (drawing && !drawMode)
            {
                drawing = false;
                drawAction = null;
            }
        }

        public override void OnMouseMove(System.Drawing.Point location)
        {
            if (drawing)
                setCell(location, drawMode);
        }

        private void setCell(System.Drawing.Point location, bool setTo)
        {
            location = LayerEditor.Layer.Definition.ConvertToGrid(location);
            if (!IsValidGridCell(location) || LayerEditor.Layer.Grid[location.X, location.Y] == setTo)
                return;

            if (drawAction == null)
                LevelEditor.Perform(drawAction = new GridDrawAction(LayerEditor.Layer, location, setTo));
            else
                drawAction.DoAgain(location);
        }
    }
}
