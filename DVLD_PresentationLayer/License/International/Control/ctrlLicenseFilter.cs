using DVLD_BusinessLogicLayer;
using System;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.License.International.Control
{
    public partial class ctrlLicenseFilter : UserControl
    {
        public class SearchEventArgs : EventArgs
        {
            public readonly int applicationID;
            public readonly int localDLAppID;
            public readonly int licenseClassID;
            public readonly int driverID;

            public SearchEventArgs(int applicationID, int localDLAppID, int licenseClassID, int driverID)
            {
                this.applicationID = applicationID;
                this.localDLAppID = localDLAppID;
                this.licenseClassID = licenseClassID;
                this.driverID = driverID;
            }
        }

        public event EventHandler<SearchEventArgs> OnSearchDone;

        public ctrlLicenseFilter()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchForLicense(Convert.ToInt32(textBox1.Text));
        }

        private bool SearchForLicense(int localLicenseID)
        {
            int applicationID = -1;
            int localDLAppID = -1;
            int licenseClassID = -1;
            int driverID = -1;

            string err = string.Empty;

            if (clsLicense.GetLicenseInfoByID(localLicenseID,
                ref applicationID, ref localDLAppID, ref licenseClassID, ref driverID,
                out err))
            {
                MessageBox.Show($"License found!\n" +
                    $"Application ID: {applicationID}\nLocal DL App ID: {localDLAppID}");

                OnSearchDone?.Invoke
                    (this, 
                    new SearchEventArgs(applicationID, localDLAppID, licenseClassID, driverID));

                return true;
            }
            else
            {
                if (!string.IsNullOrEmpty(err))
                {
                    MessageBox.Show("Error : " + err);
                }
                else
                {
                    MessageBox.Show("No License with this driving license id.");
                }
                return false;
            }
        }

        private void tboxSearchBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
