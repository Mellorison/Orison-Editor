using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.LevelData.Layers;
using System.Windows.Forms;
using OrisonEditor.LevelEditors.LayerEditors;

namespace OrisonEditor.LevelEditors.Tools.EntityTools
{
    public abstract class EntityTool : Tool
    {
        public EntityTool(string name, string image)
            : base(name, image)
        {

        }

        public EntityLayerEditor LayerEditor
        {
            get { return (EntityLayerEditor)LevelEditor.LayerEditors[Orison.LayersWindow.CurrentLayerIndex]; }
        }
    }
}
