using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.LevelData.Layers;

namespace OrisonEditor.LevelEditors.Actions.EntityActions
{
    public abstract class EntityAction : OrisonAction
    {
        public EntityLayer EntityLayer { get; private set; }

        public EntityAction(EntityLayer entityLayer)
        {
            EntityLayer = entityLayer;
        }
    }
}
