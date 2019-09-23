namespace OrisonEditor.ProjectEditors.LayerDefinitionEditors
{
    partial class GridLayerDefinitionEditor
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.exportModeComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.colorChooser = new OrisonEditor.ColorChooser();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Color";
            // 
            // exportModeComboBox
            // 
            this.exportModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.exportModeComboBox.FormattingEnabled = true;
            this.exportModeComboBox.Items.AddRange(new object[] {
            "Bitstring",
            "Trimmed Bitstring",
            "Rectangles",
            "Grid Rectangles"});
            this.exportModeComboBox.Location = new System.Drawing.Point(92, 46);
            this.exportModeComboBox.Name = "exportModeComboBox";
            this.exportModeComboBox.Size = new System.Drawing.Size(121, 21);
            this.exportModeComboBox.TabIndex = 2;
            this.exportModeComboBox.SelectionChangeCommitted += new System.EventHandler(this.exportModeComboBox_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Export Mode";
            // 
            // colorChooser
            // 
            this.colorChooser.Location = new System.Drawing.Point(87, 12);
            this.colorChooser.Name = "colorChooser";
            this.colorChooser.Size = new System.Drawing.Size(108, 28);
            this.colorChooser.TabIndex = 0;
            this.colorChooser.ColorChanged += new OrisonEditor.ColorChooser.ColorCallback(this.colorChooser_ColorChanged);
            // 
            // GridLayerDefinitionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.exportModeComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.colorChooser);
            this.Name = "GridLayerDefinitionEditor";
            this.Size = new System.Drawing.Size(353, 358);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ColorChooser colorChooser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox exportModeComboBox;
        private System.Windows.Forms.Label label2;
    }
}
