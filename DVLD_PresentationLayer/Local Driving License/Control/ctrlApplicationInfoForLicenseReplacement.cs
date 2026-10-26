using DVLD_BusinessLogicLayer;
using System;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.Local_Driving_License.Control
{
    public partial class ctrlApplicationInfoForLicenseReplacement : UserControl
    {
        public ctrlApplicationInfoForLicenseReplacement()
        {
            InitializeComponent();
        }

        public void LoadDefaultData(int applicationTypeID)
        {
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();

            lblCreatedBy.Text = clsUser.SystemUser.Username;

            SetApplicationFees(applicationTypeID);
        }

        public void SetApplicationFees(int applicationTypeID)
        {
            decimal renewLicenseApplicationFees = GetApplicationFees(applicationTypeID);

            lblApplicationFees.Text = renewLicenseApplicationFees == 0
                ? lblApplicationFees.Text : renewLicenseApplicationFees.ToString("0.0");
        }

        private decimal GetApplicationFees(int applicationTypeID)
        {
            if (clsApplicationType.GetBy(applicationTypeID,
                out string errorMessage) is clsApplicationType applicationType)
            {
                return applicationType.Fees;
            }
            else
            {
                string errorText = string.IsNullOrEmpty(errorMessage) 
                    ? "Application Type Not Found." : errorMessage;
                MessageBox.Show(errorText, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public void SetOldLicenseID(int oldLicenseID)
        {
            if(oldLicenseID != -1)
                lblOldLicenseID.Text = oldLicenseID.ToString();
        }

        public void SetNewLicenseInfo(int newLicenseApplicationID, int newLicenseID)
        {
            if (newLicenseApplicationID != -1)
                lblLRApplicationID.Text = newLicenseApplicationID.ToString();

            if (newLicenseID != -1)
                lblReplacedLicenseID.Text = newLicenseID.ToString();
        }
    }
}
