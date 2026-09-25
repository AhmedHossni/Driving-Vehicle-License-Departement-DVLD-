using DVLD_BusinessLogicLayer;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.User_Forms
{
    public partial class ctrlUserInfo : UserControl
    {
        public ctrlUserInfo()
        {
            InitializeComponent();
        }

        public void LoadUserInfo(int userId)
        {
            if (userId <= 0)
                return;

            clsUser user = clsUser.GetBy(userId, out string errorMessage);

            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage,
                    "Error Message :(",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            if (user != null)
            {
                lblUserIdValue.Text = user.Id.ToString();
                lblUsernameValue.Text = user.Username.ToString();
                lblIsActiveValue.Text = user.IsActive ? "Yes" : "No";
            }
        }

    }
}
