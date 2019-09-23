namespace OrisonEditor.LevelEditors.LevelValueEditors
{
    partial class LevelIntValueEditor
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
            this.valueTrackBar = new System.Windows.Forms.TrackBar();
            this.nameLabel = new System.Windows.Forms.Label();
            this.valueTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.valueTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // valueTrackBar
            // 
            this.valueTrackBar.AutoSize = false;
            this.valueTrackBar.Location = new System.Drawing.Point(178, 0);
            this.valueTrackBar.Name = "valueTrackBar";
            this.valueTrackBar.Size = new System.Drawing.Size(122, 23);
            this.valueTrackBar.TabIndex = 5;
            this.valueTrackBar.Scroll += new System.EventHandler(this.valueTrackBar_Scroll);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoEllipsis = true;
            this.nameLabel.Location = new System.Drawing.Point(5, 3);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(100, 20);
            this.nameLabel.TabIndex = 4;
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // valueTextBox
            // 
            this.valueTextBox.Location = new System.Drawing.Point(114, 3);
            this.valueTextBox.Name = "valueTextBox";
            this.valueTextBox.Size = new System.Drawing.Size(64, 20);
            this.valueTextBox.TabIndex = 3;
            this.valueTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.valueTextBox_KeyDown);
            this.valueTextBox.Leave += new System.EventHandler(this.valueTextBox_Leave);
            // 
            // LevelIntValueEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.valueTrackBar);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.valueTextBox);
            this.Name = "LevelIntValueEditor";
            this.Size = new System.Drawing.Size(300, 24);
            ((System.ComponentModel.ISupportInitialize)(this.valueTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar valueTrackBar;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox valueTextBox;
    }
}
