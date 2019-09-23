using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OrisonEditor.Windows
{
    public partial class PreferencesWindow : Form
    {
        public PreferencesWindow()
        {
            InitializeComponent();
        }

        private void PreferencesWindow_Shown(object sender, EventArgs e)
        {
            maximizeCheckBox.Checked = Properties.Settings.Default.StartMaximized;
            undoLimitTextBox.Text = Properties.Settings.Default.UndoLimit.ToString();
            levelLimitTextBox.Text = Properties.Settings.Default.LevelLimit.ToString();

            clearHistoryButton.Enabled = Properties.Settings.Default.RecentProjects.Count > 0;
        }

        private void PreferencesWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.StartMaximized = maximizeCheckBox.Checked;

            try
            {
                Properties.Settings.Default.UndoLimit = Convert.ToInt32(undoLimitTextBox.Text);
            }
            catch
            { }

            try
            {
                Properties.Settings.Default.LevelLimit = Convert.ToInt32(levelLimitTextBox.Text);
            }
            catch
            { }

            Properties.Settings.Default.Save();
            Orison.MainWindow.EnableEditing();
        }

        private void clearHistoryButton_Click(object sender, EventArgs e)
        {
            Orison.ClearRecentProjects();
            clearHistoryButton.Enabled = false;
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
