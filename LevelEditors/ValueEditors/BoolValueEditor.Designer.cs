namespace OrisonEditor.LevelEditors.ValueEditors
{
    partial class BoolValueEditor
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
            this.valueCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // valueCheckBox
            // 
            this.valueCheckBox.AutoSize = true;
            this.valueCheckBox.Location = new System.Drawing.Point(3, 7);
            this.valueCheckBox.Name = "valueCheckBox";
            this.valueCheckBox.Size = new System.Drawing.Size(15, 14);
            this.valueCheckBox.TabIndex = 0;
            this.valueCheckBox.UseVisualStyleBackColor = true;
            this.valueCheckBox.Click += new System.EventHandler(this.valueCheckBox_Click);
            // 
            // BoolValueEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.valueCheckBox);
            this.Name = "BoolValueEditor";
            this.Size = new System.Drawing.Size(128, 24);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox valueCheckBox;
    }
}
