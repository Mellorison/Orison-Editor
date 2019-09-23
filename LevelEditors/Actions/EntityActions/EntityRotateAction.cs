using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.LevelData.Layers;

namespace OrisonEditor.LevelEditors.Actions.EntityActions
{
    public class EntityRotateAction : EntityAction
    {
        private List<Entity> entities;
        private float rotateTo;
        private List<float> was;

        public EntityRotateAction(EntityLayer entityLayer, List<Entity> entities, float rotateTo)
            : base(entityLayer)
        {
            this.entities = new List<Entity>(entities);
            this.rotateTo = rotateTo;
            was = new List<float>();
            for (int i = 0; i < entities.Count; i++)
                was.Add(0);
        }

        public override void Do()
        {
            base.Do();

            for (int i = 0; i < entities.Count; i++)
            {
                was[i] = entities[i].Angle;
                if (entities[i].Definition.Rotatable)
                {
                    entities[i].Angle = rotateTo % 360;
                    entities[i].Angle = Util.Snap(entities[i].Angle, entities[i].Definition.RotateIncrement);
                }
            }
        }

        public override void Undo()
        {
            base.Undo();

            for (int i = 0; i < entities.Count; i++)
                entities[i].Angle = was[i];
        }

        public void DoAgain(float newRotateTo)
        {
            rotateTo = newRotateTo;
            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i].Definition.Rotatable)
                    entities[i].Angle = newRotateTo % 360;
            }
        }
    }
}
