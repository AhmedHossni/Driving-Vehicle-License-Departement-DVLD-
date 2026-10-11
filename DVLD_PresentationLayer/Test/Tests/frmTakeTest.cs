using CommonUseThings;
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
    public partial class frmTakeTest : Form
    {
        public frmTakeTest(enTestTypes testType, int testAppointmentID)
        {
            InitializeComponent();

            rbtnPass.Checked = true;

            ctrlScheduleTestInfo1.testType = testType;

            ctrlScheduleTestInfo1.LoadFormData(testAppointmentID);
        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();
    }
}
