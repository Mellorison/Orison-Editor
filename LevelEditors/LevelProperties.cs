using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OrisonEditor.LevelData;
using OrisonEditor.LevelData.Layers;
using OrisonEditor.LevelEditors.ValueEditors;
using OrisonEditor.LevelEditors.Actions.LevelActions;

namespace OrisonEditor.LevelEditors
{
    public partial class LevelProperties : Form
    {
        private Level level;
        private List<string> oldValues;

        public LevelProperties(Level level)
        {
            this.level = level;
            InitializeComponent();

            //Init textboxes
            sizeXTextBox.Text = level.Size.Width.ToString();
            sizeYTextBox.Text = level.Size.Height.ToString();
            minSizeLabel.Text = "Minimum Size: " + level.Project.LevelMinimumSize.Width + " x " + level.Project.LevelMinimumSize.Height;
            maxSizeLabel.Text = "Maximum Size: " + level.Project.LevelMaximumSize.Width + " x " + level.Project.LevelMaximumSize.Height;

            //Values
            int yy = 100;
            if (level.Values != null)
            {
                //Store the old values
                oldValues = new List<string>(level.Values.Count);
                foreach (var v in level.Values)
                    oldValues.Add(v.Content);

                //Create the editors
                ValueEditor ed;              
                foreach (var v in level.Values)
                {
                    ed = v.Definition.GetInstanceLevelEditor(v, ClientSize.Width / 2 - 150, yy);
                    Controls.Add(ed);
                    yy += ed.Height;
                }
            }

            //Resize the form
            ClientSize = new Size(ClientSize.Width, yy + 52);
            applyButton.Location = new Point(applyButton.Location.X, ClientSize.Height - 40);
            cancelButton.Location = new Point(cancelButton.Location.X, ClientSize.Height - 40);
        }

        private void LevelProperties_FormClosed(object sender, FormClosedEventArgs e)
        {
            Orison.MainWindow.EnableEditing();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            //Restore values to what they were
            if (level.Values != null)
            {
                for (int i = 0; i < level.Values.Count; i++)
                    level.Values[i].Content = oldValues[i];
            }

            Close();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            //Resize the level?
            Size s = level.Size;
            OrisonParse.Parse(ref s, sizeXTextBox, sizeYTextBox);
            if (s != level.Size)
                Orison.MainWindow.LevelEditors[Orison.CurrentLevelIndex].Perform(new LevelResizeAction(level, s));

            Close();
        }

        private void LevelProperties_Load(object sender, EventArgs e)
        {

        }
    }
}
