namespace OrisonEditor
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.ZoomLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MouseCoordinatesLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.GridCoordinatesLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.editorStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.levelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.levelPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.newLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLevelAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.closeOtherLevelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCameraAsImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deselectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editingGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transparentLayersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.centerViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.layersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tilePaletteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entitySelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resaveLevelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shiftRenamerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.swapRenamerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MasterTabControl = new System.Windows.Forms.TabControl();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tabPageContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveLevelToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.closeLevelToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.closeOthersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.duplicateLevelToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusStrip.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.tabPageContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ZoomLabel,
            this.MouseCoordinatesLabel,
            this.GridCoordinatesLabel,
            this.editorStatusLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 540);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StatusStrip.Size = new System.Drawing.Size(784, 22);
            this.StatusStrip.TabIndex = 0;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // ZoomLabel
            // 
            this.ZoomLabel.AutoSize = false;
            this.ZoomLabel.Name = "ZoomLabel";
            this.ZoomLabel.Size = new System.Drawing.Size(40, 17);
            // 
            // MouseCoordinatesLabel
            // 
            this.MouseCoordinatesLabel.AutoSize = false;
            this.MouseCoordinatesLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MouseCoordinatesLabel.Name = "MouseCoordinatesLabel";
            this.MouseCoordinatesLabel.Size = new System.Drawing.Size(120, 17);
            this.MouseCoordinatesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GridCoordinatesLabel
            // 
            this.GridCoordinatesLabel.AutoSize = false;
            this.GridCoordinatesLabel.Name = "GridCoordinatesLabel";
            this.GridCoordinatesLabel.Size = new System.Drawing.Size(100, 17);
            this.GridCoordinatesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // editorStatusLabel
            // 
            this.editorStatusLabel.Name = "editorStatusLabel";
            this.editorStatusLabel.Size = new System.Drawing.Size(0, 17);
            this.editorStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.projectToolStripMenuItem,
            this.levelToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.utilitiesToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(784, 24);
            this.MenuStrip.TabIndex = 1;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preferencesToolStripMenuItem,
            this.checkForUpdatesToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.fileToolStripMenuItem.Text = "Orison";
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences...";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.checkForUpdatesToolStripMenuItem.Text = "Check for Updates";
            this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(168, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this.openProjectToolStripMenuItem,
            this.editProjectToolStripMenuItem,
            this.closeProjectToolStripMenuItem});
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.projectToolStripMenuItem.Text = "Project";
            // 
            // newProjectToolStripMenuItem
            // 
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newProjectToolStripMenuItem.Text = "New Project";
            this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.newProjectToolStripMenuItem_Click);
            // 
            // openProjectToolStripMenuItem
            // 
            this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
            this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openProjectToolStripMenuItem.Text = "Open Project...";
            this.openProjectToolStripMenuItem.Click += new System.EventHandler(this.openProjectToolStripMenuItem_Click);
            // 
            // editProjectToolStripMenuItem
            // 
            this.editProjectToolStripMenuItem.Enabled = false;
            this.editProjectToolStripMenuItem.Name = "editProjectToolStripMenuItem";
            this.editProjectToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.editProjectToolStripMenuItem.Text = "Edit Project";
            this.editProjectToolStripMenuItem.Click += new System.EventHandler(this.editProjectToolStripMenuItem_Click);
            // 
            // closeProjectToolStripMenuItem
            // 
            this.closeProjectToolStripMenuItem.Enabled = false;
            this.closeProjectToolStripMenuItem.Name = "closeProjectToolStripMenuItem";
            this.closeProjectToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.closeProjectToolStripMenuItem.Text = "Close Project";
            this.closeProjectToolStripMenuItem.Click += new System.EventHandler(this.closeProjectToolStripMenuItem_Click);
            // 
            // levelToolStripMenuItem
            // 
            this.levelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.levelPropertiesToolStripMenuItem,
            this.toolStripSeparator3,
            this.newLevelToolStripMenuItem,
            this.openLevelToolStripMenuItem,
            this.saveLevelToolStripMenuItem,
            this.saveLevelAsToolStripMenuItem,
            this.closeLevelToolStripMenuItem,
            this.toolStripSeparator5,
            this.closeOtherLevelsToolStripMenuItem,
            this.duplicateLevelToolStripMenuItem,
            this.saveAsImageToolStripMenuItem,
            this.saveCameraAsImageToolStripMenuItem});
            this.levelToolStripMenuItem.Enabled = false;
            this.levelToolStripMenuItem.Name = "levelToolStripMenuItem";
            this.levelToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.levelToolStripMenuItem.Text = "Level";
            // 
            // levelPropertiesToolStripMenuItem
            // 
            this.levelPropertiesToolStripMenuItem.Enabled = false;
            this.levelPropertiesToolStripMenuItem.Name = "levelPropertiesToolStripMenuItem";
            this.levelPropertiesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.levelPropertiesToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.levelPropertiesToolStripMenuItem.Text = "Level Properties...";
            this.levelPropertiesToolStripMenuItem.Click += new System.EventHandler(this.levelPropertiesToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(222, 6);
            // 
            // newLevelToolStripMenuItem
            // 
            this.newLevelToolStripMenuItem.Name = "newLevelToolStripMenuItem";
            this.newLevelToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newLevelToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.newLevelToolStripMenuItem.Text = "New Level";
            this.newLevelToolStripMenuItem.Click += new System.EventHandler(this.newLevelToolStripMenuItem_Click);
            // 
            // openLevelToolStripMenuItem
            // 
            this.openLevelToolStripMenuItem.Name = "openLevelToolStripMenuItem";
            this.openLevelToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openLevelToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.openLevelToolStripMenuItem.Text = "Open Level...";
            this.openLevelToolStripMenuItem.Click += new System.EventHandler(this.openLevelToolStripMenuItem_Click);
            // 
            // saveLevelToolStripMenuItem
            // 
            this.saveLevelToolStripMenuItem.Enabled = false;
            this.saveLevelToolStripMenuItem.Name = "saveLevelToolStripMenuItem";
            this.saveLevelToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveLevelToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.saveLevelToolStripMenuItem.Text = "Save Level";
            this.saveLevelToolStripMenuItem.Click += new System.EventHandler(this.saveLevelToolStripMenuItem_Click);
            // 
            // saveLevelAsToolStripMenuItem
            // 
            this.saveLevelAsToolStripMenuItem.Enabled = false;
            this.saveLevelAsToolStripMenuItem.Name = "saveLevelAsToolStripMenuItem";
            this.saveLevelAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveLevelAsToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.saveLevelAsToolStripMenuItem.Text = "Save Level As...";
            this.saveLevelAsToolStripMenuItem.Click += new System.EventHandler(this.saveLevelAsToolStripMenuItem_Click);
            // 
            // closeLevelToolStripMenuItem
            // 
            this.closeLevelToolStripMenuItem.Enabled = false;
            this.closeLevelToolStripMenuItem.Name = "closeLevelToolStripMenuItem";
            this.closeLevelToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.closeLevelToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.closeLevelToolStripMenuItem.Text = "Close Level";
            this.closeLevelToolStripMenuItem.Click += new System.EventHandler(this.closeLevelToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(222, 6);
            // 
            // closeOtherLevelsToolStripMenuItem
            // 
            this.closeOtherLevelsToolStripMenuItem.Enabled = false;
            this.closeOtherLevelsToolStripMenuItem.Name = "closeOtherLevelsToolStripMenuItem";
            this.closeOtherLevelsToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.closeOtherLevelsToolStripMenuItem.Text = "Close Other Levels";
            this.closeOtherLevelsToolStripMenuItem.Click += new System.EventHandler(this.closeOtherLevelsToolStripMenuItem_Click);
            // 
            // duplicateLevelToolStripMenuItem
            // 
            this.duplicateLevelToolStripMenuItem.Enabled = false;
            this.duplicateLevelToolStripMenuItem.Name = "duplicateLevelToolStripMenuItem";
            this.duplicateLevelToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.duplicateLevelToolStripMenuItem.Text = "Duplicate Level";
            this.duplicateLevelToolStripMenuItem.Click += new System.EventHandler(this.duplicateLevelToolStripMenuItem_Click);
            // 
            // saveAsImageToolStripMenuItem
            // 
            this.saveAsImageToolStripMenuItem.Enabled = false;
            this.saveAsImageToolStripMenuItem.Name = "saveAsImageToolStripMenuItem";
            this.saveAsImageToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.saveAsImageToolStripMenuItem.Text = "Save As Image...";
            this.saveAsImageToolStripMenuItem.Click += new System.EventHandler(this.saveAsImageToolStripMenuItem_Click);
            // 
            // saveCameraAsImageToolStripMenuItem
            // 
            this.saveCameraAsImageToolStripMenuItem.Enabled = false;
            this.saveCameraAsImageToolStripMenuItem.Name = "saveCameraAsImageToolStripMenuItem";
            this.saveCameraAsImageToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.saveCameraAsImageToolStripMenuItem.Text = "Save Camera As Image...";
            this.saveCameraAsImageToolStripMenuItem.Click += new System.EventHandler(this.saveCameraAsImageToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator4,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator6,
            this.selectAllToolStripMenuItem,
            this.deselectToolStripMenuItem});
            this.editToolStripMenuItem.Enabled = false;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.DropDownOpening += new System.EventHandler(this.editToolStripMenuItem_DropDownOpening);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(161, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(161, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // deselectToolStripMenuItem
            // 
            this.deselectToolStripMenuItem.Name = "deselectToolStripMenuItem";
            this.deselectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.deselectToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.deselectToolStripMenuItem.Text = "Deselect";
            this.deselectToolStripMenuItem.Click += new System.EventHandler(this.deselectToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editingGridToolStripMenuItem,
            this.transparentLayersToolStripMenuItem,
            this.centerViewToolStripMenuItem,
            this.zoomOutToolStripMenuItem,
            this.zoomInToolStripMenuItem,
            this.toolStripSeparator1,
            this.layersToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.tilePaletteToolStripMenuItem,
            this.entitiesToolStripMenuItem,
            this.entitySelectionToolStripMenuItem});
            this.viewToolStripMenuItem.Enabled = false;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            this.viewToolStripMenuItem.DropDownOpened += new System.EventHandler(this.viewToolStripMenuItem_DropDownOpened);
            // 
            // editingGridToolStripMenuItem
            // 
            this.editingGridToolStripMenuItem.Name = "editingGridToolStripMenuItem";
            this.editingGridToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.editingGridToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.editingGridToolStripMenuItem.Text = "Editing Grid";
            this.editingGridToolStripMenuItem.Click += new System.EventHandler(this.editingGridToolStripMenuItem_Click);
            // 
            // transparentLayersToolStripMenuItem
            // 
            this.transparentLayersToolStripMenuItem.Name = "transparentLayersToolStripMenuItem";
            this.transparentLayersToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.transparentLayersToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.transparentLayersToolStripMenuItem.Text = "Transparent Layers";
            this.transparentLayersToolStripMenuItem.Click += new System.EventHandler(this.transparentLayersToolStripMenuItem_Click);
            // 
            // centerViewToolStripMenuItem
            // 
            this.centerViewToolStripMenuItem.Name = "centerViewToolStripMenuItem";
            this.centerViewToolStripMenuItem.ShortcutKeyDisplayString = "Home";
            this.centerViewToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.centerViewToolStripMenuItem.Text = "Center View";
            this.centerViewToolStripMenuItem.Click += new System.EventHandler(this.centerViewToolStripMenuItem_Click);
            // 
            // zoomOutToolStripMenuItem
            // 
            this.zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
            this.zoomOutToolStripMenuItem.ShortcutKeyDisplayString = "-";
            this.zoomOutToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.zoomOutToolStripMenuItem.Text = "Zoom Out";
            this.zoomOutToolStripMenuItem.Click += new System.EventHandler(this.zoomOutToolStripMenuItem_Click);
            // 
            // zoomInToolStripMenuItem
            // 
            this.zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
            this.zoomInToolStripMenuItem.ShortcutKeyDisplayString = "+";
            this.zoomInToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.zoomInToolStripMenuItem.Text = "Zoom In";
            this.zoomInToolStripMenuItem.Click += new System.EventHandler(this.zoomInToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(208, 6);
            // 
            // layersToolStripMenuItem
            // 
            this.layersToolStripMenuItem.Name = "layersToolStripMenuItem";
            this.layersToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.layersToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.layersToolStripMenuItem.Text = "Layers";
            this.layersToolStripMenuItem.Click += new System.EventHandler(this.layersToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.toolsToolStripMenuItem.Text = "Tools";
            this.toolsToolStripMenuItem.Click += new System.EventHandler(this.toolsToolStripMenuItem_Click);
            // 
            // tilePaletteToolStripMenuItem
            // 
            this.tilePaletteToolStripMenuItem.Name = "tilePaletteToolStripMenuItem";
            this.tilePaletteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.tilePaletteToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.tilePaletteToolStripMenuItem.Text = "Tile Palette";
            this.tilePaletteToolStripMenuItem.Click += new System.EventHandler(this.tilePaletteToolStripMenuItem_Click);
            // 
            // entitiesToolStripMenuItem
            // 
            this.entitiesToolStripMenuItem.Name = "entitiesToolStripMenuItem";
            this.entitiesToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.entitiesToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.entitiesToolStripMenuItem.Text = "Entities";
            this.entitiesToolStripMenuItem.Click += new System.EventHandler(this.entitiesToolStripMenuItem_Click);
            // 
            // entitySelectionToolStripMenuItem
            // 
            this.entitySelectionToolStripMenuItem.Name = "entitySelectionToolStripMenuItem";
            this.entitySelectionToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.entitySelectionToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.entitySelectionToolStripMenuItem.Text = "Entity Selection";
            this.entitySelectionToolStripMenuItem.Click += new System.EventHandler(this.entitySelectionToolStripMenuItem_Click);
            // 
            // utilitiesToolStripMenuItem
            // 
            this.utilitiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resaveLevelsToolStripMenuItem,
            this.shiftRenamerToolStripMenuItem,
            this.swapRenamerToolStripMenuItem});
            this.utilitiesToolStripMenuItem.Enabled = false;
            this.utilitiesToolStripMenuItem.Name = "utilitiesToolStripMenuItem";
            this.utilitiesToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.utilitiesToolStripMenuItem.Text = "Utilities";
            // 
            // resaveLevelsToolStripMenuItem
            // 
            this.resaveLevelsToolStripMenuItem.Name = "resaveLevelsToolStripMenuItem";
            this.resaveLevelsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.resaveLevelsToolStripMenuItem.Text = "Batch Resaver";
            this.resaveLevelsToolStripMenuItem.Click += new System.EventHandler(this.resaveLevelsToolStripMenuItem_Click);
            // 
            // shiftRenamerToolStripMenuItem
            // 
            this.shiftRenamerToolStripMenuItem.Name = "shiftRenamerToolStripMenuItem";
            this.shiftRenamerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.shiftRenamerToolStripMenuItem.Text = "Shift Renamer";
            this.shiftRenamerToolStripMenuItem.Click += new System.EventHandler(this.shiftRenamerToolStripMenuItem_Click);
            // 
            // swapRenamerToolStripMenuItem
            // 
            this.swapRenamerToolStripMenuItem.Name = "swapRenamerToolStripMenuItem";
            this.swapRenamerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.swapRenamerToolStripMenuItem.Text = "Swap Renamer";
            this.swapRenamerToolStripMenuItem.Click += new System.EventHandler(this.swapRenamerToolStripMenuItem_Click);
            // 
            // MasterTabControl
            // 
            this.MasterTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MasterTabControl.Location = new System.Drawing.Point(0, 24);
            this.MasterTabControl.Name = "MasterTabControl";
            this.MasterTabControl.SelectedIndex = 0;
            this.MasterTabControl.Size = new System.Drawing.Size(784, 516);
            this.MasterTabControl.TabIndex = 2;
            this.MasterTabControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.MasterTabControl_Selecting);
            this.MasterTabControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MasterTabControl_MouseClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(61, 4);
            // 
            // tabPageContextMenuStrip
            // 
            this.tabPageContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveLevelToolStripMenuItem1,
            this.closeLevelToolStripMenuItem1,
            this.closeOthersToolStripMenuItem,
            this.toolStripSeparator7,
            this.duplicateLevelToolStripMenuItem1});
            this.tabPageContextMenuStrip.Name = "tabPageContextMenuStrip";
            this.tabPageContextMenuStrip.Size = new System.Drawing.Size(155, 98);
            // 
            // saveLevelToolStripMenuItem1
            // 
            this.saveLevelToolStripMenuItem1.Name = "saveLevelToolStripMenuItem1";
            this.saveLevelToolStripMenuItem1.Size = new System.Drawing.Size(154, 22);
            this.saveLevelToolStripMenuItem1.Text = "Save Level";
            this.saveLevelToolStripMenuItem1.Click += new System.EventHandler(this.saveLevelToolStripMenuItem_Click);
            // 
            // closeLevelToolStripMenuItem1
            // 
            this.closeLevelToolStripMenuItem1.Name = "closeLevelToolStripMenuItem1";
            this.closeLevelToolStripMenuItem1.Size = new System.Drawing.Size(154, 22);
            this.closeLevelToolStripMenuItem1.Text = "Close Level";
            this.closeLevelToolStripMenuItem1.Click += new System.EventHandler(this.closeLevelToolStripMenuItem_Click);
            // 
            // closeOthersToolStripMenuItem
            // 
            this.closeOthersToolStripMenuItem.Name = "closeOthersToolStripMenuItem";
            this.closeOthersToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.closeOthersToolStripMenuItem.Text = "Close Others";
            this.closeOthersToolStripMenuItem.Click += new System.EventHandler(this.closeOtherLevelsToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(151, 6);
            // 
            // duplicateLevelToolStripMenuItem1
            // 
            this.duplicateLevelToolStripMenuItem1.Name = "duplicateLevelToolStripMenuItem1";
            this.duplicateLevelToolStripMenuItem1.Size = new System.Drawing.Size(154, 22);
            this.duplicateLevelToolStripMenuItem1.Text = "Duplicate Level";
            this.duplicateLevelToolStripMenuItem1.Click += new System.EventHandler(this.duplicateLevelToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.MasterTabControl);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.MenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.MenuStrip;
            this.MinimumSize = new System.Drawing.Size(800, 599);
            this.Name = "MainWindow";
            this.Text = "Orison Editor";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainWindow_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainWindow_DragEnter);
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.tabPageContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem levelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveLevelAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem duplicateLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeOtherLevelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editProjectToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem layersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        public System.Windows.Forms.ToolStripStatusLabel MouseCoordinatesLabel;
        public System.Windows.Forms.TabControl MasterTabControl;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editingGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transparentLayersToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem entitySelectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem levelPropertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripStatusLabel editorStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem tilePaletteToolStripMenuItem;
        public System.Windows.Forms.ToolStripStatusLabel GridCoordinatesLabel;
        public System.Windows.Forms.ToolStripStatusLabel ZoomLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deselectToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip tabPageContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem saveLevelToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeLevelToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeOthersToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem duplicateLevelToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCameraAsImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem centerViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utilitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resaveLevelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shiftRenamerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem swapRenamerToolStripMenuItem;
    }
}