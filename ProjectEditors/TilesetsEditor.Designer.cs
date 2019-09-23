namespace OrisonEditor.ProjectEditors
{
    partial class TilesetsEditor
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
            this.listBox = new System.Windows.Forms.ListBox();
            this.moveDownButton = new System.Windows.Forms.Button();
            this.moveUpButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.imageFileTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.imageFileButton = new System.Windows.Forms.Button();
            this.imageFileWarningLabel = new System.Windows.Forms.Label();
            this.tileSizeYTextBox = new System.Windows.Forms.TextBox();
            this.tileSizeXTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tileSpacingTextBox = new System.Windows.Forms.TextBox();
            this.imageSizeLabel = new System.Windows.Forms.Label();
            this.totalTilesLabel = new System.Windows.Forms.Label();
            this.imagePreviewer = new OrisonEditor.ImagePreviewer();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(4, 4);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(184, 420);
            this.listBox.TabIndex = 43;
            this.listBox.TabStop = false;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // moveDownButton
            // 
            this.moveDownButton.Enabled = false;
            this.moveDownButton.Location = new System.Drawing.Point(98, 458);
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(89, 23);
            this.moveDownButton.TabIndex = 42;
            this.moveDownButton.TabStop = false;
            this.moveDownButton.Text = "Move Down";
            this.moveDownButton.UseVisualStyleBackColor = true;
            this.moveDownButton.Click += new System.EventHandler(this.moveDownButton_Click);
            // 
            // moveUpButton
            // 
            this.moveUpButton.Enabled = false;
            this.moveUpButton.Location = new System.Drawing.Point(4, 458);
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.Size = new System.Drawing.Size(89, 23);
            this.moveUpButton.TabIndex = 41;
            this.moveUpButton.TabStop = false;
            this.moveUpButton.Text = "Move Up";
            this.moveUpButton.UseVisualStyleBackColor = true;
            this.moveUpButton.Click += new System.EventHandler(this.moveUpButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Enabled = false;
            this.removeButton.Location = new System.Drawing.Point(99, 430);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(89, 23);
            this.removeButton.TabIndex = 40;
            this.removeButton.TabStop = false;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(4, 430);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(89, 23);
            this.addButton.TabIndex = 39;
            this.addButton.TabStop = false;
            this.addButton.Text = "Create";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Enabled = false;
            this.nameTextBox.Location = new System.Drawing.Point(280, 341);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.nameTextBox.TabIndex = 0;
            this.nameTextBox.Validated += new System.EventHandler(this.nameTextBox_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(239, 344);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "Name";
            // 
            // imageFileTextBox
            // 
            this.imageFileTextBox.Enabled = false;
            this.imageFileTextBox.Location = new System.Drawing.Point(280, 367);
            this.imageFileTextBox.Name = "imageFileTextBox";
            this.imageFileTextBox.ReadOnly = true;
            this.imageFileTextBox.Size = new System.Drawing.Size(138, 20);
            this.imageFileTextBox.TabIndex = 47;
            this.imageFileTextBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 370);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "Image File";
            // 
            // imageFileButton
            // 
            this.imageFileButton.Enabled = false;
            this.imageFileButton.Location = new System.Drawing.Point(424, 365);
            this.imageFileButton.Name = "imageFileButton";
            this.imageFileButton.Size = new System.Drawing.Size(27, 23);
            this.imageFileButton.TabIndex = 1;
            this.imageFileButton.Text = "...";
            this.imageFileButton.UseVisualStyleBackColor = true;
            this.imageFileButton.Click += new System.EventHandler(this.imageFileButton_Click);
            // 
            // imageFileWarningLabel
            // 
            this.imageFileWarningLabel.AutoSize = true;
            this.imageFileWarningLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.imageFileWarningLabel.Location = new System.Drawing.Point(457, 370);
            this.imageFileWarningLabel.Name = "imageFileWarningLabel";
            this.imageFileWarningLabel.Size = new System.Drawing.Size(94, 13);
            this.imageFileWarningLabel.TabIndex = 50;
            this.imageFileWarningLabel.Text = "File does not exist!";
            this.imageFileWarningLabel.Visible = false;
            // 
            // tileSizeYTextBox
            // 
            this.tileSizeYTextBox.Enabled = false;
            this.tileSizeYTextBox.Location = new System.Drawing.Point(366, 393);
            this.tileSizeYTextBox.Name = "tileSizeYTextBox";
            this.tileSizeYTextBox.Size = new System.Drawing.Size(62, 20);
            this.tileSizeYTextBox.TabIndex = 3;
            this.tileSizeYTextBox.Validated += new System.EventHandler(this.tileSizeXTextBox_Validated);
            // 
            // tileSizeXTextBox
            // 
            this.tileSizeXTextBox.Enabled = false;
            this.tileSizeXTextBox.Location = new System.Drawing.Point(280, 393);
            this.tileSizeXTextBox.Name = "tileSizeXTextBox";
            this.tileSizeXTextBox.Size = new System.Drawing.Size(62, 20);
            this.tileSizeXTextBox.TabIndex = 2;
            this.tileSizeXTextBox.Validated += new System.EventHandler(this.tileSizeXTextBox_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(227, 396);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 54;
            this.label6.Text = "Tile Size";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(348, 396);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 53;
            this.label3.Text = "x";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(208, 422);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 55;
            this.label4.Text = "Tile Spacing";
            // 
            // tileSpacingTextBox
            // 
            this.tileSpacingTextBox.Enabled = false;
            this.tileSpacingTextBox.Location = new System.Drawing.Point(280, 419);
            this.tileSpacingTextBox.Name = "tileSpacingTextBox";
            this.tileSpacingTextBox.Size = new System.Drawing.Size(62, 20);
            this.tileSpacingTextBox.TabIndex = 4;
            this.tileSpacingTextBox.Validated += new System.EventHandler(this.tileSpacingTextBox_Validated);
            // 
            // imageSizeLabel
            // 
            this.imageSizeLabel.AutoSize = true;
            this.imageSizeLabel.Location = new System.Drawing.Point(208, 276);
            this.imageSizeLabel.Name = "imageSizeLabel";
            this.imageSizeLabel.Size = new System.Drawing.Size(65, 13);
            this.imageSizeLabel.TabIndex = 57;
            this.imageSizeLabel.Text = "Image Size: ";
            this.imageSizeLabel.Visible = false;
            // 
            // totalTilesLabel
            // 
            this.totalTilesLabel.AutoSize = true;
            this.totalTilesLabel.Location = new System.Drawing.Point(208, 296);
            this.totalTilesLabel.Name = "totalTilesLabel";
            this.totalTilesLabel.Size = new System.Drawing.Size(59, 13);
            this.totalTilesLabel.TabIndex = 58;
            this.totalTilesLabel.Text = "Total Tiles:";
            this.totalTilesLabel.Visible = false;
            // 
            // imagePreviewer
            // 
            this.imagePreviewer.Location = new System.Drawing.Point(195, 4);
            this.imagePreviewer.Name = "imagePreviewer";
            this.imagePreviewer.Size = new System.Drawing.Size(375, 257);
            this.imagePreviewer.TabIndex = 59;
            // 
            // TilesetsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.imagePreviewer);
            this.Controls.Add(this.totalTilesLabel);
            this.Controls.Add(this.imageSizeLabel);
            this.Controls.Add(this.tileSpacingTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tileSizeYTextBox);
            this.Controls.Add(this.tileSizeXTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.imageFileWarningLabel);
            this.Controls.Add(this.imageFileButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.imageFileTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.moveDownButton);
            this.Controls.Add(this.moveUpButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Name = "TilesetsEditor";
            this.Size = new System.Drawing.Size(573, 490);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button moveDownButton;
        private System.Windows.Forms.Button moveUpButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox imageFileTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button imageFileButton;
        private System.Windows.Forms.Label imageFileWarningLabel;
        private System.Windows.Forms.TextBox tileSizeYTextBox;
        private System.Windows.Forms.TextBox tileSizeXTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tileSpacingTextBox;
        private System.Windows.Forms.Label imageSizeLabel;
        private System.Windows.Forms.Label totalTilesLabel;
        private ImagePreviewer imagePreviewer;
    }
}
