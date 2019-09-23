using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrisonEditor.LevelEditors.Actions
{
    public class ActionBatch : OrisonAction
    {
        private List<OrisonAction> actions;

        public ActionBatch()
        {
            actions = new List<OrisonAction>();
        }

        public void Add(OrisonAction action)
        {
            actions.Add(action);
        }

        public override void Do()
        {
            base.Do();

            for (int i = 0; i < actions.Count; i++)
                actions[i].Do();
        }

        public override void Undo()
        {
            base.Undo();

            for (int i = actions.Count - 1; i >= 0; i--)
                actions[i].Undo();
        }
    }
}
