using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using OrisonEditor.LevelEditors.Actions.GridActions;

namespace OrisonEditor.LevelEditors.Tools.GridTools
{
    public class GridRectangleTool : GridTool
    {
        private bool drawing;
        private bool drawMode;
        private Point drawStart;
        private Point drawTo;
        private Pen drawPen;
        private SolidBrush fillBrush;

        public GridRectangleTool()
            : base("Rectangle", "rectangle.png")
        {
            drawing = false;
            drawPen = new Pen(Color.Black, 2);
            fillBrush = new SolidBrush(Color.Black);
        }

        public override void Draw(Graphics graphics)
        {
            if (drawing)
            {
                Rectangle draw = LayerEditor.Layer.GetGridRectangle(drawStart, drawTo);
                if (LevelEditor.Level.Bounds.IntersectsWith(draw))
                {
                    drawPen.Color = drawMode ? LayerEditor.Layer.Definition.Color : LayerEditor.Layer.Definition.Color.Invert();
                    fillBrush.Color = Color.FromArgb(130, drawPen.Color);
                    graphics.FillRectangle(fillBrush, draw);
                    graphics.DrawRectangle(drawPen, draw);
                }
            }
        }

        public override void OnMouseLeftDown(System.Drawing.Point location)
        {
            drawTo = drawStart = LayerEditor.MouseSnapPosition;
            drawing = true;
            drawMode = true;
        }

        public override void OnMouseLeftUp(Point location)
        {
            if (drawing && drawMode)
                drawRect();
        }

        public override void OnMouseRightDown(Point location)
        {
            drawTo = drawStart = LayerEditor.MouseSnapPosition;
            drawing = true;
            drawMode = false;
        }

        public override void OnMouseRightUp(Point location)
        {
            if (drawing && !drawMode)
                drawRect();
        }

        public override void OnMouseMove(Point location)
        {
            if (drawing)
                drawTo = LayerEditor.MouseSnapPosition;
        }
        
        /*
         *  Helpers
         */
        private void drawRect()
        {
            drawing = false;
            Rectangle draw = LayerEditor.Layer.GetGridRectangle(drawStart, drawTo);
            if (LevelEditor.Level.Bounds.IntersectsWith(draw))
            {
                draw = LayerEditor.Layer.Definition.ConvertToGrid(draw);
                LevelEditor.Perform(new GridRectangleAction(LayerEditor.Layer, draw, drawMode));
            }
        }
    }
}
