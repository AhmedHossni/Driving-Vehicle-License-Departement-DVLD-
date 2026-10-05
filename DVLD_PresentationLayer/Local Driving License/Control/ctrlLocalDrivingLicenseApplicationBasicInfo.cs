using DVLD_BusinessLogicLayer;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.Local_Driving_License.Control
{
    public partial class ctrlLocalDrivingLicenseApplicationBasicInfo : UserControl
    {
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
        
    }
}
