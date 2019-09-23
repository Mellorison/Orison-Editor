using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.LevelData.Layers;
using OrisonEditor.LevelEditors;
using OrisonEditor.LevelEditors.Actions.EntityActions;

namespace OrisonEditor.Clipboard
{
    public class EntityClipboardItem : ClipboardItem
    {
        public List<Entity> entities;

        public EntityClipboardItem(List<Entity> entities)
            : base()
        {
            this.entities = new List<Entity>();
            foreach (var e in entities)
                this.entities.Add(e.Clone());
        }

        public override bool CanPaste(Layer layer)
        {
            return layer is EntityLayer;
        }

        public override void Paste(LevelEditor editor, Layer layer)
        {
            List<Entity> created = new List<Entity>();

            editor.StartBatch();
            foreach (var e in entities)
            {
                Entity ee = e.Clone();
                created.Add(ee);
                editor.BatchPerform(new EntityAddAction(layer as EntityLayer, ee));
            }
            editor.EndBatch();

            Orison.EntitySelectionWindow.SetSelection(created);
        }
    }
}
