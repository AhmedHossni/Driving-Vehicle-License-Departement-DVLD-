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
    public partial class frmScheduleTest : frmMainStyle
    {
        public frmScheduleTest(enTestTypes testType, 
            int testAppointmentID, int localDLAppID)
        {
            InitializeComponent();

            ctrlScheduleTest1.testType = testType;

            ctrlScheduleTest1.LoadFormData(testAppointmentID, localDLAppID);
        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();
    }
}
