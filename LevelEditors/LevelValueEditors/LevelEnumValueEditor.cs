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
    public partial class LevelEnumValueEditor : ValueEditor
    {
        public EnumValueDefinition Definition { get; private set; }

        public LevelEnumValueEditor(Value value, int x, int y)
            : base(value, x, y)
        {
            Definition = (EnumValueDefinition)value.Definition;
            InitializeComponent();

            nameLabel.Text = Definition.Name;

            //Init the combo box
            for (int i = 0; i < Definition.Elements.Length; i++)
            {
                valueComboBox.Items.Add(Definition.Elements[i]);
                if (Value.Content == Definition.Elements[i])
                    valueComboBox.SelectedIndex = i;
            }
        }

        /*
         *  Events
         */
        private void valueComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Definition.Elements[valueComboBox.SelectedIndex] != Value.Content)
                Orison.MainWindow.LevelEditors[Orison.CurrentLevelIndex].Perform(
                        new EntitySetValueAction(null, Value, Definition.Elements[valueComboBox.SelectedIndex])
                    );
        }
    }
}
