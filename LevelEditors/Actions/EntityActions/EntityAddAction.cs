using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.LevelData.Layers;

namespace OrisonEditor.LevelEditors.Actions.EntityActions
{
    public class EntityAddAction : EntityAction
    {
        private Entity added;
        private Entity removed;

        public EntityAddAction(EntityLayer entityLayer, Entity entity)
            : base(entityLayer)
        {
            added = entity;
        }

        public override void Do()
        {
            base.Do();

            //Enforce entity limit defined by the entity definition
            if (added.Definition.Limit > 0 && EntityLayer.Entities.Count(e => e.Definition == added.Definition) == added.Definition.Limit)
                EntityLayer.Entities.Remove(removed = EntityLayer.Entities.Find(e => e.Definition == added.Definition));

            //Place the entity
            EntityLayer.Entities.Add(added);

            //Add it to the selection
            if (Orison.LayersWindow.CurrentLayer == EntityLayer)
                Orison.EntitySelectionWindow.SetSelection(added);
        }

        public override void Undo()
        {
            base.Undo();

            //Remove the entity
            EntityLayer.Entities.Remove(added);

            //Re-add the one removed due to an entity limit
            if (removed != null)
                EntityLayer.Entities.Add(removed);

            //Remove it from the selection
            if (Orison.EntitySelectionWindow.IsSelected(added))
                Orison.EntitySelectionWindow.RemoveFromSelection(added);
        }
    }
}
