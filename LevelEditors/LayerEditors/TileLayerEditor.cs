using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.LevelData.Layers;
using OrisonEditor.LevelEditors.Resizers;
using OrisonEditor.LevelEditors.Actions.TileActions;
using System.Drawing;
using OrisonEditor.Clipboard;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace OrisonEditor.LevelEditors.LayerEditors
{
    public class TileLayerEditor : LayerEditor
    {
        public new TileLayer Layer { get; private set; }

        public TileLayerEditor(LevelEditor levelEditor, TileLayer layer)
            : base(levelEditor, layer)
        {
            Layer = layer;
        }

        public override void UpdateDrawOffset(Point cameraPos)
        {
            base.UpdateDrawOffset(cameraPos);
            Layer.UpdateDrawOffset(cameraPos);
        }

        public override void Draw(Graphics graphics, bool current, bool fullAlpha)
        {
            Rectangle viewableArea = GetVisibleArea(graphics);

            int left = (viewableArea.X / TileLayer.CHUNK_SIZE);
            int top = (viewableArea.Y / TileLayer.CHUNK_SIZE);
            int right = ((viewableArea.X + viewableArea.Width) / TileLayer.CHUNK_SIZE);
            int bottom = ((viewableArea.Y + viewableArea.Height) / TileLayer.CHUNK_SIZE);

            for (int x = left; x <= right; x++)
            {
                for (int y = top; y <= bottom; y++)
                {
                    Bitmap bitmap = Layer.GetChunkBitmap(x * TileLayer.CHUNK_SIZE, y * TileLayer.CHUNK_SIZE, !fullAlpha);
                    if (bitmap != null)
                    {
                        graphics.DrawImageUnscaled(bitmap, x * TileLayer.CHUNK_SIZE, y * TileLayer.CHUNK_SIZE);
                    }
                }
            }

            
            //Draw the selection box
            if (current && Layer.Selection != null)
                graphics.DrawSelectionRectangle(new Rectangle(
                    Layer.Selection.Area.X * Layer.Definition.Grid.Width,
                    Layer.Selection.Area.Y * Layer.Definition.Grid.Height,
                    Layer.Selection.Area.Width * Layer.Definition.Grid.Width,
                    Layer.Selection.Area.Height * Layer.Definition.Grid.Height));
        }

        public override Resizer GetResizer()
        {
            return new TileResizer(this);
        }

        public override bool CanSelectAll
        {
            get
            {
                return true;
            }
        }

        public override void SelectAll()
        {
            LevelEditor.Perform(new TileSelectAction(Layer, new Rectangle(0, 0, Layer.TileCellsX, Layer.TileCellsY)));
        }

        public override bool CanDeselect
        {
            get
            {
                return Layer.Selection != null;
            }
        }

        public override void Deselect()
        {
            LevelEditor.Perform(new TileClearSelectionAction(Layer));
        }

        public override bool CanCopyOrCut
        {
            get
            {
                return Layer.Selection != null;
            }
        }

        public override void Copy()
        {
            Orison.Clipboard = new TileClipboardItem(Layer.Selection.Area, Layer);
        }

        public override void Cut()
        {
            Copy();
            LevelEditor.Perform(new TileDeleteSelectionAction(Layer));
        }
    }
}
