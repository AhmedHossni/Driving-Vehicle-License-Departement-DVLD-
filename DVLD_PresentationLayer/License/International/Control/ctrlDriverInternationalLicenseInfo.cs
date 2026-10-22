using CommonUseThings;
using DVLD_BusinessLogicLayer;
using System;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.License.International.Control
{
    public partial class ctrlDriverInternationalLicenseInfo : UserControl
    {
        public ctrlDriverInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        public void LoadInternationalLicenseInfo(int internationDLID)
        {
            if (internationDLID == -1)
                return;

            int applicationID = -1;
            int driverID = -1;
            int issuedUsingLocalLicenseID = -1;
            DateTime issueDate = DateTime.Now;
            DateTime expirationDate = DateTime.Now;
            bool isActive = false;
            string fullName = "";
            string nationalNo = "";
            string gender = "";
            DateTime dateOfBirth = DateTime.Now;
            string errorMessage = string.Empty;
            string imageName = string.Empty;

            bool isFound = clsInternationalLicense.Find(
                internationDLID,
                ref applicationID,
                ref driverID,
                ref issuedUsingLocalLicenseID,
                ref issueDate,
                ref expirationDate,
                ref isActive,
                ref fullName,
                ref nationalNo,
                ref gender,
                ref dateOfBirth,
                ref imageName,
                out errorMessage
            );

            if (isFound)
            {
                lblInternationalLicenseID.Text = internationDLID.ToString();
                lblApplicationID.Text = applicationID.ToString();
                lblDriverID.Text = driverID.ToString();
                lblFullName.Text = fullName;
                lblNationalNo.Text = nationalNo;
                lblGender.Text = gender;
                lblLocalLicenseID.Text = issuedUsingLocalLicenseID.ToString();
                lblIssueDate.Text = issueDate.ToShortDateString();
                lblExpirationDate.Text = expirationDate.ToShortDateString();
                lblDateOfBirth.Text = dateOfBirth.ToShortDateString();
                lblIsActive.Text = isActive ? "Yes" : "No";

                LoadDriverImage(imageName, gender);
            }
            else
            {
                MessageBox.Show("International License not found!");
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
