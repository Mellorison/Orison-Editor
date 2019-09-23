using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using OrisonEditor.LevelData;
using OrisonEditor.LevelEditors;
using OrisonEditor.Windows;
using OrisonEditor.Windows.Utilities;

namespace OrisonEditor
{
    public partial class MainWindow : Form
    {
        private const int EDIT_BOUNDS_PADDING = 10;

        public bool EditingGridVisible { get; private set; }
        public bool TransparentLayers { get; private set; }
        public List<LevelEditor> LevelEditors { get; private set; }

        private ImageList imageList;
        private int rightClicked = -1;      //After a right-click context menu on a tab is closed, switch to this level

        public MainWindow()
        {
            InitializeComponent();

            //Start maximized?
            if (Properties.Settings.Default.StartMaximized)
                WindowState = FormWindowState.Maximized;

            EditingGridVisible = true;
            TransparentLayers = false;
            LevelEditors = new List<LevelEditor>();

            imageList = new ImageList();
            imageList.Images.Add(Image.FromFile(Path.Combine(Orison.ProgramDirectory, "Content/icons", "oricon.png")));
            imageList.Images.Add(Image.FromFile(Path.Combine(Orison.ProgramDirectory, "Content/icons", "lvl86.png")));
            MasterTabControl.ImageList = imageList;

            AddStartPage();

            Orison.OnProjectStart += onProjectStart;
            Orison.OnProjectClose += onProjectClose;
            Orison.OnLevelAdded += onLevelAdded;
            Orison.OnLevelClosed += onLevelClosed;
            Orison.OnLevelChanged += onLevelChanged;
        }

        public void AddStartPage()
        {
            TabPage start = new TabPage("Start Page");
            start.Name = "startPage";
            start.Controls.Add(new StartPage());
            start.ImageIndex = 0;
            MasterTabControl.TabPages.Add(start);
        }

        public void RemoveStartPage()
        {
            foreach (TabPage p in MasterTabControl.TabPages)
            {
                if (p.Name == "startPage")
                {
                    MasterTabControl.TabPages.Remove(p);
                    return;
                }
            }
        }

        public void FocusEditor()
        {
            if (LevelEditors.Count > 0)
                LevelEditors[Orison.CurrentLevelIndex].Focus();
            else
                Focus();
        }

        public void EnableEditing()
        {
            Enabled = true;
            foreach (var f in OwnedForms)
                f.Enabled = true;
        }

        public void DisableEditing()
        {
            Enabled = false;
            foreach (var f in OwnedForms)
                f.Enabled = false;
        }

        private int SelectedLevelIndex
        {
            get { return MasterTabControl.SelectedIndex; }
            set {  MasterTabControl.SelectedIndex = value; }
        }

        public Rectangle EditBounds
        {
            get
            {
                if (WindowState == FormWindowState.Maximized)
                {
                    int titleBar = Size.Height - ClientSize.Height;
                    return new Rectangle(Location.X + 8 + MasterTabControl.Location.X + EDIT_BOUNDS_PADDING,
                        Location.Y + titleBar + MasterTabControl.Location.Y + 10 + EDIT_BOUNDS_PADDING, 
                        MasterTabControl.Width - (EDIT_BOUNDS_PADDING * 2),
                        MasterTabControl.Height - 20 - (EDIT_BOUNDS_PADDING * 2));
                }
                else
                {
                    int border = (Size.Width - ClientSize.Width) / 2;
                    int titleBar = Size.Height - ClientSize.Height - border;
                    return new Rectangle(
                        Location.X + border + MasterTabControl.Location.X + EDIT_BOUNDS_PADDING,
                        Location.Y + 20 + titleBar + MasterTabControl.Location.Y + EDIT_BOUNDS_PADDING,
                        MasterTabControl.Width - (EDIT_BOUNDS_PADDING * 2),
                        MasterTabControl.Height - 20 - (EDIT_BOUNDS_PADDING * 2));
                }
            }
        }

        public string StatusText
        {
            set
            {
                editorStatusLabel.Text = value;
            }
        }

        #region Ogmo Event Callbacks

        private void onProjectStart(Project project)
        {
            //Enable menu items
            newProjectToolStripMenuItem.Enabled = false;
            openProjectToolStripMenuItem.Enabled = false;
            closeProjectToolStripMenuItem.Enabled = true;
            editProjectToolStripMenuItem.Enabled = true;

            levelToolStripMenuItem.Enabled = true;
            viewToolStripMenuItem.Enabled = true;
            utilitiesToolStripMenuItem.Enabled = true;
        }

        private void onProjectClose(Project project)
        {
            //Disable menu items
            newProjectToolStripMenuItem.Enabled = true;
            openProjectToolStripMenuItem.Enabled = true;
            closeProjectToolStripMenuItem.Enabled = false;
            editProjectToolStripMenuItem.Enabled = false;          

            levelToolStripMenuItem.Enabled = false;
            viewToolStripMenuItem.Enabled = false;
            utilitiesToolStripMenuItem.Enabled = false;

            //Clear mouse/grid readouts
            MouseCoordinatesLabel.Text = GridCoordinatesLabel.Text = "";
        }

        private void onLevelAdded(int index)
        {
            TabPage t = new TabPage(Orison.Levels[index].Name);
            t.ImageIndex = 1;
            LevelEditor e = new LevelEditor(Orison.Levels[index]);
            LevelEditors.Add(e);
            t.Controls.Add(e);
            MasterTabControl.TabPages.Add(t);
        }

        private void onLevelClosed(int index)
        {
            MasterTabControl.TabPages.RemoveAt(index);
            LevelEditors[index].OnRemove();
            LevelEditors.RemoveAt(index);

            //Clear zoom/mouse/grid readouts
            if (Orison.Levels.Count == 0)
                ZoomLabel.Text = MouseCoordinatesLabel.Text = GridCoordinatesLabel.Text = "";
        }

        private void onLevelChanged(int index)
        {
            SelectedLevelIndex = index;
            
            //Switch to the editor
            if (index != -1)
                LevelEditors[index].SwitchTo();

            //Refresh stuff
            editToolStripMenuItem.Enabled =
                levelPropertiesToolStripMenuItem.Enabled =
                saveLevelToolStripMenuItem.Enabled =
                saveLevelAsToolStripMenuItem.Enabled =
                closeLevelToolStripMenuItem.Enabled =
                duplicateLevelToolStripMenuItem.Enabled =
                closeOtherLevelsToolStripMenuItem.Enabled =
                saveAsImageToolStripMenuItem.Enabled = index != -1;

            saveCameraAsImageToolStripMenuItem.Enabled = index != -1 && Orison.Project.CameraEnabled;
        }

        #endregion

        #region Tab Control Events

        private void MasterTabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            Orison.SetLevel(e.TabPageIndex);
        }

        private void MasterTabControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                int old = MasterTabControl.SelectedIndex;
                int num = -1;
                for (int i = 0; i < MasterTabControl.TabCount; i++)
                {
                    if (MasterTabControl.GetTabRect(i).Contains(e.Location))
                        num = i;
                }

                if (num != -1 && MasterTabControl.TabPages[num].Name != "startPage")
                {
                    rightClicked = num;
                    tabPageContextMenuStrip.Show(this, e.Location);
                }
            }
            else
                FocusEditor();
        }

        #endregion

        #region Ogmo Menu Events

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PreferencesWindow pref = new PreferencesWindow();
            DisableEditing();
            pref.Show(this);
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "You cannot check for updates!", "Nope!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutWindow about = new AboutWindow();
            DisableEditing();
            about.Show(this);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region Project Menu Events

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Orison.NewProject();
        }

        private void closeProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Orison.CloseProject();
        }

        private void editProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Orison.EditProject(Orison.ProjectEditMode.NormalEdit);
        }

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Orison.LoadProject();
        }

        #endregion

        #region Level Menu Events

        private int getTargetLevel()
        {
            if (rightClicked == -1)
                return SelectedLevelIndex;
            else
            {
                int num = rightClicked;
                rightClicked = -1;
                return num;
            }
        }

        private void levelPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Orison.CurrentLevel.EditProperties();
        }

        private void newLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Orison.Project == null)
                return;

            Orison.NewLevel();
        }

        private void openLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Orison.Project == null)
                return;

            Orison.OpenLevel();
        }

        private void saveLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Orison.Project == null)
                return;

            Orison.Levels[getTargetLevel()].Save();
        }

        private void saveLevelAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Orison.Project == null)
                return;

            Orison.Levels[getTargetLevel()].SaveAs();
        }

        private void closeLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Orison.Project == null)
                return;

            Orison.CloseLevel(Orison.Levels[getTargetLevel()], true);
        }

        private void duplicateLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Orison.Project == null)
                return;

            Orison.AddLevel(new Level(Orison.Levels[getTargetLevel()]));
        }

        private void closeOtherLevelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Orison.CloseOtherLevels(Orison.Levels[getTargetLevel()]);
        }

        private void saveAsImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LevelEditors[Orison.CurrentLevelIndex].SaveAsImage();
        }

        private void saveCameraAsImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LevelEditors[Orison.CurrentLevelIndex].SaveCameraAsImage();
        }

        #endregion

        #region Edit Menu Events

        private void editToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            undoToolStripMenuItem.Enabled = LevelEditors[Orison.CurrentLevelIndex].CanUndo;
            redoToolStripMenuItem.Enabled = LevelEditors[Orison.CurrentLevelIndex].CanRedo;

            cutToolStripMenuItem.Enabled = copyToolStripMenuItem.Enabled = LevelEditors[Orison.CurrentLevelIndex].LayerEditors[Orison.LayersWindow.CurrentLayerIndex].CanCopyOrCut;
            if (Orison.Clipboard == null)
                pasteToolStripMenuItem.Enabled = false;
            else
                pasteToolStripMenuItem.Enabled = Orison.Clipboard.CanPaste(Orison.LayersWindow.CurrentLayer);
            selectAllToolStripMenuItem.Enabled = LevelEditors[Orison.CurrentLevelIndex].LayerEditors[Orison.LayersWindow.CurrentLayerIndex].CanSelectAll;
            deselectToolStripMenuItem.Enabled = LevelEditors[Orison.CurrentLevelIndex].LayerEditors[Orison.LayersWindow.CurrentLayerIndex].CanDeselect;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LevelEditors[Orison.CurrentLevelIndex].Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LevelEditors[Orison.CurrentLevelIndex].Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LevelEditors[Orison.CurrentLevelIndex].LayerEditors[Orison.LayersWindow.CurrentLayerIndex].CanCopyOrCut)
                LevelEditors[Orison.CurrentLevelIndex].LayerEditors[Orison.LayersWindow.CurrentLayerIndex].Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LevelEditors[Orison.CurrentLevelIndex].LayerEditors[Orison.LayersWindow.CurrentLayerIndex].CanCopyOrCut)
                LevelEditors[Orison.CurrentLevelIndex].LayerEditors[Orison.LayersWindow.CurrentLayerIndex].Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Orison.Clipboard != null && Orison.Clipboard.CanPaste(Orison.LayersWindow.CurrentLayer))
                Orison.Clipboard.Paste(LevelEditors[Orison.CurrentLevelIndex], Orison.LayersWindow.CurrentLayer);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectAllToolStripMenuItem.Enabled = LevelEditors[Orison.CurrentLevelIndex].LayerEditors[Orison.LayersWindow.CurrentLayerIndex].CanSelectAll)
                LevelEditors[Orison.CurrentLevelIndex].LayerEditors[Orison.LayersWindow.CurrentLayerIndex].SelectAll();
        }

        private void deselectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LevelEditors[Orison.CurrentLevelIndex].LayerEditors[Orison.LayersWindow.CurrentLayerIndex].CanDeselect)
                LevelEditors[Orison.CurrentLevelIndex].LayerEditors[Orison.LayersWindow.CurrentLayerIndex].Deselect();
        }

        #endregion

        #region View Menu Events

        private void viewToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            editingGridToolStripMenuItem.Checked = EditingGridVisible;
            transparentLayersToolStripMenuItem.Checked = TransparentLayers;

            layersToolStripMenuItem.Enabled = Orison.LayersWindow.EditorVisible;
            layersToolStripMenuItem.Checked = Orison.LayersWindow.UserVisible;

            toolsToolStripMenuItem.Enabled = Orison.ToolsWindow.EditorVisible;
            toolsToolStripMenuItem.Checked = Orison.ToolsWindow.UserVisible;

            entitiesToolStripMenuItem.Enabled = Orison.EntitiesWindow.EditorVisible;
            entitiesToolStripMenuItem.Checked = Orison.EntitiesWindow.UserVisible;

            entitySelectionToolStripMenuItem.Enabled = Orison.EntitySelectionWindow.EditorVisible;
            entitySelectionToolStripMenuItem.Checked = Orison.EntitySelectionWindow.UserVisible;

            tilePaletteToolStripMenuItem.Enabled = Orison.TilePaletteWindow.EditorVisible;
            tilePaletteToolStripMenuItem.Checked = Orison.TilePaletteWindow.UserVisible;
        }

        private void editingGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditingGridVisible = !EditingGridVisible;
        }

        private void transparentLayersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TransparentLayers = !TransparentLayers;
        }

        private void centerViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LevelEditors[Orison.CurrentLevelIndex].LevelView.Center();
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LevelEditors[Orison.CurrentLevelIndex].LevelView.ZoomOut();
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LevelEditors[Orison.CurrentLevelIndex].LevelView.ZoomIn();
        }

        private void layersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Orison.LayersWindow.EditorVisible)
            {
                Orison.LayersWindow.UserVisible = !Orison.LayersWindow.UserVisible;
                FocusEditor();
            }
        }

        private void toolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Orison.ToolsWindow.EditorVisible)
            {
                Orison.ToolsWindow.UserVisible = !Orison.ToolsWindow.UserVisible;
                FocusEditor();
            }
        }

        private void tilePaletteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Orison.TilePaletteWindow.EditorVisible)
            {
                Orison.TilePaletteWindow.UserVisible = !Orison.TilePaletteWindow.UserVisible;
                FocusEditor();
            }
        }

        private void entitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Orison.EntitiesWindow.EditorVisible)
            {
                Orison.EntitiesWindow.UserVisible = !Orison.EntitiesWindow.UserVisible;
                FocusEditor();
            }
        }

        private void entitySelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Orison.EntitySelectionWindow.EditorVisible)
            {
                Orison.EntitySelectionWindow.UserVisible = !Orison.EntitySelectionWindow.UserVisible;
                FocusEditor();
            }
        }

        #endregion

        #region Utilities Menu Events

        private void resaveLevelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form window = null;
            foreach (Form form in OwnedForms)
            {
                if (form is ResaveLevelsWindow)
                {
                    window = form;
                    break;
                }
            }

            if (window == null)
            {
                window = new ResaveLevelsWindow();
                window.Show(this);
            }

            window.Focus();
        }

        private void shiftRenamerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form window = null;
            foreach (Form form in OwnedForms)
            {
                if (form is ShiftRenameLevelsWindow)
                {
                    window = form;
                    break;
                }
            }

            if (window == null)
            {
                window = new ShiftRenameLevelsWindow();
                window.Show(this);
            }

            window.Focus();
        }

        private void swapRenamerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form window = null;
            foreach (Form form in OwnedForms)
            {
                if (form is SwapRenameLevelsWindow)
                {
                    window = form;
                    break;
                }
            }

            if (window == null)
            {
                window = new SwapRenameLevelsWindow();
                window.Show(this);
            }

            window.Focus();
        }

        #endregion

        #region Drag and Drop Events

        private void MainWindow_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void MainWindow_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (Orison.Project == null)
            {
                if (files.Length == 1 && Path.GetExtension(files[0]) == ".oep")
                    Orison.LoadProject(files[0]);
            }
            else
            {
                foreach (string file in files)
                    Orison.AddLevel(new Level(Orison.Project, file));
            }
        }

        #endregion

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
