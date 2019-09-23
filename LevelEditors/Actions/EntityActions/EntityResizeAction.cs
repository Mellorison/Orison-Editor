using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.LevelData.Layers;
using System.Drawing;

namespace OrisonEditor.LevelEditors.Actions.EntityActions
{
    public class EntityResizeAction : EntityAction
    {
        private List<Entity> entities;
        private Size resize;
        private List<Size> was;

        public EntityResizeAction(EntityLayer entityLayer, List<Entity> entities, Size resize)
            : base(entityLayer)
        {
            this.entities = new List<Entity>(entities);
            this.resize = resize;
            was = new List<Size>();
            for (int i = 0; i < entities.Count; i++)
                was.Add(new Size());
        }

        public override void Do()
        {
            base.Do();

            for (int i = 0; i < entities.Count; i++)
            {
                was[i] = entities[i].Size;
                if (entities[i].Definition.ResizableX)
                    entities[i].Size.Width = Math.Max(entities[i].Definition.Size.Width, entities[i].Size.Width + resize.Width);
                if (entities[i].Definition.ResizableY)
                    entities[i].Size.Height = Math.Max(entities[i].Definition.Size.Height, entities[i].Size.Height + resize.Height);
            }
        }

        public override void Undo()
        {
            base.Undo();

            for (int i = 0; i < entities.Count; i++)
                entities[i].Size = was[i];
        }

        public void DoAgain(Size add)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i].Definition.ResizableX)
                    entities[i].Size.Width = Math.Max(entities[i].Definition.Size.Width, entities[i].Size.Width + add.Width);
                if (entities[i].Definition.ResizableY)
                    entities[i].Size.Height = Math.Max(entities[i].Definition.Size.Height, entities[i].Size.Height + add.Height);
            }

            resize += add;
        }
    }
}
