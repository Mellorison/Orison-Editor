using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OrisonEditor.Windows
{
    public partial class AboutWindow : Form
    {
        public AboutWindow()
        {
            InitializeComponent();

            versionLabel.Text = "Mutated XPlatform";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            Orison.MainWindow.Activate();
            Orison.MainWindow.EnableEditing();
        }

        /*private void donateButton_Click(object sender, EventArgs e)
        {
            Orison.DonationLink();
        }*/

        private void websiteButton_Click(object sender, EventArgs e)
        {
            Orison.WebsiteLink();
        }
    }
}
