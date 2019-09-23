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
    public partial class TilesetsEditor : UserControl, IProjectChanger
    {
        private const string DEFAULT_NAME = "NewTileset";

        private List<Tileset> tilesets;
        private string directory;

        public TilesetsEditor()
        {
            InitializeComponent();
        }

        public void LoadFromProject(Project project)
        {
            tilesets = project.Tilesets;
            foreach (var t in tilesets)
                listBox.Items.Add(t.Name);

            directory = project.SavedDirectory;
        }

        private void setControlsFromTileset(Tileset t)
        {
            removeButton.Enabled = true;
            moveUpButton.Enabled = listBox.SelectedIndex > 0;
            moveDownButton.Enabled = listBox.SelectedIndex < listBox.Items.Count - 1;

            imagePreviewer.Enabled = true;
            nameTextBox.Enabled = true;
            imageFileTextBox.Enabled = true;
            imageFileButton.Enabled = true;
            imageFileWarningLabel.Enabled = true;
            tileSizeXTextBox.Enabled = true;
            tileSizeYTextBox.Enabled = true;
            tileSpacingTextBox.Enabled = true;

            nameTextBox.Text = t.Name;
            imageFileTextBox.Text = t.FilePath;
            tileSizeXTextBox.Text = t.TileSize.Width.ToString();
            tileSizeYTextBox.Text = t.TileSize.Height.ToString();
            tileSpacingTextBox.Text = t.TileSep.ToString();

            LoadPreview();
        }

        private void disableControls()
        {
            removeButton.Enabled = false;
            moveUpButton.Enabled = false;
            moveDownButton.Enabled = false;

            imagePreviewer.Enabled = false;
            nameTextBox.Enabled = false;
            imageFileTextBox.Enabled = false;
            imageFileButton.Enabled = false;
            imageFileWarningLabel.Enabled = false;
            tileSizeXTextBox.Enabled = false;
            tileSizeYTextBox.Enabled = false;
            tileSpacingTextBox.Enabled = false;

            imageFileWarningLabel.Visible = false;
            clearPreview();
        }

        private string getNewName()
        {
            int i = 0;
            string name;

            do
            {
                name = DEFAULT_NAME + i.ToString();
                i++;
            }
            while (tilesets.Find(t => t.Name == name) != null);

            return name;
        }

        private void LoadPreview()
        {
            tilesets[listBox.SelectedIndex].GenerateBitmap();
            Bitmap bitmap = tilesets[listBox.SelectedIndex].GetBitmap();
            if (bitmap == null)
            {
                imageSizeLabel.Visible = false;
                totalTilesLabel.Visible = false;
                imagePreviewer.ClearImage();
            }
            else
            {
                imagePreviewer.LoadImage(bitmap);
                imageSizeLabel.Visible = true;
                imageSizeLabel.Text = "Image Size: " + tilesets[listBox.SelectedIndex].Size.Width + " x " + tilesets[listBox.SelectedIndex].Size.Height;
                totalTilesLabel.Visible = true;
                updateTotalTiles();               
            }

            imageFileWarningLabel.Visible = !imagePreviewer.BitmapValid; 
        }

        private void clearPreview()
        {
            imagePreviewer.ClearImage();
            imageSizeLabel.Visible = false;
            totalTilesLabel.Visible = false;
        }

        private void updateTotalTiles()
        {
            totalTilesLabel.Text = "Tiles: " + tilesets[listBox.SelectedIndex].TilesAcross.ToString() + " x " + tilesets[listBox.SelectedIndex].TilesDown.ToString() + " (" + tilesets[listBox.SelectedIndex].TilesTotal.ToString() + " total)";
        }

        /*
         *  Events
         */
        private void addButton_Click(object sender, EventArgs e)
        {
            Tileset t = new Tileset();
            t.Name = getNewName();
            tilesets.Add(t);
            listBox.SelectedIndex = listBox.Items.Add(t.Name);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            int index = listBox.SelectedIndex;
            tilesets.RemoveAt(listBox.SelectedIndex);
            listBox.Items.RemoveAt(listBox.SelectedIndex);

            listBox.SelectedIndex = Math.Min(listBox.Items.Count - 1, index);
        }

        private void moveUpButton_Click(object sender, EventArgs e)
        {
            int index = listBox.SelectedIndex;

            Tileset temp = tilesets[index];
            tilesets[index] = tilesets[index - 1];
            tilesets[index - 1] = temp;

            listBox.Items[index] = tilesets[index].Name;
            listBox.Items[index - 1] = tilesets[index - 1].Name;
            listBox.SelectedIndex = index - 1;
        }

        private void moveDownButton_Click(object sender, EventArgs e)
        {
            int index = listBox.SelectedIndex;

            Tileset temp = tilesets[index];
            tilesets[index] = tilesets[index + 1];
            tilesets[index + 1] = temp;

            listBox.Items[index] = tilesets[index].Name;
            listBox.Items[index + 1] = tilesets[index + 1].Name;
            listBox.SelectedIndex = index + 1;
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == -1)
                disableControls();
            else
                setControlsFromTileset(tilesets[listBox.SelectedIndex]);
        }

        private void nameTextBox_Validated(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == -1)
                return;

            tilesets[listBox.SelectedIndex].Name = nameTextBox.Text;
            listBox.Items[listBox.SelectedIndex] = nameTextBox.Text;
        }

        private void tileSizeXTextBox_Validated(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == -1)
                return;

            OrisonParse.Parse(ref tilesets[listBox.SelectedIndex].TileSize, tileSizeXTextBox, tileSizeYTextBox);
            updateTotalTiles();
        }

        private void tileSpacingTextBox_Validated(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == -1)
                return;

            OrisonParse.Parse(ref tilesets[listBox.SelectedIndex].TileSep, tileSpacingTextBox);
            updateTotalTiles();
        }

        private void imageFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = Orison.IMAGE_FILE_FILTER;
            dialog.CheckFileExists = true;

            if (File.Exists(Path.Combine(directory, imageFileTextBox.Text)))
                dialog.InitialDirectory = Path.Combine(directory, imageFileTextBox.Text);
            else
                dialog.InitialDirectory = directory;

            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;

            imageFileTextBox.Text = Util.RelativePath(directory, dialog.FileName);
            tilesets[listBox.SelectedIndex].SetFilePath(imageFileTextBox.Text);

            LoadPreview();       
        }
    }
}
