using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OrisonEditor.LevelEditors.ValueEditors;
using OrisonEditor.LevelData.Layers;
using OrisonEditor.Definitions.ValueDefinitions;
using OrisonEditor.LevelEditors.Actions.EntityActions;

namespace OrisonEditor.LevelEditors.LevelValueEditors
{
    public partial class LevelBoolValueEditor : ValueEditor
    {
        public BoolValueDefinition Definition { get; private set; }

        public LevelBoolValueEditor(Value value, int x, int y)
            : base(value, x, y)
        {
            Definition = (BoolValueDefinition)value.Definition;
            InitializeComponent();

            nameLabel.Text = Definition.Name;
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
