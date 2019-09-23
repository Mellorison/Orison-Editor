namespace OrisonEditor.Windows.Utilities
{
    partial class SwapRenameLevelsWindow
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
            this.levelATextbox = new System.Windows.Forms.TextBox();
            this.levelBTextbox = new System.Windows.Forms.TextBox();
            this.performButton = new System.Windows.Forms.Button();
            this.levelABrowseButton = new System.Windows.Forms.Button();
            this.levelBBrowseButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // levelATextbox
            // 
            this.levelATextbox.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelATextbox.Location = new System.Drawing.Point(67, 15);
            this.levelATextbox.Name = "levelATextbox";
            this.levelATextbox.Size = new System.Drawing.Size(152, 23);
            this.levelATextbox.TabIndex = 0;
            // 
            // levelBTextbox
            // 
            this.levelBTextbox.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelBTextbox.Location = new System.Drawing.Point(67, 50);
            this.levelBTextbox.Name = "levelBTextbox";
            this.levelBTextbox.Size = new System.Drawing.Size(152, 23);
            this.levelBTextbox.TabIndex = 1;
            // 
            // performButton
            // 
            this.performButton.Location = new System.Drawing.Point(96, 90);
            this.performButton.Name = "performButton";
            this.performButton.Size = new System.Drawing.Size(107, 23);
            this.performButton.TabIndex = 2;
            this.performButton.Text = "Perform";
            this.performButton.UseVisualStyleBackColor = true;
            this.performButton.Click += new System.EventHandler(this.performButton_Click);
            // 
            // levelABrowseButton
            // 
            this.levelABrowseButton.Location = new System.Drawing.Point(225, 15);
            this.levelABrowseButton.Name = "levelABrowseButton";
            this.levelABrowseButton.Size = new System.Drawing.Size(51, 23);
            this.levelABrowseButton.TabIndex = 3;
            this.levelABrowseButton.TabStop = false;
            this.levelABrowseButton.Text = "...";
            this.levelABrowseButton.UseVisualStyleBackColor = true;
            this.levelABrowseButton.Click += new System.EventHandler(this.levelABrowseButton_Click);
            // 
            // levelBBrowseButton
            // 
            this.levelBBrowseButton.Location = new System.Drawing.Point(225, 50);
            this.levelBBrowseButton.Name = "levelBBrowseButton";
            this.levelBBrowseButton.Size = new System.Drawing.Size(51, 23);
            this.levelBBrowseButton.TabIndex = 4;
            this.levelBBrowseButton.TabStop = false;
            this.levelBBrowseButton.Text = "...";
            this.levelBBrowseButton.UseVisualStyleBackColor = true;
            this.levelBBrowseButton.Click += new System.EventHandler(this.levelBBrowseButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Level A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Level B";
            // 
            // SwapRenameLevelsWindow
            // 
            this.AcceptButton = this.performButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 127);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.levelBBrowseButton);
            this.Controls.Add(this.levelABrowseButton);
            this.Controls.Add(this.performButton);
            this.Controls.Add(this.levelBTextbox);
            this.Controls.Add(this.levelATextbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SwapRenameLevelsWindow";
            this.Text = "Swap Renamer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox levelATextbox;
        private System.Windows.Forms.TextBox levelBTextbox;
        private System.Windows.Forms.Button performButton;
        private System.Windows.Forms.Button levelABrowseButton;
        private System.Windows.Forms.Button levelBBrowseButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}