using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OrisonEditor.Definitions.LayerDefinitions;
using System.Diagnostics;
using OrisonEditor.Windows;

namespace OrisonEditor.ProjectEditors
{
    public partial class ProjectEditor : Form
    {
        private Project oldProject;
        private Project newProject;
        private Orison.ProjectEditMode editMode;
        private Orison.FinishProjectEditAction finishAction;

        public ProjectEditor(Project project, Orison.ProjectEditMode editMode)
        {
            this.Text = "Project Editor - " + project.Name;
            this.oldProject = project;
            this.editMode = editMode;
            InitializeComponent();

            newProject = new Project();
            newProject.CloneFrom(oldProject);

            //Load the contents of the editors
            settingsEditor.LoadFromProject(newProject);
            layersEditor.LoadFromProject(newProject);
            tilesetsEditor.LoadFromProject(newProject);
            objectsEditor.LoadFromProject(newProject);

            //Events
            FormClosed += onClose;
        }

        private void onClose(object sender, FormClosedEventArgs e)
        {
            Orison.FinishProjectEdit(finishAction);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (editMode == Orison.ProjectEditMode.NormalEdit)
                finishAction = Orison.FinishProjectEditAction.None;
            else
                finishAction = Orison.FinishProjectEditAction.CloseProject;

            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //Check for errors
            string errors = newProject.ErrorCheck();
            if (errors != "")
            {
                MessageBox.Show(this, "Project could not be saved because of the following errors:\n" + errors);
                return;
            }

            //Copy the edited project onto the old one
            oldProject.CloneFrom(newProject);

            //Save the project after closing the form
            if (editMode == Orison.ProjectEditMode.ErrorOnLoad)
                finishAction = Orison.FinishProjectEditAction.LoadAndSaveProject;
            else
                finishAction = Orison.FinishProjectEditAction.SaveProject;

            //Close the project editor
            Close();
        }

        private void ProjectEditor_Load(object sender, EventArgs e)
        {

        }
    }
}
