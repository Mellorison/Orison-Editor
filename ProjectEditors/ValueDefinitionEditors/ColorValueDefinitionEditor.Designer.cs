namespace OrisonEditor.ProjectEditors.ValueDefinitionEditors
{
    partial class ColorValueDefinitionEditor
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
            this.defaultColorChooser = new OrisonEditor.ColorChooser();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Default";
            // 
            // defaultColorChooser
            // 
            this.defaultColorChooser.Location = new System.Drawing.Point(47, 3);
            this.defaultColorChooser.Name = "defaultColorChooser";
            this.defaultColorChooser.Size = new System.Drawing.Size(153, 28);
            this.defaultColorChooser.TabIndex = 1;
            this.defaultColorChooser.ColorChanged += new OrisonEditor.ColorChooser.ColorCallback(this.defaultColorChooser_ColorChanged);
            // 
            // ColorValueEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.defaultColorChooser);
            this.Name = "ColorValueEditor";
            this.Size = new System.Drawing.Size(239, 104);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ColorChooser defaultColorChooser;
        private System.Windows.Forms.Label label1;
    }
}
