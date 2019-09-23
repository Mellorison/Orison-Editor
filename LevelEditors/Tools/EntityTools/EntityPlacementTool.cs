using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.LevelData.Layers;
using OrisonEditor.LevelEditors.Actions.EntityActions;

namespace OrisonEditor.LevelEditors.Tools.EntityTools
{
    public class EntityPlacementTool : EntityTool
    {
        public EntityPlacementTool()
            : base("Create", "pencil.png")
        {

        }

        public override void Draw(System.Drawing.Graphics graphics)
        {
            if (Orison.EntitiesWindow.CurrentEntity != null && LevelEditor.Focused)
                Orison.EntitiesWindow.CurrentEntity.Draw(graphics, Util.Ctrl ? LevelEditor.MousePosition : LayerEditor.MouseSnapPosition, 0, DrawUtil.AlphaMode.Half);
        }

        public override void OnMouseLeftClick(System.Drawing.Point location)
        {
            if (Orison.EntitiesWindow.CurrentEntity != null)
                LevelEditor.Perform(new EntityAddAction(LayerEditor.Layer, new Entity(LayerEditor.Layer, Orison.EntitiesWindow.CurrentEntity, Util.Ctrl ? LevelEditor.MousePosition : LayerEditor.MouseSnapPosition)));
        }
    }
}
