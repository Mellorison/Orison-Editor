using OrisonEditor.ProjectEditors.ValueDefinitionEditors;
namespace OrisonEditor.ProjectEditors
{
    partial class EntityDefinitionsEditor
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
            this.label2 = new System.Windows.Forms.Label();
            this.sizeXTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.limitTextBox = new System.Windows.Forms.TextBox();
            this.resizableXCheckBox = new System.Windows.Forms.CheckBox();
            this.resizableYCheckBox = new System.Windows.Forms.CheckBox();
            this.rotatableCheckBox = new System.Windows.Forms.CheckBox();
            this.rotationIncrementTextBox = new System.Windows.Forms.TextBox();
            this.rotationIncrementLabel = new System.Windows.Forms.Label();
            this.sizeYTextBox = new System.Windows.Forms.TextBox();
            this.originYTextBox = new System.Windows.Forms.TextBox();
            this.originXTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nodesCheckBox = new System.Windows.Forms.CheckBox();
            this.nodeLimitTextBox = new System.Windows.Forms.TextBox();
            this.nodeLimitLabel = new System.Windows.Forms.Label();
            this.nodeDrawLabel = new System.Windows.Forms.Label();
            this.nodeDrawComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.graphicTypeComboBox = new System.Windows.Forms.ComboBox();
            this.rectangleGraphicPanel = new System.Windows.Forms.Panel();
            this.rectangleColorChooser = new OrisonEditor.ColorChooser();
            this.label12 = new System.Windows.Forms.Label();
            this.imageFileGraphicPanel = new System.Windows.Forms.Panel();
            this.imagePreviewer = new OrisonEditor.ImagePreviewer();
            this.imageFileWarningLabel = new System.Windows.Forms.Label();
            this.imageFileButton = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.imageFileTextBox = new System.Windows.Forms.TextBox();
            this.imageFileTiledCheckBox = new System.Windows.Forms.CheckBox();
            this.valuesEditor = new OrisonEditor.ProjectEditors.ValueDefinitionEditors.ValueDefinitionsEditor();
            this.nodeGhostCheckBox = new System.Windows.Forms.CheckBox();
            this.rectangleGraphicPanel.SuspendLayout();
            this.imageFileGraphicPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(4, 4);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(184, 420);
            this.listBox.TabIndex = 48;
            this.listBox.TabStop = false;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // moveDownButton
            // 
            this.moveDownButton.Enabled = false;
            this.moveDownButton.Location = new System.Drawing.Point(98, 458);
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(89, 23);
            this.moveDownButton.TabIndex = 47;
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
            this.moveUpButton.TabIndex = 46;
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
            this.removeButton.TabIndex = 45;
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
            this.addButton.TabIndex = 44;
            this.addButton.TabStop = false;
            this.addButton.Text = "Create";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Enabled = false;
            this.nameTextBox.Location = new System.Drawing.Point(262, 11);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(133, 20);
            this.nameTextBox.TabIndex = 0;
            this.nameTextBox.Validated += new System.EventHandler(this.nameTextBox_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(221, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(229, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 51;
            this.label2.Text = "Size";
            // 
            // sizeXTextBox
            // 
            this.sizeXTextBox.Enabled = false;
            this.sizeXTextBox.Location = new System.Drawing.Point(262, 37);
            this.sizeXTextBox.Name = "sizeXTextBox";
            this.sizeXTextBox.Size = new System.Drawing.Size(42, 20);
            this.sizeXTextBox.TabIndex = 2;
            this.sizeXTextBox.Validated += new System.EventHandler(this.sizeXTextBox_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(310, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 56;
            this.label3.Text = "x";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(446, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 57;
            this.label4.Text = "Limit";
            // 
            // limitTextBox
            // 
            this.limitTextBox.Enabled = false;
            this.limitTextBox.Location = new System.Drawing.Point(480, 11);
            this.limitTextBox.Name = "limitTextBox";
            this.limitTextBox.Size = new System.Drawing.Size(62, 20);
            this.limitTextBox.TabIndex = 1;
            this.limitTextBox.Validated += new System.EventHandler(this.limitTextBox_Validated);
            // 
            // resizableXCheckBox
            // 
            this.resizableXCheckBox.AutoSize = true;
            this.resizableXCheckBox.Enabled = false;
            this.resizableXCheckBox.Location = new System.Drawing.Point(215, 73);
            this.resizableXCheckBox.Name = "resizableXCheckBox";
            this.resizableXCheckBox.Size = new System.Drawing.Size(82, 17);
            this.resizableXCheckBox.TabIndex = 6;
            this.resizableXCheckBox.Text = "Resizable X";
            this.resizableXCheckBox.UseVisualStyleBackColor = true;
            this.resizableXCheckBox.CheckedChanged += new System.EventHandler(this.resizableXCheckBox_CheckedChanged);
            // 
            // resizableYCheckBox
            // 
            this.resizableYCheckBox.AutoSize = true;
            this.resizableYCheckBox.Enabled = false;
            this.resizableYCheckBox.Location = new System.Drawing.Point(331, 73);
            this.resizableYCheckBox.Name = "resizableYCheckBox";
            this.resizableYCheckBox.Size = new System.Drawing.Size(82, 17);
            this.resizableYCheckBox.TabIndex = 7;
            this.resizableYCheckBox.Text = "Resizable Y";
            this.resizableYCheckBox.UseVisualStyleBackColor = true;
            this.resizableYCheckBox.CheckedChanged += new System.EventHandler(this.resizableYCheckBox_CheckedChanged);
            // 
            // rotatableCheckBox
            // 
            this.rotatableCheckBox.AutoSize = true;
            this.rotatableCheckBox.Enabled = false;
            this.rotatableCheckBox.Location = new System.Drawing.Point(215, 96);
            this.rotatableCheckBox.Name = "rotatableCheckBox";
            this.rotatableCheckBox.Size = new System.Drawing.Size(72, 17);
            this.rotatableCheckBox.TabIndex = 8;
            this.rotatableCheckBox.Text = "Rotatable";
            this.rotatableCheckBox.UseVisualStyleBackColor = true;
            this.rotatableCheckBox.CheckedChanged += new System.EventHandler(this.rotatableCheckBox_CheckedChanged);
            // 
            // rotationIncrementTextBox
            // 
            this.rotationIncrementTextBox.Location = new System.Drawing.Point(428, 94);
            this.rotationIncrementTextBox.Name = "rotationIncrementTextBox";
            this.rotationIncrementTextBox.Size = new System.Drawing.Size(62, 20);
            this.rotationIncrementTextBox.TabIndex = 9;
            this.rotationIncrementTextBox.Visible = false;
            this.rotationIncrementTextBox.Validated += new System.EventHandler(this.rotationIncrementTextBox_Validated);
            // 
            // rotationIncrementLabel
            // 
            this.rotationIncrementLabel.AutoSize = true;
            this.rotationIncrementLabel.Location = new System.Drawing.Point(325, 97);
            this.rotationIncrementLabel.Name = "rotationIncrementLabel";
            this.rotationIncrementLabel.Size = new System.Drawing.Size(97, 13);
            this.rotationIncrementLabel.TabIndex = 64;
            this.rotationIncrementLabel.Text = "Rotation Increment";
            this.rotationIncrementLabel.Visible = false;
            // 
            // sizeYTextBox
            // 
            this.sizeYTextBox.Enabled = false;
            this.sizeYTextBox.Location = new System.Drawing.Point(328, 37);
            this.sizeYTextBox.Name = "sizeYTextBox";
            this.sizeYTextBox.Size = new System.Drawing.Size(42, 20);
            this.sizeYTextBox.TabIndex = 3;
            this.sizeYTextBox.Validated += new System.EventHandler(this.sizeXTextBox_Validated);
            // 
            // originYTextBox
            // 
            this.originYTextBox.Enabled = false;
            this.originYTextBox.Location = new System.Drawing.Point(500, 37);
            this.originYTextBox.Name = "originYTextBox";
            this.originYTextBox.Size = new System.Drawing.Size(42, 20);
            this.originYTextBox.TabIndex = 5;
            this.originYTextBox.Validated += new System.EventHandler(this.originXTextBox_Validated);
            // 
            // originXTextBox
            // 
            this.originXTextBox.Enabled = false;
            this.originXTextBox.Location = new System.Drawing.Point(434, 37);
            this.originXTextBox.Name = "originXTextBox";
            this.originXTextBox.Size = new System.Drawing.Size(42, 20);
            this.originXTextBox.TabIndex = 4;
            this.originXTextBox.Validated += new System.EventHandler(this.originXTextBox_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(482, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 13);
            this.label6.TabIndex = 68;
            this.label6.Text = ",";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(394, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 66;
            this.label7.Text = "Origin";
            // 
            // nodesCheckBox
            // 
            this.nodesCheckBox.AutoSize = true;
            this.nodesCheckBox.Enabled = false;
            this.nodesCheckBox.Location = new System.Drawing.Point(215, 131);
            this.nodesCheckBox.Name = "nodesCheckBox";
            this.nodesCheckBox.Size = new System.Drawing.Size(57, 17);
            this.nodesCheckBox.TabIndex = 10;
            this.nodesCheckBox.Text = "Nodes";
            this.nodesCheckBox.UseVisualStyleBackColor = true;
            this.nodesCheckBox.CheckedChanged += new System.EventHandler(this.nodesCheckBox_CheckedChanged);
            // 
            // nodeLimitTextBox
            // 
            this.nodeLimitTextBox.Location = new System.Drawing.Point(316, 130);
            this.nodeLimitTextBox.Name = "nodeLimitTextBox";
            this.nodeLimitTextBox.Size = new System.Drawing.Size(50, 20);
            this.nodeLimitTextBox.TabIndex = 11;
            this.nodeLimitTextBox.Visible = false;
            this.nodeLimitTextBox.Validated += new System.EventHandler(this.nodeLimitTextBox_Validated);
            // 
            // nodeLimitLabel
            // 
            this.nodeLimitLabel.AutoSize = true;
            this.nodeLimitLabel.Location = new System.Drawing.Point(282, 132);
            this.nodeLimitLabel.Name = "nodeLimitLabel";
            this.nodeLimitLabel.Size = new System.Drawing.Size(28, 13);
            this.nodeLimitLabel.TabIndex = 73;
            this.nodeLimitLabel.Text = "Limit";
            this.nodeLimitLabel.Visible = false;
            // 
            // nodeDrawLabel
            // 
            this.nodeDrawLabel.AutoSize = true;
            this.nodeDrawLabel.Location = new System.Drawing.Point(381, 132);
            this.nodeDrawLabel.Name = "nodeDrawLabel";
            this.nodeDrawLabel.Size = new System.Drawing.Size(32, 13);
            this.nodeDrawLabel.TabIndex = 74;
            this.nodeDrawLabel.Text = "Draw";
            this.nodeDrawLabel.Visible = false;
            // 
            // nodeDrawComboBox
            // 
            this.nodeDrawComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nodeDrawComboBox.Enabled = false;
            this.nodeDrawComboBox.FormattingEnabled = true;
            this.nodeDrawComboBox.Items.AddRange(new object[] {
            "None",
            "Path",
            "Circuit",
            "Fan"});
            this.nodeDrawComboBox.Location = new System.Drawing.Point(419, 130);
            this.nodeDrawComboBox.Name = "nodeDrawComboBox";
            this.nodeDrawComboBox.Size = new System.Drawing.Size(57, 21);
            this.nodeDrawComboBox.TabIndex = 12;
            this.nodeDrawComboBox.Visible = false;
            this.nodeDrawComboBox.SelectionChangeCommitted += new System.EventHandler(this.nodeDrawComboBox_SelectionChangeCommitted);
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Location = new System.Drawing.Point(205, 64);
            this.label8.MaximumSize = new System.Drawing.Size(600, 2);
            this.label8.MinimumSize = new System.Drawing.Size(100, 2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(348, 2);
            this.label8.TabIndex = 77;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(206, 121);
            this.label5.MaximumSize = new System.Drawing.Size(600, 2);
            this.label5.MinimumSize = new System.Drawing.Size(100, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(348, 2);
            this.label5.TabIndex = 78;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Location = new System.Drawing.Point(206, 157);
            this.label9.MaximumSize = new System.Drawing.Size(600, 2);
            this.label9.MinimumSize = new System.Drawing.Size(100, 2);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(348, 2);
            this.label9.TabIndex = 79;
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Location = new System.Drawing.Point(206, 357);
            this.label10.MaximumSize = new System.Drawing.Size(600, 2);
            this.label10.MinimumSize = new System.Drawing.Size(100, 2);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(348, 2);
            this.label10.TabIndex = 80;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(208, 369);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 13);
            this.label11.TabIndex = 81;
            this.label11.Text = "Graphic Type";
            // 
            // graphicTypeComboBox
            // 
            this.graphicTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.graphicTypeComboBox.Enabled = false;
            this.graphicTypeComboBox.FormattingEnabled = true;
            this.graphicTypeComboBox.Items.AddRange(new object[] {
            "Rectangle",
            "Image File"});
            this.graphicTypeComboBox.Location = new System.Drawing.Point(285, 366);
            this.graphicTypeComboBox.Name = "graphicTypeComboBox";
            this.graphicTypeComboBox.Size = new System.Drawing.Size(86, 21);
            this.graphicTypeComboBox.TabIndex = 14;
            this.graphicTypeComboBox.SelectionChangeCommitted += new System.EventHandler(this.graphicTypeComboBox_SelectionChangeCommitted);
            // 
            // rectangleGraphicPanel
            // 
            this.rectangleGraphicPanel.Controls.Add(this.rectangleColorChooser);
            this.rectangleGraphicPanel.Controls.Add(this.label12);
            this.rectangleGraphicPanel.Location = new System.Drawing.Point(211, 393);
            this.rectangleGraphicPanel.Name = "rectangleGraphicPanel";
            this.rectangleGraphicPanel.Size = new System.Drawing.Size(343, 88);
            this.rectangleGraphicPanel.TabIndex = 83;
            // 
            // rectangleColorChooser
            // 
            this.rectangleColorChooser.Location = new System.Drawing.Point(51, 5);
            this.rectangleColorChooser.Name = "rectangleColorChooser";
            this.rectangleColorChooser.Size = new System.Drawing.Size(108, 28);
            this.rectangleColorChooser.TabIndex = 1;
            this.rectangleColorChooser.ColorChanged += new OrisonEditor.ColorChooser.ColorCallback(this.rectangleColorChooser_ColorChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Color";
            // 
            // imageFileGraphicPanel
            // 
            this.imageFileGraphicPanel.Controls.Add(this.imagePreviewer);
            this.imageFileGraphicPanel.Controls.Add(this.imageFileWarningLabel);
            this.imageFileGraphicPanel.Controls.Add(this.imageFileButton);
            this.imageFileGraphicPanel.Controls.Add(this.label13);
            this.imageFileGraphicPanel.Controls.Add(this.imageFileTextBox);
            this.imageFileGraphicPanel.Controls.Add(this.imageFileTiledCheckBox);
            this.imageFileGraphicPanel.Enabled = false;
            this.imageFileGraphicPanel.Location = new System.Drawing.Point(211, 393);
            this.imageFileGraphicPanel.Name = "imageFileGraphicPanel";
            this.imageFileGraphicPanel.Size = new System.Drawing.Size(343, 88);
            this.imageFileGraphicPanel.TabIndex = 15;
            this.imageFileGraphicPanel.Visible = false;
            // 
            // imagePreviewer
            // 
            this.imagePreviewer.Location = new System.Drawing.Point(4, 4);
            this.imagePreviewer.Name = "imagePreviewer";
            this.imagePreviewer.Size = new System.Drawing.Size(85, 81);
            this.imagePreviewer.TabIndex = 88;
            // 
            // imageFileWarningLabel
            // 
            this.imageFileWarningLabel.AutoSize = true;
            this.imageFileWarningLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.imageFileWarningLabel.Location = new System.Drawing.Point(263, 12);
            this.imageFileWarningLabel.Name = "imageFileWarningLabel";
            this.imageFileWarningLabel.Size = new System.Drawing.Size(77, 13);
            this.imageFileWarningLabel.TabIndex = 54;
            this.imageFileWarningLabel.Text = "Does not exist!";
            this.imageFileWarningLabel.Visible = false;
            // 
            // imageFileButton
            // 
            this.imageFileButton.Location = new System.Drawing.Point(231, 7);
            this.imageFileButton.Name = "imageFileButton";
            this.imageFileButton.Size = new System.Drawing.Size(27, 23);
            this.imageFileButton.TabIndex = 1;
            this.imageFileButton.Text = "...";
            this.imageFileButton.UseVisualStyleBackColor = true;
            this.imageFileButton.Click += new System.EventHandler(this.imageFileButton_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(92, 12);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 13);
            this.label13.TabIndex = 52;
            this.label13.Text = "File";
            // 
            // imageFileTextBox
            // 
            this.imageFileTextBox.Location = new System.Drawing.Point(120, 9);
            this.imageFileTextBox.Name = "imageFileTextBox";
            this.imageFileTextBox.ReadOnly = true;
            this.imageFileTextBox.Size = new System.Drawing.Size(105, 20);
            this.imageFileTextBox.TabIndex = 0;
            // 
            // imageFileTiledCheckBox
            // 
            this.imageFileTiledCheckBox.AutoSize = true;
            this.imageFileTiledCheckBox.Location = new System.Drawing.Point(102, 39);
            this.imageFileTiledCheckBox.Name = "imageFileTiledCheckBox";
            this.imageFileTiledCheckBox.Size = new System.Drawing.Size(75, 17);
            this.imageFileTiledCheckBox.TabIndex = 2;
            this.imageFileTiledCheckBox.Text = "Tile Image";
            this.imageFileTiledCheckBox.UseVisualStyleBackColor = true;
            this.imageFileTiledCheckBox.CheckedChanged += new System.EventHandler(this.imageFileTiledCheckBox_CheckedChanged);
            // 
            // valuesEditor
            // 
            this.valuesEditor.Enabled = false;
            this.valuesEditor.Location = new System.Drawing.Point(211, 163);
            this.valuesEditor.Name = "valuesEditor";
            this.valuesEditor.Size = new System.Drawing.Size(343, 193);
            this.valuesEditor.TabIndex = 13;
            this.valuesEditor.Title = "Values";
            // 
            // nodeGhostCheckBox
            // 
            this.nodeGhostCheckBox.AutoSize = true;
            this.nodeGhostCheckBox.Checked = true;
            this.nodeGhostCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.nodeGhostCheckBox.Location = new System.Drawing.Point(494, 131);
            this.nodeGhostCheckBox.Name = "nodeGhostCheckBox";
            this.nodeGhostCheckBox.Size = new System.Drawing.Size(54, 17);
            this.nodeGhostCheckBox.TabIndex = 84;
            this.nodeGhostCheckBox.Text = "Ghost";
            this.nodeGhostCheckBox.UseVisualStyleBackColor = true;
            this.nodeGhostCheckBox.CheckedChanged += new System.EventHandler(this.nodeGhostCheckBox_CheckedChanged);
            // 
            // EntityDefinitionsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nodeGhostCheckBox);
            this.Controls.Add(this.imageFileGraphicPanel);
            this.Controls.Add(this.rectangleGraphicPanel);
            this.Controls.Add(this.graphicTypeComboBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.nodeDrawComboBox);
            this.Controls.Add(this.nodeDrawLabel);
            this.Controls.Add(this.nodeLimitLabel);
            this.Controls.Add(this.nodeLimitTextBox);
            this.Controls.Add(this.nodesCheckBox);
            this.Controls.Add(this.valuesEditor);
            this.Controls.Add(this.originYTextBox);
            this.Controls.Add(this.originXTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.sizeYTextBox);
            this.Controls.Add(this.rotationIncrementLabel);
            this.Controls.Add(this.rotationIncrementTextBox);
            this.Controls.Add(this.rotatableCheckBox);
            this.Controls.Add(this.resizableYCheckBox);
            this.Controls.Add(this.resizableXCheckBox);
            this.Controls.Add(this.limitTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.sizeXTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.moveDownButton);
            this.Controls.Add(this.moveUpButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Name = "EntityDefinitionsEditor";
            this.Size = new System.Drawing.Size(573, 490);
            this.rectangleGraphicPanel.ResumeLayout(false);
            this.rectangleGraphicPanel.PerformLayout();
            this.imageFileGraphicPanel.ResumeLayout(false);
            this.imageFileGraphicPanel.PerformLayout();
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox sizeXTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox limitTextBox;
        private System.Windows.Forms.CheckBox resizableXCheckBox;
        private System.Windows.Forms.CheckBox resizableYCheckBox;
        private System.Windows.Forms.CheckBox rotatableCheckBox;
        private System.Windows.Forms.TextBox rotationIncrementTextBox;
        private System.Windows.Forms.Label rotationIncrementLabel;
        private System.Windows.Forms.TextBox sizeYTextBox;
        private System.Windows.Forms.TextBox originYTextBox;
        private System.Windows.Forms.TextBox originXTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private ValueDefinitionsEditor valuesEditor;
        private System.Windows.Forms.CheckBox nodesCheckBox;
        private System.Windows.Forms.TextBox nodeLimitTextBox;
        private System.Windows.Forms.Label nodeLimitLabel;
        private System.Windows.Forms.Label nodeDrawLabel;
        private System.Windows.Forms.ComboBox nodeDrawComboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox graphicTypeComboBox;
        private System.Windows.Forms.Panel rectangleGraphicPanel;
        private ColorChooser rectangleColorChooser;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel imageFileGraphicPanel;
        private System.Windows.Forms.Label imageFileWarningLabel;
        private System.Windows.Forms.Button imageFileButton;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox imageFileTextBox;
        private System.Windows.Forms.CheckBox imageFileTiledCheckBox;
        private ImagePreviewer imagePreviewer;
        private System.Windows.Forms.CheckBox nodeGhostCheckBox;
    }
}
