using System.Xml.Serialization;
using OrisonEditor.LevelData.Layers;
using OrisonEditor.LevelEditors.LevelValueEditors;
using OrisonEditor.LevelEditors.ValueEditors;
using OrisonEditor.ProjectEditors.ValueDefinitionEditors;

namespace OrisonEditor.Definitions.ValueDefinitions
{
    [XmlRoot("string")]
    public class StringValueDefinition : ValueDefinition
    {
        [XmlAttribute]
        public string Default;
        [XmlAttribute]
        public int MaxChars;
        [XmlAttribute]
        public bool MultiLine;

        public StringValueDefinition()
            : base()
        {
            Default = "";
            MaxChars = -1;
            MultiLine = false;
        }

        public override System.Windows.Forms.UserControl GetEditor()
        {
            return new StringValueDefinitionEditor(this);
        }

        public override ValueEditor GetInstanceEditor(Value instance, int x, int y)
        {
            return new StringValueEditor(instance, x, y);
        }

        public override ValueEditor GetInstanceLevelEditor(Value instance, int x, int y)
        {
            return new LevelStringValueEditor(instance, x, y);
        }

        public override ValueDefinition Clone()
        {
            StringValueDefinition def = new StringValueDefinition();
            def.Name = Name;
            def.Default = Default;
            def.MaxChars = MaxChars;
            def.MultiLine = MultiLine;
            return def;
        }

        public override string GetDefault()
        {
            return Default;
        }

        public override string ToString()
        {
            return Name + " (string)";
        }
    }
}
