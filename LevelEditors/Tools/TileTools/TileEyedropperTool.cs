using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrisonEditor.LevelEditors.Tools.TileTools
{
    public class TileEyedropperTool : TileTool
    {
        public TileEyedropperTool()
            : base("Eyedropper", "eyedropper.png")
        {

        }

        public override void OnMouseLeftClick(System.Drawing.Point location)
        {
            if (!LevelEditor.Level.Bounds.Contains(location))
                return;

            location = LayerEditor.Layer.Definition.ConvertToGrid(location);
            Orison.TilePaletteWindow.TilesStartID = LayerEditor.Layer[location.X, location.Y];
        }
    }
}
