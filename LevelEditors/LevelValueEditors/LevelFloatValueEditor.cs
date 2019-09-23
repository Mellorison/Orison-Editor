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
    public partial class LevelFloatValueEditor : ValueEditor
    {
        public FloatValueDefinition Definition { get; private set; }

        public LevelFloatValueEditor(Value value, int x, int y)
            : base(value, x, y)
        {
            Definition = (FloatValueDefinition)value.Definition;
            InitializeComponent();

            nameLabel.Text = Definition.Name;
            valueTextBox.Text = Value.Content;
        }

        private void handleTextBox()
        {
            string temp = Value.Content;
            OrisonParse.ParseFloatToString(ref temp, Definition.Min, Definition.Max, Definition.Round, valueTextBox);
            if (temp != Value.Content)
                Orison.MainWindow.LevelEditors[Orison.CurrentLevelIndex].Perform(
                        new EntitySetValueAction(null, Value, temp)
                    );
        }

        /*
         *  Events
         */
        private void valueTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                handleTextBox();
        }

        private void valueTextBox_Leave(object sender, EventArgs e)
        {
            handleTextBox();
        }
    }
}
