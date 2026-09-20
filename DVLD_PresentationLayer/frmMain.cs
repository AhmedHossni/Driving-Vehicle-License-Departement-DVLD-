using Driving___Vehicle_License_Departement__DVLD_.People_Forms;
using Driving___Vehicle_License_Departement__DVLD_.User_Forms;
using DVLD_BusinessLogicLayer;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_
{
    public partial class frmMain : frmMainStyle
    {
        public frmMain()
        {
            InitializeComponent();

            // Move form position on the screen
            pnlLogo.MouseDown += frm_MouseDown;
            pnlMainBtns.MouseDown += frm_MouseDown;
            pnlFrmBtns.MouseDown += frm_MouseDown;

            SetupCustomButton(btnApp, imglistMain.Images[0]);
            SetupCustomButton(btnPeople, imglistMain.Images[1]);
            SetupCustomButton(btnDrivers, imglistMain.Images[2]);
            SetupCustomButton(btnUsers, imglistMain.Images[3]);
            SetupCustomButton(btnAccountSettings, imglistMain.Images[4]);
        }

        private void SetupCustomButton(Button btn, Image btnImage)
        {
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            btn.Image = btnImage;
            btn.ImageAlign = ContentAlignment.MiddleLeft;
            btn.TextAlign = ContentAlignment.MiddleCenter; 
            btn.TextImageRelation = TextImageRelation.ImageBeforeText;

            btn.Padding = new Padding(8, 0, 8, 0);

            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;


            btn.BackColor = Color.FromArgb(245, 245, 247);
            btn.ForeColor = ColorTranslator.FromHtml("#DDAF79");

            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(230, 230, 235);
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(210, 210, 220);

        }

        private void buttonMinimize_Click(object sender, EventArgs e) =>
            this.WindowState = FormWindowState.Minimized;


        private void btnFormClose_Click(object sender, EventArgs e) =>
            this.Close();

        private void ShowBtnAccountSettingsCMS(object sender, EventArgs e)
        {
            cmsAccountSettingsBtn.Show(btnAccountSettings, new Point(0, btnAccountSettings.Height));
        }

        private void ShowBtnAccountSettingsCMS(object sender, MouseEventArgs e)
        {
            ShowBtnAccountSettingsCMS(sender, (EventArgs)e);
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            new frmUsersList().ShowDialog();
        }

        private void btnPeople_Click(object sender, EventArgs e)
        {
            new frmPeopleList().ShowDialog();
        }

        private void cmsAccountSettingsBtn_MouseLeave(object sender, EventArgs e)
        {
            cmsAccountSettingsBtn.Close();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserFullInformaion userFullInformaion = 
                new frmUserFullInformaion(clsUser.SystemUser.Id, 
                clsUser.SystemUser.PersonId);

            userFullInformaion.ShowDialog();
        }

        private void btnsExceptAccountSettings_MouseMove(object sender, MouseEventArgs e)
        {
            cmsAccountSettingsBtn.Close();
        }
    }
}
