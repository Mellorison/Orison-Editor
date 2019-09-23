using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OrisonEditor.LevelData.Layers;

namespace OrisonEditor.LevelEditors.ValueEditors
{
    public partial class ValueEditor : UserControl
    {
        public Value Value { get; private set; }

        private ValueEditor()
        {
            //Never call this!
        }

        public ValueEditor(Value value, int x, int y)
        {
            Value = value;
            Location = new Point(x, y);
        }
    }
}
