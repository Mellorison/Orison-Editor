using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.LevelData.Layers;
using System.Drawing;

namespace OrisonEditor.LevelEditors.Actions.EntityActions
{
    public class EntityMoveAction : EntityAction
    {
        private List<Entity> entities;
        private Point move;

        public EntityMoveAction(EntityLayer entityLayer, List<Entity> entities, Point move)
            : base(entityLayer)
        {
            this.entities = new List<Entity>(entities);
            this.move = move;
        }

        public override void Do()
        {
            base.Do();

            foreach (Entity e in entities)
            {
                e.Position = new Point(e.Position.X + move.X, e.Position.Y + move.Y);
                e.MoveNodes(move);
            }
        }

        public override void Undo()
        {
            base.Undo();

            foreach (Entity e in entities)
            {
                e.Position = new Point(e.Position.X - move.X, e.Position.Y - move.Y);
                e.MoveNodes(new Point(-move.X, -move.Y));
            }
        }

        public void DoAgain(Point add)
        {
            foreach (Entity e in entities)
            {
                e.Position = new Point(e.Position.X + add.X, e.Position.Y + add.Y);
                e.MoveNodes(add);
            }
            move = new Point(move.X + add.X, move.Y + add.Y);
        }
    }
}
