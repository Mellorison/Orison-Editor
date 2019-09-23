using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using OrisonEditor.Clipboard;
using OrisonEditor.Definitions;
using OrisonEditor.Definitions.LayerDefinitions;
using OrisonEditor.LevelData;
using OrisonEditor.LevelEditors.Tools;
using OrisonEditor.ProjectEditors;
using OrisonEditor.Windows;
using System.Diagnostics;

namespace OrisonEditor
{
    static public class Orison
    {
        public const string PROJECT_EXT = ".oep";
        public const string LEVEL_EXT = ".oel";
        public const string PROJECT_FILTER = "Orison Editor Project File|*" + PROJECT_EXT;
        public const string LEVEL_FILTER = "Orison Editor Level File|*" + LEVEL_EXT;
        public const string NEW_PROJECT_NAME = "New Project";
        public const string NEW_LEVEL_NAME = "Unsaved Level";
        public const string IMAGE_FILE_FILTER = "PNG image file|*.png|BMP image file|*.bmp";
        private const int RECENT_PROJECT_LIMIT = 10;

        public enum FinishProjectEditAction { None, CloseProject, SaveProject, LoadAndSaveProject };
        public enum ProjectEditMode { NormalEdit, NewProject, ErrorOnLoad };

        public delegate void ProjectCallback(Project project);
        public delegate void LevelCallback(int index);
        public delegate void LayerCallback(LayerDefinition layerDefinition, int index);
        public delegate void ToolCallback(Tool tool);
        public delegate void EntityCallback(EntityDefinition objectDefinition);

        static public MainWindow MainWindow { get; private set; }
        static public ToolsWindow ToolsWindow { get; private set; }
        static public LayersWindow LayersWindow { get; private set; }
        static public TilePaletteWindow TilePaletteWindow { get; private set; }
        static public EntitiesWindow EntitiesWindow { get; private set; }
        static public EntitySelectionWindow EntitySelectionWindow { get; private set; }

        static private string toLoad;
        static public string ProgramDirectory { get; private set; }
        static public Project Project { get; private set; }
        static public List<Level> Levels { get; private set; }
        static public int CurrentLevelIndex { get; private set; }
        static public ClipboardItem Clipboard;

        static public event ProjectCallback OnProjectStart;
        static public event ProjectCallback OnProjectClose;
        static public event ProjectCallback OnProjectEdited;
        static public event LevelCallback OnLevelAdded;
        static public event LevelCallback OnLevelClosed;
        static public event LevelCallback OnLevelChanged;        

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            initialize();

            if (args.Length > 0 && File.Exists(args[0]) && Path.GetExtension(args[0]) == ".oep")
                toLoad = args[0];
            else
                toLoad = "";

            Application.Run(MainWindow);
        }

        static private void initialize()
        {
            //Figure out the program directory
            ProgramDirectory = Application.ExecutablePath.Remove(Application.ExecutablePath.IndexOf(Path.GetFileName(Application.ExecutablePath)));

            //Initialize global pens/brushes/bitmaps
            DrawUtil.Initialize();

            //Make sure the recent project list is valid
            InitRecentProjects();

            //The levels holder
            Levels = new List<Level>();
            CurrentLevelIndex = -1;

            //The windows
            MainWindow = new MainWindow();
            MainWindow.Shown += new EventHandler(MainWindow_Shown);
            LayersWindow = new LayersWindow();
            ToolsWindow = new ToolsWindow();
            TilePaletteWindow = new TilePaletteWindow();
            EntitiesWindow = new EntitiesWindow();
            EntitySelectionWindow = new EntitySelectionWindow();

            LayersWindow.Show(MainWindow);
            ToolsWindow.Show(MainWindow);
            TilePaletteWindow.Show(MainWindow);
            EntitiesWindow.Show(MainWindow);
            EntitySelectionWindow.Show(MainWindow);
            LayersWindow.EditorVisible = ToolsWindow.EditorVisible = TilePaletteWindow.EditorVisible = EntitiesWindow.EditorVisible = EntitySelectionWindow.EditorVisible = false;

            //Add the exit event
            Application.ApplicationExit += onApplicationExit;
        }

        static void MainWindow_Shown(object sender, EventArgs e)
        {
            if (toLoad != "")
            {
                LoadProject(toLoad);
                toLoad = "";
            }
        }

        static void onApplicationExit(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        static public void LogException(Exception e)
        {
            string logPath = Path.Combine(Orison.ProgramDirectory, "errorLog.txt");

            FileStream file = new FileStream(logPath, FileMode.Append);
            StreamWriter logStream = new StreamWriter(file);
            logStream.Write(e.ToString() + "\r\n\r\n===============================\r\n\r\n");
            logStream.Close();
            file.Close();
        }

        #region Project Handlers

        static public void NewProject()
        {
            Project = new Project();
            Project.InitDefault();
            if (Project.SaveAs())
            {
                StartProject(Project);
                EditProject(ProjectEditMode.NewProject);
            }
        }

        static public void LoadProject()
        {
            //Get the file to load from the user
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = PROJECT_FILTER;
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;

            LoadProject(dialog.FileName);
        }

        static public void LoadProject(string filename)
        {
            if (!File.Exists(filename))
            {
                MessageBox.Show(MainWindow, "Project file could not be loaded because it does not exist!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Close the current project before loading the new one
            if (Project != null)
                CloseProject();

            //Load it
            XmlSerializer xs = new XmlSerializer(typeof(Project));
            Stream s = new FileStream(filename, FileMode.Open);
            Project = (Project)xs.Deserialize(s);
            s.Close();
            Project.Filename = filename;

            //Error check
            string errors = Project.ErrorCheck();
            if (errors == "")
                FinishProjectEdit(FinishProjectEditAction.LoadAndSaveProject);
            else
            {
                MessageBox.Show(MainWindow, "Project could not be loaded because of the following errors:\n" + errors + "\nFix the errors to continue with loading.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EditProject(ProjectEditMode.ErrorOnLoad);
            }
        }

        static public void StartProject(Project project)
        {
            Orison.MainWindow.RemoveStartPage();

            Project = project;

            //Load the images
            Project.LoadContent();

            //Call the added event
            if (OnProjectStart != null)
                OnProjectStart(project);
        }

        static public void CloseProject()
        {
            //Close all the open levels
            CloseAllLevels();

            //Set the status message
            Orison.MainWindow.StatusText = "Closed project " + Orison.Project.Name;

            //Call closed event
            if (OnProjectClose != null)
                OnProjectClose(Project);

            //Remove it!
            Project = null;

            //Tool and layer selection can be cleared now
            LayersWindow.SetLayer(-1);
            ToolsWindow.ClearTool();

            //Force a garbage collection
            Orison.MainWindow.AddStartPage();
            System.GC.Collect();
        }

        static public void EditProject(ProjectEditMode editMode)
        {
            //Warn!
            if (Orison.Levels.Count > 0 && Orison.Levels.Find(e => e.Changed) != null)
            {
                if (MessageBox.Show(MainWindow, "Warning: All levels must be closed if any changes to the project are made. You have unsaved changes in some open levels which will be lost. Still edit the project?", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.OK)
                    return;
            }

            //Disable the main window
            MainWindow.DisableEditing();

            //Show the project editor
            ProjectEditor editor = new ProjectEditor(Project, editMode);
            editor.Show(MainWindow);
        }

        static public void FinishProjectEdit(FinishProjectEditAction action = FinishProjectEditAction.None)
        {
            //Re-activate the main window
            MainWindow.EnableEditing();

            if (action == FinishProjectEditAction.CloseProject)
                CloseProject();
            else if (action == FinishProjectEditAction.SaveProject)
            {
                //Close all the levels
                CloseAllLevels();

                //Save the project
                Project.Save();
                Project.LoadContent();

                //Call the event
                if (OnProjectEdited != null)
                    OnProjectEdited(Project);

                //Start a blank level
                NewLevel();

                //Set the layer
                Orison.LayersWindow.SetLayer(0);

                //Set the status message
                Orison.MainWindow.StatusText = "Edited project " + Orison.Project.Name + ", all levels closed";
                UpdateRecentProjects(Project);
                GC.Collect();
            }
            else if (action == FinishProjectEditAction.LoadAndSaveProject)
            {
                //Start the project and save it
                StartProject(Project);
                Project.Save(); 

                //Start a blank level and start at the first layer
                LayersWindow.SetLayer(0);
                NewLevel();

                Orison.MainWindow.StatusText = "Opened project " + Orison.Project.Name;
                UpdateRecentProjects(Project);
                GC.Collect();
            }
        }

        #endregion

        #region Level Handlers

        static public Level CurrentLevel
        {
            get
            {
                if (CurrentLevelIndex == -1)
                    return null;
                else
                    return Levels[CurrentLevelIndex];
            }
        }

        static public void SetLevel(int index)
        {
            //Can't set to what is already the current level
            if (index == CurrentLevelIndex)
                return;

            //Make it current
            CurrentLevelIndex = index;

            //Call the event
            if (OnLevelChanged != null)
                OnLevelChanged(index);
        }
        
        static public Level GetLevelByPath(string path)
        {
            return Levels.Find(e => e.SavePath == path);
        }

        static public void NewLevel()
        {
            AddLevel(new Level(Project, ""));
            SetLevel(Levels.Count - 1);
        }

        static public void OpenLevel()
        {
            //Get the file to load from the user
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.Filter = Orison.LEVEL_FILTER;
            dialog.InitialDirectory = Orison.Project.SavedDirectory;
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;

            //If the only open level is an empty one, close it
            if (Orison.Levels.Count == 1 && Orison.Levels[0].IsEmpty)
                Orison.CloseLevel(Orison.Levels[0], false);

            //Get all the selected files, and alphabetize the list
            List<string> filenames = new List<string>(dialog.FileNames);
        
            if (filenames.All((s) => { int i; return int.TryParse(Path.GetFileNameWithoutExtension(s), out i); }))
                filenames.Sort((a, b) => { return Convert.ToInt32(Path.GetFileNameWithoutExtension(a)) - Convert.ToInt32(Path.GetFileNameWithoutExtension(b)); });
            else
                filenames.Sort();

            //Load all the levels in the selected list, as long as they aren't already open
            foreach (string f in filenames)
            {
                int levelID = -1;
                for (int i = 0; i < Orison.Levels.Count; i++)
                {
                    if (Orison.Levels[i].SavePath == f)
                    {
                        levelID = i;
                        break;
                    }
                }

                if (levelID == -1)
                {
                    Level level = new Level(Project, f);

                    //If it's salvaged...
                    if (level.Salvaged)
                    {
                        DialogResult result = MessageBox.Show("The selected level is inconsistent with the current project and has been automatically modified to make it loadable. Would you like to save this modified version under a different name before continuing?",
                        "Salvaged Level", MessageBoxButtons.YesNoCancel);

                        switch (result)
                        {
                            case DialogResult.Yes:
                                level.SaveAs();
                                break;

                            case DialogResult.Cancel:
                                continue;
                        }                        
                    }

                    //Init the level editor
                    AddLevel(level);
                    SetLevel(Levels.Count - 1);
                }
                else
                    SetLevel(levelID);
            }

            //Set the status message
            string[] files = new string[dialog.FileNames.Length];
            for (int i = 0; i < dialog.FileNames.Length; i++)
                files[i] = Path.GetFileName(dialog.FileNames[i]);
            Orison.MainWindow.StatusText = "Opened level(s) " + String.Join(", ", files);
        }

        static public bool AddLevel(Level level)
        {
            //Can't if past level limit
            if (Orison.Levels.Count >= Properties.Settings.Default.LevelLimit)
            {
                MessageBox.Show(Orison.MainWindow, "Couldn't add level because the level limit was exceeded! You can change the level limit in the Preferences menu.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //Add it
            Levels.Add(level);

            //Call the event
            if (OnLevelAdded != null)
                OnLevelAdded(Levels.Count - 1);

            return true;
        }

        static public bool CloseLevel(Level level, bool askToSave)
        {
            //If it's changed, ask to save it
            if (askToSave && level.Changed)
            {
                DialogResult result = MessageBox.Show(MainWindow, "Save changes to \"" + level.SaveName + "\" before closing it?", "Unsaved Changes!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Cancel)
                    return false;
                else if (result == DialogResult.Yes)
                    return level.Save();
            }

            //Remove it
            int index = Levels.IndexOf(level);
            Levels.Remove(level);

            //Call the event
            if (OnLevelClosed != null)
                OnLevelClosed(index);

            //Set the current level to another one if that was the current one
            if (CurrentLevelIndex == index)
                SetLevel(Math.Min(index, Levels.Count - 1));
            else if (CurrentLevelIndex > index)
                CurrentLevelIndex--;

            //Force a garbage collection
            System.GC.Collect();

            //Set the status text
            Orison.MainWindow.StatusText = "Closed level " + level.SaveName;

            return true;
        }

        static public void CloseAllLevels()
        {
            while (Levels.Count > 0)
                CloseLevel(Levels[0], false);

            Orison.MainWindow.StatusText = "Closed all levels";
        }

        static public void CloseOtherLevels(Level level)
        {
            List<Level> temp = new List<Level>(Levels);
            foreach (Level lev in temp)
            {
                if (lev != level)
                {
                    if (!CloseLevel(lev, true))
                        return;
                }
            }
        }

        static public bool CloseLevelsByFilepaths(IEnumerable<string> filepaths)
        {
            foreach (var f in filepaths)
            {
                Level level = Orison.GetLevelByFilepath(f);
                if (level != null)
                    if (!Orison.CloseLevel(level, true))
                        return false;
            }
            return true;
        }

        static public bool CloseLevelByFilepath(string filepath)
        {
            Level level = GetLevelByFilepath(filepath);
            if (level != null)
                return Orison.CloseLevel(level, true);
            return true;
        }

        static public Level GetLevelByFilepath(string filepath)
        {
            filepath = filepath.Replace('/', '\\');
            foreach (Level level in Levels)
            {
                if (level.HasBeenSaved && level.SavePath == filepath)
                    return level;
            }
            return null;
        }

        #endregion

        #region Recent Project List

        static public void InitRecentProjects()
        {
            if (Properties.Settings.Default.RecentProjects == null || Properties.Settings.Default.RecentProjectNames == null || Properties.Settings.Default.RecentProjects.Count != Properties.Settings.Default.RecentProjectNames.Count)
            {
                Properties.Settings.Default.RecentProjects = new System.Collections.Specialized.StringCollection();
                Properties.Settings.Default.RecentProjectNames = new System.Collections.Specialized.StringCollection();
                Properties.Settings.Default.Save();
            }
        }

        static public void ClearRecentProjects()
        {
            Properties.Settings.Default.RecentProjects.Clear();
            Properties.Settings.Default.RecentProjectNames.Clear();
        }

        static public void CheckRecentProjects()
        {
            for (int i = 0; i < Properties.Settings.Default.RecentProjects.Count; i++)
            {
                if (!File.Exists(Properties.Settings.Default.RecentProjects[i]))
                {
                    Properties.Settings.Default.RecentProjects.RemoveAt(i);
                    Properties.Settings.Default.RecentProjectNames.RemoveAt(i);
                    i--;
                }
            }
        }

        static public void UpdateRecentProjects(Project project)
        {
            for (int i = 0; i < Properties.Settings.Default.RecentProjects.Count; i++)
            {
                if (Properties.Settings.Default.RecentProjects[i] == project.Filename)
                {
                    Properties.Settings.Default.RecentProjects.RemoveAt(i);
                    Properties.Settings.Default.RecentProjectNames.RemoveAt(i);
                    break;
                }
            }

            Properties.Settings.Default.RecentProjects.Insert(0, project.Filename);
            Properties.Settings.Default.RecentProjectNames.Insert(0, project.Name);
            if (Properties.Settings.Default.RecentProjects.Count > RECENT_PROJECT_LIMIT)
            {
                Properties.Settings.Default.RecentProjects.RemoveAt(RECENT_PROJECT_LIMIT);
                Properties.Settings.Default.RecentProjectNames.RemoveAt(RECENT_PROJECT_LIMIT);
            }
        }

        #endregion

        #region Web Links

        static public void DonationLink()
        {
            System.Diagnostics.Process.Start("http://www.danieltumelo.teammakkon.com/");
        }

        static public void WebsiteLink()
        {
            System.Diagnostics.Process.Start("http://www.danieltumelo.teammakkon.com/");
        }

        #endregion
    }
}
