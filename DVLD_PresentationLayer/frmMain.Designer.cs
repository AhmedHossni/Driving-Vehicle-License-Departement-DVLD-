namespace Driving___Vehicle_License_Departement__DVLD_
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnlMainBtns = new System.Windows.Forms.Panel();
            this.pnlFrmBtns = new System.Windows.Forms.Panel();
            this.btnAccountSettings = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnDrivers = new System.Windows.Forms.Button();
            this.btnPeople = new System.Windows.Forms.Button();
            this.btnApp = new System.Windows.Forms.Button();
            this.cmsAccountSettingsBtn = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.imglistMain = new System.Windows.Forms.ImageList(this.components);
            this.cmsApplicationBtn = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.currentUserInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.manageApplicationTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageTestTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMainBtns.SuspendLayout();
            this.cmsAccountSettingsBtn.SuspendLayout();
            this.cmsApplicationBtn.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMainBtns
            // 
            this.pnlMainBtns.BackColor = System.Drawing.Color.White;
            this.pnlMainBtns.Controls.Add(this.pnlFrmBtns);
            this.pnlMainBtns.Controls.Add(this.btnAccountSettings);
            this.pnlMainBtns.Controls.Add(this.btnUsers);
            this.pnlMainBtns.Controls.Add(this.btnDrivers);
            this.pnlMainBtns.Controls.Add(this.btnPeople);
            this.pnlMainBtns.Controls.Add(this.btnApp);
            this.pnlMainBtns.Location = new System.Drawing.Point(-5, -1);
            this.pnlMainBtns.Name = "pnlMainBtns";
            this.pnlMainBtns.Size = new System.Drawing.Size(1171, 162);
            this.pnlMainBtns.TabIndex = 0;
            // 
            // pnlFrmBtns
            // 
            this.pnlFrmBtns.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(16)))), ((int)(((byte)(25)))));
            this.pnlFrmBtns.Location = new System.Drawing.Point(3, 0);
            this.pnlFrmBtns.Name = "pnlFrmBtns";
            this.pnlFrmBtns.Size = new System.Drawing.Size(1175, 43);
            this.pnlFrmBtns.TabIndex = 5;
            // 
            // btnAccountSettings
            // 
            this.btnAccountSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(197)))), ((int)(((byte)(138)))));
            this.btnAccountSettings.Location = new System.Drawing.Point(789, 67);
            this.btnAccountSettings.Name = "btnAccountSettings";
            this.btnAccountSettings.Size = new System.Drawing.Size(187, 67);
            this.btnAccountSettings.TabIndex = 4;
            this.btnAccountSettings.Text = "Account Settings";
            this.btnAccountSettings.UseVisualStyleBackColor = true;
            this.btnAccountSettings.Click += new System.EventHandler(this.ShowBtnAccountSettingsCMS);
            this.btnAccountSettings.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ShowBtnAccountSettingsCMS);
            // 
            // btnUsers
            // 
            this.btnUsers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(197)))), ((int)(((byte)(138)))));
            this.btnUsers.Location = new System.Drawing.Point(596, 67);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(187, 67);
            this.btnUsers.TabIndex = 3;
            this.btnUsers.Text = "Users";
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            this.btnUsers.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnsExceptAccountSettings_MouseMove);
            // 
            // btnDrivers
            // 
            this.btnDrivers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(197)))), ((int)(((byte)(138)))));
            this.btnDrivers.Location = new System.Drawing.Point(403, 67);
            this.btnDrivers.Name = "btnDrivers";
            this.btnDrivers.Size = new System.Drawing.Size(187, 67);
            this.btnDrivers.TabIndex = 2;
            this.btnDrivers.Text = "Drivers";
            this.btnDrivers.UseVisualStyleBackColor = true;
            this.btnDrivers.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnsExceptAccountSettings_MouseMove);
            // 
            // btnPeople
            // 
            this.btnPeople.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(197)))), ((int)(((byte)(138)))));
            this.btnPeople.Location = new System.Drawing.Point(210, 67);
            this.btnPeople.Name = "btnPeople";
            this.btnPeople.Size = new System.Drawing.Size(187, 67);
            this.btnPeople.TabIndex = 1;
            this.btnPeople.Text = "People";
            this.btnPeople.UseVisualStyleBackColor = true;
            this.btnPeople.Click += new System.EventHandler(this.btnPeople_Click);
            this.btnPeople.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnsExceptAccountSettings_MouseMove);
            // 
            // btnApp
            // 
            this.btnApp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(197)))), ((int)(((byte)(138)))));
            this.btnApp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApp.Location = new System.Drawing.Point(17, 67);
            this.btnApp.Name = "btnApp";
            this.btnApp.Size = new System.Drawing.Size(187, 67);
            this.btnApp.TabIndex = 0;
            this.btnApp.Text = "Applications";
            this.btnApp.UseVisualStyleBackColor = true;
            this.btnApp.Click += new System.EventHandler(this.btnApp_Click);
            this.btnApp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnApp_MouseMove);
            // 
            // cmsAccountSettingsBtn
            // 
            this.cmsAccountSettingsBtn.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsAccountSettingsBtn.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentUserInfoToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.signOutToolStripMenuItem});
            this.cmsAccountSettingsBtn.Name = "cmsAccountSettingsBtn";
            this.cmsAccountSettingsBtn.Size = new System.Drawing.Size(198, 82);
            this.cmsAccountSettingsBtn.MouseLeave += new System.EventHandler(this.cmsAccountSettingsBtn_MouseLeave);
            // 
            // imglistMain
            // 
            this.imglistMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglistMain.ImageStream")));
            this.imglistMain.TransparentColor = System.Drawing.Color.Transparent;
            this.imglistMain.Images.SetKeyName(0, "member.png");
            this.imglistMain.Images.SetKeyName(1, "customers-icon-35912.png");
            this.imglistMain.Images.SetKeyName(2, "users.png");
            this.imglistMain.Images.SetKeyName(3, "users.png");
            this.imglistMain.Images.SetKeyName(4, "account_settings.png");
            // 
            // cmsApplicationBtn
            // 
            this.cmsApplicationBtn.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsApplicationBtn.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.manageApplicationTypesToolStripMenuItem,
            this.manageTestTypesToolStripMenuItem});
            this.cmsApplicationBtn.Name = "cmsAccountSettingsBtn";
            this.cmsApplicationBtn.Size = new System.Drawing.Size(259, 134);
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.Black;
            this.pnlLogo.BackgroundImage = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.Gemini_Generated_Image_8di3kg8di3kg8di3_removebg_preview__1_;
            this.pnlLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlLogo.Location = new System.Drawing.Point(-5, 154);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(1168, 422);
            this.pnlLogo.TabIndex = 1;
            // 
            // currentUserInfoToolStripMenuItem
            // 
            this.currentUserInfoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("currentUserInfoToolStripMenuItem.Image")));
            this.currentUserInfoToolStripMenuItem.Name = "currentUserInfoToolStripMenuItem";
            this.currentUserInfoToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.currentUserInfoToolStripMenuItem.Text = "Current User Info";
            this.currentUserInfoToolStripMenuItem.Click += new System.EventHandler(this.currentUserInfoToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("changePasswordToolStripMenuItem.Image")));
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // signOutToolStripMenuItem
            // 
            this.signOutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("signOutToolStripMenuItem.Image")));
            this.signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            this.signOutToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.signOutToolStripMenuItem.Text = "Sign Out";
            this.signOutToolStripMenuItem.Click += new System.EventHandler(this.signOutToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.LicenseView_400;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(258, 26);
            this.toolStripMenuItem1.Text = "Driving Licences Services";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.Applications;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(258, 26);
            this.toolStripMenuItem2.Text = "Manage Applications";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.Detain_512;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(258, 26);
            this.toolStripMenuItem3.Text = "Detain Licenses";
            // 
            // manageApplicationTypesToolStripMenuItem
            // 
            this.manageApplicationTypesToolStripMenuItem.Image = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.Application_Types_5121;
            this.manageApplicationTypesToolStripMenuItem.Name = "manageApplicationTypesToolStripMenuItem";
            this.manageApplicationTypesToolStripMenuItem.Size = new System.Drawing.Size(258, 26);
            this.manageApplicationTypesToolStripMenuItem.Text = "Manage Application Types";
            this.manageApplicationTypesToolStripMenuItem.Click += new System.EventHandler(this.manageApplicationTypesToolStripMenuItem_Click);
            // 
            // manageTestTypesToolStripMenuItem
            // 
            this.manageTestTypesToolStripMenuItem.Image = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.TestType_512;
            this.manageTestTypesToolStripMenuItem.Name = "manageTestTypesToolStripMenuItem";
            this.manageTestTypesToolStripMenuItem.Size = new System.Drawing.Size(258, 26);
            this.manageTestTypesToolStripMenuItem.Text = "Manage Test Types";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1163, 587);
            this.Controls.Add(this.pnlLogo);
            this.Controls.Add(this.pnlMainBtns);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmMain";
            this.Text = "Main Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.pnlMainBtns.ResumeLayout(false);
            this.cmsAccountSettingsBtn.ResumeLayout(false);
            this.cmsApplicationBtn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMainBtns;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Button btnAccountSettings;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnDrivers;
        private System.Windows.Forms.Button btnPeople;
        private System.Windows.Forms.Button btnApp;
        private System.Windows.Forms.ImageList imglistMain;
        private System.Windows.Forms.ContextMenuStrip cmsAccountSettingsBtn;
        private System.Windows.Forms.ToolStripMenuItem currentUserInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signOutToolStripMenuItem;
        private System.Windows.Forms.Panel pnlFrmBtns;
        private System.Windows.Forms.ContextMenuStrip cmsApplicationBtn;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem manageApplicationTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageTestTypesToolStripMenuItem;
    }
}