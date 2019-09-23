using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using OrisonEditor.LevelData;

namespace OrisonEditor.Windows.Utilities
{
    public partial class ShiftRenameLevelsWindow : UtilityForm
    {
        public ShiftRenameLevelsWindow()
        {
            InitializeComponent();
        }

        private void performButton_Click(object sender, EventArgs e)
        {
            int shift = (int)shiftUpDown.Value;
            int min = (int)rangeMinUpDown.Value;
            int max = (int)rangeMaxUpDown.Value;
            bool overwrite = overwriteCheckbox.Checked;
            string pattern = patternTextbox.Text;

            //Error if shift is 0
            if (shift == 0)
            {
                MessageBox.Show(this, "Shift amount cannot be zero!", "Shift Renamer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Find which files will be shifted
            List<int> toShift = new List<int>();
            int overwrites = 0;
            {
                int sign = Math.Sign(shift);
                int start = sign == 1 ? max : min;
                int end = sign == 1 ? min - 1 : max + 1;
                for (int i = start; i != end; i -= sign)
                {
                    string match = pattern.Replace("#", i.ToString());
                    if (File.Exists(Path.Combine(Orison.Project.SavedDirectory, match)))
                    {
                        if (toShift.Contains(i + shift) || !File.Exists(Path.Combine(Orison.Project.SavedDirectory, pattern.Replace("#", (i + shift).ToString()))))
                            toShift.Add(i);
                        else
                        {
                            if (overwrite)
                                toShift.Add(i);
                            overwrites++;
                        }
                    }
                }
            }

            //Escape if no levels are shiftable
            if (toShift.Count == 0)
            {
                string msg = (overwrites > 0) ? "All levels that match the criteria would result in overwrites!" : "No levels found that match the given criteria!";
                MessageBox.Show(this, msg, "Shift Renamer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Show analysis results
            DialogResult result = MessageBox.Show(this, toShift.Count + " level(s) will be renamed and " + overwrites.ToString() + " level(s) will be overwritten.\nWould you like to continue? There is no undo for this action!", "Shift Renamer", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result != System.Windows.Forms.DialogResult.Yes)
                return;

            //Close involved levels
            foreach (int i in toShift)
            {
                string source = Path.Combine(Orison.Project.SavedDirectory, pattern.Replace("#", i.ToString()));
                string dest = Path.Combine(Orison.Project.SavedDirectory, pattern.Replace("#", (i + shift).ToString()));

                if (!Orison.CloseLevelByFilepath(source) || !Orison.CloseLevelByFilepath(dest))
                    return;
            }

            //Do the renaming!
            for (int i = 0; i < toShift.Count; i++)
            {
                //Figure out the file paths
                string source = Path.Combine(Orison.Project.SavedDirectory, pattern.Replace("#", toShift[i].ToString()));
                string dest = Path.Combine(Orison.Project.SavedDirectory, pattern.Replace("#", (toShift[i] + shift).ToString()));

                //Close the levels if they're open
                Orison.CloseLevelByFilepath(source);
                Orison.CloseLevelByFilepath(dest);
                
                //Rename it
                File.Copy(source, dest, overwrite);
                File.Delete(source);
            }
        }

        private void rangeMinUpDown_ValueChanged(object sender, EventArgs e)
        {
            rangeMaxUpDown.Value = Math.Max(rangeMinUpDown.Value, rangeMaxUpDown.Value);
        }

        private void rangeMaxUpDown_ValueChanged(object sender, EventArgs e)
        {
            rangeMinUpDown.Value = Math.Min(rangeMinUpDown.Value, rangeMaxUpDown.Value);           
        }
    }
}
