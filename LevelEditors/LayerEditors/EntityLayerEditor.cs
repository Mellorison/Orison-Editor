using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.LevelData.Layers;
using OrisonEditor.LevelEditors.Actions.EntityActions;
using OrisonEditor.Clipboard;
using System.Drawing;

namespace OrisonEditor.LevelEditors.LayerEditors
{
    public class EntityLayerEditor : LayerEditor
    {
        public new EntityLayer Layer { get; private set; }

        public EntityLayerEditor(LevelEditor levelEditor, EntityLayer layer)
            : base(levelEditor, layer)
        {
            Layer = layer;
        }

        public override void Draw(System.Drawing.Graphics graphics, bool current, bool fullAlpha)
        {
            Rectangle viewableArea = GetVisibleArea(graphics);
            foreach (Entity e in Layer.Entities)
            {
                if (e.Bounds.IntersectsWith(viewableArea))
                {
                    e.Draw(graphics, current, fullAlpha);
                }
            }
        }

        public override void OnKeyDown(System.Windows.Forms.Keys key)
        {
            base.OnKeyDown(key);

            if (key == System.Windows.Forms.Keys.Delete)
            {
                if (Orison.EntitySelectionWindow.AmountSelected > 0)
                    LevelEditor.Perform(new EntityRemoveAction(Layer, Orison.EntitySelectionWindow.Selected));
            }
        }

        public override bool CanCopyOrCut
        {
            get
            {
                return Orison.EntitySelectionWindow.Selected.Count > 0;
            }
        }

        public override void Copy()
        {
            Orison.Clipboard = new EntityClipboardItem(Orison.EntitySelectionWindow.Selected);
        }

        public override void Cut()
        {
            Copy();
            LevelEditor.Perform(new EntityRemoveAction(Layer, Orison.EntitySelectionWindow.Selected));
        }

        public override bool CanSelectAll
        {
            get
            {
                return Layer.Entities.Count > 0;
            }
        }

        public override void SelectAll()
        {
            Orison.EntitySelectionWindow.SetSelection(Layer.Entities);
        }

        public override bool CanDeselect
        {
            get
            {
                return Layer.Entities.Count > 0;
            }
        }

        public override void Deselect()
        {
            Orison.EntitySelectionWindow.ClearSelection();
        }
    }
}
