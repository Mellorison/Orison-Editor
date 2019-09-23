using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OrisonEditor.LevelData;
using System.IO;

namespace OrisonEditor.Windows.Utilities
{
    public partial class ResaveLevelsWindow : UtilityForm
    {
        public ResaveLevelsWindow()
        {
            InitializeComponent();
            RefreshDescription();
        }

        private void RefreshDescription()
        {
            if (allRadioButton.Checked)
            {
                descLabel.Text = "Resaves all the levels in the project directory, and recursively through all subfolders.";
            }
            else if (levelsRadioButton.Checked)
            {
                descLabel.Text = "Select which levels to resave.";
            }
            else if (directoryRadioButton.Checked)
            {
                descLabel.Text = "Select a folder. Resaves all the levels in the selected folder, and recursively through all subfolders."; 
            }
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDescription();
        }

        private void performButton_Click(object sender, EventArgs e)
        {
            IEnumerable<string> files = null;

            if (allRadioButton.Checked)
            {
                files = Directory.EnumerateFiles(Orison.Project.SavedDirectory, "*.oel", SearchOption.AllDirectories);
            }
            else if (levelsRadioButton.Checked)
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.InitialDirectory = Orison.Project.SavedDirectory;
                dialog.Title = "Batch Resaver";
                dialog.Multiselect = true;
                dialog.Filter = Orison.LEVEL_FILTER;
                dialog.CheckFileExists = true;
                DialogResult result = dialog.ShowDialog(this);

                if (result == System.Windows.Forms.DialogResult.Cancel)
                    return;

                files = dialog.FileNames;
            }
            else if (directoryRadioButton.Checked)
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                dialog.ShowNewFolderButton = false;
                dialog.SelectedPath = Orison.Project.SavedDirectory;
                dialog.RootFolder = Environment.SpecialFolder.MyDocuments;
                dialog.Description = "Select a folder to search for levels to resave.";
                DialogResult result = dialog.ShowDialog(this);

                if (result == System.Windows.Forms.DialogResult.Cancel)
                    return;

                files = Directory.EnumerateFiles(dialog.SelectedPath, "*.oel", SearchOption.AllDirectories);
            }

            ResaveLevels(files);
        }

        private void ResaveLevels(IEnumerable<string> files)
        {
            //If any of the levels are open, close them
            if (files != null)
                if (!Orison.CloseLevelsByFilepaths(files))
                    return;

            //Resave the levels
            int i = 0;
            if (files != null)
            {
                foreach (var f in files)
                {
                    if (File.Exists(f))
                    {
                        Level level = new Level(Orison.Project, f);
                        if (!level.Salvaged)
                        {
                            level.WriteTo(level.SavePath);
                            i++;
                        }
                    }
                }
            }

            MessageBox.Show(this, "Resave Utility finished, resaved " + i + " level(s).", "Batch Resaver");
            Close();
        }
    }
}
