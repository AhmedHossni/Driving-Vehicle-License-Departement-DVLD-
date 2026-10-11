using CommonUseThings;
using Driving___Vehicle_License_Departement__DVLD_.Properties;
using DVLD_BusinessLogicLayer;
using System;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.Test.Tests.Control
{
    public partial class ctrlScheduleTestInfo : UserControl
    {
        enTestTypes _testType = enTestTypes.VisionTest;

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

        public ctrlScheduleTestInfo()
        {
            InitializeComponent();
        }

        public void LoadFormData(int testAppointmentID)
        {
            string errorMessage = string.Empty;
            int LDLAppID = -1;
            string className = string.Empty;
            string fullName = string.Empty;
            int trials = 0;
            DateTime formScheduleDate = DateTime.Now;
            decimal testTypeFees = 0;
            int? rtAppID = null;
            decimal rtFees = 0;
            bool isLocked = false;


            if (!clsTestAppointment.GetFullTestAppointmentDetails(testAppointmentID,
                ref LDLAppID,
                ref className,
                ref fullName,
                ref trials,
                ref formScheduleDate,
                ref testTypeFees,
                ref rtAppID,
                ref rtFees,
                ref isLocked,
                out errorMessage
                ))
            {
                if(string.IsNullOrEmpty(errorMessage))
                {
                    MessageBox.Show("There is no test appointment with this id.", "Not Founded :(",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
            }

            HandleErrorMessage(ref errorMessage);

            lblLocalDLIdValue.Text = LDLAppID.ToString();
            lblDClassValue.Text = className;
            lblNameValue.Text = fullName;
            lblTrialValue.Text = trials.ToString();

            lblFeesValue.Text = testTypeFees.ToString("0.0");

            lblScheduleDateValue.Text = formScheduleDate.ToShortDateString();
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
    }
}
