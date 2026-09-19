using CommonUseThings;
using DVLD_BusinessLogicLayer;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_
{
    public partial class frmLogin : frmMainStyle
    {

        private readonly string LoginFileFullName = $"{clsProjectSetting.FilesPath}\\LoginInfo.txt";
        public frmLogin()
        {
            InitializeComponent();

            // Move form position on the screen
            pnlEgyptFlagImg.MouseDown += frm_MouseDown;
            pnlLoginComponents.MouseDown += frm_MouseDown;

            // Allow the user to log in by pressing the Enter key
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(frmLogin_EnterKeyDown);
        }

        private void frmLogin_EnterKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoginProcess();
        }

        private void btnFormClose_Click(object sender, EventArgs e) => this.Close();

        private void btnLogin_Click(object sender, EventArgs e) => LoginProcess();

        private void LoginProcess()
        {
            string errorMessage = string.Empty;

            if (clsUser.CheckUsernameAndPassword(tboxUsername.Text, tboxPassword.Text, out errorMessage))
            {

                this.DialogResult = DialogResult.OK;

                if (chboxRememberMe.Checked)
                    RememberUserLoginInfo();
                else
                    ClearUserLoginInfo();

                this.Close();
            }
            else
            {
                if (!string.IsNullOrEmpty(errorMessage))
                    MessageBox.Show(errorMessage, "Error Message :("
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Username or password is not correct", "Login Faild :("
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RememberUserLoginInfo()
        {
            Directory.CreateDirectory(clsProjectSetting.FilesPath);

            using (var streamWriter = File.CreateText(LoginFileFullName))
            {
                streamWriter.WriteLine($"{tboxUsername.Text}\n{tboxPassword.Text}");
            }
        }
        private void ClearUserLoginInfo()
        {
            var streamWriter = File.CreateText(LoginFileFullName);
            streamWriter?.Dispose();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (File.Exists(LoginFileFullName))
            {
                var txtFileLines = File.ReadAllLines(LoginFileFullName);

                if(txtFileLines.Length == 2)
                {
                    tboxUsername.Text = txtFileLines[0];
                    tboxPassword.Text = txtFileLines[1];
                }
            }
            else
            {
                var streamWriter = File.CreateText(LoginFileFullName);
                streamWriter?.Dispose();
            }
        }
    }
}
