namespace OrisonEditor.Windows.Utilities
{
    partial class ShiftRenameLevelsWindow
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.patternTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rangeLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.overwriteCheckbox = new System.Windows.Forms.CheckBox();
            this.shiftUpDown = new System.Windows.Forms.NumericUpDown();
            this.rangeMinUpDown = new System.Windows.Forms.NumericUpDown();
            this.rangeMaxUpDown = new System.Windows.Forms.NumericUpDown();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.performButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.shiftUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rangeMinUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rangeMaxUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // patternTextbox
            // 
            this.patternTextbox.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patternTextbox.Location = new System.Drawing.Point(147, 24);
            this.patternTextbox.Name = "patternTextbox";
            this.patternTextbox.Size = new System.Drawing.Size(201, 23);
            this.patternTextbox.TabIndex = 0;
            this.patternTextbox.Text = "level#.oel";
            this.toolTip.SetToolTip(this.patternTextbox, "Enter a matching pattern for level names to shift. Numeral to shift should be rep" +
        "laced by #\r\nExamples: \'level#.oel\', \'level_2_#.oel\'");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Level Name Pattern";
            // 
            // rangeLabel
            // 
            this.rangeLabel.AutoSize = true;
            this.rangeLabel.Location = new System.Drawing.Point(58, 55);
            this.rangeLabel.Name = "rangeLabel";
            this.rangeLabel.Size = new System.Drawing.Size(82, 13);
            this.rangeLabel.TabIndex = 4;
            this.rangeLabel.Text = "Affected Range";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(290, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "(inclusive)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(112, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Shift";
            // 
            // overwriteCheckbox
            // 
            this.overwriteCheckbox.AutoSize = true;
            this.overwriteCheckbox.Location = new System.Drawing.Point(146, 115);
            this.overwriteCheckbox.Name = "overwriteCheckbox";
            this.overwriteCheckbox.Size = new System.Drawing.Size(104, 17);
            this.overwriteCheckbox.TabIndex = 5;
            this.overwriteCheckbox.Text = "Allow Overwrites";
            this.toolTip.SetToolTip(this.overwriteCheckbox, "If unchecked, the renamer will not shift levels which would result in overwriting" +
        " an unshifted level");
            this.overwriteCheckbox.UseVisualStyleBackColor = true;
            // 
            // shiftUpDown
            // 
            this.shiftUpDown.Location = new System.Drawing.Point(146, 81);
            this.shiftUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.shiftUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.shiftUpDown.Name = "shiftUpDown";
            this.shiftUpDown.Size = new System.Drawing.Size(69, 20);
            this.shiftUpDown.TabIndex = 4;
            this.toolTip.SetToolTip(this.shiftUpDown, "The amount to shift the level names by");
            this.shiftUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rangeMinUpDown
            // 
            this.rangeMinUpDown.Location = new System.Drawing.Point(147, 53);
            this.rangeMinUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.rangeMinUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.rangeMinUpDown.Name = "rangeMinUpDown";
            this.rangeMinUpDown.Size = new System.Drawing.Size(52, 20);
            this.rangeMinUpDown.TabIndex = 2;
            this.toolTip.SetToolTip(this.rangeMinUpDown, "The lowest-numbered level to shift");
            this.rangeMinUpDown.ValueChanged += new System.EventHandler(this.rangeMinUpDown_ValueChanged);
            // 
            // rangeMaxUpDown
            // 
            this.rangeMaxUpDown.Location = new System.Drawing.Point(221, 53);
            this.rangeMaxUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.rangeMaxUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.rangeMaxUpDown.Name = "rangeMaxUpDown";
            this.rangeMaxUpDown.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rangeMaxUpDown.Size = new System.Drawing.Size(52, 20);
            this.rangeMaxUpDown.TabIndex = 3;
            this.toolTip.SetToolTip(this.rangeMaxUpDown, "The highest-numbered level to shift");
            this.rangeMaxUpDown.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.rangeMaxUpDown.ValueChanged += new System.EventHandler(this.rangeMaxUpDown_ValueChanged);
            // 
            // toolTip
            // 
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // performButton
            // 
            this.performButton.Location = new System.Drawing.Point(127, 158);
            this.performButton.Name = "performButton";
            this.performButton.Size = new System.Drawing.Size(134, 23);
            this.performButton.TabIndex = 10;
            this.performButton.Text = "Perform";
            this.performButton.UseVisualStyleBackColor = true;
            this.performButton.Click += new System.EventHandler(this.performButton_Click);
            // 
            // ShiftRenameLevelsWindow
            // 
            this.AcceptButton = this.performButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 193);
            this.Controls.Add(this.performButton);
            this.Controls.Add(this.rangeMaxUpDown);
            this.Controls.Add(this.rangeMinUpDown);
            this.Controls.Add(this.shiftUpDown);
            this.Controls.Add(this.overwriteCheckbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rangeLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.patternTextbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShiftRenameLevelsWindow";
            this.Text = "Shift Renamer";
            ((System.ComponentModel.ISupportInitialize)(this.shiftUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rangeMinUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rangeMaxUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox patternTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label rangeLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox overwriteCheckbox;
        private System.Windows.Forms.NumericUpDown shiftUpDown;
        private System.Windows.Forms.NumericUpDown rangeMinUpDown;
        private System.Windows.Forms.NumericUpDown rangeMaxUpDown;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button performButton;
    }
}