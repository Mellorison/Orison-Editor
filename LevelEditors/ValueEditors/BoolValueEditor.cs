using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OrisonEditor.Definitions.ValueDefinitions;
using OrisonEditor.LevelData.Layers;
using OrisonEditor.LevelEditors.Actions.EntityActions;

namespace OrisonEditor.LevelEditors.ValueEditors
{
    public partial class BoolValueEditor : ValueEditor
    {
        public BoolValueDefinition Definition { get; private set; }

        public BoolValueEditor(Value value, int x, int y)
            : base(value, x, y)
        {
            Definition = (BoolValueDefinition)value.Definition;
            InitializeComponent();

            valueCheckBox.Text = Definition.Name;
            valueCheckBox.Location = new Point(64 - valueCheckBox.Size.Width / 2, 5);
            valueCheckBox.Checked = Convert.ToBoolean(Value.Content);
        }

        /*
         *  Events
         */
        private void valueCheckBox_Click(object sender, EventArgs e)
        {
            Orison.MainWindow.LevelEditors[Orison.CurrentLevelIndex].Perform(
                    new EntitySetValueAction(null, Value, valueCheckBox.Checked.ToString())
                );
        }
    }
}
