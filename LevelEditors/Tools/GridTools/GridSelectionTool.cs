using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using OrisonEditor.LevelEditors.Actions.GridActions;

namespace OrisonEditor.LevelEditors.Tools.GridTools
{
    public class GridSelectionTool : GridTool
    {
        private bool drawing;
        private Point drawStart;
        private Point drawTo;

        public GridSelectionTool()
            : base("Select", "selection.png")
        {

        }

        public override void Draw(Graphics graphics)
        {
            if (drawing)
            {
                Rectangle draw = LayerEditor.Layer.GetGridRectangle(drawStart, drawTo);
                if (LevelEditor.Level.Bounds.IntersectsWith(draw))
                    graphics.DrawSelectionRectangle(draw);
            }
        }

        public override void OnMouseLeftDown(System.Drawing.Point location)
        {
            drawTo = drawStart = LayerEditor.MouseSnapPosition;
            drawing = true;
        }

        public override void OnMouseLeftUp(Point location)
        {
            if (drawing)
            {
                drawing = false;
                drawTo = LayerEditor.MouseSnapPosition;

                Rectangle rect = LayerEditor.Layer.GetGridRectangle(drawStart, drawTo);
                rect.X /= LayerEditor.Layer.Definition.Grid.Width;
                rect.Width /= LayerEditor.Layer.Definition.Grid.Width;
                rect.Y /= LayerEditor.Layer.Definition.Grid.Height;
                rect.Height /= LayerEditor.Layer.Definition.Grid.Height;

                if (rect.IntersectsWith(new Rectangle(0, 0, LayerEditor.Layer.GridCellsX, LayerEditor.Layer.GridCellsY)))
                    LevelEditor.Perform(new GridSelectAction(LayerEditor.Layer, rect));
            }
        }

        public override void OnMouseMove(Point location)
        {
            if (drawing)
                drawTo = LayerEditor.MouseSnapPosition;
        }

        public override void OnMouseRightClick(Point location)
        {
            if (!drawing)
                LevelEditor.Perform(new GridClearSelectionAction(LayerEditor.Layer));
        }
    }
}
