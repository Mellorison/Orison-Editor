namespace OrisonEditor.Windows
{
    partial class EntityButton
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
            this.components = new System.ComponentModel.Container();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.entityNameLabel = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTip
            // 
            this.toolTip.ShowAlways = true;
            // 
            // entityNameLabel
            // 
            this.entityNameLabel.AutoEllipsis = true;
            this.entityNameLabel.BackColor = System.Drawing.SystemColors.Control;
            this.entityNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entityNameLabel.Location = new System.Drawing.Point(33, 2);
            this.entityNameLabel.Name = "entityNameLabel";
            this.entityNameLabel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.entityNameLabel.Size = new System.Drawing.Size(90, 20);
            this.entityNameLabel.TabIndex = 4;
            this.entityNameLabel.Text = "Name";
            this.entityNameLabel.Click += new System.EventHandler(this.label_Click);
            this.entityNameLabel.MouseEnter += new System.EventHandler(this.entityNameLabel_MouseEnter);
            this.entityNameLabel.MouseLeave += new System.EventHandler(this.entityNameLabel_MouseLeave);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(5, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(24, 24);
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.label_Click);
            this.pictureBox.MouseEnter += new System.EventHandler(this.entityNameLabel_MouseEnter);
            this.pictureBox.MouseLeave += new System.EventHandler(this.entityNameLabel_MouseLeave);
            // 
            // EntityButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.entityNameLabel);
            this.Controls.Add(this.pictureBox);
            this.Name = "EntityButton";
            this.Size = new System.Drawing.Size(130, 24);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label entityNameLabel;
        private System.Windows.Forms.PictureBox pictureBox;
    }
}
