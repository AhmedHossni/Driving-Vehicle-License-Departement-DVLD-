using CommonUseThings;
using Driving___Vehicle_License_Departement__DVLD_.License.International.Control;
using Driving___Vehicle_License_Departement__DVLD_.Driver;
using Driving___Vehicle_License_Departement__DVLD_.License.International;
using DVLD_BusinessLogicLayer;
using System;
using System.Windows.Forms;
using Driving___Vehicle_License_Departement__DVLD_.License;

namespace Driving___Vehicle_License_Departement__DVLD_.Local_Driving_License.Applications
{
    public partial class frmRenewLicenseApplication : frmMainStyle
    {
       ctrlLicenseFilter.SearchEventArgs searchEventArgs;
        int _renewedLicenseID = -1;
        int _renewedLocalApplicationID = -1;

        public frmRenewLicenseApplication()
        {
            InitializeComponent();

            ctrlLicenseFilter1.OnSearchDone
                += CtrlLicenseFilter1_OnSearchDone;

            ctrlApplicationNewLicenseInfo1.LoadRenewLocalLicenseData(-1, -1);
        }

        private void CtrlLicenseFilter1_OnSearchDone(object sender,
            ctrlLicenseFilter.SearchEventArgs localLicenseInfo)
        {
            if (localLicenseInfo != null)
            {
                searchEventArgs = localLicenseInfo;

                ctrlDriverLicenseInfo1.LoadDriverLicenseInfo(localLicenseInfo.LocalDLAppID);

                ctrlApplicationNewLicenseInfo1
                        .LoadRenewLocalLicenseData(localLicenseInfo.LocalLicenseID, 
                        localLicenseInfo.LicenseClassID);

                llblShowLicenseHistory.Enabled = true;

                if (!localLicenseInfo.IsActive)
                {
                    MessageBox.Show("This licene is not active," +
                        " so you can't renew it.",
                                    "Not Allowed",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                    btnRenewLicense.Enabled = false;

                    return;
                }

                if (!IsDrivingLicenseExpired(searchEventArgs.LocalLicenseID))
                {

                    btnRenewLicense.Enabled = false;

                    return;
                }

                btnRenewLicense.Enabled = true;
            }
            else
            {
                btnRenewLicense.Enabled = false;
                llblShowNewLicenseInfo.Enabled = false;
                llblShowLicenseHistory.Enabled = false;

                ctrlDriverLicenseInfo1.LoadDriverLicenseInfo(-1);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();


        private bool IsDrivingLicenseExpired(int localDrivingLicenseID)
        {
            string errorMessage = string.Empty;
            DateTime expirationDate = DateTime.Now;
            bool isExpired = false;

            if (clsLicense.CheckLicenseExpiration
                (localDrivingLicenseID, ref expirationDate, ref isExpired, out errorMessage))
            {
                if (isExpired)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show($"This Driving License is not expired!" +
                        $"\nExpiration Date: {expirationDate.ToShortDateString()}",
                        "Not Allowed",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return false;
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    frmMainStyle.HandleErrorMessage(ref errorMessage, "Failed Process :(");
                }
                else
                {
                    string defaultError = "License not found or could not be verified.";
                    frmMainStyle.HandleErrorMessage(ref defaultError, "Failed Process :(");
                }

                return true;
            }
        }

        private void btnRenewLicense_Click(object sender, EventArgs e)
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

            clsLicense renewedLicense = new clsLicense();

            renewedLicense.ApplicationID = application.Id;
            renewedLicense.DriverID = searchEventArgs.DriverID;
            renewedLicense.LicenseClassID = searchEventArgs.LicenseClassID;
            renewedLicense.IssueDate = DateTime.Now;


            renewedLicense.Notes = string.IsNullOrEmpty(ctrlApplicationNewLicenseInfo1.Notes)
                ? null : ctrlApplicationNewLicenseInfo1.Notes;
            renewedLicense.IsActive = true;
            renewedLicense.IssueReason = 2;
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

            btnRenewLicense.Enabled = false;
            llblShowNewLicenseInfo.Enabled = true;
            _renewedLicenseID = renewedLicense.LicenseID;
            _renewedLocalApplicationID 
                = localDrivingLicenseApplication.LocalDrivingLicenseApplicationId;

            ctrlApplicationNewLicenseInfo1.SetSavedData(renewedLicense.ApplicationID, renewedLicense.LicenseID);
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
    }
}
