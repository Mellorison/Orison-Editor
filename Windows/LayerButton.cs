using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OrisonEditor.Definitions.LayerDefinitions;
using System.IO;
using System.Diagnostics;

namespace OrisonEditor.Windows
{
    public partial class LayerButton : UserControl
    {
        static private readonly OrisonColor NotSelected = new OrisonColor(220, 220, 220);
        static private readonly OrisonColor Selected = new OrisonColor(255, 125, 50);
        static private readonly OrisonColor Hover = new OrisonColor(255, 220, 130);

        public LayerDefinition LayerDefinition { get; private set; }
        private bool selected;

        public LayerButton(LayerDefinition definition, int y)
        {
            LayerDefinition = definition;
            InitializeComponent();
            Location = new Point(0, y);
            pictureBox.Image = Image.FromFile(Path.Combine(Orison.ProgramDirectory, @"Content\layers", LayerDefinition.Image));
            layerNameLabel.Text = definition.Name;

            //Init state
            selected = Orison.LayersWindow.CurrentLayerIndex != -1 && Orison.Project.LayerDefinitions[Orison.LayersWindow.CurrentLayerIndex] == LayerDefinition;
            layerNameLabel.BackColor = selected ? Selected : NotSelected;
            visibleCheckBox.Checked = LayerDefinition.Visible;

            //Add events
            Orison.LayersWindow.OnLayerChanged += onLayerChanged;          
        }

        public void OnRemove()
        {
            //Clean up events
            Orison.LayersWindow.OnLayerChanged -= onLayerChanged;
        }

        private void onLayerChanged(LayerDefinition layer, int index)
        {
            selected = layer == LayerDefinition;
            layerNameLabel.BackColor = selected ? Selected : NotSelected;
        }

        private void visibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            LayerDefinition.Visible = visibleCheckBox.Checked;
        }

        private void layerNameLabel_MouseEnter(object sender, EventArgs e)
        {
            if (!selected)
                layerNameLabel.BackColor = Hover;
        }

        private void layerNameLabel_MouseLeave(object sender, EventArgs e)
        {
            if (!selected)
                layerNameLabel.BackColor = NotSelected;
        }

        private void layerNameLabel_Click(object sender, EventArgs e)
        {
            Orison.LayersWindow.SetLayer(Orison.Project.LayerDefinitions.IndexOf(LayerDefinition));
        }
    }
}
