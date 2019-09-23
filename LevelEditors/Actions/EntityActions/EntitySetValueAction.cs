using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.LevelData.Layers;

namespace OrisonEditor.LevelEditors.Actions.EntityActions
{
    public class EntitySetValueAction : EntityAction
    {
        private Value value;
        private string setTo;
        private string was;

        public EntitySetValueAction(EntityLayer entityLayer, Value value, string setTo)
            : base(entityLayer)
        {
            this.value = value;
            this.setTo = setTo;
        }

        public override void Do()
        {
            base.Do();

            was = value.Content;
            value.Content = setTo;
            Orison.EntitySelectionWindow.RefreshContents();
        }

        public override void Undo()
        {
            base.Undo();

            value.Content = was;
            Orison.EntitySelectionWindow.RefreshContents();
        }
    }
}
