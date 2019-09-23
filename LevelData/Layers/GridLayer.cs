using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.Definitions.LayerDefinitions;
using System.Xml;
using OrisonEditor.LevelEditors.LayerEditors;
using System.Drawing;
using System.Diagnostics;
using OrisonEditor.LevelEditors.Resizers;

namespace OrisonEditor.LevelData.Layers
{
    public class GridLayer : Layer
    {
        public new GridLayerDefinition Definition { get; private set; }
        public bool[,] Grid;
        public GridSelection Selection;

        public GridLayer(Level level, GridLayerDefinition definition)
            : base(level, definition)
        {
            Definition = definition;

            int tileWidth = Level.Size.Width / definition.Grid.Width + (Level.Size.Width % definition.Grid.Width != 0 ? 1 : 0);
            int tileHeight = Level.Size.Height / definition.Grid.Height + (Level.Size.Height % definition.Grid.Height != 0 ? 1 : 0);
            Grid = new bool[tileWidth, tileHeight];
        }

        public override XmlElement GetXML(XmlDocument doc)
        {
            XmlElement xml = doc.CreateElement(Definition.Name);

            //Write the export mode
            XmlAttribute attr = doc.CreateAttribute("exportMode");
            attr.InnerText = Definition.ExportMode.ToString();
            xml.Attributes.Append(attr);

            switch (Definition.ExportMode)
            {
                case GridLayerDefinition.ExportModes.Bitstring:
                case GridLayerDefinition.ExportModes.TrimmedBitstring:
                    //Bitstring export
                    string[] rows = new string[Grid.GetLength(1)];
                    for (int i = 0; i < Grid.GetLength(1); i++)
                    {
                        rows[i] = "";
                        for (int j = 0; j < Grid.GetLength(0); j++)
                            rows[i] += Grid[j, i] ? "1" : "0";
                    }

                    if (Definition.ExportMode == GridLayerDefinition.ExportModes.TrimmedBitstring)
                    {
                        //Trim off trailing zeroes on rows and then trim trailing empty rows
                        for (int i = 0; i < rows.Length; i++)
                            rows[i] = rows[i].TrimEnd('0');

                        string s = string.Join("\n", rows, 0, rows.Length);
                        s = s.TrimEnd('\n');
                        xml.InnerText = s;
                    }
                    else
                        xml.InnerText = string.Join("\n", rows, 0, rows.Length);
                    break;

                case GridLayerDefinition.ExportModes.Rectangles:
                case GridLayerDefinition.ExportModes.GridRectangles:
                    //Rectangles export
                    bool[,] copy = (bool[,])Grid.Clone();
                    List<Rectangle> rects = new List<Rectangle>();

                    //Create the rectangles
                    Point p = getFirstCell(copy);
                    while (p.X != -1)
                    {
                        copy[p.X, p.Y] = false;
                        int w = 1;
                        int h = 1;

                        //Extend it to the right
                        while (p.X + w < copy.GetLength(0) && copy[p.X + w, p.Y])
                        {
                            copy[p.X + w, p.Y] = false;
                            w++;
                        }

                        //Extend it downward
                        while (p.Y + h < copy.GetLength(1))
                        {
                            bool done = false;
                            for (int i = p.X; i < p.X + w; i++)
                            {
                                if (!copy[i, p.Y + h])
                                {
                                    done = true;
                                    break;
                                }
                            }
                            if (done)
                                break;

                            for (int i = p.X; i < p.X + w; i++)
                                copy[i, p.Y + h] = false;
                            h++;
                        }

                        //Push the rectangle
                        Rectangle rect = new Rectangle(p.X, p.Y, w, h);
                        if (Definition.ExportMode == GridLayerDefinition.ExportModes.Rectangles)
                            rect = GridToLevel(rect);
                        rects.Add(rect);

                        p = getFirstCell(copy);
                    }

                    //Export them as tags
                    foreach (Rectangle r in rects)
                    {
                        XmlElement rx = doc.CreateElement("rect");
                        XmlAttribute a;

                        a = doc.CreateAttribute("x");
                        a.InnerText = r.X.ToString();
                        rx.Attributes.Append(a);

                        a = doc.CreateAttribute("y");
                        a.InnerText = r.Y.ToString();
                        rx.Attributes.Append(a);

                        a = doc.CreateAttribute("w");
                        a.InnerText = r.Width.ToString();
                        rx.Attributes.Append(a);

                        a = doc.CreateAttribute("h");
                        a.InnerText = r.Height.ToString();
                        rx.Attributes.Append(a);

                        xml.AppendChild(rx);
                    }
                    break;
            }

            return xml;
        }

        public override bool SetXML(XmlElement xml)
        {
            Grid.Initialize();

            bool cleanXML = true;

            //Get the export mode
            GridLayerDefinition.ExportModes exportMode;
            if (xml.Attributes["exportMode"] != null)
                exportMode = (GridLayerDefinition.ExportModes)Enum.Parse(typeof(GridLayerDefinition.ExportModes), xml.Attributes["exportMode"].InnerText);
            else
                exportMode = Definition.ExportMode;

            //Import the XML!
            switch (exportMode)
            {
                case GridLayerDefinition.ExportModes.Bitstring:
                case GridLayerDefinition.ExportModes.TrimmedBitstring:
                    //Bitstring import
                    string s = xml.InnerText;
                    int x = 0;
                    int y = 0;
                    for (int i = 0; i < s.Length; i++)
                    {
                        //If the grid is bigger than it should be, something has gone wrong with the XML
                        if (x >= Grid.GetLength(0) && s[i] != '\n')
                        {
                            cleanXML = false;
                            while (i < s.Length && s[i] != '\n')
                                i++;
                            x = 0;
                            y++;
                            continue;
                        }
                        else if (y >= Grid.GetLength(1))
                        {
                            cleanXML = false;
                            break;
                        }

                        if (s[i] == '1')
                            Grid[x, y] = true;

                        if (s[i] == '\n')
                        {
                            x = 0;
                            y++;
                        }
                        else
                            x++;
                    }
                    break;

                case GridLayerDefinition.ExportModes.Rectangles:
                case GridLayerDefinition.ExportModes.GridRectangles:
                    //Rectangles import
                    foreach (XmlElement r in xml.GetElementsByTagName("rect"))
                    {
                        Rectangle rect = new Rectangle(Convert.ToInt32(r.Attributes["x"].InnerText), Convert.ToInt32(r.Attributes["y"].InnerText), Convert.ToInt32(r.Attributes["w"].InnerText), Convert.ToInt32(r.Attributes["h"].InnerText));

                        if (exportMode == GridLayerDefinition.ExportModes.Rectangles)
                            rect = LevelToGrid(rect);

                        for (int i = 0; i < rect.Width; i++)
                        {
                            for (int j = 0; j < rect.Height; j++)
                            {
                                if (rect.X + i >= Grid.GetLength(0) || rect.Y + j >= Grid.GetLength(1))
                                {
                                    cleanXML = false;
                                    continue;
                                }

                                Grid[rect.X + i, rect.Y + j] = true;
                            }
                        }
                    }
                    break;
            }

            return cleanXML;
        }

        /*
         *  Helpers
         */
        private Point getFirstCell(bool[,] from)
        {
            for (int i = 0; i < from.GetLength(0); i++)
                for (int j = 0; j < from.GetLength(1); j++)
                    if (from[i, j])
                        return new Point(i, j);

            return new Point(-1, -1);
        }

        private Rectangle GridToLevel(Rectangle r)
        {
            return new Rectangle(r.X * Definition.Grid.Width, r.Y * Definition.Grid.Height, r.Width * Definition.Grid.Width, r.Height * Definition.Grid.Height);
        }

        private Rectangle LevelToGrid(Rectangle r)
        {
            return new Rectangle(r.X / Definition.Grid.Width, r.Y / Definition.Grid.Height, r.Width / Definition.Grid.Width, r.Height / Definition.Grid.Height); 
        }

        public override LayerEditor GetEditor(LevelEditors.LevelEditor editor)
        {
            return new GridLayerEditor(editor, this);
        }

        public Rectangle GetGridRectangle(Point start, Point end)
        {
            Rectangle r = new Rectangle();

            //Get the rectangle
            r.X = Math.Min(start.X, end.X);
            r.Y = Math.Min(start.Y, end.Y);
            r.Width = Math.Abs(end.X - start.X) + Definition.Grid.Width;
            r.Height = Math.Abs(end.Y - start.Y) + Definition.Grid.Height;

            //Enforce Bounds
            if (r.X < 0)
            {
                r.Width += r.X;
                r.X = 0;
            }

            if (r.Y < 0)
            {
                r.Height += r.Y;
                r.Y = 0;
            }

            int width = Grid.GetLength(0) * Definition.Grid.Width;
            int height = Grid.GetLength(1) * Definition.Grid.Height;

            if (r.X + r.Width > width)
                r.Width = width - r.X;

            if (r.Y + r.Height > height)
                r.Height = height - r.Y;

            return r;
        }

        public int GridCellsX
        {
            get { return Grid.GetLength(0); }
        }

        public int GridCellsY
        {
            get { return Grid.GetLength(1); }
        }
    }
}
