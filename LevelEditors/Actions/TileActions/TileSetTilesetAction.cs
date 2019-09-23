using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.LevelData.Layers;
using OrisonEditor.Definitions;

namespace OrisonEditor.LevelEditors.Actions.TileActions
{
    public class TileSetTilesetAction : TileAction
    {
        private Tileset setTo;
        private Tileset was;

        private int[,] oldIDs;

        public TileSetTilesetAction(TileLayer tileLayer, Tileset setTo)
            : base(tileLayer)
        {
            this.setTo = setTo;
        }

        public override void Do()
        {
            base.Do();

            was = TileLayer.Tileset;
            TileLayer.Tileset = setTo;

            oldIDs = TileLayer.Tiles;
            TileLayer.Tiles = setTo.TransformMap(was, TileLayer.Tiles);

            Orison.TilePaletteWindow.SetTileset(setTo);
        }

        public override void Undo()
        {
            base.Undo();

            TileLayer.Tileset = was;
            TileLayer.Tiles = oldIDs;

            Orison.TilePaletteWindow.SetTileset(was);
        }
    }
}
