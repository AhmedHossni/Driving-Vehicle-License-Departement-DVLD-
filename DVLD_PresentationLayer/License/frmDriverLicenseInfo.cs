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
    public partial class frmLocalDriverLicenseInfo : frmMainStyle
    {
        public enum IDType { LocalDrivingLicenseApplicationID, ApplicationID}
        public frmLocalDriverLicenseInfo(int id, IDType idType)
        {
            InitializeComponent();

            switch (idType)
            {
                case IDType.LocalDrivingLicenseApplicationID:
                    ctrlDriverLicenseInfo1.LoadDriverLicenseInfo(id);
                    break;
                case IDType.ApplicationID:
                    ctrlDriverLicenseInfo1.LoadDriverLicenseInfoByApplicationID(id);
                    break;
            }
            
        }
    }
}
