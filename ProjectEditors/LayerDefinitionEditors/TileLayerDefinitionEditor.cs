using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OrisonEditor.Definitions.LayerDefinitions;
using System.Diagnostics;

namespace OrisonEditor.ProjectEditors.LayerDefinitionEditors
{
    public partial class TileLayerDefinitionEditor : UserControl
    {
        private TileLayerDefinition def;

        public TileLayerDefinitionEditor(TileLayerDefinition def)
        {
            this.def = def;
            InitializeComponent();
            Location = new Point(206, 128);

            exportModeComboBox.SelectedIndex = (int)def.ExportMode;
        }

        private void exportModeComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            def.ExportMode = (TileLayerDefinition.TileExportMode)exportModeComboBox.SelectedIndex;
        }
    }
}
