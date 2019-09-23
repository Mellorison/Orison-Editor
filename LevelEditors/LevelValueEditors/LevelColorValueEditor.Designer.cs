namespace OrisonEditor.LevelEditors.LevelValueEditors
{
    partial class LevelColorValueEditor
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.colorChooser = new OrisonEditor.ColorChooser();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoEllipsis = true;
            this.nameLabel.Location = new System.Drawing.Point(3, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(100, 20);
            this.nameLabel.TabIndex = 4;
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // colorChooser
            // 
            this.colorChooser.Location = new System.Drawing.Point(114, -2);
            this.colorChooser.Name = "colorChooser";
            this.colorChooser.Size = new System.Drawing.Size(102, 28);
            this.colorChooser.TabIndex = 3;
            this.colorChooser.ColorChanged += new OrisonEditor.ColorChooser.ColorCallback(this.colorChooser_ColorChanged);
            // 
            // LevelColorValueEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.colorChooser);
            this.Name = "LevelColorValueEditor";
            this.Size = new System.Drawing.Size(300, 24);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private ColorChooser colorChooser;
    }
}
