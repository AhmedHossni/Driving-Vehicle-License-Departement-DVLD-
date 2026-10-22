using CommonUseThings;
using DVLD_BusinessLogicLayer;
using System;
using System.Windows.Forms;

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
                lblIssueReason.Text = issueReason.ToString();

                lblNotes.Text 
                    = string.IsNullOrEmpty(notes) ? "No Notes" : notes;
                lblIsDetained.Text = "No";

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
