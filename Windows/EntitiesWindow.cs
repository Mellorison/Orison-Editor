using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OrisonEditor.Definitions;
using OrisonEditor.Definitions.LayerDefinitions;
using System.Diagnostics;
using OrisonEditor.LevelData.Layers;

namespace OrisonEditor.Windows
{
    public partial class EntitiesWindow : OrisonWindow
    {
        public EntityDefinition CurrentEntity { get; private set; }
        public event Orison.EntityCallback OnEntityChanged;

        public EntitiesWindow()
            : base(HorizontalSnap.Left, VerticalSnap.Bottom)
        {
            Name = "EntitiesWindow";
            Text = "Entities";
            CurrentEntity = null;

            FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            AutoScroll = true;
            HorizontalScroll.Enabled = false;

            //Events
            Orison.OnProjectStart += InitFromProject;
            Orison.OnProjectEdited += InitFromProject;
            Orison.LayersWindow.OnLayerChanged += onLayerChanged;
        }

        public override bool ShouldBeVisible()
        {
            return Orison.LayersWindow.CurrentLayer is EntityLayer;
        }

        public void SetObject(EntityDefinition def)
        {
            if (CurrentEntity == def)
                return;

            CurrentEntity = def;

            //Call the event
            if (OnEntityChanged != null)
                OnEntityChanged(def);
        }

        private void InitFromProject(Project project)
        {
            ClientSize = new Size(148, 220);
            MaximumSize = new Size(Size.Width, 1000);
            MinimumSize = new Size(Size.Width, 80);

            foreach (EntityButton b in Controls)
                b.OnRemove();
            Controls.Clear();
            for (int i = 0; i < project.EntityDefinitions.Count; i++)
                Controls.Add(new EntityButton(project.EntityDefinitions[i], 0, 1 + i * 25));

            SetObject(null);
        }

        /*
         *  Events
         */
        private void onLayerChanged(LayerDefinition def, int index)
        {
            EditorVisible = def is EntityLayerDefinition;
        }
    }
}
