using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.LevelData.Layers;

namespace OrisonEditor.LevelEditors.Actions.EntityActions
{
    public class EntityRemoveAction : EntityAction
    {
        private List<Entity> toRemove;

        public EntityRemoveAction(EntityLayer entityLayer, List<Entity> entities)
            : base(entityLayer)
        {
            toRemove = entities;
        }

        public override void Do()
        {
            base.Do();

            foreach (var e in toRemove)
                EntityLayer.Entities.Remove(e);

            Orison.EntitySelectionWindow.RemoveFromSelection(toRemove);
        }

        public override void Undo()
        {
            base.Undo();

            foreach (var e in toRemove)
                EntityLayer.Entities.Add(e);
        }
    }
}
