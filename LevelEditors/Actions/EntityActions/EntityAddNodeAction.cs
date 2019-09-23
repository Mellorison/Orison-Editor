using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.LevelData.Layers;
using System.Drawing;

namespace OrisonEditor.LevelEditors.Actions.EntityActions
{
    public class EntityAddNodeAction : EntityAction
    {
        private Entity entity;
        private Point node;

        public EntityAddNodeAction(EntityLayer entityLayer, Entity entity, Point node)
            : base(entityLayer)
        {
            this.entity = entity;
            this.node = node;
        }

        public override void Do()
        {
            base.Do();

            entity.Nodes.Add(node);
        }

        public override void Undo()
        {
            base.Undo();

            entity.Nodes.RemoveAt(entity.Nodes.Count - 1);
        }
    }
}
