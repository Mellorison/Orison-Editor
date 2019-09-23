using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using OrisonEditor.Definitions.ValueDefinitions;
using OrisonEditor.Definitions.LayerDefinitions;
using OrisonEditor.Definitions;
using System.IO;
using OrisonEditor.LevelData.Layers;
using System.Xml;

namespace OrisonEditor
{
    static class OrisonParse
    {
        static public void Parse(ref int to, TextBox box)
        {
            try
            {
                to = Convert.ToInt32(box.Text);
            }
            catch
            {
                box.Text = to.ToString();
            }
        }

        static public void Parse(ref float to, TextBox box)
        {
            try
            {
                to = Convert.ToSingle(box.Text);
            }
            catch
            {
                box.Text = to.ToString();
            }
        }

        static public void Parse(ref PointF to, TextBox x, TextBox y)
        {
            try
            {
                to.X = Convert.ToSingle(x.Text);
            }
            catch
            {
                x.Text = to.X.ToString();
            }

            try
            {
                to.Y = Convert.ToSingle(y.Text);
            }
            catch
            {
                y.Text = to.Y.ToString();
            }
        }

        static public void Parse(ref Size to, TextBox x, TextBox y)
        {
            try
            {
                to.Width = Convert.ToInt32(x.Text);
            }
            catch
            {
                x.Text = to.Width.ToString();
            }

            try
            {
                to.Height = Convert.ToInt32(y.Text);
            }
            catch
            {
                y.Text = to.Height.ToString();
            }
        }

        static public void Parse(ref Point to, TextBox x, TextBox y)
        {
            try
            {
                to.X = Convert.ToInt32(x.Text);
            }
            catch
            {
                x.Text = to.X.ToString();
            }

            try
            {
                to.Y = Convert.ToInt32(y.Text);
            }
            catch
            {
                y.Text = to.Y.ToString();
            }
        }

        static public void Parse(ref Rectangle to, TextBox x, TextBox y, TextBox w, TextBox h)
        {
            try
            {
                to.X = Convert.ToInt32(x.Text);
            }
            catch
            {
                x.Text = to.X.ToString();
            }

            try
            {
                to.Y = Convert.ToInt32(y.Text);
            }
            catch
            {
                y.Text = to.Y.ToString();
            }

            try
            {
                to.Width = Convert.ToInt32(w.Text);
            }
            catch
            {
                w.Text = to.Width.ToString();
            }

            try
            {
                to.Height = Convert.ToInt32(h.Text);
            }
            catch
            {
                h.Text = to.Height.ToString();
            }
        }

        static public void Parse(ref OrisonColor to, TextBox box)
        {
            try
            {
                to = new OrisonColor(box.Text);
            }
            catch
            {
                box.Text = to.ToString();
            }
        }

        static public void ParseIntToString(ref string to, int min, int max, TextBox box)
        {
            try
            {
                int i = Convert.ToInt32(box.Text);
                i = Math.Max(min, i);
                i = Math.Min(max, i);
                box.Text = to = i.ToString();
            }
            catch
            {
                box.Text = to;
            }
        }

        static public void ParseFloatToString(ref string to, float min, float max, float inc, TextBox box)
        {
            try
            {
                float i = Convert.ToSingle(box.Text);
                i = Math.Max(min, i);
                i = Math.Min(max, i);
                i = (float)Math.Round((decimal)(i / inc), MidpointRounding.AwayFromZero) * inc;
                box.Text = to = i.ToString();
            }
            catch
            {
                box.Text = to;
            }
        }

        static public void ParseString(ref string to, int maxChars, TextBox box)
        {
            if (maxChars > 0)
                to = box.Text.Substring(0, Math.Min(maxChars, box.Text.Length));
            else
                to = box.Text;
            box.Text = to;
        }

        /*
         *  XML reading/writing
         */
        static public void ImportValues(List<Value> values, XmlElement xml)
        {
            foreach (XmlAttribute a in xml.Attributes)
            {
                Value v = values.Find(val => val.Definition.Name == a.Name);
                if (v != null)
                    v.Content = a.InnerText;
            }
        }

        /*
         *  Error checking
         */
        static public string Error(string error)
        {
            return "-" + error + "\n";
        }

        static public string CheckDefinitionList(List<ValueDefinition> defs, string container)
        {
            string s = "";

            //Check for duplicate value names
            List<string> found = new List<string>();
            foreach (ValueDefinition v in defs)
            {
                if (v.Name != "" && !found.Contains(v.Name) && defs.FindAll(e => e.Name == v.Name).Count > 1)
                {
                    s += OrisonParse.Error(container + " contains multiple values with the name \"" + v.Name + "\"");
                    found.Add(v.Name);
                }
            }

            //Check for blank value names
            if (defs.Find(e => e.Name == "") != null)
                s += OrisonParse.Error(container + " contains value(s) with blank name");

            return s;
        }

        static public string CheckDefinitionList(List<LayerDefinition> defs)
        {
            string s = "";

            //Check for duplicate value names
            List<string> found = new List<string>();
            foreach (LayerDefinition v in defs)
            {
                if (v.Name != "" && !found.Contains(v.Name) && defs.FindAll(e => e.Name == v.Name).Count > 1)
                {
                    s += OrisonParse.Error("There are multiple layers with the name \"" + v.Name + "\"");
                    found.Add(v.Name);
                }
            }

            //Check for blank value names
            if (defs.Find(e => e.Name == "") != null)
                s += OrisonParse.Error("There are layer(s) with blank name");

            return s;
        }

        static public string CheckDefinitionList(List<Tileset> defs)
        {
            string s = "";

            //Check for duplicate value names
            List<string> found = new List<string>();
            foreach (Tileset v in defs)
            {
                if (v.Name != "" && !found.Contains(v.Name) && defs.FindAll(e => e.Name == v.Name).Count > 1)
                {
                    s += OrisonParse.Error("There are multiple tilesets with the name \"" + v.Name + "\"");
                    found.Add(v.Name);
                }
            }

            //Check for blank value names
            if (defs.Find(e => e.Name == "") != null)
                s += OrisonParse.Error("There are one or more tilesets with blank name");

            return s;
        }

        static public string CheckDefinitionList(List<EntityDefinition> defs)
        {
            string s = "";

            //Check for duplicate value names
            List<string> found = new List<string>();
            foreach (EntityDefinition v in defs)
            {
                if (v.Name != "" && !found.Contains(v.Name) && defs.FindAll(e => e.Name == v.Name).Count > 1)
                {
                    s += OrisonParse.Error("There are multiple entities with the name \"" + v.Name + "\"");
                    found.Add(v.Name);
                }
            }

            //Check for blank value names
            if (defs.Find(e => e.Name == "") != null)
                s += OrisonParse.Error("There are one or more entities with blank names");

            return s;
        }

        static public string CheckPath(string relPath, string absPath, string name)
        {
            if (!File.Exists(Path.Combine(absPath, relPath)))
                return Error(name + " does not exist");
            else
                return "";
        }

        static public string CheckNonblankString(string s, string name)
        {
            if (s != "")
                return "";
            else
                return Error(name + " is blank");
        }

        static public string CheckPosInt(int i, string name)
        {
            if (i > 0)
                return "";
            else
                return Error(name + " is not a positive integer");
        }

        static public string CheckPosSize(Size size, string name)
        {
            string s = "";
            s += CheckPosInt(size.Width, name + " Width");
            s += CheckPosInt(size.Height, name + " Height");
            return s;
        }

        static public string CheckEntityValues(EntityDefinition entity, List<ValueDefinition> list)
        {
            string s = "";

            foreach (var v in list)
            {
                switch (v.Name)
                {
                    default:
                        break;
                    case "x":
                    case "y":
                    case "id":
                    case "width":
                    case "height":
                    case "angle": 
                        s += Error("Entity \"" + entity.Name + "\" contains a value with the invalid name \"" + v.Name + "\" (reserved word in entities)");
                        break;
                }
            }

            return s;
        }

        static public string CheckLevelValues(List<ValueDefinition> list)
        {
            string s = "";

            foreach (var v in list)
            {
                switch (v.Name)
                {
                    default:
                        break;
                    case "width":
                    case "height":
                        s += Error("Level contains a value with the invalid name \"" + v.Name + "\" (reserved word in levels)");
                        break;
                }
            }

            return s;
        }
    }
}
