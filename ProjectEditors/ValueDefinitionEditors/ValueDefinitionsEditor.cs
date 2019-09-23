using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OrisonEditor.Definitions.ValueDefinitions;
using System.Diagnostics;
using OrisonEditor.ProjectEditors.ValueDefinitionEditors;

namespace OrisonEditor.ProjectEditors.ValueDefinitionEditors
{
    public partial class ValueDefinitionsEditor : UserControl
    {
        private const string NEW_VALUE = "NewValue";

        private List<ValueDefinition> values;
        private UserControl valueEditor;
        private bool indexChangeable = true;

        public ValueDefinitionsEditor()
        {
            InitializeComponent();
            this.values = new List<ValueDefinition>();
            valueEditor = null;

            //Initialize the type dropdown
            foreach (var s in ValueDefinition.VALUE_NAMES)
                typeComboBox.Items.Add(s);
        }

        public void SetList(List<ValueDefinition> values)
        {
            this.values = values;

            //Initialize the visual value list
            listBox.SelectedIndex = -1;
            listBox.Items.Clear();
            foreach (ValueDefinition v in values)
                listBox.Items.Add(v.ToString());
        }

        public string Title
        {
            get { return titleLabel.Text; }
            set { titleLabel.Text = value; }
        }

        private void setControlsFromValue(ValueDefinition v)
        {
            removeButton.Enabled = true;

            //Set the name              
            nameTextBox.CausesValidation = true;
            nameTextBox.Enabled = true;
            nameTextBox.Text = v.Name; 

            //Set the type
            typeComboBox.CausesValidation = true;
            typeComboBox.Enabled = true;
            typeComboBox.SelectedIndex = ValueDefinition.VALUE_TYPES.FindIndex(e => e == v.GetType());

            //Remove the old value editor
            if (valueEditor != null)
                Controls.Remove(valueEditor);

            //Add the new one!
            valueEditor = v.GetEditor();
            if (valueEditor != null)
            {
                valueEditor.TabIndex = 2;
                Controls.Add(valueEditor);
            }
        }

        private void disableControls()
        {
            removeButton.Enabled = false;

            nameTextBox.CausesValidation = false;
            nameTextBox.Enabled = false;        
            nameTextBox.Text = "";

            typeComboBox.CausesValidation = false;
            typeComboBox.Enabled = false;

            if (valueEditor != null)
            {
                Controls.Remove(valueEditor);
                valueEditor = null;
            }
        }

        private string getNewName()
        {
            int i = 0;
            string name;

            do
            {
                name = NEW_VALUE + i.ToString();
                i++;
            }
            while (values.Find(e => e.Name == name) != null);

            return name;
        }

        /*
         *  Events
         */
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!indexChangeable)
                return;

            if (listBox.SelectedIndex != -1)
                setControlsFromValue(values[listBox.SelectedIndex]);
            else
                disableControls();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            IntValueDefinition v = new IntValueDefinition();
            v.Name = getNewName();
            values.Add(v);
            listBox.SelectedIndex = listBox.Items.Add(v.ToString());
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            int index = listBox.SelectedIndex;
            values.RemoveAt(listBox.SelectedIndex);
            listBox.Items.RemoveAt(listBox.SelectedIndex);

            listBox.SelectedIndex = Math.Min(listBox.Items.Count - 1, index);
        }

        private void nameTextBox_Validated(object sender, EventArgs e)
        {
            indexChangeable = false;
            values[listBox.SelectedIndex].Name = nameTextBox.Text;
            listBox.Items[listBox.SelectedIndex] = values[listBox.SelectedIndex].ToString();
            indexChangeable = true;
        }

        private void typeComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ValueDefinition oldDef = values[listBox.SelectedIndex];
            ValueDefinition newDef = null;

            for (int i = 0; i < ValueDefinition.VALUE_TYPES.Count; i++)
            {
                if (typeComboBox.SelectedIndex == i)
                {
                    newDef = (ValueDefinition)Activator.CreateInstance(ValueDefinition.VALUE_TYPES[i]);
                    break;
                }
            }

            newDef.Name = oldDef.Name;
            values[listBox.SelectedIndex] = newDef;
            setControlsFromValue(newDef);
        }
    }
}
