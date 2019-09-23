using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OrisonEditor.Windows.Utilities
{
    public class UtilityForm : Form
    {
        public UtilityForm()
        {
            FormClosed += OnFormClosed;
            Orison.OnProjectClose += OnProjectClose;
        }

        private void OnProjectClose(Project project)
        {
            Close();
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            Orison.OnProjectClose -= OnProjectClose;
        }
    }
}
