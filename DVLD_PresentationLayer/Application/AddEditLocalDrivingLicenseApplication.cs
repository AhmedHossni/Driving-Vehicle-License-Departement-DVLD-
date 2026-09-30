using DVLD_BusinessLogicLayer;
using System;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.Application
{
    public partial class AddEditLocalDrivingLicenseApplication : Form
    {
        clsApplication _formApplication;
        //clsLDrivingLicenseApplicaion _formLDLApplication;
        public AddEditLocalDrivingLicenseApplication(int LDLAppID)
        {
            InitializeComponent();

            HandleFormIsAddOrUpdate(LDLAppID);

            ctrlSearchForPerson1.SearchResultHandler
                += CtrlSearchForPerson1_SearchResultHandler;
        }

        private void HandleFormIsAddOrUpdate(int LDLAppID)
        {
            if (LDLAppID != -1)
            {
                LoadLDLDataToForm(LDLAppID);
                this.Text = "Edit User Info";
                lblFormLabel.Text = "Update Local Driving License Appication";
            }
            else
            {
                this.Text = "Add New User";
                lblFormLabel.Text = "New Local Driving License Appication";
            }
        }

        private void LoadApplicationDataToForm(int applicaionId)
        {
            if (clsApplication.GetBy(applicaionId, out string error) is clsApplication application
                && !(application is null))
            {
                _formApplication = application;
            }
        }

        private void LoadLDLDataToForm(int applicaionId)
        {
            //if (clsApplication.GetBy(applicaionId, out string error) is clsApplication application
            //    && !(application is null))
            //{
            //    _formApplication = application;
            //}
        }

        private void LoadLDLDataFromForm()
        {
            // 
        }

        private void CtrlSearchForPerson1_SearchResultHandler(int personId)
            => _formApplication.PersonId = personId;

        private void btnSave_Click(object sender, EventArgs e)
        {
            LoadLDLDataFromForm();

            if (_formApplication.Save(out string errorMessage))
            {
                lblLocalDrivingLicebseApplicationID.Text = _formUser.Id.ToString();

                this.Text = "Edit User Info";

                MessageBox.Show("The operation has been completed successfully.",
                    "Success :)",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                AddOrEditUserOperationHandler?.Invoke();
            }
            else
            {
                if (!string.IsNullOrEmpty(errorMessage))
                    MessageBox.Show(errorMessage,
                        "Error Message :(", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }

        private void btnNextTab_Click(object sender, EventArgs e)
            => tctrlLicenseApplicationInfo.SelectedTab = tctrlLicenseApplicationInfo.TabPages[1];

        private void btnPreviousTab_Click(object sender, EventArgs e)
            => tctrlLicenseApplicationInfo.SelectedTab = tctrlLicenseApplicationInfo.TabPages[0];

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();
    }
}
