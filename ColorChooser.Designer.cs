namespace OrisonEditor
{
    partial class ColorChooser
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
            this.hexTextBox = new System.Windows.Forms.TextBox();
            this.colorButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // hexTextBox
            // 
            this.hexTextBox.Location = new System.Drawing.Point(4, 4);
            this.hexTextBox.Name = "hexTextBox";
            this.hexTextBox.Size = new System.Drawing.Size(54, 20);
            this.hexTextBox.TabIndex = 0;
            this.hexTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hexTextBox_KeyDown);
            this.hexTextBox.Validated += new System.EventHandler(this.hexTextBox_Validated);
            // 
            // colorButton
            // 
            this.colorButton.Location = new System.Drawing.Point(64, 3);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(38, 23);
            this.colorButton.TabIndex = 3;
            this.colorButton.TabStop = false;
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // ColorChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.colorButton);
            this.Controls.Add(this.hexTextBox);
            this.Name = "ColorChooser";
            this.Size = new System.Drawing.Size(108, 28);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox hexTextBox;
        private System.Windows.Forms.Button colorButton;
    }
}
