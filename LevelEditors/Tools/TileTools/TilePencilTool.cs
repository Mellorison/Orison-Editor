using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.LevelEditors.Actions.TileActions;
using System.Drawing;

namespace OrisonEditor.LevelEditors.Tools.TileTools
{
    public class TilePencilTool : TileTool
    {
        private bool drawing;
        private bool drawMode;
        private Point drawStart;
        private TileDrawAction drawAction;

        public TilePencilTool()
            : base("Pencil", "pencil.png")
        {
            drawing = false;
        }

        public override void OnMouseLeftDown(Point location)
        {
            if (!drawing)
            {
                drawing = true;
                drawMode = true;
 
                SetTiles(location, Orison.TilePaletteWindow.Tiles, true);
            }
        }

        public override void OnMouseRightDown(Point location)
        {
            if (!drawing)
            {
                drawing = true;
                drawMode = false;

                SetTiles(location, null);
            }
        }

        public override void OnMouseLeftUp(Point location)
        {
            if (drawing && drawMode)
            {
                drawing = false;
                drawAction = null;
            }
        }

        public override void OnMouseRightUp(Point location)
        {
            if (drawing && !drawMode)
            {
                drawing = false;
                drawAction = null;
            }
        }

        public override void OnMouseMove(Point location)
        {
            if (drawing)
                SetTiles(location, drawMode ? Orison.TilePaletteWindow.Tiles : null);
        }

        private void SetTiles(Point location, Rectangle? setTo, bool start = false)
        {
            location = LayerEditor.Layer.Definition.ConvertToGrid(location);
            if (!IsValidTileCell(location))
                return;

            if (!setTo.HasValue)
            {
                if (LayerEditor.Layer[location.X, location.Y] != -1)
                {
                    if (drawAction == null)
                        LevelEditor.Perform(drawAction = new TileDrawAction(LayerEditor.Layer, location, -1));
                    else
                        drawAction.DoAgain(location, -1);
                }
            }
            else if (setTo.Value.Area() == 1)
            {
                int id = LayerEditor.Layer.Tileset.GetIDFromCell(setTo.Value.Location);
                if (LayerEditor.Layer[location.X, location.Y] != id)
                {
                    if (drawAction == null)
                        LevelEditor.Perform(drawAction = new TileDrawAction(LayerEditor.Layer, location, id));
                    else
                        drawAction.DoAgain(location, id);
                }
            }
            else
            {
                if (start)
                    drawStart = location;

                //Draw the tiles
                for (int x = 0; x < setTo.Value.Width && location.X + x < LayerEditor.Layer.TileCellsX; x++)
                {
                    for (int y = 0; y < setTo.Value.Height && location.Y + y < LayerEditor.Layer.TileCellsY; y++)
                    {
                        int id = LayerEditor.Layer.Tileset.GetIDFromSelectionRectPoint(setTo.Value, drawStart, new Point(location.X + x, location.Y + y));

                        if (LayerEditor.Layer[location.X + x, location.Y + y] != id)
                        {
                            if (drawAction == null)
                                LevelEditor.Perform(drawAction = new TileDrawAction(LayerEditor.Layer, location, id));
                            else
                                drawAction.DoAgain(new Point(location.X + x, location.Y + y), id);
                        }
                    }
                }
            }
        }
    }
}
