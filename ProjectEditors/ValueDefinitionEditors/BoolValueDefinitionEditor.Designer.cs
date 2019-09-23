namespace OrisonEditor.ProjectEditors.ValueDefinitionEditors
{
    partial class BoolValueDefinitionEditor
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
            this.defaultCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // defaultCheckBox
            // 
            this.defaultCheckBox.AutoSize = true;
            this.defaultCheckBox.Location = new System.Drawing.Point(3, 3);
            this.defaultCheckBox.Name = "defaultCheckBox";
            this.defaultCheckBox.Size = new System.Drawing.Size(93, 17);
            this.defaultCheckBox.TabIndex = 0;
            this.defaultCheckBox.Text = "Default to true";
            this.defaultCheckBox.UseVisualStyleBackColor = true;
            this.defaultCheckBox.CheckedChanged += new System.EventHandler(this.defaultCheckBox_CheckedChanged);
            // 
            // BoolValueEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.defaultCheckBox);
            this.Name = "BoolValueEditor";
            this.Size = new System.Drawing.Size(239, 104);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox defaultCheckBox;
    }
}
