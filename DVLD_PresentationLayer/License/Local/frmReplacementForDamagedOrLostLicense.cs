using CommonUseThings;
using Driving___Vehicle_License_Departement__DVLD_.Driver;
using Driving___Vehicle_License_Departement__DVLD_.License.International.Control;
using DVLD_BusinessLogicLayer;
using System;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.License.Local
{
    public partial class frmReplacementForDamagedOrLostLicense : frmMainStyle
    {
        ctrlLicenseFilter.SearchEventArgs searchEventArgs;
        int _renewedLicenseID = -1;
        int _renewedLocalApplicationID = -1;

        public frmReplacementForDamagedOrLostLicense()
        {
            InitializeComponent();

            ctrlLicenseFilter1.OnSearchDone
                += CtrlLicenseFilter1_OnSearchDone;

            ctrlApplicationInfoForLicenseReplacement1.LoadDefaultData((int)enIssueReasons.DamagedLicense);
        }


        private void CtrlLicenseFilter1_OnSearchDone(object sender,
            ctrlLicenseFilter.SearchEventArgs localLicenseInfo)
        {
            if (localLicenseInfo != null)
            {
                searchEventArgs = localLicenseInfo;

                ctrlDriverLicenseInfo1.LoadDriverLicenseInfo(localLicenseInfo.LocalDLAppID);

                ctrlApplicationInfoForLicenseReplacement1
                        .SetOldLicenseID(localLicenseInfo.LocalLicenseID);

                llblShowLicenseHistory.Enabled = true;

                if (!localLicenseInfo.IsActive)
                {
                    MessageBox.Show("This licene is not active," +
                        " so you can't renew it.",
                                    "Not Allowed",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                    btnIssueReplacement.Enabled = false;

                    return;
                }

                btnIssueReplacement.Enabled = true;
            }
            else
            {
                btnIssueReplacement.Enabled = false;
                llblShowNewLicenseInfo.Enabled = false;
                llblShowLicenseHistory.Enabled = false;

                ctrlDriverLicenseInfo1.LoadDriverLicenseInfo(-1);
            }
        }

        private void btnIssueReplacemene_Click(object sender, EventArgs e)
        {
            string errorMessage = string.Empty;

            clsApplication application = new clsApplication();

            application.ApplicaionTypeID = (int)enApplicationTypes.RenewDrivingLicenseService;
            application.ApplicaionStatus = enApplicationStatus.Complete;
            application.CreatedByUserID = clsUser.SystemUser.Id;
            application.ApplicationDate = DateTime.Now;
            application.LastStatusDate = DateTime.Now;
            application.PersonId = searchEventArgs.PersonID;

            if (!application.Save(out errorMessage))
            {
                MessageBox.Show($"Failed to save application: {errorMessage}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsLocalDrivingLicenseApplication localDrivingLicenseApplication
                = new clsLocalDrivingLicenseApplication();

            localDrivingLicenseApplication.ApplicationId = application.Id;
            localDrivingLicenseApplication.LicenseClassId = searchEventArgs.LicenseClassID;

            if (!localDrivingLicenseApplication.Save(out errorMessage))
            {
                if (string.IsNullOrEmpty(errorMessage))
                    MessageBox.Show($"Failed to save local license application: {errorMessage}",
                        "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            clsLicense renewedLicense = new clsLicense();

            renewedLicense.ApplicationID = localDrivingLicenseApplication.ApplicationId;
            renewedLicense.LicenseClassID = searchEventArgs.LicenseClassID;
            renewedLicense.DriverID = searchEventArgs.DriverID;
            renewedLicense.IssueDate = DateTime.Now;
            renewedLicense.IsActive = true;

            renewedLicense.IssueReason = (byte)(rbtnLostLicense.Checked 
                ? enIssueReasons.LostLicense : enIssueReasons.DamagedLicense);

            renewedLicense.CreatedByUserID = clsUser.SystemUser.Id;

            if (!renewedLicense.Save())
            {
                MessageBox.Show("Failed to issue the new license.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!DeactivateOldLicense(searchEventArgs.LocalLicenseID))
            {
                return;
            }

            MessageBox.Show($"License Renewed Successfully with ID = {renewedLicense.LicenseID}",
                            "License Issued",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

            _renewedLicenseID = renewedLicense.LicenseID;
            llblShowNewLicenseInfo.Enabled = true;
            btnIssueReplacement.Enabled = false;

            _renewedLocalApplicationID
                = localDrivingLicenseApplication.LocalDrivingLicenseApplicationId;

            ctrlApplicationInfoForLicenseReplacement1.SetNewLicenseInfo
                (renewedLicense.ApplicationID, renewedLicense.LicenseID);
        }

        private bool DeactivateOldLicense(int licenseID)
        {
            string errorMessage = string.Empty;

            if (clsLicense.DeactivateLicense(licenseID, out errorMessage))
            {
                MessageBox.Show("License deactivated successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                string errorText = string.IsNullOrEmpty(errorMessage)
                                   ? "Failed to deactivate license."
                                   : errorMessage;

                MessageBox.Show(errorText, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }

        private void llblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmDriverLicenseHistory(searchEventArgs.DriverID).ShowDialog();
        }

        private void llblShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmLocalDriverLicenseInfo(_renewedLocalApplicationID).ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();

        private void SetApplicationFees(enIssueReasons issueReason)
        {
            ctrlApplicationInfoForLicenseReplacement1.SetApplicationFees((int)issueReason);
        }

        private void rbtnDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            SetApplicationFees(enIssueReasons.DamagedLicense);
        }

        private void rbtnLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            SetApplicationFees(enIssueReasons.LostLicense);
        }
    }
}
