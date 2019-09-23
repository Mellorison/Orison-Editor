using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.LevelData.Layers;

namespace OrisonEditor.LevelEditors.Actions
{
    public abstract class OrisonAction
    {
        public bool LevelWasChanged = true;
        public bool Performed { get; private set; }

        public virtual void Do() { Performed = true; }
        public virtual void Undo() { Performed = false; }
    }
}
