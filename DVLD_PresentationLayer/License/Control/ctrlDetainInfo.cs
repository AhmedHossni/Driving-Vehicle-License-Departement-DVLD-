using DVLD_BusinessLogicLayer;
using System;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.License.Control
{
    public partial class ctrlDetainInfo : UserControl
    {
        public decimal DetainFees => string.IsNullOrWhiteSpace(txtFineFees.Text)
            ? 0 : Convert.ToDecimal(txtFineFees.Text);
        public ctrlDetainInfo()
        {
            InitializeComponent();
        }

        public void LoadDefaultData()
        {
            lblDetainDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedByUser.Text = clsUser.SystemUser.Username;
            lblDetainID.Text = "[???]";
            lblLicenseID.Text = "[???]";
        }

        public void SetDetainID(int detainID)
        {
            lblDetainID.Text = detainID.ToString();
        }

        public void SetLicenseID(int licenseID)
        {
            lblLicenseID.Text = licenseID.ToString();
        }

        public void EnabledAddFees(bool isEnabled)
        {
            txtFineFees.Enabled = isEnabled;
        }

        private void txtFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
