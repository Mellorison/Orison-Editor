using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace OrisonEditor.ProjectEditors
{
    public partial class SettingsEditor : UserControl, IProjectChanger
    {
        private Project project;

        public SettingsEditor()
        {
            InitializeComponent();
        }

        public void LoadFromProject(Project project)
        {
            this.project = project;

            projectNameTextBox.Text = project.Name;
            backgroundColorChooser.Color = project.BackgroundColor;
            gridColorChooser.Color = project.GridColor;
            defaultWidthTextBox.Text = project.LevelDefaultSize.Width.ToString();
            defaultHeightTextBox.Text = project.LevelDefaultSize.Height.ToString();
            minWidthTextBox.Text = project.LevelMinimumSize.Width.ToString();
            minHeightTextBox.Text = project.LevelMinimumSize.Height.ToString();
            maxWidthTextBox.Text = project.LevelMaximumSize.Width.ToString();
            maxHeightTextBox.Text = project.LevelMaximumSize.Height.ToString();
            angleModeComboBox.SelectedIndex = (int)project.AngleMode;
            cameraWidthTextBox.Enabled = cameraHeightTextBox.Enabled = exportCameraPositionCheckbox.Enabled = cameraEnabledCheckbox.Checked = project.CameraEnabled;
            cameraWidthTextBox.Text = project.CameraSize.Width.ToString();
            cameraHeightTextBox.Text = project.CameraSize.Height.ToString();
            exportCameraPositionCheckbox.Checked = project.ExportCameraPosition;

            valuesEditor.SetList(project.LevelValueDefinitions);
        }

        private void projectNameTextBox_Validated(object sender, EventArgs e)
        {
            project.Name = projectNameTextBox.Text;
        }

        private void backgroundColorChooser_ColorChanged(OrisonColor color)
        {
            project.BackgroundColor = color;
        }

        private void defaultWidthTextBox_Validated(object sender, EventArgs e)
        {
            OrisonParse.Parse(ref project.LevelDefaultSize, defaultWidthTextBox, defaultHeightTextBox);
        }

        private void minWidthTextBox_Validated(object sender, EventArgs e)
        {
            OrisonParse.Parse(ref project.LevelMinimumSize, minWidthTextBox, minHeightTextBox);
        }

        private void maxWidthTextBox_TextChanged(object sender, EventArgs e)
        {
            OrisonParse.Parse(ref project.LevelMaximumSize, maxWidthTextBox, maxHeightTextBox);
        }

        private void gridColorChooser_ColorChanged(OrisonColor color)
        {
            project.GridColor = color;
        }

        private void angleModeComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            project.AngleMode = (Project.AngleExportMode)angleModeComboBox.SelectedIndex;
        }

        private void cameraEnabledCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            cameraWidthTextBox.Enabled = cameraHeightTextBox.Enabled = exportCameraPositionCheckbox.Enabled = project.CameraEnabled = cameraEnabledCheckbox.Checked;
        }

        private void cameraWidthTextBox_Validated(object sender, EventArgs e)
        {
            OrisonParse.Parse(ref project.CameraSize, cameraWidthTextBox, cameraHeightTextBox);
        }

        private void exportCameraPositionCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            project.ExportCameraPosition = exportCameraPositionCheckbox.Checked;
        }

    }
}
