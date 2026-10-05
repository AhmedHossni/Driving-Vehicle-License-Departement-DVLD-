using Driving___Vehicle_License_Departement__DVLD_.Person_Forms;
using DVLD_BusinessLogicLayer;
using System;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.Application.Control
{
    public partial class ctrlApplicationFullInfo : UserControl
    {
        private int _personId = -1;
        public event Action PersonDataChangedHandler;

        public ctrlApplicationFullInfo()
        {
            InitializeComponent();
        }

        public void LoadLocalDLAppFormInfo(int applicationId)
        {
            string applicationTypeTitle = null;
            string fullname = null;
            string username = null;
            int passedTest = 0;

            clsApplication application = clsApplication.GetFullInfoBy(applicationId, ref applicationTypeTitle,
                ref fullname, ref username, out string errorMessage);

            if (!(application is null))
            {
                lblAppIdValue.Text = applicationId.ToString();
                lblStatusValue.Text = application.ApplicaionStatus.ToString();
                lblFeesValue.Text = application.PaidFees.ToString();
                lblTypeTitleValue.Text = applicationTypeTitle;
                lblApplicant.Text = fullname;

                lblDateValue.Text = application.ApplicationDate.ToString("dd/MM/yyyy");
                lblLastStatusDateValue.Text = application.LastStatusDate.ToString("dd/MM/yyyy");
                lblCreatedByValue.Text = username;

                _personId = application.PersonId;
            }
            else
            {
                string errorText = "There is no local driving license application" +
                        $"with id equals ({applicationId})";

                if (!string.IsNullOrEmpty(errorMessage))
                    errorText = errorMessage;

                MessageBox.Show(errorText, "Error Message :(",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonInfo frmPersonInfo 
                = new frmPersonInfo(_personId);

            frmPersonInfo.PersonDataChangedHandler += FrmPersonInfo_PersonDataChangedHandler;

            frmPersonInfo.ShowDialog();
        }

        private void FrmPersonInfo_PersonDataChangedHandler()
        {
            PersonDataChangedHandler?.Invoke();

            lblApplicant.Text = clsPerson.GetBy(_personId, out string errorMessage) is clsPerson person
                ? person.FullName() : "N/A";
        }
    }
}
