using CommonUseThings;
using DVLD_BusinessLogicLayer;
using System;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.Application.Control
{
    public partial class ctrlInternationalDrivingLicenseApplicationInfo : UserControl
    {
        public ctrlInternationalDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        public void LoadInternationalLicenseData(int driverID)
        {
            if (driverID == -1)
            {
                LoadCtrlDefaultData();
                return;
            }

            LoadInternationalLicenseDataBy(driverID);
        }

        private void LoadInternationalLicenseDataBy(int driverID)
        {
            int internationalLicenseID = -1;
            int applicationID = -1;
            int issuedUsingLocalLicenseID = -1;
            DateTime issueDate = DateTime.MinValue;
            DateTime expirationDate = DateTime.MinValue;
            bool isActive = false;
            int createdByUserID = -1;
            string errorMessage = string.Empty;

            bool isFound = clsInternationalLicense.GetInternationalLicenseInfoByDriverID(
                driverID,
                out internationalLicenseID,
                out applicationID,
                out issuedUsingLocalLicenseID,
                out issueDate,
                out expirationDate,
                out isActive,
                out createdByUserID,
                out errorMessage
            );

            if (isFound)
            {
                lblILAppIDValue.Text = applicationID.ToString();

                lblApplicationDateValue.Text
                    = clsApplication.GetBy(applicationID, out string errMessage)
                    ?.ApplicationDate.ToShortDateString();

                lblIssueDateValue.Text = issueDate.ToShortDateString();

                lblFeesValue.Text = clsApplicationType.GetBy
                    ((int)enApplicationTypes.NewInternationalLicense,out errMessage)?.Fees.ToString("0.0");

                lblInternationalLicenseIDValue.Text = internationalLicenseID.ToString();

                lblLocalLicenseIDValue.Text = issuedUsingLocalLicenseID.ToString();

                lblExpirationDateValue.Text = expirationDate.ToShortDateString();

                lblCreatedByValue.Text = clsUser.SystemUser.Username;
            }
            else
            {
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    frmMainStyle.HandleErrorMessage(ref errorMessage, "Failed Process :(");
                }
                else
                {
                    MessageBox.Show("No international license found for this driver.",
                        "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void LoadCtrlDefaultData()
        {
            lblApplicationDateValue.Text = DateTime.Now.ToShortDateString();
            lblIssueDateValue.Text = DateTime.Now.ToShortDateString();
            lblExpirationDateValue.Text = DateTime.Now.AddYears(1).ToShortDateString();

            lblFeesValue.Text = clsApplicationType.GetBy((int)enApplicationTypes.NewInternationalLicense,
                out string errorMessage)?.Fees.ToString("0.0");

            lblCreatedByValue.Text = clsUser.SystemUser.Username;
        }

        public void SetLocalLicenseID(int localLicenseID)
        {
            lblLocalLicenseIDValue.Text 
                = localLicenseID.ToString();
        }

        public void SetApplicationID(int ilApplicationID,
            int iLicenseID)
        {
            lblInternationalLicenseIDValue.Text 
                = iLicenseID.ToString();

            lblILAppIDValue.Text 
                = ilApplicationID.ToString();
        }
    }
}
