using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OrisonEditor.LevelData.Layers;
using OrisonEditor.ProjectEditors;
using OrisonEditor.Definitions.ValueDefinitions;
using System.Diagnostics;
using OrisonEditor.LevelEditors.Actions.EntityActions;

namespace OrisonEditor.LevelEditors.ValueEditors
{
    public partial class IntValueEditor : ValueEditor
    {
        public IntValueDefinition Definition { get; private set; }

        public IntValueEditor(Value value, int x, int y)
            : base(value, x, y)
        {
            Definition = (IntValueDefinition)value.Definition;
            InitializeComponent();

            nameLabel.Text = Definition.Name;
            valueTextBox.Text = Value.Content;

            //Deal with the slider
            if (Definition.ShowSlider)
            {
                valueTrackBar.Minimum = Definition.Min;
                valueTrackBar.Maximum = Definition.Max;
                valueTrackBar.Value = Convert.ToInt32(Value.Content); 
                valueTrackBar.TickFrequency = (Definition.Max - Definition.Min) / 10;
            }
            else
            {
                Controls.Remove(valueTrackBar);
                valueTrackBar = null;
                Size = new Size(128, 24);
            }
        }

        private void handleTextBox()
        {
            string temp = Value.Content;
            OrisonParse.ParseIntToString(ref temp, Definition.Min, Definition.Max, valueTextBox);
            if (temp != Value.Content)
            {
                if (valueTrackBar != null)
                    valueTrackBar.Value = Convert.ToInt32(temp);
                Orison.MainWindow.LevelEditors[Orison.CurrentLevelIndex].Perform(
                        new EntitySetValueAction(null, Value, temp)
                    );
            }
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

        private void valueTrackBar_Scroll(object sender, EventArgs e)
        {
            if (valueTrackBar.Value.ToString() != Value.Content)
            {
                valueTextBox.Text = valueTrackBar.Value.ToString();
                Orison.MainWindow.LevelEditors[Orison.CurrentLevelIndex].Perform(
                        new EntitySetValueAction(null, Value, valueTrackBar.Value.ToString())
                    );
            }
        }
    }
}
