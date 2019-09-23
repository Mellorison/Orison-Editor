using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.LevelData.Layers;
using OrisonEditor.LevelEditors.LayerEditors;

namespace OrisonEditor.LevelEditors.Resizers
{
    public class TileResizer : Resizer
    {
        public new TileLayerEditor Editor { get; private set; }

        public int[,] oldTiles;

        public TileResizer(TileLayerEditor tileEditor)
            : base(tileEditor)
        {
            Editor = tileEditor;
        }

        public override void Resize()
        {
            TileLayer layer = Editor.Layer;

            oldTiles = layer.Tiles.Clone() as int[,];
            int tileWidth = layer.Level.Size.Width / layer.Definition.Grid.Width + (layer.Level.Size.Width % layer.Definition.Grid.Width != 0 ? 1 : 0);
            int tileHeight = layer.Level.Size.Height / layer.Definition.Grid.Height + (layer.Level.Size.Height % layer.Definition.Grid.Height != 0 ? 1 : 0);
            int[,] newTiles = new int[tileWidth, tileHeight];

            for (int i = 0; i < tileWidth; i++)
                for (int j = 0; j < tileHeight; j++)
                    newTiles[i, j] = -1;

            for (int i = 0; i < newTiles.GetLength(0) && i < oldTiles.GetLength(0); i++)
                for (int j = 0; j < newTiles.GetLength(1) && j < oldTiles.GetLength(1); j++)
                    newTiles[i, j] = oldTiles[i, j];

            layer.Tiles = newTiles;
        }

        public override void Undo()
        {
            Editor.Layer.Tiles = oldTiles;
        }
    }
}
