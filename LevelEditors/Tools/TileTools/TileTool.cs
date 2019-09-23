using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.LevelData.Layers;
using System.Windows.Forms;
using OrisonEditor.LevelEditors.LayerEditors;
using System.Drawing;

namespace OrisonEditor.LevelEditors.Tools.TileTools
{
    public abstract class TileTool : Tool
    {
        public TileTool(string name, string image)
            : base(name, image)
        {

        }

        public TileLayerEditor LayerEditor
        {
            get { return (TileLayerEditor)LevelEditor.LayerEditors[Orison.LayersWindow.CurrentLayerIndex]; }
        }

        public bool IsValidTileCell(Point cell)
        {
            return cell.X >= 0 && cell.Y >= 0 && cell.X < LayerEditor.Layer.TileCellsX && cell.Y < LayerEditor.Layer.TileCellsY;
        } 
    }
}
