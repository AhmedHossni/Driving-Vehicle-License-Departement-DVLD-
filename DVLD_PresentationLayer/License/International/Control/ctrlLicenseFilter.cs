using DVLD_BusinessLogicLayer;
using System;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.License.International.Control
{
    public partial class ctrlLicenseFilter : UserControl
    {
        public class SearchEventArgs : EventArgs
        {
            public readonly int LocalLicenseID;
            public readonly int ApplicationID;
            public readonly int LocalDLAppID;
            public readonly int LicenseClassID;
            public readonly int DriverID;
            public readonly bool IsActive;
            public readonly int PersonID;

            public SearchEventArgs(int localLicenseID, int applicationID, int localDLAppID, 
                int licenseClassID, int driverID, bool isActive, int personID)
            {
                LocalLicenseID = localLicenseID;
                ApplicationID = applicationID;
                LocalDLAppID = localDLAppID;
                LicenseClassID = licenseClassID;
                DriverID = driverID;
                IsActive = isActive;
                PersonID = personID;
            }
        }

        public event EventHandler<SearchEventArgs> OnSearchDone;

        public ctrlLicenseFilter()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != string.Empty)
                SearchForLicense(Convert.ToInt32(textBox1.Text));
        }

        private bool SearchForLicense(int localLicenseID)
        {
            int applicationID = -1;
            int localDLAppID = -1;
            int licenseClassID = -1;
            int driverID = -1;
            bool isActive = false;
            int personID = -1;

            string err = string.Empty;

            if (clsLicense.GetLicenseInfoByID(localLicenseID,
                ref applicationID, ref localDLAppID,
                ref licenseClassID, ref driverID, ref isActive, ref personID,
                out err))
            {
                OnSearchDone?.Invoke
                    (this, 
                    new SearchEventArgs
                    (localLicenseID, applicationID, localDLAppID,
                    licenseClassID, driverID,
                    isActive, personID));

                return true;
            }
            else
            {
                OnSearchDone?.Invoke(this, null);

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

           if (textBox1.Text.Length >= int.MaxValue.ToString().Length -1
                && e.KeyChar != (char)Keys.Back
                && e.KeyChar != (char)Keys.Enter)
                e.Handled = true;

            if (e.KeyChar == ((char)Keys.Enter))
                btnSearch_Click(btnSearch, e);
        }
    }
}
