using DVLD_BusinessLogicLayer;
using System;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.User_Forms
{
    public partial class frmAddEditUser : Form
    {
        clsUser _formUser 
            = new clsUser();

        public frmAddEditUser(int userId)
        {
            InitializeComponent();              

            if (userId != -1)
            {
                LoadUserData(userId);
                this.Text = "Update User Info";
            }
            else
            {
                this.Text = "Add New User";
            }

            if (clsUser.SystemUser?.Id != userId
                && _formUser.PersonId != -1)
                DisableEditUserInfo();

            ctrlSearchForPerson1.SearchResultHandler
                += CtrlSearchForPerson1_SearchResultHandler;
        }

        private void DisableEditUserInfo()
        {
            ctrlSearchForPerson1.DisableSearchFeature(true);
            tboxUserName.Enabled = false;

            tboxPassword.Enabled = false;
            tboxConfirmPassword.Enabled = false;
            chboxIsActive.Enabled = false;
            
            btnSave.Enabled = false;
        }

        private void SetUserDataToForm()
        {
            if(!(_formUser is null))
            {
                lblUserIdValue.Text = _formUser.Id.ToString();
                tboxUserName.Text = _formUser.Username;

                tboxPassword.Text = _formUser.Password;
                tboxConfirmPassword.Text = _formUser.Password;

                ctrlSearchForPerson1.LoadPersonDetails(_formUser.PersonId);
            }
        }

        private void LoadUserData(int userId)
        {
            if (clsUser.GetBy(userId, out string error) is clsUser user
                && !(user is null))
            {
                _formUser = user;
            }

            SetUserDataToForm();
        }

        private void CtrlSearchForPerson1_SearchResultHandler(int personId)
            => _formUser.PersonId = personId;

        private void btnPersonInfoNext_Click(object sender, EventArgs e)
            => tctrlAddEditUser.SelectedTab = tctrlAddEditUser.TabPages[1];

        private void btnPreviousTab_Click(object sender, EventArgs e)
            => tctrlAddEditUser.SelectedTab = tctrlAddEditUser.TabPages[0];

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(_formUser.Save(out string errorMessage))
                lblUserIdValue.Text = _formUser.Id.ToString();
            else
            {
                if(!string.IsNullOrEmpty(errorMessage))
                    MessageBox.Show(errorMessage,
                        "Error Message :(", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }
    }
}
