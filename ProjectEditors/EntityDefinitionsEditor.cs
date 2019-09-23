using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OrisonEditor.Definitions;
using System.IO;
using System.Diagnostics;

namespace OrisonEditor.ProjectEditors
{
    public partial class EntityDefinitionsEditor : UserControl, IProjectChanger
    {
        private const string NEW_NAME = "NewObject";

        private List<EntityDefinition> entities;
        private string directory;

        public EntityDefinitionsEditor()
        {
            InitializeComponent();
        }

        public void LoadFromProject(Project project)
        {
            entities = project.EntityDefinitions;
            foreach (var o in entities)
                listBox.Items.Add(o.Name);

            directory = project.SavedDirectory;
        }

        private void SetControlsFromObject(EntityDefinition def)
        {
            removeButton.Enabled = true;
            moveUpButton.Enabled = listBox.SelectedIndex > 0;
            moveDownButton.Enabled = listBox.SelectedIndex < listBox.Items.Count - 1;

            nameTextBox.Enabled = true;
            limitTextBox.Enabled = true;
            sizeXTextBox.Enabled = true;
            sizeYTextBox.Enabled = true;
            originXTextBox.Enabled = true;
            originYTextBox.Enabled = true;
            resizableXCheckBox.Enabled = true;
            resizableYCheckBox.Enabled = true;
            rotatableCheckBox.Enabled = true;
            valuesEditor.Enabled = true;
            nodesCheckBox.Enabled = true;
            graphicTypeComboBox.Enabled = true;

            //Basics
            nameTextBox.Text = def.Name;
            limitTextBox.Text = def.Limit.ToString();
            sizeXTextBox.Text = def.Size.Width.ToString();
            sizeYTextBox.Text = def.Size.Height.ToString();
            originXTextBox.Text = def.Origin.X.ToString();
            originYTextBox.Text = def.Origin.Y.ToString();

            //Resizable/rotation
            resizableXCheckBox.Checked = def.ResizableX;
            resizableYCheckBox.Checked = def.ResizableY;
            rotatableCheckBox.Checked = def.Rotatable;
            rotationIncrementTextBox.Text = def.RotateIncrement.ToString();
            RotationFieldsVisible = def.Rotatable;

            //Nodes
            nodesCheckBox.Checked = def.NodesDefinition.Enabled;
            nodeLimitTextBox.Text = def.NodesDefinition.Limit.ToString();
            nodeDrawComboBox.SelectedIndex = (int)def.NodesDefinition.DrawMode;
            nodeGhostCheckBox.Checked = def.NodesDefinition.Ghost;
            NodesFieldsVisible = def.NodesDefinition.Enabled;

            //Values
            valuesEditor.SetList(def.ValueDefinitions);

            //Graphic
            graphicTypeComboBox.SelectedIndex = (int)def.ImageDefinition.DrawMode;
            GraphicFieldsVisibility = (int)def.ImageDefinition.DrawMode;
            rectangleColorChooser.Color = def.ImageDefinition.RectColor;
            imageFileTextBox.Text = def.ImageDefinition.ImagePath;
            imageFileTiledCheckBox.Checked = def.ImageDefinition.Tiled;
            imageFileWarningLabel.Visible = !CheckImageFile();
            LoadImageFilePreview();
        }

        private void DisableControls()
        {
            removeButton.Enabled = false;
            moveUpButton.Enabled = false;
            moveDownButton.Enabled = false;

            nameTextBox.Enabled = false;
            limitTextBox.Enabled = false;
            sizeXTextBox.Enabled = false;
            sizeYTextBox.Enabled = false;
            originXTextBox.Enabled = false;
            originYTextBox.Enabled = false;
            resizableXCheckBox.Enabled = false;
            resizableYCheckBox.Enabled = false;
            rotatableCheckBox.Enabled = false;
            nodesCheckBox.Enabled = false;
            valuesEditor.Enabled = false;
            graphicTypeComboBox.Enabled = false;

            RotationFieldsVisible = false;
            NodesFieldsVisible = false;
            GraphicFieldsVisibility = -1;
            ClearImageFilePreview();
        }

        private EntityDefinition GetDefault()
        {
            EntityDefinition def = new EntityDefinition();

            int i = 0;
            string name;

            do
            {
                name = NEW_NAME + i.ToString();
                i++;
            }
            while (entities.Find(o => o.Name == name) != null);

            def.Name = name;

            return def;
        }

        private bool RotationFieldsVisible
        {
            set
            {
                rotationIncrementLabel.Visible = rotationIncrementTextBox.Enabled = rotationIncrementTextBox.Visible = value;
            }
        }

        private bool NodesFieldsVisible
        {
            set
            {
                nodeLimitTextBox.Visible = nodeLimitTextBox.Enabled = value;
                nodeLimitLabel.Visible = value;
                nodeDrawComboBox.Visible = nodeDrawComboBox.Enabled = value;
                nodeDrawLabel.Visible = value;
                nodeGhostCheckBox.Visible = value;
            }
        }

        private int GraphicFieldsVisibility
        {
            set
            {
                rectangleGraphicPanel.Visible = rectangleGraphicPanel.Enabled = (value == 0);
                imageFileGraphicPanel.Visible = imageFileGraphicPanel.Enabled = (value == 1);
            }
        }

        private bool CheckImageFile()
        {
            return File.Exists(Path.Combine(directory, imageFileTextBox.Text));
        }

        private void LoadImageFilePreview()
        {
            imagePreviewer.LoadImage(Path.Combine(directory, imageFileTextBox.Text));
        }

        private void ClearImageFilePreview()
        {
            imagePreviewer.ClearImage();
        }

        #region Selector Events

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == -1)
                DisableControls();
            else
                SetControlsFromObject(entities[listBox.SelectedIndex]);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            EntityDefinition def = GetDefault();
            entities.Add(def);
            listBox.SelectedIndex = listBox.Items.Add(def.Name);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            int index = listBox.SelectedIndex;
            entities.RemoveAt(listBox.SelectedIndex);
            listBox.Items.RemoveAt(listBox.SelectedIndex);

            listBox.SelectedIndex = Math.Min(listBox.Items.Count - 1, index);
        }

        private void moveUpButton_Click(object sender, EventArgs e)
        {
            int index = listBox.SelectedIndex;

            EntityDefinition temp = entities[index];
            entities[index] = entities[index - 1];
            entities[index - 1] = temp;

            listBox.Items[index] = entities[index].Name;
            listBox.Items[index - 1] = entities[index - 1].Name;
            listBox.SelectedIndex = index - 1;
        }

        private void moveDownButton_Click(object sender, EventArgs e)
        {
            int index = listBox.SelectedIndex;

            EntityDefinition temp = entities[index];
            entities[index] = entities[index + 1];
            entities[index + 1] = temp;

            listBox.Items[index] = entities[index].Name;
            listBox.Items[index + 1] = entities[index + 1].Name;
            listBox.SelectedIndex = index + 1;
        }

        #endregion

        #region Basic Settings Events

        private void nameTextBox_Validated(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == -1)
                return;

            entities[listBox.SelectedIndex].Name = nameTextBox.Text;
            listBox.Items[listBox.SelectedIndex] = nameTextBox.Text;
        }

        private void limitTextBox_Validated(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == -1)
                return;

            OrisonParse.Parse(ref entities[listBox.SelectedIndex].Limit, limitTextBox);
        }

        private void sizeXTextBox_Validated(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == -1)
                return;

            OrisonParse.Parse(ref entities[listBox.SelectedIndex].Size, sizeXTextBox, sizeYTextBox);
        }

        private void originXTextBox_Validated(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == -1)
                return;

            OrisonParse.Parse(ref entities[listBox.SelectedIndex].Origin, originXTextBox, originYTextBox);
        }

        #endregion

        #region Size/Rotate Events

        private void resizableXCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == -1)
                return;

            entities[listBox.SelectedIndex].ResizableX = resizableXCheckBox.Checked;
        }

        private void resizableYCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == -1)
                return;

            entities[listBox.SelectedIndex].ResizableY = resizableYCheckBox.Checked;
        }

        private void rotatableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == -1)
                return;

            entities[listBox.SelectedIndex].Rotatable = rotatableCheckBox.Checked;
            RotationFieldsVisible = rotatableCheckBox.Checked;
        }

        private void rotationIncrementTextBox_Validated(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == -1)
                return;

            OrisonParse.Parse(ref entities[listBox.SelectedIndex].RotateIncrement, rotationIncrementTextBox);
        }

        #endregion

        #region Nodes Events

        private void nodesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == -1)
                return;

            entities[listBox.SelectedIndex].NodesDefinition.Enabled = nodesCheckBox.Checked;
            NodesFieldsVisible = nodesCheckBox.Checked;
        }

        private void nodeLimitTextBox_Validated(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == -1)
                return;

            OrisonParse.Parse(ref entities[listBox.SelectedIndex].NodesDefinition.Limit, nodeLimitTextBox);
        }

        private void nodeDrawComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == -1)
                return;

            entities[listBox.SelectedIndex].NodesDefinition.DrawMode = (EntityNodesDefinition.PathMode)nodeDrawComboBox.SelectedIndex;
        }

        private void nodeGhostCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            entities[listBox.SelectedIndex].NodesDefinition.Ghost = nodeGhostCheckBox.Checked;
        }

        #endregion

        #region Graphics Events

        private void graphicTypeComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == -1)
                return;

            entities[listBox.SelectedIndex].ImageDefinition.DrawMode = (EntityImageDefinition.DrawModes)graphicTypeComboBox.SelectedIndex;
            GraphicFieldsVisibility = graphicTypeComboBox.SelectedIndex;
        }

        private void rectangleColorChooser_ColorChanged(OrisonColor color)
        {
            if (listBox.SelectedIndex == -1)
                return;

            entities[listBox.SelectedIndex].ImageDefinition.RectColor = color;
        }

        private void imageFileTiledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == -1)
                return;

            entities[listBox.SelectedIndex].ImageDefinition.Tiled = imageFileTiledCheckBox.Checked;
        }

        private void imageFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = Orison.IMAGE_FILE_FILTER;
            dialog.CheckFileExists = true;

            if (CheckImageFile())
                dialog.InitialDirectory = Util.DirectoryPath(Path.Combine(directory, imageFileTextBox.Text));
            else
                dialog.InitialDirectory = directory;

            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;

            imageFileTextBox.Text = Util.RelativePath(directory, dialog.FileName);
            imageFileWarningLabel.Visible = !CheckImageFile();
            LoadImageFilePreview();

            entities[listBox.SelectedIndex].ImageDefinition.ImagePath = imageFileTextBox.Text;
        }

        #endregion
    }
}
