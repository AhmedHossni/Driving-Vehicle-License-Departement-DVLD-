using CommonUseThings;
using Driving___Vehicle_License_Departement__DVLD_.Properties;
using DVLD_BusinessLogicLayer;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.Test.Tests
{
    public partial class frmTestAppointments : frmMainStyle
    {
        enTestTypes _formTestType;
        int _localDLAppId;
        int _applicatioId;

        private Point _point = new Point();

        public frmTestAppointments(enTestTypes testType, int localDLAppId)
        {
            InitializeComponent();

            _formTestType = testType;

            _localDLAppId = localDLAppId;

            SetApplictionID(localDLAppId);

            SetFormValuesBy(testType);

            LoadDGVAppointments(localDLAppId);

            ctrlLocalDrivingLicenseApplicationBasicInfo1.LoadLocalDLAppFormInfo(localDLAppId);

            ctrlApplicationFullInfo1.LoadLocalDLAppFormInfo(_applicatioId);
        }

        private int GetAndSelectCurrentGridRowId()
        {
            DataGridView.HitTestInfo hitInfo = dgvAppointmentsList.HitTest(_point.X, _point.Y);

            if (hitInfo.RowIndex != -1)
            {
                dgvAppointmentsList.ClearSelection();
                dgvAppointmentsList.Rows[hitInfo.RowIndex].Selected = true;
                dgvAppointmentsList.CurrentCell = dgvAppointmentsList.Rows[hitInfo.RowIndex].Cells[0];
                return (int)dgvAppointmentsList.CurrentCell.Value;
            }
            else
            {
                return -1;
            }
        }

        private void dgvAppointmentsList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
            => _point = dgvAppointmentsList.PointToClient(Cursor.Position);

        private void LoadDGVAppointments(int localDLAppId)
        {
            if (clsTestAppointment.GetAllPersonTestAppointmentsBy(localDLAppId, _formTestType,
                out string errorMessage) is DataTable dataTable && !(dataTable is null))
                dgvAppointmentsList.DataSource = dataTable.DefaultView;

            if (dgvAppointmentsList.Columns["PaidFees"] != null)
                dgvAppointmentsList.Columns["PaidFees"].DefaultCellStyle.Format = "0.0";
        }

        private void SetApplictionID(int localDLAppID)
        {
            clsLocalDrivingLicenseApplication localDrivingLicenseApplication
                = clsLocalDrivingLicenseApplication.GetBy(localDLAppID, out string errorMessage);

            if(!string.IsNullOrEmpty(errorMessage))
                MessageBox.Show(errorMessage, "Error Message",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            if(localDrivingLicenseApplication != null)
                _applicatioId = localDrivingLicenseApplication.ApplicationId;
        }

        private void SetFormValuesBy(enTestTypes type)
        {
            switch (type)
            {
                case enTestTypes.VisionTest:
                    this.Text = "Vision Test Appointments";
                    pictureBox2.Image = Resources.Vision_512;
                    break;
                case enTestTypes.WrittenTest:
                    this.Text = "Written Test Appointments";
                    pictureBox2.Image = Resources.Written_Test_Big;
                    break;
                case enTestTypes.PracticalTest:
                    this.Text = "Practical Test Appointments";
                    pictureBox2.Image = Resources.Driving_Test_Big;
                    break;
            }
        }

        private void btnClose_Click(object sender, System.EventArgs e)
            => this.Close();

        private void btnAddScheduleTest_Click(object sender, System.EventArgs e)
        {
            if (clsTestAppointment.DoesApplicationHavePassedOrUnlockedTest
                (_localDLAppId, (int)_formTestType, out bool result, out string errorMessage) && result)
            {
                MessageBox.Show("Person already has an active appointment for this test or has already passed it.",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else CallSheduleTestForm(-1);
        }

        private void CallSheduleTestForm(int testAppointmentID)
        {
            frmScheduleTest frmScheduleTest
                = new frmScheduleTest(_formTestType, testAppointmentID, _localDLAppId);

            frmScheduleTest.OnTestSchedulesChange += FrmScheduleTest_OnTestSchedulesChange;

            frmScheduleTest.ShowDialog();      
        }

        private void FrmScheduleTest_OnTestSchedulesChange(object sender, EventArgs e)
        {
            LoadDGVAppointments(_localDLAppId);
        }

        private void editTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CallSheduleTestForm(GetAndSelectCurrentGridRowId());
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTakeTest frmTakeTest 
                = new frmTakeTest(_formTestType, GetAndSelectCurrentGridRowId());

            frmTakeTest.ShowDialog();
        }
    }
}
