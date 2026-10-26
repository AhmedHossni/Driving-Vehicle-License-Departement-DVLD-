using Driving___Vehicle_License_Departement__DVLD_.License;
using DVLD_BusinessLogicLayer;
using System;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.Local_Driving_License.Control
{
    public partial class ctrlLocalDrivingLicenseApplicationBasicInfo : UserControl
    {
        int _localDrivingLicenseAppID = -1;
        public ctrlLocalDrivingLicenseApplicationBasicInfo()
        {
            InitializeComponent();
        }

        public void LoadLocalDLAppFormInfo(int localDLAppId)
        {
            string appliedForLicense = null;
            int passedTest = 0;

            if (clsLocalDrivingLicenseApplication.GetBasicInfoBy(localDLAppId, ref appliedForLicense,
                ref passedTest, out string errorMessage))
            {
                lblLDLAppIdValue.Text = localDLAppId.ToString();
                lblAppliedForLicenseValue.Text = appliedForLicense;
                lblPassedTestsValue.Text = passedTest.ToString() + "/3";

                EnableShowLDLIfThisAppHaveOne(localDLAppId);
            }
            else
            {
                string errorText = "There is no local driving license application" +
                        $"with id equals ({localDLAppId})";

                if (!string.IsNullOrEmpty(errorMessage))
                    errorText = errorMessage;

                    MessageBox.Show(errorText, "Error Message :(",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnableShowLDLIfThisAppHaveOne(int localDLAppId)
        {
            if(clsLicense.GetDriverInfoByLDLAppID(localDLAppId, out int licenseID, out string className, out int driverID,
            out string fullName, out string nationalNo, out string gender,
            out DateTime issueDate, out DateTime expirationDate, out byte issueReason,
            out string notes, out bool isActive, out DateTime dateOfBirth,
            out string imagePath, out bool isDetained, out string errorMessage) == true)
            {
                llblShowLicenseInfo.Enabled = true;
                _localDrivingLicenseAppID = localDLAppId;
            }
        }

        private void llblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmLocalDriverLicenseInfo(_localDrivingLicenseAppID).ShowDialog();
        }
    }
}
