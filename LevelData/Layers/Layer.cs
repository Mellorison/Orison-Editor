using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.Definitions.LayerDefinitions;
using System.Xml;
using OrisonEditor.LevelEditors.LayerEditors;
using OrisonEditor.LevelEditors;
using System.Drawing;
using OrisonEditor.LevelEditors.Resizers;

namespace OrisonEditor.LevelData.Layers
{
    public abstract class Layer
    {
        public LayerDefinition Definition { get; private set; }
        public Level Level { get; private set; }

        public Layer(Level level, LayerDefinition definition)
        {
            Level = level;
            Definition = definition;
        }

        public abstract XmlElement GetXML(XmlDocument doc);
        public abstract bool SetXML(XmlElement xml);
        public abstract LayerEditor GetEditor(LevelEditor editor);
    }
}
