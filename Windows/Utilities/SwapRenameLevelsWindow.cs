using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace OrisonEditor.Windows.Utilities
{
    public partial class SwapRenameLevelsWindow : UtilityForm
    {
        public SwapRenameLevelsWindow()
        {
            InitializeComponent();
        }

        private void levelABrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Swap Level A";
            dialog.Filter = Orison.LEVEL_FILTER;
            dialog.CheckFileExists = true;

            if (levelATextbox.Text != "")
                dialog.InitialDirectory = Path.GetDirectoryName(Path.Combine(Orison.Project.SavedDirectory, levelATextbox.Text));
            else if (levelBTextbox.Text != "")
                dialog.InitialDirectory = Path.GetDirectoryName(Path.Combine(Orison.Project.SavedDirectory, levelBTextbox.Text));
            else
                dialog.InitialDirectory = Orison.Project.SavedDirectory;
        
            DialogResult result = dialog.ShowDialog(this);

            if (result == System.Windows.Forms.DialogResult.OK)
                levelATextbox.Text = Util.RelativePath(Orison.Project.SavedDirectory, dialog.FileName);
        }

        private void levelBBrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Swap Level B";
            dialog.Filter = Orison.LEVEL_FILTER;
            dialog.CheckFileExists = true;

            if (levelBTextbox.Text != "")
                dialog.InitialDirectory = Path.GetDirectoryName(Path.Combine(Orison.Project.SavedDirectory, levelBTextbox.Text));
            else if (levelATextbox.Text != "")
                dialog.InitialDirectory = Path.GetDirectoryName(Path.Combine(Orison.Project.SavedDirectory, levelATextbox.Text));
            else
                dialog.InitialDirectory = Orison.Project.SavedDirectory;
           
            DialogResult result = dialog.ShowDialog(this);

            if (result == System.Windows.Forms.DialogResult.OK)
                levelBTextbox.Text = Util.RelativePath(Orison.Project.SavedDirectory, dialog.FileName);
        }

        private void performButton_Click(object sender, EventArgs e)
        {
            string levelA = Path.Combine(Orison.Project.SavedDirectory, levelATextbox.Text);
            string levelB = Path.Combine(Orison.Project.SavedDirectory, levelBTextbox.Text);

            //Close the levels if they're open
            if (!Orison.CloseLevelByFilepath(levelA) || !Orison.CloseLevelByFilepath(levelB))
                return;

            //If they don't exist, error
            if (!File.Exists(levelA))
            {
                MessageBox.Show(this, "Level file A does not exist!", "Swap Renamer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (!File.Exists(levelB))
            {
                MessageBox.Show(this, "Level file B does not exist!", "Swap Renamer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //If they're the same file, error
            if (levelA == levelB)
            {
                MessageBox.Show(this, "Cannot swap a file with itself!", "Swap Renamer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Do the swap
            string temp = Path.Combine(Orison.ProgramDirectory, "temp");
            File.Copy(levelA, temp, true);
            File.Copy(levelB, levelA, true);
            File.Copy(temp, levelB, true);
            File.Delete(temp);

            //Report success
            MessageBox.Show(this, "Swap completed", "Swap Renamer", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
