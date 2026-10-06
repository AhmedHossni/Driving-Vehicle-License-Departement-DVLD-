namespace Driving___Vehicle_License_Departement__DVLD_.Test.Tests
{
    public partial class frmVisionTestAppointments : frmMainStyle
    {
        public frmVisionTestAppointments(int localDLAppId, int ApplicationId)
        {
            InitializeComponent();

            ctrlLocalDrivingLicenseApplicationBasicInfo1.LoadLocalDLAppFormInfo(localDLAppId);

            ctrlApplicationFullInfo1.LoadLocalDLAppFormInfo(ApplicationId);
        }

        private void btnClose_Click(object sender, System.EventArgs e)
            => this.Close();

        private void btnAddPerson_Click(object sender, System.EventArgs e)
        {
            frmScheduleTest frmScheduleTest 
                = new frmScheduleTest("Vision");

            frmScheduleTest.ShowDialog();
        }
    }
}
