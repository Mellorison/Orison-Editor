namespace OrisonEditor.Windows
{
    partial class LayerButton
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.layerNameLabel = new System.Windows.Forms.Label();
            this.visibleCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(24, 24);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.layerNameLabel_Click);
            this.pictureBox.MouseEnter += new System.EventHandler(this.layerNameLabel_MouseEnter);
            this.pictureBox.MouseLeave += new System.EventHandler(this.layerNameLabel_MouseLeave);
            // 
            // layerNameLabel
            // 
            this.layerNameLabel.AutoEllipsis = true;
            this.layerNameLabel.BackColor = System.Drawing.SystemColors.Control;
            this.layerNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layerNameLabel.Location = new System.Drawing.Point(28, 2);
            this.layerNameLabel.Name = "layerNameLabel";
            this.layerNameLabel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.layerNameLabel.Size = new System.Drawing.Size(72, 20);
            this.layerNameLabel.TabIndex = 1;
            this.layerNameLabel.Text = "Name";
            this.layerNameLabel.Click += new System.EventHandler(this.layerNameLabel_Click);
            this.layerNameLabel.MouseEnter += new System.EventHandler(this.layerNameLabel_MouseEnter);
            this.layerNameLabel.MouseLeave += new System.EventHandler(this.layerNameLabel_MouseLeave);
            // 
            // visibleCheckBox
            // 
            this.visibleCheckBox.AutoSize = true;
            this.visibleCheckBox.Location = new System.Drawing.Point(104, 6);
            this.visibleCheckBox.Name = "visibleCheckBox";
            this.visibleCheckBox.Size = new System.Drawing.Size(15, 14);
            this.visibleCheckBox.TabIndex = 2;
            this.visibleCheckBox.UseVisualStyleBackColor = true;
            this.visibleCheckBox.CheckedChanged += new System.EventHandler(this.visibleCheckBox_CheckedChanged);
            // 
            // LayerButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.visibleCheckBox);
            this.Controls.Add(this.layerNameLabel);
            this.Controls.Add(this.pictureBox);
            this.Name = "LayerButton";
            this.Size = new System.Drawing.Size(120, 24);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label layerNameLabel;
        private System.Windows.Forms.CheckBox visibleCheckBox;
    }
}
