using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Drawing;
using OrisonEditor.LevelData.Layers;
using OrisonEditor.LevelEditors;

namespace OrisonEditor.LevelData
{
    public class Level
    {
        //Running instance variables
        public Project Project { get; private set; }
        public string SavePath;
        private bool changed;
        public bool Salvaged { get; private set; }

        //Actual parameters to be edited/exported
        public Size Size;
        public List<Layer> Layers { get; private set; }
        public List<Value> Values { get; private set; }
        public Point CameraPosition;

        public Level(Project project, string filename)
        {
            this.Project = project;

            if (File.Exists(filename))
            {
                //Load the level from XML
                XmlDocument doc = new XmlDocument();
                FileStream stream = new FileStream(filename, FileMode.Open);
                doc.Load(stream);
                stream.Close();

                LoadFromXML(doc);
                SavePath = filename;
            }
            else
            {
                //Initialize size
                Size = Project.LevelDefaultSize;

                //Initialize layers
                Layers = new List<Layer>();
                foreach (var def in Project.LayerDefinitions)
                    Layers.Add(def.GetInstance(this));

                //Initialize values
                if (Project.LevelValueDefinitions.Count > 0)
                {
                    Values = new List<Value>();
                    foreach (var def in Project.LevelValueDefinitions)
                        Values.Add(new Value(def));
                }

                SavePath = "";
            }

            changed = false;
        }

        public Level(Project project, XmlDocument xml)
        {
            this.Project = project;
            initialize();

            LoadFromXML(xml);
            SavePath = "";
            changed = false;
        }

        public Level(Level level)
            : this(level.Project, level.GenerateXML())
        {

        }

        public void CloneFrom(Level level)
        {
            LoadFromXML(level.GenerateXML());
        }

        private void initialize()
        {
            
        }

        public bool Changed
        {
            get { return changed; }
            set
            {
                changed = value;
                int idx = Orison.Levels.FindIndex(l => l == this);
                if (idx >= 0) Orison.MainWindow.MasterTabControl.TabPages[idx].Text = Name;
            }
        }

        public string Name
        {
            get
            {
                string s;
                if (string.IsNullOrEmpty(SavePath))
                    s = Orison.NEW_LEVEL_NAME;
                else
                    s = Path.GetFileName(SavePath);
                if (Changed)
                    s += "*";
                return s;
            }
        }

        public string SaveName
        {
            get
            {
                string s;
                if (string.IsNullOrEmpty(SavePath))
                    s = Orison.NEW_LEVEL_NAME;
                else
                    s = Path.GetFileName(SavePath);
                return s;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return !HasBeenSaved && !Changed;
            }
        }

        public bool HasBeenSaved
        {
            get { return !string.IsNullOrEmpty(SavePath); }
        }

        public Rectangle Bounds
        {
            get { return new Rectangle(0, 0, Size.Width, Size.Height); }
        }

        public PointF Center
        {
            get { return new PointF(Size.Width / 2, Size.Height / 2); }
        }

        /*
         *  XML
         */
        public XmlDocument GenerateXML()
        {
            XmlDocument doc = new XmlDocument();
            XmlAttribute a;

            XmlElement level = doc.CreateElement("level");
            doc.AppendChild(level);

            //Export the size  
            {
                a = doc.CreateAttribute("width");
                a.InnerText = Size.Width.ToString();
                level.Attributes.Append(a);

                a = doc.CreateAttribute("height");
                a.InnerText = Size.Height.ToString();
                level.Attributes.Append(a);
            }

            //Export camera position
            if (Orison.Project.ExportCameraPosition)
            {
                XmlElement cam = doc.CreateElement("camera");

                a = doc.CreateAttribute("x");
                a.InnerText = CameraPosition.X.ToString();
                cam.Attributes.Append(a);

                a = doc.CreateAttribute("y");
                a.InnerText = CameraPosition.Y.ToString();
                cam.Attributes.Append(a);

                level.AppendChild(cam);
            }

            //Export the level values
            if (Values != null)
                foreach (var v in Values)
                    level.Attributes.Append(v.GetXML(doc));

            //Export the layers
            for (int i = 0; i < Layers.Count; i++)
                level.AppendChild(Layers[i].GetXML(doc));

            return doc;
        }

        private void LoadFromXML(XmlDocument xml)
        {
            bool cleanXML = true;
            XmlElement level = (XmlElement)xml.GetElementsByTagName("level")[0];

            {
                Size size = new Size();

                //Import the size               
                if (level.Attributes["width"] != null)
                    size.Width = Convert.ToInt32(level.Attributes["width"].InnerText);
                else
                    size.Width = Orison.Project.LevelDefaultSize.Width;
                if (level.Attributes["height"] != null)
                    size.Height = Convert.ToInt32(level.Attributes["height"].InnerText);
                else
                    size.Height = Orison.Project.LevelDefaultSize.Height;

                //Error check the width
                if (size.Width < Orison.Project.LevelMinimumSize.Width)
                {
                    size.Width = Orison.Project.LevelMinimumSize.Width;
                    cleanXML = false;
                }
                else if (size.Width > Orison.Project.LevelMaximumSize.Width)
                {
                    size.Width = Orison.Project.LevelMaximumSize.Width;
                    cleanXML = false;
                }

                //Error check the height
                if (size.Height < Orison.Project.LevelMinimumSize.Height)
                {
                    size.Height = Orison.Project.LevelMinimumSize.Height;
                    cleanXML = false;
                }
                else if (size.Height > Orison.Project.LevelMaximumSize.Height)
                {
                    size.Height = Orison.Project.LevelMaximumSize.Height;
                    cleanXML = false;
                }

                Size = size;
            }

            //Import the camera position
            if (level.GetElementsByTagName("camera").Count > 0)
            {
                XmlElement cam = (XmlElement)level.GetElementsByTagName("camera")[0];
                CameraPosition.X = Convert.ToInt32(cam.Attributes["x"].InnerText);
                CameraPosition.Y = Convert.ToInt32(cam.Attributes["y"].InnerText);
            }

            //Import the level values
            //Initialize values
            if (Project.LevelValueDefinitions.Count > 0)
            {
                Values = new List<Value>();
                foreach (var def in Project.LevelValueDefinitions)
                    Values.Add(new Value(def));
                OrisonParse.ImportValues(Values, level);
            }

            //Import layers
            Layers = new List<Layer>();
            for (int i = 0; i < Project.LayerDefinitions.Count; i++)
            {
                Layer layer = Project.LayerDefinitions[i].GetInstance(this);
                Layers.Add(layer);
                if (level[Project.LayerDefinitions[i].Name] != null)
                    cleanXML = (layer.SetXML(level[Project.LayerDefinitions[i].Name]) && cleanXML);
            }

            Salvaged = !cleanXML;
        }

        public void EditProperties()
        {
            Orison.MainWindow.DisableEditing();
            LevelProperties lp = new LevelProperties(this);
            lp.Show(Orison.MainWindow);
        }

        #region Saving

        public bool Save()
        {
            //If it hasn't been saved before, do SaveAs instead
            if (!HasBeenSaved)
                return SaveAs();

            WriteTo(SavePath);
            return true;
        }

        public bool SaveAs()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = Project.SavedDirectory;
            dialog.RestoreDirectory = true;
            dialog.FileName = SaveName;
            dialog.DefaultExt = Orison.LEVEL_EXT;
            dialog.OverwritePrompt = true;
            dialog.Filter = Orison.LEVEL_FILTER;

            //Handle cancel
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return false;

            SavePath = dialog.FileName;
            WriteTo(dialog.FileName);

            return true;
        }

        public void WriteTo(string filename)
        {
            //Generate the XML and write it!            
            XmlDocument doc = GenerateXML();
            doc.Save(filename);

            Changed = false;
        }

        #endregion
    }
}
