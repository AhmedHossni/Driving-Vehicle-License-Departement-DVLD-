using CommonUseThings;
using DVLD_BusinessLogicLayer;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.License.Control
{
    public partial class ctrlReleaseDetainedLicenseInfo : UserControl
    {
        public ctrlReleaseDetainedLicenseInfo()
        {
            InitializeComponent();
        }

        public bool LoadDetainData(int licenseID)
        {
            if(clsDetainedLicense.GetBy(licenseID,
                out string errorMessage) is clsDetainedLicense detainedLicense)
            {
                lblLicenseID.Text = licenseID.ToString();

                lblDetainID.Text = detainedLicense.DetainID.ToString();

                lblDetainDate.Text = detainedLicense.DetainDate.ToShortDateString();

                lblFineFees.Text = detainedLicense.FineFees != 0 
                    ? detainedLicense.FineFees.ToString("0.0") : "0";

                decimal applicationFees = SetLabelApplicationFees(out bool isOperationDoneSucessfully);

                if(!isOperationDoneSucessfully)
                    return false;

                lblTotalFees.Text = (detainedLicense.FineFees + applicationFees) != 0 
                    ? (detainedLicense.FineFees + applicationFees).ToString("0.0") : "0";

                 if(!SetCreateByUsername(detainedLicense.CreatedByUserID))
                    return false;

                return true;
            }
            else
            {

                MessageBox.Show(errorMessage, "Error Message",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }

        public void SetApplicationID(int applicationID)
        {
            lblApplicationID.Text = applicationID.ToString();
        }


        private bool SetCreateByUsername(int userID)
        {
            if (clsUser.GetBy(userID,
                out string errorMessage) is clsUser user)
            {
                lblCreatedByUser.Text = user.Username;
                return true;
            }
            else
            {
                if (!string.IsNullOrEmpty(errorMessage))
                    MessageBox.Show(errorMessage, "Error Message",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("An error occurred while loading the data for the user who stop this license", "Error Message",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }

        private decimal SetLabelApplicationFees(out bool isOperationDoneSucessfully)
        {
            if(clsApplicationType.GetBy((int)enApplicationTypes.ReleaseDetailedDrivingLicense, 
                out string errorMessage) is clsApplicationType applicationType)
            {
                lblApplicationFees.Text 
                    = applicationType.Fees.ToString("0.0");

                isOperationDoneSucessfully = true;

                return applicationType.Fees;
            }
            else
            {
                if(!string.IsNullOrEmpty(errorMessage))
                    MessageBox.Show(errorMessage, "Error Message",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Error occers when load fees data from database", "Error Message",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                isOperationDoneSucessfully = false;

                return 0;
            }
        }
    }
}
