using CommonUseThings;
using DVLD_BusinessLogicLayer;
using System;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.Test.Tests
{
    public partial class frmTakeTest : Form
    {
        int _testAppointmentID = -1;
        public frmTakeTest(enTestTypes testType, int testAppointmentID)
        {
            InitializeComponent();

            _testAppointmentID = testAppointmentID;

            rbtnPass.Checked = true;

            ctrlScheduleTestInfo1.testType = testType;

            ctrlScheduleTestInfo1.LoadFormData(testAppointmentID);
        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!clsTestAppointment.LockAppointment(_testAppointmentID, out string errorMessage))
            {
                frmMainStyle.HandleErrorMessage(ref errorMessage, "Process Faild :(");
                return;
            }

            if (clsTest.AddResultRow(_testAppointmentID,
                rbtnPass.Checked ? true : false, rtxtboxNotes.Text, clsUser.SystemUser.Id,
                out int testID, out errorMessage))
            {
                MessageBox.Show("Saving row is done successfully.", "Operation Done Sucessfully",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                frmMainStyle.HandleErrorMessage(ref errorMessage, "Saving Process Faild :(");
        }
    }
}
