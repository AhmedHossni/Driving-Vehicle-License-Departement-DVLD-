using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.Test.Tests
{
    public partial class frmVisionTestAppointments : frmMainStyle
    {
        public frmVisionTestAppointments(int localDLAppId, int ApplicationId)
        {
            InitializeComponent();

            ctrlLocalDrivingLicenseApplicationBasicInfo1.LoadLocalDLAppFormInfo(localDLAppId);

            ctrlApplicationFullInfo1.LoadLocalDLAppFormInfo(ApplicationId);
        }
    }
}
