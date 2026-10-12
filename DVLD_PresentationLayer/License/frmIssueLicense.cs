using DVLD_BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.License
{
    public partial class frmIssueLicense : Form
    {
        int _localDrivingLicenseAppID = -1;
        public frmIssueLicense(int localDrivingLicenseAppID)
        {
            InitializeComponent();

            _localDrivingLicenseAppID = localDrivingLicenseAppID;

            ctrlLocalDrivingLicenseApplicationBasicInfo1.
                LoadLocalDLAppFormInfo(localDrivingLicenseAppID);

            SetApplictionInfo();
        }

        private void SetApplictionInfo()
        {
            if(clsLocalDrivingLicenseApplication.GetBy(_localDrivingLicenseAppID,
                out string errorMessage) is clsLocalDrivingLicenseApplication localDrivingLicenseApplication)
            {
                ctrlApplicationFullInfo1.LoadFormInfo(localDrivingLicenseApplication.ApplicationId);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();
    }
}
