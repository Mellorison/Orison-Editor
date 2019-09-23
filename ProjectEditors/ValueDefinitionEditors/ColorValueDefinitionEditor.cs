using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OrisonEditor.Definitions.ValueDefinitions;

namespace OrisonEditor.ProjectEditors.ValueDefinitionEditors
{
    public partial class ColorValueDefinitionEditor : UserControl
    {
        private ColorValueDefinition def;

        public ColorValueDefinitionEditor(ColorValueDefinition def)
        {
            this.def = def;
            InitializeComponent();
            Location = new Point(99, 53);

            defaultColorChooser.Color = def.Default;
        }

        private void defaultColorChooser_ColorChanged(OrisonColor color)
        {
            def.Default = color;
        }
    }
}
