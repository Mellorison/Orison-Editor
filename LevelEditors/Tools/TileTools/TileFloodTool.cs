using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.LevelEditors.Actions.TileActions;
using System.Drawing;
using System.Diagnostics;

namespace OrisonEditor.LevelEditors.Tools.TileTools
{
    public class TileFloodTool : TileTool
    {
        public TileFloodTool()
            : base("Flood Fill", "flood.png")
        {

        }

        public override void OnMouseLeftClick(Point location)
        {
            location = LayerEditor.Layer.Definition.ConvertToGrid(location);
            if (IsValidTileCell(location) && LayerEditor.Layer[location.X, location.Y] != Orison.TilePaletteWindow.TilesStartID)
                LevelEditor.Perform(new TileFloodAction(LayerEditor.Layer, location, Orison.TilePaletteWindow.Tiles));
        }

        public override void OnMouseRightClick(Point location)
        {
            location = LayerEditor.Layer.Definition.ConvertToGrid(location);
            if (IsValidTileCell(location) && LayerEditor.Layer[location.X, location.Y] != -1)
                LevelEditor.Perform(new TileFloodAction(LayerEditor.Layer, location, null));
        }
    }
}
