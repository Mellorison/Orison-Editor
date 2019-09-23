using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using OrisonEditor.LevelData.Layers;
using OrisonEditor.LevelEditors.LayerEditors;

namespace OrisonEditor.LevelEditors.Resizers
{
    public abstract class Resizer
    {
        public LayerEditor Editor { get; private set; }

        public Resizer(LayerEditor editor)
        {
            Editor = editor;
        }

        public abstract void Resize();
        public abstract void Undo();
    }
}
