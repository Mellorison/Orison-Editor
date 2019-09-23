using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.LevelData.Layers;
using OrisonEditor.LevelEditors.LayerEditors;

namespace OrisonEditor.LevelEditors.Resizers
{
    public class GridResizer : Resizer
    {
        public new GridLayerEditor Editor { get; private set; }

        public bool[,] oldGrid;

        public GridResizer(GridLayerEditor gridEditor)
            : base(gridEditor)
        {
            Editor = gridEditor;
        }

        public override void Resize()
        {
            GridLayer layer = Editor.Layer;

            oldGrid = layer.Grid;
            int tileWidth = layer.Level.Size.Width / layer.Definition.Grid.Width + (layer.Level.Size.Width % layer.Definition.Grid.Width != 0 ? 1 : 0);
            int tileHeight = layer.Level.Size.Height / layer.Definition.Grid.Height + (layer.Level.Size.Height % layer.Definition.Grid.Height != 0 ? 1 : 0);
            layer.Grid = new bool[tileWidth, tileHeight];

            for (int i = 0; i < layer.Grid.GetLength(0) && i < oldGrid.GetLength(0); i++)
                for (int j = 0; j < layer.Grid.GetLength(1) && j < oldGrid.GetLength(1); j++)
                    layer.Grid[i, j] = oldGrid[i, j];
        }

        public override void Undo()
        {
            Editor.Layer.Grid = oldGrid;
        }
    }
}
