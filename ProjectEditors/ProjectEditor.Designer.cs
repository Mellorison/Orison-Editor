namespace OrisonEditor.ProjectEditors
{
    partial class ProjectEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectEditor));
            this.cancelButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.entitiesTabPage = new System.Windows.Forms.TabPage();
            this.tilesetsTabPage = new System.Windows.Forms.TabPage();
            this.layersTabPage = new System.Windows.Forms.TabPage();
            this.settingsTabPage = new System.Windows.Forms.TabPage();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.settingsEditor = new OrisonEditor.ProjectEditors.SettingsEditor();
            this.layersEditor = new OrisonEditor.ProjectEditors.LayerDefinitionsEditor();
            this.tilesetsEditor = new OrisonEditor.ProjectEditors.TilesetsEditor();
            this.objectsEditor = new OrisonEditor.ProjectEditors.EntityDefinitionsEditor();
            this.entitiesTabPage.SuspendLayout();
            this.tilesetsTabPage.SuspendLayout();
            this.layersTabPage.SuspendLayout();
            this.settingsTabPage.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(504, 525);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 38);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(344, 525);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(154, 38);
            this.applyButton.TabIndex = 1;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // entitiesTabPage
            // 
            this.entitiesTabPage.Controls.Add(this.objectsEditor);
            this.entitiesTabPage.Location = new System.Drawing.Point(4, 22);
            this.entitiesTabPage.Name = "entitiesTabPage";
            this.entitiesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.entitiesTabPage.Size = new System.Drawing.Size(573, 490);
            this.entitiesTabPage.TabIndex = 3;
            this.entitiesTabPage.Text = "Entities";
            this.entitiesTabPage.UseVisualStyleBackColor = true;
            // 
            // tilesetsTabPage
            // 
            this.tilesetsTabPage.Controls.Add(this.tilesetsEditor);
            this.tilesetsTabPage.Location = new System.Drawing.Point(4, 22);
            this.tilesetsTabPage.Name = "tilesetsTabPage";
            this.tilesetsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.tilesetsTabPage.Size = new System.Drawing.Size(573, 490);
            this.tilesetsTabPage.TabIndex = 2;
            this.tilesetsTabPage.Text = "Tilesets";
            this.tilesetsTabPage.UseVisualStyleBackColor = true;
            // 
            // layersTabPage
            // 
            this.layersTabPage.Controls.Add(this.layersEditor);
            this.layersTabPage.Location = new System.Drawing.Point(4, 22);
            this.layersTabPage.Name = "layersTabPage";
            this.layersTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.layersTabPage.Size = new System.Drawing.Size(573, 490);
            this.layersTabPage.TabIndex = 1;
            this.layersTabPage.Text = "Layers";
            this.layersTabPage.UseVisualStyleBackColor = true;
            // 
            // settingsTabPage
            // 
            this.settingsTabPage.Controls.Add(this.settingsEditor);
            this.settingsTabPage.Location = new System.Drawing.Point(4, 22);
            this.settingsTabPage.Name = "settingsTabPage";
            this.settingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.settingsTabPage.Size = new System.Drawing.Size(573, 490);
            this.settingsTabPage.TabIndex = 0;
            this.settingsTabPage.Text = "Settings";
            this.settingsTabPage.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.settingsTabPage);
            this.tabControl.Controls.Add(this.layersTabPage);
            this.tabControl.Controls.Add(this.tilesetsTabPage);
            this.tabControl.Controls.Add(this.entitiesTabPage);
            this.tabControl.Location = new System.Drawing.Point(2, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(581, 516);
            this.tabControl.TabIndex = 0;
            // 
            // settingsEditor
            // 
            this.settingsEditor.Location = new System.Drawing.Point(0, 0);
            this.settingsEditor.Margin = new System.Windows.Forms.Padding(4);
            this.settingsEditor.Name = "settingsEditor";
            this.settingsEditor.Size = new System.Drawing.Size(573, 490);
            this.settingsEditor.TabIndex = 0;
            // 
            // layersEditor
            // 
            this.layersEditor.Location = new System.Drawing.Point(0, 0);
            this.layersEditor.Margin = new System.Windows.Forms.Padding(4);
            this.layersEditor.Name = "layersEditor";
            this.layersEditor.Size = new System.Drawing.Size(573, 490);
            this.layersEditor.TabIndex = 0;
            // 
            // tilesetsEditor
            // 
            this.tilesetsEditor.Location = new System.Drawing.Point(-4, 0);
            this.tilesetsEditor.Margin = new System.Windows.Forms.Padding(4);
            this.tilesetsEditor.Name = "tilesetsEditor";
            this.tilesetsEditor.Size = new System.Drawing.Size(573, 490);
            this.tilesetsEditor.TabIndex = 0;
            // 
            // objectsEditor
            // 
            this.objectsEditor.Location = new System.Drawing.Point(-4, 0);
            this.objectsEditor.Margin = new System.Windows.Forms.Padding(4);
            this.objectsEditor.Name = "objectsEditor";
            this.objectsEditor.Size = new System.Drawing.Size(573, 490);
            this.objectsEditor.TabIndex = 0;
            // 
            // ProjectEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(581, 558);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(597, 597);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(597, 597);
            this.Name = "ProjectEditor";
            this.Load += new System.EventHandler(this.ProjectEditor_Load);
            this.entitiesTabPage.ResumeLayout(false);
            this.tilesetsTabPage.ResumeLayout(false);
            this.layersTabPage.ResumeLayout(false);
            this.settingsTabPage.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.TabPage entitiesTabPage;
        private System.Windows.Forms.TabPage tilesetsTabPage;
        private System.Windows.Forms.TabPage layersTabPage;
        private System.Windows.Forms.TabPage settingsTabPage;
        private System.Windows.Forms.TabControl tabControl;
        private SettingsEditor settingsEditor;
        private LayerDefinitionsEditor layersEditor;
        private EntityDefinitionsEditor objectsEditor;
        private TilesetsEditor tilesetsEditor;
    }
}