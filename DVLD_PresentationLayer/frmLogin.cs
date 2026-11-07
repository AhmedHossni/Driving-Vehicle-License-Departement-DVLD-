using CommonUseThings;
using DVLD_BusinessLogicLayer;
using Microsoft.Win32;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_
{
    public partial class frmLogin : frmMainStyle
    {

        private readonly string LoginFileFullName = $"{clsProjectSetting.FilesPath}\\LoginInfo.txt";
        public frmLogin()
        {
            InitializeComponent();

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

                // Save login info in text file
                //if (chboxRememberMe.Checked)
                //    SaveUserLoginInfoInTextFile();
                //else
                //    ClearUserLoginInfoFromTextFile();

                SaveUserLoginInfoInWinRegistry(!chboxRememberMe.Checked);

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

        private void SaveUserLoginInfoInTextFile()
        {
            Directory.CreateDirectory(clsProjectSetting.FilesPath);

            using (var streamWriter = File.CreateText(LoginFileFullName))
            {
                streamWriter.WriteLine($"{tboxUsername.Text}\n{tboxPassword.Text}");
            }
        }

        private void ClearUserLoginInfoFromTextFile()
        {
            var streamWriter = File.CreateText(LoginFileFullName);
            streamWriter?.Dispose();
        }

        private void SaveUserLoginInfoInWinRegistry(bool wantToClearLoginInfo)
        {
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD_App";

            try
            {
                Registry.SetValue(keyPath, "Username",
                    wantToClearLoginInfo ? string.Empty : tboxUsername.Text, RegistryValueKind.String);

                Registry.SetValue(keyPath, "Password",
                    wantToClearLoginInfo ? string.Empty : tboxPassword.Text, RegistryValueKind.String);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error message",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReadUserLoginInfoFromWinRegistry()
        {
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD_App";

            try
            {
                tboxUsername.Text = (string)Registry.GetValue(keyPath, "Username", string.Empty);
                tboxPassword.Text = (string)Registry.GetValue(keyPath, "Password", string.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error message",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReadUserLoginDataFromTextFile()
        {
            if (File.Exists(LoginFileFullName))
            {
                var txtFileLines = File.ReadAllLines(LoginFileFullName);

                if (txtFileLines.Length == 2)
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

        private void frmLogin_Load(object sender, EventArgs e)
        {
            // ReadUserLoginDataFromTextFile();

            ReadUserLoginInfoFromWinRegistry();
        }
    }
}
