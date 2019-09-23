using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.LevelData.Layers;
using OrisonEditor.LevelEditors;

namespace OrisonEditor.Clipboard
{
    public abstract class ClipboardItem
    {
        public abstract bool CanPaste(Layer layer); //Paste Layer
        public abstract void Paste(LevelEditor editor, Layer layer); //Level Editor Layer abstract.
    }
}
