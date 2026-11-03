using CommonUseThings;
using DVLD_BusinessLogicLayer;
using System;
using System.Windows.Forms;
using static Driving___Vehicle_License_Departement__DVLD_.License.International.Control.ctrlLicenseFilter;
using static DVLD_BusinessLogicLayer.clsLicense;

namespace Driving___Vehicle_License_Departement__DVLD_.License.Control
{
    public partial class ctrlDriverLicenseInfo : UserControl
    {
        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();
        }

        public void LoadDriverLicenseInfo(int localDLAppID)
        {
            int licenseID = -1;
            string className = "";
            int driverID = -1;
            string fullName = "";
            string nationalNo = "";
            string gender = "";
            DateTime issueDate = DateTime.MinValue;
            DateTime expirationDate = DateTime.MinValue;
            byte issueReason = 0;
            string notes = "";
            bool isActive = false;
            DateTime dateOfBirth = DateTime.MinValue;
            string imagePath = "";
            bool isDetained = false;
            string errorMessage = "";

            bool isFound = clsLicense.GetDriverInfoByLDLAppID(
                localDLAppID,
                out licenseID,
                out className,
                out driverID,
                out fullName,
                out nationalNo,
                out gender,
                out issueDate,
                out expirationDate,
                out issueReason,
                out notes,
                out isActive,
                out dateOfBirth,
                out imagePath,
                out isDetained,
                out errorMessage
            );

            if (isFound)
            {
                lblLicenseID.Text = licenseID.ToString();
                lblClass.Text = className;
                lblFullName.Text = fullName;
                lblNationalNo.Text = nationalNo;
                lblGendor.Text = gender;
                lblIssueDate.Text = issueDate.ToShortDateString();
                lblExpirationDate.Text = expirationDate.ToShortDateString();
                lblNotes.Text = notes;
                lblIsActive.Text = isActive ? "Yes" : "No";
                lblDateOfBirth.Text = dateOfBirth.ToShortDateString();
                lblDriverID.Text = driverID.ToString();
                lblIssueReason.Text = EnumToString.enIssueReasonsToString((enIssueReasons)issueReason);

                lblNotes.Text 
                    = string.IsNullOrEmpty(notes) ? "No Notes" : notes;

                lblIsDetained.Text = isDetained ? "Yes" : "No";

                LoadDriverImage(imagePath, gender);
            }
            else
            {
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    MessageBox.Show("Database Error: " + errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"No license found with Local Driving License Application ID = {localDLAppID}", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void LoadDriverLicenseInfoByApplicationID(int applicationID)
        {
            clsDriverLicenseInfoDTO licenseInfo = 
                clsLicense.GetDriverLicenseInfoByApplicationID(applicationID, out string errorMessage);

            if (licenseInfo != null)
            {
                lblLicenseID.Text = licenseInfo.LicenseID.ToString();
                lblClass.Text = licenseInfo.ClassName;
                lblFullName.Text = licenseInfo.FullName;
                lblNationalNo.Text = licenseInfo.NationalNo;
                lblGendor.Text = licenseInfo.Gender;
                lblIssueDate.Text = licenseInfo.IssueDate.ToShortDateString();
                lblExpirationDate.Text = licenseInfo.ExpirationDate.ToShortDateString();
                lblIsActive.Text = licenseInfo.IsActive ? "Yes" : "No";
                lblDateOfBirth.Text = licenseInfo.DateOfBirth.ToShortDateString();
                lblDriverID.Text = licenseInfo.DriverID.ToString();
                lblIssueReason.Text = EnumToString.enIssueReasonsToString((enIssueReasons)licenseInfo.IssueReason);
                lblNotes.Text = string.IsNullOrEmpty(licenseInfo.Notes) ? "No Notes" : licenseInfo.Notes;
                lblIsDetained.Text = licenseInfo.IsDetained ? "Yes" : "No";

                LoadDriverImage(licenseInfo.ImagePath, licenseInfo.Gender);
            }
            else
            {
                MessageBox.Show(errorMessage, "There is a problem",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoadDriverImage(string imageName, string gender)
        {
            string fullImagePath = clsProjectSetting.ImageDefaultPath + "\\" + imageName;

            if (!string.IsNullOrEmpty(imageName) && System.IO.File.Exists(fullImagePath))
            {
                pbPersonImage.Load(fullImagePath);
            }
            else
            {
                string defaultPath = (gender == "Male")
                    ? clsProjectSetting.MaleDefaultImagePath
                    : clsProjectSetting.FemaleDefaultImagePath;

                if (!string.IsNullOrEmpty(defaultPath) && System.IO.File.Exists(defaultPath))
                {
                    pbPersonImage.Load(defaultPath);
                }
                else
                {
                    pbPersonImage.Image = null;
                }
            }
        }
    }
}
