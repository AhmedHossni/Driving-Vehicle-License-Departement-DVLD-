using DVLD_BusinessLogicLayer;
using System;
using System.Text;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.User_Forms
{
    public partial class frmAddEditUser : Form
    {
        clsUser _formUser 
            = new clsUser();

        public event Action AddOrEditUserOperationHandler;

        public frmAddEditUser(int userId)
        {
            InitializeComponent();              

            if (userId != -1)
            {
                LoadUserDataToForm(userId);
                this.Text = "Edit User Info";
            }
            else
            {
                this.Text = "Add New User";
            }

            if (clsUser.SystemUser?.Id != userId
                && _formUser.PersonId != -1)
                DisableEditUserInfo();

            ctrlSearchForPerson.SearchResultHandler
                += CtrlSearchForPerson1_SearchResultHandler;
        }

        private void DisableEditUserInfo()
        {
            ctrlSearchForPerson.DisableSearchFeature(true);
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

                ctrlSearchForPerson.LoadPersonDetails(_formUser.PersonId);
            }
        }

        private void LoadUserDataToForm(int userId)
        {
            if (clsUser.GetBy(userId, out string error) is clsUser user
                && !(user is null))
            {
                _formUser = user;
            }

            SetUserDataToForm();
        }

        private void LoadUserDataFromForm()
        {
            _formUser.Username = tboxUserName.Text;

            _formUser.Password = tboxPassword.Text;

            _formUser.IsActive = chboxIsActive.Checked;
        }

        private void CtrlSearchForPerson1_SearchResultHandler(int personId)
            => _formUser.PersonId = personId;

        private void btnPersonInfoNext_Click(object sender, EventArgs e)
            => tctrlAddEditUser.SelectedTab = tctrlAddEditUser.TabPages[1];

        private void btnPreviousTab_Click(object sender, EventArgs e)
            => tctrlAddEditUser.SelectedTab = tctrlAddEditUser.TabPages[0];

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();

        private bool ValidateUserData()
        {
            StringBuilder errorMessage 
                = new StringBuilder(string.Empty);

            if(!string.IsNullOrEmpty(epIsUserDataValid.GetError(tboxUserName)))
                errorMessage.AppendLine("- Username can't be empty!");


            if (string.IsNullOrEmpty(tboxPassword.Text))
            {
                errorMessage.AppendLine("- Password can not be empty.");

                SetTextBoxErrorMessageIfEmpty(tboxPassword);
            }

            if (!IsPasswordAndHisConfirmEquals())
            {
                errorMessage.AppendLine("- Passwords do not match.");

                epIsUserDataValid.SetError(tboxConfirmPassword, "Passwords do not match.");
            }

            if (_formUser.PersonId == -1)
                errorMessage.AppendLine("- You should select a person");


            if (!string.IsNullOrEmpty(errorMessage.ToString()))
            {
                MessageBox.Show(errorMessage.ToString(),
                    "Invalid value :(",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateUserData())
                return;

            LoadUserDataFromForm();

            if (_formUser.Save(out string errorMessage))
            {
                lblUserIdValue.Text = _formUser.Id.ToString();

                this.Text = "Edit User Info";

                MessageBox.Show("The operation has been completed successfully.",
                    "Success :)",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                AddOrEditUserOperationHandler?.Invoke();
            }
            else
            {
                if(!string.IsNullOrEmpty(errorMessage))
                    MessageBox.Show(errorMessage,
                        "Error Message :(", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }

        private void userDataTextBox_Leave(object sender, EventArgs e)
        {
            if(sender is TextBox textBox)
                SetTextBoxErrorMessageIfEmpty(textBox);

        }

        private void SetTextBoxErrorMessageIfEmpty(TextBox textBox)
        {
            if (textBox is null)
                return;

            if (string.IsNullOrEmpty(textBox.Text))
                epIsUserDataValid.SetError(textBox, $"{textBox.Tag} can't be empty!");
            else
                epIsUserDataValid.SetError(textBox, string.Empty);
        }

        private bool IsPasswordAndHisConfirmEquals()
            => tboxPassword.Text == tboxConfirmPassword.Text;

        private void tboxConfirmPassword_Leave(object sender, EventArgs e)
        {
            if (!IsPasswordAndHisConfirmEquals())
                epIsUserDataValid.SetError(tboxConfirmPassword, $"Passwords do not match.");
            else
                epIsUserDataValid.SetError(tboxConfirmPassword, string.Empty);
        }
    }
}
