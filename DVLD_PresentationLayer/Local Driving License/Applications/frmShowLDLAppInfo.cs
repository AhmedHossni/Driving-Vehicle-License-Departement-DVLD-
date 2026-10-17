using DVLD_BusinessLogicLayer;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.Local_Driving_License.Applications
{
    public partial class frmShowLDLAppInfo : frmMainStyle
    {
        int _applicatioId = -1;
        public frmShowLDLAppInfo(int localDLAppId)
        {
            InitializeComponent();

            SetApplictionID(localDLAppId);

            ctrlLocalDrivingLicenseApplicationBasicInfo1.LoadLocalDLAppFormInfo(localDLAppId);

            ctrlApplicationFullInfo1.LoadFormInfo(_applicatioId);
        }

        private void SetApplictionID(int localDLAppID)
        {
            clsLocalDrivingLicenseApplication localDrivingLicenseApplication
                = clsLocalDrivingLicenseApplication.GetBy(localDLAppID, out string errorMessage);

            if (!string.IsNullOrEmpty(errorMessage))
                MessageBox.Show(errorMessage, "Error Message",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (localDrivingLicenseApplication != null)
                _applicatioId = localDrivingLicenseApplication.ApplicationId;
        }
    }
}
