namespace OrisonEditor.ProjectEditors.ValueDefinitionEditors
{
    partial class FloatValueDefinitionEditor
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
            this.roundTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(140, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Max";
            // 
            // maxTextBox
            // 
            this.maxTextBox.Location = new System.Drawing.Point(169, 42);
            this.maxTextBox.Name = "maxTextBox";
            this.maxTextBox.Size = new System.Drawing.Size(67, 20);
            this.maxTextBox.TabIndex = 20;
            this.maxTextBox.Validated += new System.EventHandler(this.maxTextBox_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Min";
            // 
            // minTextBox
            // 
            this.minTextBox.Location = new System.Drawing.Point(48, 42);
            this.minTextBox.Name = "minTextBox";
            this.minTextBox.Size = new System.Drawing.Size(69, 20);
            this.minTextBox.TabIndex = 18;
            this.minTextBox.Validated += new System.EventHandler(this.minTextBox_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Default";
            // 
            // defaultTextBox
            // 
            this.defaultTextBox.Location = new System.Drawing.Point(48, 15);
            this.defaultTextBox.Name = "defaultTextBox";
            this.defaultTextBox.Size = new System.Drawing.Size(69, 20);
            this.defaultTextBox.TabIndex = 16;
            this.defaultTextBox.Validated += new System.EventHandler(this.defaultTextBox_Validated);
            // 
            // roundTextBox
            // 
            this.roundTextBox.Location = new System.Drawing.Point(169, 15);
            this.roundTextBox.Name = "roundTextBox";
            this.roundTextBox.Size = new System.Drawing.Size(67, 20);
            this.roundTextBox.TabIndex = 24;
            this.roundTextBox.Validated += new System.EventHandler(this.roundTextBox_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Round";
            // 
            // FloatValueDefinitionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.roundTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.maxTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.minTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.defaultTextBox);
            this.Name = "FloatValueDefinitionEditor";
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
        private System.Windows.Forms.TextBox roundTextBox;
        private System.Windows.Forms.Label label1;
    }
}
