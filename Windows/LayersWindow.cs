using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OrisonEditor.LevelData.Layers;
using System.Diagnostics;

namespace OrisonEditor.Windows
{
    public partial class LayersWindow : OrisonWindow
    {
        public int CurrentLayerIndex { get; private set; }
        public event Orison.LayerCallback OnLayerChanged;

        public LayersWindow()
            : base(HorizontalSnap.Left, VerticalSnap.Top)
        {
            Name = "LayersWindow";
            Text = "Layers";
            CurrentLayerIndex = -1;

            //Events
            Orison.OnProjectStart += initFromProject;
            Orison.OnProjectEdited += initFromProject;
        }

        public override bool ShouldBeVisible()
        {
            return Orison.Project.LayerDefinitions.Count > 1;
        }

        protected override void handleKeyDown(KeyEventArgs e)
        {
            if (e.Control && e.KeyCode >= Keys.D1 && e.KeyCode <= Keys.D9)
            {
                int i = (int)e.KeyCode - (int)Keys.D1;
                if (i < Orison.Project.LayerDefinitions.Count)
                    SetLayer(i);
            }
        }

        public Layer CurrentLayer
        {
            get
            {
                if (Orison.CurrentLevel == null || CurrentLayerIndex == -1)
                    return null;
                else
                    return Orison.CurrentLevel.Layers[CurrentLayerIndex];
            }
        }

        public void SetLayer(int index)
        {
            //Can't set to what is already the current layer
            if (index == CurrentLayerIndex)
                return;

            //Make it current
            CurrentLayerIndex = index;

            //Call the event
            if (OnLayerChanged != null)
                OnLayerChanged(index == -1 ? null : Orison.Project.LayerDefinitions[index], index);
        }

        private void initFromProject(Project project)
        {
            ClientSize = new Size(120, project.LayerDefinitions.Count * 24);

            foreach (LayerButton b in Controls)
                b.OnRemove();
            Controls.Clear();
            for (int i = 0; i < project.LayerDefinitions.Count; i++)
                Controls.Add(new LayerButton(project.LayerDefinitions[i], (project.LayerDefinitions.Count - i - 1) * 24));

            CurrentLayerIndex = -1;
        }
    }
}
