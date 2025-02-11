using System;
using System.Windows.Forms;
using UnifiedAutomation.UaBase;

namespace UnifiedAutomation.Sample.Forms
{
    public partial class AddUserIdentityDialog : Form
    {
        public AddUserIdentityDialog()
        {
            InitializeComponent();
            Icon = GuiUtils.GetDefaultIcon();
        }

        private void SetBTN_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void CancelBTN_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
