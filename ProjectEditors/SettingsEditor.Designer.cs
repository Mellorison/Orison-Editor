using OrisonEditor.ProjectEditors.ValueDefinitionEditors;
namespace OrisonEditor.ProjectEditors
{
    partial class SettingsEditor
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
            this.maxHeightTextBox = new System.Windows.Forms.TextBox();
            this.maxWidthTextBox = new System.Windows.Forms.TextBox();
            this.minHeightTextBox = new System.Windows.Forms.TextBox();
            this.minWidthTextBox = new System.Windows.Forms.TextBox();
            this.defaultHeightTextBox = new System.Windows.Forms.TextBox();
            this.defaultWidthTextBox = new System.Windows.Forms.TextBox();
            this.projectNameTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.angleModeComboBox = new System.Windows.Forms.ComboBox();
            this.gridColorChooser = new OrisonEditor.ColorChooser();
            this.backgroundColorChooser = new OrisonEditor.ColorChooser();
            this.valuesEditor = new OrisonEditor.ProjectEditors.ValueDefinitionEditors.ValueDefinitionsEditor();
            this.colorChooser1 = new OrisonEditor.ColorChooser();
            this.label12 = new System.Windows.Forms.Label();
            this.cameraEnabledCheckbox = new System.Windows.Forms.CheckBox();
            this.cameraHeightTextBox = new System.Windows.Forms.TextBox();
            this.cameraWidthTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.exportCameraPositionCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // maxHeightTextBox
            // 
            this.maxHeightTextBox.Location = new System.Drawing.Point(207, 217);
            this.maxHeightTextBox.Name = "maxHeightTextBox";
            this.maxHeightTextBox.Size = new System.Drawing.Size(62, 20);
            this.maxHeightTextBox.TabIndex = 9;
            this.maxHeightTextBox.Validated += new System.EventHandler(this.maxWidthTextBox_TextChanged);
            // 
            // maxWidthTextBox
            // 
            this.maxWidthTextBox.Location = new System.Drawing.Point(121, 217);
            this.maxWidthTextBox.Name = "maxWidthTextBox";
            this.maxWidthTextBox.Size = new System.Drawing.Size(62, 20);
            this.maxWidthTextBox.TabIndex = 8;
            this.maxWidthTextBox.TextChanged += new System.EventHandler(this.maxWidthTextBox_TextChanged);
            // 
            // minHeightTextBox
            // 
            this.minHeightTextBox.Location = new System.Drawing.Point(207, 191);
            this.minHeightTextBox.Name = "minHeightTextBox";
            this.minHeightTextBox.Size = new System.Drawing.Size(62, 20);
            this.minHeightTextBox.TabIndex = 7;
            this.minHeightTextBox.Validated += new System.EventHandler(this.minWidthTextBox_Validated);
            // 
            // minWidthTextBox
            // 
            this.minWidthTextBox.Location = new System.Drawing.Point(121, 191);
            this.minWidthTextBox.Name = "minWidthTextBox";
            this.minWidthTextBox.Size = new System.Drawing.Size(62, 20);
            this.minWidthTextBox.TabIndex = 6;
            this.minWidthTextBox.Validated += new System.EventHandler(this.minWidthTextBox_Validated);
            // 
            // defaultHeightTextBox
            // 
            this.defaultHeightTextBox.Location = new System.Drawing.Point(207, 165);
            this.defaultHeightTextBox.Name = "defaultHeightTextBox";
            this.defaultHeightTextBox.Size = new System.Drawing.Size(62, 20);
            this.defaultHeightTextBox.TabIndex = 5;
            this.defaultHeightTextBox.Validated += new System.EventHandler(this.defaultWidthTextBox_Validated);
            // 
            // defaultWidthTextBox
            // 
            this.defaultWidthTextBox.Location = new System.Drawing.Point(121, 165);
            this.defaultWidthTextBox.Name = "defaultWidthTextBox";
            this.defaultWidthTextBox.Size = new System.Drawing.Size(62, 20);
            this.defaultWidthTextBox.TabIndex = 4;
            this.defaultWidthTextBox.Validated += new System.EventHandler(this.defaultWidthTextBox_Validated);
            // 
            // projectNameTextBox
            // 
            this.projectNameTextBox.Location = new System.Drawing.Point(131, 13);
            this.projectNameTextBox.Name = "projectNameTextBox";
            this.projectNameTextBox.Size = new System.Drawing.Size(197, 20);
            this.projectNameTextBox.TabIndex = 0;
            this.projectNameTextBox.Validated += new System.EventHandler(this.projectNameTextBox_Validated);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(64, 220);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "Maximum";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(67, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Minimum";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(74, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Default";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(59, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Level Size";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(189, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "x";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(189, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "x";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "x";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Project Name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(33, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "Background Color";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(72, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 37;
            this.label10.Text = "Grid Color";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(59, 106);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 13);
            this.label11.TabIndex = 39;
            this.label11.Text = "Angle Export";
            // 
            // angleModeComboBox
            // 
            this.angleModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.angleModeComboBox.FormattingEnabled = true;
            this.angleModeComboBox.Items.AddRange(new object[] {
            "Radians",
            "Degrees"});
            this.angleModeComboBox.Location = new System.Drawing.Point(131, 103);
            this.angleModeComboBox.Name = "angleModeComboBox";
            this.angleModeComboBox.Size = new System.Drawing.Size(80, 21);
            this.angleModeComboBox.TabIndex = 3;
            this.angleModeComboBox.SelectionChangeCommitted += new System.EventHandler(this.angleModeComboBox_SelectionChangeCommitted);
            // 
            // gridColorChooser
            // 
            this.gridColorChooser.Location = new System.Drawing.Point(127, 68);
            this.gridColorChooser.Name = "gridColorChooser";
            this.gridColorChooser.Size = new System.Drawing.Size(108, 28);
            this.gridColorChooser.TabIndex = 2;
            this.gridColorChooser.ColorChanged += new OrisonEditor.ColorChooser.ColorCallback(this.gridColorChooser_ColorChanged);
            // 
            // backgroundColorChooser
            // 
            this.backgroundColorChooser.Location = new System.Drawing.Point(127, 39);
            this.backgroundColorChooser.Name = "backgroundColorChooser";
            this.backgroundColorChooser.Size = new System.Drawing.Size(108, 28);
            this.backgroundColorChooser.TabIndex = 1;
            this.backgroundColorChooser.ColorChanged += new OrisonEditor.ColorChooser.ColorCallback(this.backgroundColorChooser_ColorChanged);
            // 
            // valuesEditor
            // 
            this.valuesEditor.Location = new System.Drawing.Point(57, 260);
            this.valuesEditor.Name = "valuesEditor";
            this.valuesEditor.Size = new System.Drawing.Size(341, 191);
            this.valuesEditor.TabIndex = 13;
            this.valuesEditor.Title = "Level Values";
            // 
            // colorChooser1
            // 
            this.colorChooser1.Location = new System.Drawing.Point(127, 57);
            this.colorChooser1.Name = "colorChooser1";
            this.colorChooser1.Size = new System.Drawing.Size(108, 28);
            this.colorChooser1.TabIndex = 36;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(332, 144);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 41;
            this.label12.Text = "Camera";
            // 
            // cameraEnabledCheckbox
            // 
            this.cameraEnabledCheckbox.AutoSize = true;
            this.cameraEnabledCheckbox.Location = new System.Drawing.Point(350, 164);
            this.cameraEnabledCheckbox.Name = "cameraEnabledCheckbox";
            this.cameraEnabledCheckbox.Size = new System.Drawing.Size(65, 17);
            this.cameraEnabledCheckbox.TabIndex = 10;
            this.cameraEnabledCheckbox.Text = "Enabled";
            this.cameraEnabledCheckbox.UseVisualStyleBackColor = true;
            this.cameraEnabledCheckbox.CheckedChanged += new System.EventHandler(this.cameraEnabledCheckbox_CheckedChanged);
            // 
            // cameraHeightTextBox
            // 
            this.cameraHeightTextBox.Location = new System.Drawing.Point(466, 187);
            this.cameraHeightTextBox.Name = "cameraHeightTextBox";
            this.cameraHeightTextBox.Size = new System.Drawing.Size(62, 20);
            this.cameraHeightTextBox.TabIndex = 12;
            this.cameraHeightTextBox.Validated += new System.EventHandler(this.cameraWidthTextBox_Validated);
            // 
            // cameraWidthTextBox
            // 
            this.cameraWidthTextBox.Location = new System.Drawing.Point(380, 187);
            this.cameraWidthTextBox.Name = "cameraWidthTextBox";
            this.cameraWidthTextBox.Size = new System.Drawing.Size(62, 20);
            this.cameraWidthTextBox.TabIndex = 11;
            this.cameraWidthTextBox.Validated += new System.EventHandler(this.cameraWidthTextBox_Validated);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(347, 190);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(27, 13);
            this.label13.TabIndex = 46;
            this.label13.Text = "Size";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(448, 190);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(12, 13);
            this.label14.TabIndex = 45;
            this.label14.Text = "x";
            // 
            // exportCameraPositionCheckbox
            // 
            this.exportCameraPositionCheckbox.AutoSize = true;
            this.exportCameraPositionCheckbox.Location = new System.Drawing.Point(368, 216);
            this.exportCameraPositionCheckbox.Name = "exportCameraPositionCheckbox";
            this.exportCameraPositionCheckbox.Size = new System.Drawing.Size(135, 17);
            this.exportCameraPositionCheckbox.TabIndex = 47;
            this.exportCameraPositionCheckbox.Text = "Export Camera Position";
            this.exportCameraPositionCheckbox.UseVisualStyleBackColor = true;
            this.exportCameraPositionCheckbox.CheckedChanged += new System.EventHandler(this.exportCameraPositionCheckbox_CheckedChanged);
            // 
            // SettingsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.exportCameraPositionCheckbox);
            this.Controls.Add(this.cameraHeightTextBox);
            this.Controls.Add(this.cameraWidthTextBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cameraEnabledCheckbox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.angleModeComboBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.gridColorChooser);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.backgroundColorChooser);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.valuesEditor);
            this.Controls.Add(this.maxHeightTextBox);
            this.Controls.Add(this.maxWidthTextBox);
            this.Controls.Add(this.minHeightTextBox);
            this.Controls.Add(this.minWidthTextBox);
            this.Controls.Add(this.defaultHeightTextBox);
            this.Controls.Add(this.defaultWidthTextBox);
            this.Controls.Add(this.projectNameTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SettingsEditor";
            this.Size = new System.Drawing.Size(573, 490);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox maxHeightTextBox;
        private System.Windows.Forms.TextBox maxWidthTextBox;
        private System.Windows.Forms.TextBox minHeightTextBox;
        private System.Windows.Forms.TextBox minWidthTextBox;
        private System.Windows.Forms.TextBox defaultHeightTextBox;
        private System.Windows.Forms.TextBox defaultWidthTextBox;
        private System.Windows.Forms.TextBox projectNameTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ValueDefinitionsEditor valuesEditor;
        private System.Windows.Forms.Label label9;
        private ColorChooser backgroundColorChooser;
        private ColorChooser colorChooser1;
        private System.Windows.Forms.Label label10;
        private ColorChooser gridColorChooser;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox angleModeComboBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox cameraEnabledCheckbox;
        private System.Windows.Forms.TextBox cameraHeightTextBox;
        private System.Windows.Forms.TextBox cameraWidthTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox exportCameraPositionCheckbox;
    }
}
