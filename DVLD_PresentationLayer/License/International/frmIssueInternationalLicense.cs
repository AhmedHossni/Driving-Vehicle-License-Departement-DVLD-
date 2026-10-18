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
    public partial class frmIssueInternationalLicense : Form
    {
        public frmIssueInternationalLicense()
        {
            InitializeComponent();

            ctrlLicenseFilter1.OnSearchDone 
                += CtrlLicenseFilter1_OnSearchDone;
        }

        private void CtrlLicenseFilter1_OnSearchDone(object sender,
            Control.ctrlLicenseFilter.SearchEventArgs e)
        {
            if (e != null)
            {
                if (e.licenseClassID != 3)
                {
                    MessageBox.Show("This is not an ordinary driving license," +
                        " so you are not allowed to create an international driving license from it.",
                                    "Not Allowed",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                    btnIssue.Enabled = false;
                    return;
                }

                ctrlDriverLicenseInfo1.LoadDriverLicenseInfo(e.driverID);
                ctrlApplicationFullInfo1.LoadFormInfo(e.applicationID);
                btnIssue.Enabled = true;
            }
        }
    }
}
