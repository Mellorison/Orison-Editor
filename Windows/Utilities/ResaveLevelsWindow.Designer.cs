namespace OrisonEditor.Windows.Utilities
{
    partial class ResaveLevelsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResaveLevelsWindow));
            this.allRadioButton = new System.Windows.Forms.RadioButton();
            this.levelsRadioButton = new System.Windows.Forms.RadioButton();
            this.directoryRadioButton = new System.Windows.Forms.RadioButton();
            this.topLabel = new System.Windows.Forms.Label();
            this.warningLabel = new System.Windows.Forms.Label();
            this.performButton = new System.Windows.Forms.Button();
            this.descLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // allRadioButton
            // 
            this.allRadioButton.AllowDrop = true;
            this.allRadioButton.AutoSize = true;
            this.allRadioButton.Location = new System.Drawing.Point(22, 136);
            this.allRadioButton.Name = "allRadioButton";
            this.allRadioButton.Size = new System.Drawing.Size(103, 17);
            this.allRadioButton.TabIndex = 0;
            this.allRadioButton.Text = "Project Directory";
            this.allRadioButton.UseVisualStyleBackColor = true;
            this.allRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // levelsRadioButton
            // 
            this.levelsRadioButton.AllowDrop = true;
            this.levelsRadioButton.AutoSize = true;
            this.levelsRadioButton.Checked = true;
            this.levelsRadioButton.Location = new System.Drawing.Point(22, 90);
            this.levelsRadioButton.Name = "levelsRadioButton";
            this.levelsRadioButton.Size = new System.Drawing.Size(101, 17);
            this.levelsRadioButton.TabIndex = 1;
            this.levelsRadioButton.TabStop = true;
            this.levelsRadioButton.Text = "Selected Levels";
            this.levelsRadioButton.UseVisualStyleBackColor = true;
            // 
            // directoryRadioButton
            // 
            this.directoryRadioButton.AllowDrop = true;
            this.directoryRadioButton.AutoSize = true;
            this.directoryRadioButton.Location = new System.Drawing.Point(22, 113);
            this.directoryRadioButton.Name = "directoryRadioButton";
            this.directoryRadioButton.Size = new System.Drawing.Size(112, 17);
            this.directoryRadioButton.TabIndex = 2;
            this.directoryRadioButton.Text = "Selected Directory";
            this.directoryRadioButton.UseVisualStyleBackColor = true;
            this.directoryRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // topLabel
            // 
            this.topLabel.Location = new System.Drawing.Point(28, 16);
            this.topLabel.Name = "topLabel";
            this.topLabel.Size = new System.Drawing.Size(378, 66);
            this.topLabel.TabIndex = 3;
            this.topLabel.Text = resources.GetString("topLabel.Text");
            this.topLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // warningLabel
            // 
            this.warningLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warningLabel.Location = new System.Drawing.Point(-3, 181);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(440, 23);
            this.warningLabel.TabIndex = 4;
            this.warningLabel.Text = "Warning: There is no undo for this action!";
            this.warningLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // performButton
            // 
            this.performButton.Location = new System.Drawing.Point(161, 227);
            this.performButton.Name = "performButton";
            this.performButton.Size = new System.Drawing.Size(110, 23);
            this.performButton.TabIndex = 6;
            this.performButton.Text = "Perform";
            this.performButton.UseVisualStyleBackColor = true;
            this.performButton.Click += new System.EventHandler(this.performButton_Click);
            // 
            // descLabel
            // 
            this.descLabel.Location = new System.Drawing.Point(169, 100);
            this.descLabel.Name = "descLabel";
            this.descLabel.Size = new System.Drawing.Size(229, 43);
            this.descLabel.TabIndex = 7;
            // 
            // ResaveLevelsWindow
            // 
            this.AcceptButton = this.performButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(434, 262);
            this.Controls.Add(this.descLabel);
            this.Controls.Add(this.performButton);
            this.Controls.Add(this.warningLabel);
            this.Controls.Add(this.topLabel);
            this.Controls.Add(this.directoryRadioButton);
            this.Controls.Add(this.levelsRadioButton);
            this.Controls.Add(this.allRadioButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResaveLevelsWindow";
            this.Text = "Batch Resaver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton allRadioButton;
        private System.Windows.Forms.RadioButton levelsRadioButton;
        private System.Windows.Forms.RadioButton directoryRadioButton;
        private System.Windows.Forms.Label topLabel;
        private System.Windows.Forms.Label warningLabel;
        private System.Windows.Forms.Button performButton;
        private System.Windows.Forms.Label descLabel;
    }
}