using CommonUseThings;
using Driving___Vehicle_License_Departement__DVLD_.Properties;
using DVLD_BusinessLogicLayer;
using System;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.Test.Tests.Control
{
    public partial class ctrlScheduleTest : UserControl
    {
        clsTestAppointment _formTestAppointment = new clsTestAppointment();
        enTestTypes _testType;
        public enTestTypes testType 
        { 
            get 
            { 
                return _testType;
            } 
            set 
            {
                _testType = value;
                SetCtrlValuesBy(value);
            }
        }

        public ctrlScheduleTest()
        {
            InitializeComponent();

            DefaultStartValues();
        }

        public void LoadFormData(int testAppointmentID, int LDLAppID)
        {
            string errorMessage = string.Empty;
            string className = string.Empty;
            string fullName = string.Empty;
            int trials = 0;
            DateTime scheduleDate = DateTime.Now;
            decimal testTypeFees = 0;
            int? rtAppID = null;
            decimal rtFees = 0;
            bool isLocked = false;

            if(testAppointmentID != -1)
            {
                clsTestAppointment.GetFullTestAppointmentDetails(testAppointmentID,
                    ref LDLAppID,
                    ref className,
                    ref fullName,
                    ref trials,
                    ref scheduleDate,
                    ref testTypeFees,
                    ref rtAppID,
                    ref rtFees,
                    ref isLocked,
                    out errorMessage
                    );

                if (clsTestAppointment.GetBy(testAppointmentID)
                    is clsTestAppointment testAppointment && !(testAppointment is null))
                _formTestAppointment = testAppointment;
            }
            else
            {
                clsLocalDrivingLicenseApplication.GetDrivingLicenseAppScheduleTestInfo(LDLAppID,
                    testType, ref className,
                    ref testTypeFees,
                    ref fullName,
                    ref trials,
                    out errorMessage);
            }

            HandleErrorMessage(ref errorMessage);

            HandleScheduleIsLocked(isLocked);

            lblLocalDLIdValue.Text = LDLAppID.ToString();
            lblDClassValue.Text = className;
            lblNameValue.Text = fullName;
            lblTrialValue.Text = trials.ToString();

            if (scheduleDate < DateTime.Now && 
                testAppointmentID != -1)
            {
                dateTimePicker1.MinDate = scheduleDate;
                dateTimePicker1.Value = scheduleDate;
                HandleScheduleIsLocked(true);
            }

            lblFeesValue.Text = testTypeFees.ToString("0.0");
            lblRAppFeesValue.Text = rtFees != 0 
                ? rtFees.ToString("0.0") : rtFees.ToString();
            lblTotalFeesValue.Text = (rtFees + testTypeFees).ToString("0.0");

            if(rtAppID != null)
                lblTestRAppIdValue.Text = rtAppID.ToString();
        }

        private void HandleScheduleIsLocked(bool isLocked)
        {
            if(isLocked)
            {
                dateTimePicker1.Enabled = false;
                btnSave.Enabled = false;
            }
        }

        private void HandleErrorMessage(ref string errorMessage)
        {
            if (!string.IsNullOrEmpty(errorMessage))
                MessageBox.Show(errorMessage, "Erro Message :(",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SetCtrlValuesBy(enTestTypes type)
        {
            switch (type)
            {
                case enTestTypes.VisionTest:
                    gbBoxTestName.Text = "Vision Test";
                    pictureBox1.Image = Resources.Vision_512;
                    break;
                case enTestTypes.WrittenTest:
                    gbBoxTestName.Text = "Written Test";
                    pictureBox1.Image = Resources.Written_Test_Big;
                    break;
                case enTestTypes.PracticalTest:
                    gbBoxTestName.Text = "Practical Test";
                    pictureBox1.Image = Resources.Driving_Test_Big;
                    break;
                default:
                    gbBoxTestName.Text = "No Test Type Selected";
                    break;
            }
        }

        private void DefaultStartValues()
        {
            dateTimePicker1.MinDate = DateTime.Now.AddDays(1);
        }

        private void LoadTestAppointmentDataFromForm()
        {
            _formTestAppointment.TestType = _testType;

            _formTestAppointment.LocalDrivingLicenseApplicationID = 
                Convert.ToInt32(lblDClassValue.Text);
            
            _formTestAppointment.AppointmentDate = dateTimePicker1.Value;

            _formTestAppointment.PaidFees = Convert.ToDecimal(lblTotalFeesValue);

            if (_formTestAppointment.CreatedByUserID == -1)
                _formTestAppointment.CreatedByUserID = clsUser.SystemUser.Id;
            
            _formTestAppointment.IsLocked = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            LoadTestAppointmentDataFromForm();

            if (_formTestAppointment.Save(out string errorMessage))
            {
                MessageBox.Show("Saving operation is done successfully.", "Operation Done Successfully :)",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                HandleErrorMessage(ref errorMessage);
            }
        }
    }
}
