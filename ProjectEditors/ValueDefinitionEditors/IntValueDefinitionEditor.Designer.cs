namespace OrisonEditor.ProjectEditors.ValueDefinitionEditors
{
    partial class IntValueDefinitionEditor
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
            this.label5 = new System.Windows.Forms.Label();
            this.maxTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.minTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.defaultTextBox = new System.Windows.Forms.TextBox();
            this.sliderCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(130, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Max";
            // 
            // maxTextBox
            // 
            this.maxTextBox.Location = new System.Drawing.Point(159, 41);
            this.maxTextBox.Name = "maxTextBox";
            this.maxTextBox.Size = new System.Drawing.Size(77, 20);
            this.maxTextBox.TabIndex = 12;
            this.maxTextBox.TextChanged += new System.EventHandler(this.maxTextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Min";
            // 
            // minTextBox
            // 
            this.minTextBox.Location = new System.Drawing.Point(47, 41);
            this.minTextBox.Name = "minTextBox";
            this.minTextBox.Size = new System.Drawing.Size(77, 20);
            this.minTextBox.TabIndex = 10;
            this.minTextBox.Validated += new System.EventHandler(this.minTextBox_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Default";
            // 
            // defaultTextBox
            // 
            this.defaultTextBox.Location = new System.Drawing.Point(47, 14);
            this.defaultTextBox.Name = "defaultTextBox";
            this.defaultTextBox.Size = new System.Drawing.Size(77, 20);
            this.defaultTextBox.TabIndex = 8;
            this.defaultTextBox.Validated += new System.EventHandler(this.defaultTextBox_Validated);
            // 
            // sliderCheckBox
            // 
            this.sliderCheckBox.AutoSize = true;
            this.sliderCheckBox.Location = new System.Drawing.Point(33, 67);
            this.sliderCheckBox.Name = "sliderCheckBox";
            this.sliderCheckBox.Size = new System.Drawing.Size(82, 17);
            this.sliderCheckBox.TabIndex = 14;
            this.sliderCheckBox.Text = "Show Slider";
            this.sliderCheckBox.UseVisualStyleBackColor = true;
            this.sliderCheckBox.CheckedChanged += new System.EventHandler(this.sliderCheckBox_CheckedChanged);
            // 
            // IntValueDefinitionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sliderCheckBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.maxTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.minTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.defaultTextBox);
            this.Name = "IntValueDefinitionEditor";
            this.Size = new System.Drawing.Size(239, 104);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox maxTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox minTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox defaultTextBox;
        private System.Windows.Forms.CheckBox sliderCheckBox;
    }
}
