using OrisonEditor.LevelData.Layers;
using OrisonEditor.LevelEditors.LevelValueEditors;
using OrisonEditor.LevelEditors.ValueEditors;
using OrisonEditor.ProjectEditors.ValueDefinitionEditors;

namespace OrisonEditor.Definitions.ValueDefinitions
{
    public class ColorValueDefinition : ValueDefinition
    {
        public OrisonColor Default;

        public ColorValueDefinition()
            : base()
        {
            Default = new OrisonColor(255, 255, 255);
        }

        public override System.Windows.Forms.UserControl GetEditor()
        {
            return new ColorValueDefinitionEditor(this);
        }

        public override ValueEditor GetInstanceEditor(Value instance, int x, int y)
        {
            return new ColorValueEditor(instance, x, y);
        }

        public override ValueEditor GetInstanceLevelEditor(Value instance, int x, int y)
        {
            return new LevelColorValueEditor(instance, x, y);
        }

        public override ValueDefinition Clone()
        {
            ColorValueDefinition def = new ColorValueDefinition();
            def.Name = Name;
            def.Default = Default;
            return def;
        }

        public override string GetDefault()
        {
            return Default.ToString();
        }

        public override string ToString()
        {
            return Name + " (color)";
        }
    }
}
