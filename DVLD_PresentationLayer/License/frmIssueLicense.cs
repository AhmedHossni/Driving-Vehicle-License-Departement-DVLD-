using System;
using System.Windows.Forms;
using CommonUseThings;
using DVLD_BusinessLogicLayer;

namespace Driving___Vehicle_License_Departement__DVLD_.License
{
    public partial class frmIssueLicense : Form
    {
        clsLocalDrivingLicenseApplication _localDrivingLicenseApplication 
            = new clsLocalDrivingLicenseApplication();

        public frmIssueLicense(int localDrivingLicenseAppID)
        {
            InitializeComponent();

            ctrlLocalDrivingLicenseApplicationBasicInfo1.
                LoadLocalDLAppFormInfo(localDrivingLicenseAppID);

            SetApplictionInfo(localDrivingLicenseAppID);

            ctrlApplicationFullInfo1.LoadFormInfo(_localDrivingLicenseApplication.ApplicationId);
        }

        private void SetApplictionInfo(int localDLAppID)
        {
            if(clsLocalDrivingLicenseApplication.GetBy(localDLAppID,
                out string errorMessage) is clsLocalDrivingLicenseApplication localDrivingLicenseApplication)
            {
                _localDrivingLicenseApplication = localDrivingLicenseApplication;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();

        private bool SaveNewLDL(int driverID)
        {
            if(_localDrivingLicenseApplication.LocalDrivingLicenseApplicationId 
                == -1)
                return false;

            clsLicense license = new clsLicense();

            license.DriverID = driverID;
            license.ApplicationID = _localDrivingLicenseApplication.ApplicationId;
            license.LicenseClassID = _localDrivingLicenseApplication.LicenseClassId;
            license.IssueDate = DateTime.Now;
            license.Notes = richTextBox1.Text;
            license.IsActive = true;
            license.IssueReason = 1;
            license.CreatedByUserID = clsUser.SystemUser.Id;

            if (license.Save())
            {
                MessageBox.Show("The license was successfully issued with the number: " 
                    + license.LicenseID);

                return true;
            }
            else
            {
                MessageBox.Show("The issuance process failed!");

                return false;
            }
        }

        private bool SaveDriver(out int driverID)
        {
            driverID = -1;

            clsDriver driver = new clsDriver();

            driver.CreatedByUserID = clsUser.SystemUser.Id;
            
            if (clsApplication.GetBy(_localDrivingLicenseApplication.ApplicationId,
                out string errorMessage) is clsApplication application)
                driver.PersonID = application.PersonId;
            else
            {
                frmMainStyle.HandleErrorMessage(ref errorMessage,
                    "Faild Process :(");      
                return false;
            }

            if (driver.Save(out errorMessage))
            {
                driverID = driver.DriverID;
                return true;
            }
            else
            {
                if (string.IsNullOrEmpty(errorMessage))
                    MessageBox.Show("The issuance process failed!");
                else
                    frmMainStyle.HandleErrorMessage(ref errorMessage,
                    "Faild Process :(");

                return false;
            }
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if(SaveDriver(out int driverID))
            {
                if (SaveNewLDL(driverID))
                {
                    btnIssue.Enabled = false;

                    clsApplication.UpdateStatusByLDLAppID
                        (_localDrivingLicenseApplication.ApplicationId,
                        enApplicationStatus.Complete, DateTime.Now, out string errorMessage);                  
                }
                    
            }
        }
    }
}
