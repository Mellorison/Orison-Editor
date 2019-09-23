using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.LevelData.Layers;
using System.Drawing;

namespace OrisonEditor.LevelEditors.Actions.EntityActions
{
    public class EntityRemoveNodeAction : EntityAction
    {
        private Entity entity;
        private int index;
        private Point was;

        public EntityRemoveNodeAction(EntityLayer entityLayer, Entity entity, int index)
            : base(entityLayer)
        {
            this.entity = entity;
            this.index = index;
        }

        public override void Do()
        {
            base.Do();

            was = entity.Nodes[index];
            entity.Nodes.RemoveAt(index);
        }

        public override void Undo()
        {
            base.Undo();

            entity.Nodes.Insert(index, was);
        }
    }
}
