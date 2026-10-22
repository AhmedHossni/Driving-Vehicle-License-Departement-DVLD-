using CommonUseThings;
using Driving___Vehicle_License_Departement__DVLD_.Driver;
using DVLD_BusinessLogicLayer;
using System;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.License.International
{
    public partial class frmIssueInternationalLicense : frmMainStyle
    {
        Control.ctrlLicenseFilter.SearchEventArgs searchEventArgs;
        int internationalDrivingLicenseID = -1;

        public frmIssueInternationalLicense()
        {
            InitializeComponent();

            ctrlLicenseFilter1.OnSearchDone 
                += CtrlLicenseFilter1_OnSearchDone;
        }

        private void CtrlLicenseFilter1_OnSearchDone(object sender,
            Control.ctrlLicenseFilter.SearchEventArgs localLicenseInfo)
        {
            if (localLicenseInfo != null)
            {
                searchEventArgs = localLicenseInfo;

                ctrlDriverLicenseInfo1.LoadDriverLicenseInfo(localLicenseInfo.LocalDLAppID);
                
                ctrlInternationalDrivingLicenseApplicationInfo1
                        .SetLocalLicenseID(localLicenseInfo.LocalLicenseID);

                llblShowLicenseHistory.Enabled = true;

                if (localLicenseInfo.LicenseClassID != 3)
                {
                    MessageBox.Show("This is not an ordinary driving license," +
                        " so you are not allowed to create an international driving license from it.",
                                    "Not Allowed",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                    btnIssue.Enabled = false;
                    return;
                }

                if(!localLicenseInfo.IsActive)
                {
                    MessageBox.Show("This is not an ordinary driving license," +
                        " so you are not allowed to create an international driving license from it.",
                                    "Not Allowed",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                    btnIssue.Enabled = false;

                    return;
                }

                if (IsDriverHaveAlreadyIDL(localLicenseInfo.DriverID))
                {
                    ctrlInternationalDrivingLicenseApplicationInfo1
                        .LoadInternationalLicenseData(localLicenseInfo.DriverID);

                    btnIssue.Enabled = false;
                    llblShowLicenseInfo.Enabled = true;

                    clsInternationalLicense
                        .GetInternationalLicenseIDByDriverID(localLicenseInfo.DriverID,
                        out int internationalLicenseID, out string errorMessage);

                    internationalDrivingLicenseID = internationalLicenseID;

                    return;
                }

                ctrlInternationalDrivingLicenseApplicationInfo1
                        .LoadInternationalLicenseData(-1);

                btnIssue.Enabled = true;
            }
            else
            {
                btnIssue.Enabled = false;
                llblShowLicenseInfo.Enabled = false;
                llblShowLicenseHistory .Enabled = false;

                ctrlDriverLicenseInfo1.LoadDriverLicenseInfo(-1);

                ctrlInternationalDrivingLicenseApplicationInfo1
                        .LoadInternationalLicenseData(-1);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();


        private bool IsDriverHaveAlreadyIDL(int driverID)
        {
            string errorMessage = string.Empty;

            if (clsInternationalLicense.IsExistByDriverID(driverID, out errorMessage))
            {
                MessageBox.Show("This driver already has an international license!",
                                "Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            else
            {
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    frmMainStyle.HandleErrorMessage(ref errorMessage, "Failed Process :(");
                    return true;
                }
                else
                    return false;
            }
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            
            clsApplication application 
                = new clsApplication();

            application.ApplicaionTypeID = (int)enApplicationTypes.NewInternationalLicense;
            application.ApplicaionStatus = enApplicationStatus.New;
            application.CreatedByUserID = clsUser.SystemUser.Id;
            application.ApplicationDate = DateTime.Now;
            application.LastStatusDate = DateTime.Now;
            application.PersonId = searchEventArgs.PersonID;

            if(application.Save(out string errorMessage))
            {
                clsInternationalLicense newInternationalLicense
                    = new clsInternationalLicense();

                newInternationalLicense.ApplicationID = application.Id;
                newInternationalLicense.CreatedByUserID = clsUser.SystemUser.Id;
                newInternationalLicense.DriverID = searchEventArgs.DriverID;
                newInternationalLicense.IssueDate = DateTime.Now;
                newInternationalLicense.IsActive = true;

                newInternationalLicense.ExpirationDate 
                    = newInternationalLicense.IssueDate.AddYears(1);

                newInternationalLicense.IssuedUsingLocalLicenseID
                    = searchEventArgs.LocalLicenseID;

                if (newInternationalLicense.Save())
                {
                    MessageBox.Show($"Saving new international license with id : " +
                        $"{newInternationalLicense.InternationalLicenseID}",
                        "Saving is done", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    btnIssue.Enabled = false;

                    llblShowLicenseInfo.Enabled = true;

                    internationalDrivingLicenseID 
                        = newInternationalLicense.InternationalLicenseID;

                    ctrlInternationalDrivingLicenseApplicationInfo1
                        .SetApplicationID(newInternationalLicense.ApplicationID,
                        newInternationalLicense.InternationalLicenseID);
                }
            }      
        }

        private void llblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmDriverLicenseHistory(searchEventArgs.DriverID).ShowDialog();
        }

        private void llblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmDriverInternationalLicenseInfo(internationalDrivingLicenseID).ShowDialog();
        }
    }
}