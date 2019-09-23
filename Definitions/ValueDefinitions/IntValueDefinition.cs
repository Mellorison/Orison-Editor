using System.Windows.Forms;
using System.Xml.Serialization;
using OrisonEditor.LevelData.Layers;
using OrisonEditor.LevelEditors.LevelValueEditors;
using OrisonEditor.LevelEditors.ValueEditors;
using OrisonEditor.ProjectEditors.ValueDefinitionEditors;

namespace OrisonEditor.Definitions.ValueDefinitions
{
    [XmlRoot("int")]
    public class IntValueDefinition : ValueDefinition
    {
        [XmlAttribute]
        public int Default;
        [XmlAttribute]
        public int Min;
        [XmlAttribute]
        public int Max;
        [XmlAttribute]
        public bool ShowSlider;

        public IntValueDefinition()
            : base()
        {
            Default = 0;
            Min = 0;
            Max = 100;
            ShowSlider = false;
        }

        public override UserControl GetEditor()
        {
            return new IntValueDefinitionEditor(this);
        }

        public override ValueEditor GetInstanceEditor(Value instance, int x, int y)
        {
            return new IntValueEditor(instance, x, y);
        }

        public override ValueEditor GetInstanceLevelEditor(Value instance, int x, int y)
        {
            return new LevelIntValueEditor(instance, x, y);
        }

        public override ValueDefinition Clone()
        {
            IntValueDefinition def = new IntValueDefinition();
            def.Name = Name;
            def.Default = Default;
            def.Min = Min;
            def.Max = Max;
            def.ShowSlider = ShowSlider;
            return def;
        }

        public override string GetDefault()
        {
            return Default.ToString();
        }

        public override string ToString()
        {
            return Name + " (int)";
        }
    }
}
