using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.LevelData.Layers;
using System.Drawing;

namespace OrisonEditor.LevelEditors.Actions.EntityActions
{
    class EntityMoveNodeAction : EntityAction
    {
        private Entity entity;
        private int nodeIndex;
        private Point moveTo;
        private Point oldPos;

        public EntityMoveNodeAction(EntityLayer entityLayer, Entity entity, int nodeIndex, Point moveTo)
            : base(entityLayer)
        {
            this.entity = entity;
            this.nodeIndex = nodeIndex;
            this.moveTo = moveTo;
        }

        public override void Do()
        {
            base.Do();

            oldPos = entity.Nodes[nodeIndex];
            entity.Nodes[nodeIndex] = moveTo;
        }

        public override void Undo()
        {
            base.Undo();

            entity.Nodes[nodeIndex] = oldPos;
        }

        public void DoAgain(Point moveTo)
        {
            this.moveTo = moveTo;
            entity.Nodes[nodeIndex] = moveTo;
        }
    }
}
