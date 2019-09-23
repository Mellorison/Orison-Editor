using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.LevelData.Layers;
using OrisonEditor.LevelEditors.Tools.GridTools;
using System.Drawing;
using OrisonEditor.LevelEditors.Actions.GridActions;
using System.Diagnostics;
using OrisonEditor.Clipboard;
using OrisonEditor.LevelEditors.Resizers;

namespace OrisonEditor.LevelEditors.LayerEditors
{
    public class GridLayerEditor : LayerEditor
    {
        public new GridLayer Layer { get; private set; }

        private SolidBrush rectBrush;

        public GridLayerEditor(LevelEditor levelEditor, GridLayer layer)
            : base(levelEditor, layer)
        {
            Layer = layer;
            rectBrush = new SolidBrush(layer.Definition.Color);
        }

        public override void Draw(Graphics graphics, bool current, bool fullAlpha)
        {
            //Draw the grid cells
            Rectangle visible = GetVisibleGridArea(graphics);
            rectBrush.Color = Color.FromArgb(fullAlpha ? 255 : LAYER_ABOVE_ALPHA, rectBrush.Color);
            for (int i = visible.X; i < visible.Right; i++)
                for (int j = visible.Y; j < visible.Bottom; j++)
                    if (Layer.Grid[i, j])
                        graphics.FillRectangle(rectBrush, new Rectangle(i * Layer.Definition.Grid.Width, j * Layer.Definition.Grid.Height, Layer.Definition.Grid.Width, Layer.Definition.Grid.Height));

            //Draw the selection box
            if (current && Layer.Selection != null)
                graphics.DrawSelectionRectangle( 
                    new Rectangle(Layer.Selection.Area.X * Layer.Definition.Grid.Width,
                        Layer.Selection.Area.Y * Layer.Definition.Grid.Height,
                        Layer.Selection.Area.Width * Layer.Definition.Grid.Width,
                        Layer.Selection.Area.Height * Layer.Definition.Grid.Height));
        }

        public override Resizer GetResizer()
        {
            return new GridResizer(this);
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
            LevelEditor.Perform(new GridSelectAction(Layer, new Rectangle(0, 0, Layer.GridCellsX, Layer.GridCellsY)));
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
            LevelEditor.Perform(new GridClearSelectionAction(Layer));
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
            Orison.Clipboard = new GridClipboardItem(Layer.Selection.Area, Layer);
        }

        public override void Cut()
        {
            Copy();
            LevelEditor.Perform(new GridDeleteSelectionAction(Layer));
        }

        public override void OnKeyDown(System.Windows.Forms.Keys key)
        {
            base.OnKeyDown(key);

            if (key == System.Windows.Forms.Keys.Delete)
            {
                if (Layer.Selection != null)
                    LevelEditor.Perform(new GridDeleteSelectionAction(Layer));
            }
            else if (key == System.Windows.Forms.Keys.D)
            {
                if (Layer.Selection != null)
                    LevelEditor.Perform(Layer.Selection.GetMoveAction(new Point(1, 0)));
            }
            else if (key == System.Windows.Forms.Keys.S)
            {
                if (Layer.Selection != null)
                    LevelEditor.Perform(Layer.Selection.GetMoveAction(new Point(0, 1)));
            }
            else if (key == System.Windows.Forms.Keys.W)
            {
                if (Layer.Selection != null)
                    LevelEditor.Perform(Layer.Selection.GetMoveAction(new Point(0, -1)));
            }
            else if (key == System.Windows.Forms.Keys.A)
            {
                if (Layer.Selection != null)
                    LevelEditor.Perform(Layer.Selection.GetMoveAction(new Point(-1, 0)));
            }
        }
    }
}
