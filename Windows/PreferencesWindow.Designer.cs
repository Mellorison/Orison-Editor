namespace OrisonEditor.Windows
{
    partial class PreferencesWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreferencesWindow));
            this.maximizeCheckBox = new System.Windows.Forms.CheckBox();
            this.clearHistoryButton = new System.Windows.Forms.Button();
            this.undoLimitTextBox = new System.Windows.Forms.TextBox();
            this.doneButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.levelLimitTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // maximizeCheckBox
            // 
            this.maximizeCheckBox.AutoSize = true;
            this.maximizeCheckBox.Location = new System.Drawing.Point(12, 12);
            this.maximizeCheckBox.Name = "maximizeCheckBox";
            this.maximizeCheckBox.Size = new System.Drawing.Size(119, 17);
            this.maximizeCheckBox.TabIndex = 0;
            this.maximizeCheckBox.Text = "Maximize on startup";
            this.maximizeCheckBox.UseVisualStyleBackColor = true;
            // 
            // clearHistoryButton
            // 
            this.clearHistoryButton.Location = new System.Drawing.Point(12, 93);
            this.clearHistoryButton.Name = "clearHistoryButton";
            this.clearHistoryButton.Size = new System.Drawing.Size(134, 23);
            this.clearHistoryButton.TabIndex = 2;
            this.clearHistoryButton.Text = "Clear Project History";
            this.clearHistoryButton.UseVisualStyleBackColor = true;
            this.clearHistoryButton.Click += new System.EventHandler(this.clearHistoryButton_Click);
            // 
            // undoLimitTextBox
            // 
            this.undoLimitTextBox.Location = new System.Drawing.Point(124, 38);
            this.undoLimitTextBox.Name = "undoLimitTextBox";
            this.undoLimitTextBox.Size = new System.Drawing.Size(52, 20);
            this.undoLimitTextBox.TabIndex = 3;
            // 
            // doneButton
            // 
            this.doneButton.Location = new System.Drawing.Point(197, 122);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(75, 23);
            this.doneButton.TabIndex = 4;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Undo limit (per level):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Open level limit:";
            // 
            // levelLimitTextBox
            // 
            this.levelLimitTextBox.Location = new System.Drawing.Point(124, 63);
            this.levelLimitTextBox.Name = "levelLimitTextBox";
            this.levelLimitTextBox.Size = new System.Drawing.Size(52, 20);
            this.levelLimitTextBox.TabIndex = 7;
            // 
            // PreferencesWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 155);
            this.Controls.Add(this.levelLimitTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.doneButton);
            this.Controls.Add(this.undoLimitTextBox);
            this.Controls.Add(this.clearHistoryButton);
            this.Controls.Add(this.maximizeCheckBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PreferencesWindow";
            this.Text = "Preferences";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PreferencesWindow_FormClosed);
            this.Shown += new System.EventHandler(this.PreferencesWindow_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox maximizeCheckBox;
        private System.Windows.Forms.Button clearHistoryButton;
        private System.Windows.Forms.TextBox undoLimitTextBox;
        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox levelLimitTextBox;
    }
}