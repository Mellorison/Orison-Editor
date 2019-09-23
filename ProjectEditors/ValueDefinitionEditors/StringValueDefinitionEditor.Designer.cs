namespace OrisonEditor.ProjectEditors.ValueDefinitionEditors
{
    partial class StringValueDefinitionEditor
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
            this.defaultTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.multiLineCheckBox = new System.Windows.Forms.CheckBox();
            this.maxCharsTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // defaultTextBox
            // 
            this.defaultTextBox.Location = new System.Drawing.Point(54, 3);
            this.defaultTextBox.Name = "defaultTextBox";
            this.defaultTextBox.Size = new System.Drawing.Size(172, 20);
            this.defaultTextBox.TabIndex = 0;
            this.defaultTextBox.Validated += new System.EventHandler(this.defaultTextBox_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Default";
            // 
            // multiLineCheckBox
            // 
            this.multiLineCheckBox.AutoSize = true;
            this.multiLineCheckBox.Location = new System.Drawing.Point(155, 84);
            this.multiLineCheckBox.Name = "multiLineCheckBox";
            this.multiLineCheckBox.Size = new System.Drawing.Size(71, 17);
            this.multiLineCheckBox.TabIndex = 2;
            this.multiLineCheckBox.Text = "Multi-Line";
            this.multiLineCheckBox.UseVisualStyleBackColor = true;
            this.multiLineCheckBox.CheckedChanged += new System.EventHandler(this.multiLineCheckBox_CheckedChanged);
            // 
            // maxCharsTextBox
            // 
            this.maxCharsTextBox.Location = new System.Drawing.Point(70, 81);
            this.maxCharsTextBox.Name = "maxCharsTextBox";
            this.maxCharsTextBox.Size = new System.Drawing.Size(69, 20);
            this.maxCharsTextBox.TabIndex = 3;
            this.maxCharsTextBox.Validated += new System.EventHandler(this.maxCharsTextBox_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Max Chars";
            // 
            // StringValueEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.maxCharsTextBox);
            this.Controls.Add(this.multiLineCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.defaultTextBox);
            this.Name = "StringValueEditor";
            this.Size = new System.Drawing.Size(239, 104);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox defaultTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox multiLineCheckBox;
        private System.Windows.Forms.TextBox maxCharsTextBox;
        private System.Windows.Forms.Label label2;
    }
}
