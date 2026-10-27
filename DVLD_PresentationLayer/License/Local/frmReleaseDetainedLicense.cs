using CommonUseThings;
using Driving___Vehicle_License_Departement__DVLD_.Driver;
using Driving___Vehicle_License_Departement__DVLD_.License.International.Control;
using DVLD_BusinessLogicLayer;
using System;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.License.Local
{
    public partial class frmReleaseDetainedLicense : frmMainStyle
    {
        ctrlLicenseFilter.SearchEventArgs searchEventArgs;

        public frmReleaseDetainedLicense()
        {
            InitializeComponent();

            ctrlLicenseFilter1.OnSearchDone
                += CtrlLicenseFilter1_OnSearchDone;
        }

        public frmReleaseDetainedLicense(int licenseID) : this()
        {
            ctrlLicenseFilter1.ReturnDataAndDisableSearchFilter(licenseID);
        }

        private void CtrlLicenseFilter1_OnSearchDone(object sender,
            ctrlLicenseFilter.SearchEventArgs localLicenseInfo)
        {
            if (localLicenseInfo != null)
            {
                searchEventArgs = localLicenseInfo;

                ctrlDriverLicenseInfo1.LoadDriverLicenseInfo(localLicenseInfo.LocalDLAppID);

                if (!IsLicenseDetained(localLicenseInfo.LocalLicenseID))           
                    return;

                if (!ctrlReleaseDetainedLicenseInfo1.LoadDetainData(localLicenseInfo.LocalLicenseID))
                    return;

                llblShowLicenseHistory.Enabled = true;
                llblShowLicenseInfo.Enabled = true;
                btnReleaseLicense.Enabled = true;
            }
            else
            {
                llblShowLicenseInfo.Enabled = false;
                llblShowLicenseHistory.Enabled = false;
                btnReleaseLicense.Enabled = false;

                ctrlDriverLicenseInfo1.LoadDriverLicenseInfo(-1);
            }
        }

        private bool IsLicenseDetained(int licenseID)
        {
            string errorMessage = string.Empty;

            if (clsDetainedLicense.IsLicenseDetained(licenseID,
                out errorMessage))
            {
                return true;
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show($"Error: {errorMessage}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(
                    "This license is not detained.",
                    "Not Detained",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            return false;
        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();

        private void llblShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmLocalDriverLicenseInfo(searchEventArgs.LocalDLAppID).ShowDialog();
        }

        private void llblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmDriverLicenseHistory(searchEventArgs.DriverID).ShowDialog();
        }

        private void btnReleaseLicense_Click(object sender, EventArgs e)
        {
            clsApplication application = new clsApplication();

            application.ApplicaionStatus = enApplicationStatus.Complete;

            application.CreatedByUserID = clsUser.SystemUser.Id;

            application.ApplicationDate = DateTime.Now;

            application.LastStatusDate = application.ApplicationDate;

            application.ApplicaionTypeID = (int)enApplicationTypes.ReleaseDetailedDrivingLicense;

            application.PersonId = searchEventArgs.PersonID;

            if (!application.Save(out string errorMessage))
            {
                MessageBox.Show(errorMessage, "Error Message",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if(clsDetainedLicense.GetBy(searchEventArgs.LocalLicenseID, out errorMessage) 
                is clsDetainedLicense detainedLicense)
            {
                detainedLicense.ReleaseDate = DateTime.Now;
                detainedLicense.ReleasedByUserID = clsUser.SystemUser.Id;
                detainedLicense.ReleaseApplicationID = application.Id;
                detainedLicense.IsReleased = true;
            }
            else
            {
                MessageBox.Show(errorMessage, "Error Message",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if(detainedLicense.Save(out errorMessage))
            {
                MessageBox.Show("Release license operation is done.", "Operation Done",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnReleaseLicense.Enabled = false;

                ctrlReleaseDetainedLicenseInfo1.SetApplicationID(application.Id);

                ctrlDriverLicenseInfo1.LoadDriverLicenseInfo(searchEventArgs.LocalDLAppID);
            }
            else
            {
                MessageBox.Show(errorMessage, "Error Message",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
        }
    }
}
