using CommonUseThings;
using DVLD_BusinessLogicLayer;
using System;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.Application.Control
{
    public partial class ctrlApplicationNewLicenseInfo : UserControl
    {
        public string Notes => rtboxNotes.Text;

        public ctrlApplicationNewLicenseInfo()
        {
            InitializeComponent();
        }

        private void LoadDefaultControlData()
        {
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();

            lblIssueDate.Text = DateTime.Now.ToShortDateString();

            lblCreatedBy.Text = clsUser.SystemUser.Username;

            decimal renewLicenseApplicationFees = GetApplicationFees();
            lblApplicationFees.Text = renewLicenseApplicationFees == 0 
                ? lblApplicationFees.Text : renewLicenseApplicationFees.ToString("0.0");
        }

        private decimal GetApplicationFees()
        {
            if(clsApplicationType.GetBy((int)enApplicationTypes.RenewDrivingLicenseService,
                out string errorMessage) is clsApplicationType applicationType)
            {
                return applicationType.Fees;
            }
            else
            {
                string errorText = string.IsNullOrEmpty(errorMessage) ? "Application Type Not Found." : errorMessage;
                MessageBox.Show(errorText, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public void LoadRenewLocalLicenseData(int oldLocalLicenseID, int localLicenseClass)
        {
            if(oldLocalLicenseID == -1)
            {
                LoadDefaultControlData();
                return;
            }

            decimal lPaidFees = 0;
            decimal appPaidFees = 0;
            DateTime applicationDate = DateTime.Now;
            DateTime issueDate = DateTime.Now;
            DateTime expirationDate = DateTime.Now;
            string createBy = string.Empty;
            string errorMessage = string.Empty;

            bool isFound = clsLicense.GetLicenseInfoByID(
                oldLocalLicenseID,
                ref lPaidFees,
                ref appPaidFees,
                ref applicationDate,
                ref issueDate,
                ref expirationDate,
                ref createBy,
                out errorMessage
            );

            if (isFound)
            {
                if(decimal.TryParse(lblApplicationFees.Text, out decimal rappFees))
                    lblTotalFees.Text = (lPaidFees + rappFees).ToString("0.0");

                lblOldLicenseID.Text = oldLocalLicenseID.ToString();
                lblLiceseFees.Text = lPaidFees.ToString("0.0");              
                lblApplicationDate.Text = DateTime.Now.ToShortDateString();
                lblIssueDate.Text = DateTime.Now.ToShortDateString();
                SetExpirationDate(localLicenseClass, DateTime.Now);
                lblCreatedBy.Text = clsUser.SystemUser.Username;

            }
            else
            {
                string errorText = string.IsNullOrEmpty(errorMessage) ? "License not found." : errorMessage;
                MessageBox.Show(errorText, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetExpirationDate(int oldLocalLicenseClass, DateTime issueDate)
        {
            if(clsLicenseClass.Find(oldLocalLicenseClass) is clsLicenseClass licenseClass)
            {
                int defaultValidityLength =  Convert.ToInt32(licenseClass.DefaultValidityLength);

                lblExpirationDate.Text 
                    = issueDate.AddYears(defaultValidityLength).ToShortDateString();
            }    
        }

        public void SetSavedData(int rLicenseAppID, int rLicenseID)
        {
            lblRLApplictionID.Text = rLicenseAppID.ToString();
            lblRenewLicenseID.Text = rLicenseID.ToString();
        }
    }
}
