using DVLD_BusinessLogicLayer;
using System;
using System.Text;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.User_Forms
{
    public partial class frmChangeUserPassword : Form
    {
        private clsUser _formUser 
            = new clsUser();

        readonly int _personId = -1;

        public event Action UserDataChangedHandler;
        public event Action PersonDataChangedHandler;

        public frmChangeUserPassword(int userId, int personId,
            Action userDataChangedHandler = null,
            Action personDataChangedHandler = null)
        {
            InitializeComponent();

            if (userId != clsUser.SystemUser.Id)
                CancelEditMode();

            LoadUserDataToForm(userId);

            ctrlUserInfo1.LoadUserInfo(userId);

            _personId = personId;
            UserDataChangedHandler = userDataChangedHandler;
            PersonDataChangedHandler = personDataChangedHandler;

            CtrlPersonInfo1_PersonDataChangedHandler();

            ctrlPersonInfo1.PersonDataChangedHandler += CtrlPersonInfo1_PersonDataChangedHandler;
        }

        private void CancelEditMode()
        {
            
            tboxCurrentPassword.Enabled = false;
            tboxNewPassword.Enabled = false;
            tboxConfirmPassword.Enabled = false;

            btnSave.Enabled = false;

            MessageBox.Show("You can't change other users password.",
                "Invalid Operation :)",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void LoadUserDataToForm(int userId)
        {
            if (clsUser.GetBy(userId, out string error) is clsUser user
                && !(user is null))
            {
                _formUser = user;
            }
        }

        private void CtrlPersonInfo1_PersonDataChangedHandler()
        {
            ctrlPersonInfo1.LoadPersonData(_personId);

            PersonDataChangedHandler?.Invoke();
        }

        private void PasswordsTBox_Leave(object sender, EventArgs e)
        {
            if(((TextBox)sender).Text == string.Empty)
                epMainError.SetError((TextBox)sender, "Password can't be empty");
            else 
                epMainError.SetError((TextBox)sender, string.Empty);
        }

        private bool NewPasswordsAreMatch()
        {
            return tboxNewPassword.Text == tboxConfirmPassword.Text;
        }

        private void tboxConfirmPassword_Leave(object sender, EventArgs e)
        {
            if (!NewPasswordsAreMatch())
                epMainError.SetError((TextBox)sender, "Passwords do not match.");
            else 
                epMainError.SetError((TextBox)sender, string.Empty);
        }

        private bool CheckCurrentUserPasswordIsTrue()
        {
            return tboxCurrentPassword.Text == _formUser.Password;
        }

        private bool ValidateUserData()
        {
            StringBuilder errorMessage
                = new StringBuilder(string.Empty);

            if (!CheckCurrentUserPasswordIsTrue())
            {
                errorMessage.AppendLine("- Current password is incorrect.");

                epMainError.SetError(tboxCurrentPassword, "Current password is incorrect.");
            }

            if (string.IsNullOrEmpty(tboxNewPassword.Text))
            {
                errorMessage.AppendLine("- Password can not be empty.");

                PasswordsTBox_Leave(tboxNewPassword, new EventArgs());
            }

            if (!NewPasswordsAreMatch())
            {
                errorMessage.AppendLine("- Passwords do not match.");

                epMainError.SetError(tboxConfirmPassword, "Passwords do not match.");
            }

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
                MessageBox.Show("The operation has been completed successfully.",
                    "Success :)",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                if (!string.IsNullOrEmpty(errorMessage))
                    MessageBox.Show(errorMessage,
                        "Error Message :(", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }

        private void LoadUserDataFromForm()
        {
            _formUser.Password = tboxNewPassword.Text;
        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();
    }
}
