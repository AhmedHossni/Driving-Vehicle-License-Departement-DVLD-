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
    public partial class frmDriverLicenseInfo : frmMainStyle
    {
        public frmDriverLicenseInfo(int localDrivingLicenseAppID)
        {
            InitializeComponent();

            ctrlDriverLicenseInfo1.LoadDriverLicenseInfo(localDrivingLicenseAppID);
        }
    }
}
