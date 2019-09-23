using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OrisonEditor.Definitions.LayerDefinitions;
using System.Diagnostics;

namespace OrisonEditor.ProjectEditors
{
    public partial class LayerDefinitionsEditor : UserControl, IProjectChanger
    {
        private const string NEW_LAYER_NAME = "NewLayer";

        private List<LayerDefinition> layerDefinitions;
        private UserControl layerEditor;
        private bool indexChangeable = true;

        public LayerDefinitionsEditor()
        {
            InitializeComponent();
            layerEditor = null;

            //Init the type combobox items
            foreach (var s in LayerDefinition.LAYER_NAMES)
                typeComboBox.Items.Add(s);
        }

        public void LoadFromProject(Project project)
        {
            layerDefinitions = project.LayerDefinitions;
            foreach (LayerDefinition d in layerDefinitions)
                listBox.Items.Add(d.Name);
        }

        private void setControlsFromDefinition(LayerDefinition definition)
        {
            //Enabled stuff
            removeButton.Enabled = true;
            moveUpButton.Enabled = listBox.SelectedIndex > 0;
            moveDownButton.Enabled = listBox.SelectedIndex < listBox.Items.Count - 1;
            nameTextBox.Enabled = true;
            gridXTextBox.Enabled = true;
            gridYTextBox.Enabled = true;
            scrollXTextBox.Enabled = true;
            scrollYTextBox.Enabled = true;
            typeComboBox.Enabled = true;

            //Load properties
            nameTextBox.Text = definition.Name;
            gridXTextBox.Text = definition.Grid.Width.ToString();
            gridYTextBox.Text = definition.Grid.Height.ToString();
            scrollXTextBox.Text = definition.ScrollFactor.X.ToString();
            scrollYTextBox.Text = definition.ScrollFactor.Y.ToString();
            typeComboBox.SelectedIndex = LayerDefinition.LAYER_TYPES.FindIndex(e => e == definition.GetType());

            //Remove the old layer editor
            if (layerEditor != null)
                Controls.Remove(layerEditor);

            //Add the new one
            layerEditor = definition.GetEditor();
            if (layerEditor != null)
            {
                layerEditor.TabIndex = 6;
                Controls.Add(layerEditor);
            }
        }

        private void disableControls()
        {
            //Disable all
            removeButton.Enabled = false;
            moveUpButton.Enabled = false;
            moveDownButton.Enabled = false;
            nameTextBox.Enabled = false;
            gridXTextBox.Enabled = false;
            gridYTextBox.Enabled = false;
            scrollXTextBox.Enabled = false;
            scrollYTextBox.Enabled = false;
            typeComboBox.Enabled = false;

            if (layerEditor != null)
            {
                Controls.Remove(layerEditor);
                layerEditor = null;
            }
        }

        private LayerDefinition getDefaultLayer()
        {
            int i = 0;
            string name;

            do
            {
                name = NEW_LAYER_NAME + i.ToString();
                i++;
            }
            while (layerNameTaken(name));

            GridLayerDefinition grid = new GridLayerDefinition();
            grid.Name = name;
            grid.Grid = new Size(16, 16);
            return grid;
        }

        private bool layerNameTaken(string name)
        {
            return layerDefinitions.Find(e => e.Name == name) != null;
        }

        /*
         *  Events
         */
        private void addButton_Click(object sender, EventArgs e)
        {
            LayerDefinition def = getDefaultLayer();

            layerDefinitions.Add(def);
            listBox.SelectedIndex = listBox.Items.Add(def.Name);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            int index = listBox.SelectedIndex;

            layerDefinitions.RemoveAt(index);
            listBox.Items.RemoveAt(index);

            listBox.SelectedIndex = Math.Min(listBox.Items.Count - 1, index);
        }

        private void moveUpButton_Click(object sender, EventArgs e)
        {
            int index = listBox.SelectedIndex;

            LayerDefinition temp = layerDefinitions[index];
            layerDefinitions[index] = layerDefinitions[index - 1];
            layerDefinitions[index - 1] = temp;

            listBox.Items[index] = layerDefinitions[index].Name;
            listBox.Items[index - 1] = layerDefinitions[index - 1].Name;
            listBox.SelectedIndex = index - 1;
        }

        private void moveDownButton_Click(object sender, EventArgs e)
        {
            int index = listBox.SelectedIndex;

            LayerDefinition temp = layerDefinitions[index];
            layerDefinitions[index] = layerDefinitions[index + 1];
            layerDefinitions[index + 1] = temp;

            listBox.Items[index] = layerDefinitions[index].Name;
            listBox.Items[index + 1] = layerDefinitions[index + 1].Name;
            listBox.SelectedIndex = index + 1;
        }

        private void nameTextBox_Validated(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == -1)
                return;

            indexChangeable = false;
            layerDefinitions[listBox.SelectedIndex].Name = nameTextBox.Text;
            listBox.Items[listBox.SelectedIndex] = (nameTextBox.Text == "" ? "(blank)" : nameTextBox.Text);
            indexChangeable = true;
        }

        private void gridXTextBox_Validated(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == -1)
                return;

            OrisonParse.Parse(ref layerDefinitions[listBox.SelectedIndex].Grid, gridXTextBox, gridYTextBox);
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!indexChangeable)
                return;

            if (listBox.SelectedIndex != -1)
                setControlsFromDefinition(layerDefinitions[listBox.SelectedIndex]);
            else
                disableControls();
        }

        private void typeComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == -1)
                return;

            LayerDefinition oldDef = layerDefinitions[listBox.SelectedIndex];
            LayerDefinition newDef;

            newDef = (LayerDefinition)Activator.CreateInstance(LayerDefinition.LAYER_TYPES[typeComboBox.SelectedIndex]);

            newDef.Name = oldDef.Name;
            newDef.Grid = oldDef.Grid;
            layerDefinitions[listBox.SelectedIndex] = newDef;
            setControlsFromDefinition(newDef);
        }

        private void scrollXTextBox_Validated(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == -1)
                return;

            OrisonParse.Parse(ref layerDefinitions[listBox.SelectedIndex].ScrollFactor, scrollXTextBox, scrollYTextBox);
        }
    }
}
