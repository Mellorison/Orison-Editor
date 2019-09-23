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
    public partial class StringValueDefinitionEditor : UserControl
    {
        private StringValueDefinition def;

        public StringValueDefinitionEditor(StringValueDefinition def)
        {
            this.def = def;
            InitializeComponent();
            Location = new Point(99, 53);

            defaultTextBox.Text = def.Default;
            maxCharsTextBox.Text = def.MaxChars.ToString();
            multiLineCheckBox.Checked = def.MultiLine;

            enforceMultiline();
        }

        private void enforceMaxChars()
        {
            if (def.MaxChars > 0 && defaultTextBox.Text.Length > 0)
                defaultTextBox.Text = defaultTextBox.Text.Substring(0, def.MaxChars);
        }

        private void enforceMultiline()
        {
            defaultTextBox.Multiline = def.MultiLine;

            if (defaultTextBox.Multiline)
                defaultTextBox.Size = new Size(defaultTextBox.Size.Width, 75);
        }

        private void defaultTextBox_Validated(object sender, EventArgs e)
        {
            enforceMaxChars();
            def.Default = defaultTextBox.Text;
        }

        private void maxCharsTextBox_Validated(object sender, EventArgs e)
        {
            OrisonParse.Parse(ref def.MaxChars, maxCharsTextBox);
            enforceMaxChars();
        }

        private void multiLineCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            def.MultiLine = multiLineCheckBox.Checked;
            enforceMultiline();
        }
    }
}
