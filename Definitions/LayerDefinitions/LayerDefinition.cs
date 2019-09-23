using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml.Serialization;
using System.Windows.Forms;
using OrisonEditor.LevelData.Layers;
using OrisonEditor.LevelData;

namespace OrisonEditor.Definitions.LayerDefinitions
{
    [XmlInclude(typeof(GridLayerDefinition))]
    [XmlInclude(typeof(TileLayerDefinition))]
    [XmlInclude(typeof(EntityLayerDefinition))]

    public abstract class LayerDefinition
    {
        static public readonly List<Type> LAYER_TYPES = new List<Type>(new Type[] { typeof(GridLayerDefinition), typeof(TileLayerDefinition), typeof(EntityLayerDefinition) });
        static public readonly List<string> LAYER_NAMES = new List<string>(new string[] { "Grid", "Tiles", "Entities" });

        [XmlIgnore]
        public string Image { get; protected set; }
        [XmlIgnore]
        public bool Visible;

        public string Name;
        public Size Grid;
        public PointF ScrollFactor;

        public LayerDefinition()
        {
            Image = "";
            Name = "";
            ScrollFactor = new PointF(1, 1); 
            Visible = true;
        }

        public override string ToString()
        {
            return Name + " - " + GetType().ToString();
        }

        public abstract UserControl GetEditor();
        public abstract Layer GetInstance(Level level);
        public abstract LayerDefinition Clone();

        #region Utilities

        public Point ConvertToGrid(Point p)
        {
            return new Point(p.X / Grid.Width, p.Y / Grid.Height);
        }

        public Rectangle ConvertToGrid(Rectangle r)
        {
            return new Rectangle(r.X / Grid.Width, r.Y / Grid.Height, r.Width / Grid.Width, r.Height / Grid.Height);
        }

        public Point SnapToGrid(Point p)
        {
            return new Point((p.X / Grid.Width) * Grid.Width, (p.Y / Grid.Height) * Grid.Height);
        }

        #endregion
    }
}
