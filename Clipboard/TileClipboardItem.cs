using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using OrisonEditor.LevelData.Layers;
using OrisonEditor.LevelEditors;
using OrisonEditor.LevelEditors.Actions.TileActions;

namespace OrisonEditor.Clipboard
{
    public class TileClipboardItem : ClipboardItem
    {
        public Rectangle Area;
        public int[,] Data;

        public TileClipboardItem(Rectangle area, TileLayer layer)
            : base()
        {
            Area = area;

            Data = new int[Area.Width, Area.Height];
            for (int i = 0; i < Area.Width; i++)
                for (int j = 0; j < Area.Height; j++)
                    Data[i, j] = layer[i + Area.X, j + Area.Y];
        }

        public override bool CanPaste(Layer layer)
        {
            return layer is TileLayer;
        }

        public override void Paste(LevelEditor editor, Layer layer)
        {
            editor.Perform(new TilePasteSelectionAction(layer as TileLayer, Area, Data));
        }
    }
}
