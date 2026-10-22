using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.License.International
{
    public partial class frmDriverInternationalLicenseInfo : frmMainStyle
    {
        public frmDriverInternationalLicenseInfo(int internationDLID)
        {
            InitializeComponent();

            ctrlDriverInternationalLicenseInfo1.LoadInternationalLicenseInfo(internationDLID);
        }
    }
}
