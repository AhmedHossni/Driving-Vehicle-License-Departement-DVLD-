namespace Driving___Vehicle_License_Departement__DVLD_.License.Local
{
    partial class frmReleaseDetainedLicense
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
            this.llblShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.llblShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.btnReleaseLicense = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrlReleaseDetainedLicenseInfo1 = new Driving___Vehicle_License_Departement__DVLD_.License.Control.ctrlReleaseDetainedLicenseInfo();
            this.ctrlDriverLicenseInfo1 = new Driving___Vehicle_License_Departement__DVLD_.License.Control.ctrlDriverLicenseInfo();
            this.ctrlLicenseFilter1 = new Driving___Vehicle_License_Departement__DVLD_.License.International.Control.ctrlLicenseFilter();
            this.SuspendLayout();
            // 
            // llblShowLicenseInfo
            // 
            this.llblShowLicenseInfo.AutoSize = true;
            this.llblShowLicenseInfo.Enabled = false;
            this.llblShowLicenseInfo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblShowLicenseInfo.Location = new System.Drawing.Point(243, 702);
            this.llblShowLicenseInfo.Name = "llblShowLicenseInfo";
            this.llblShowLicenseInfo.Size = new System.Drawing.Size(196, 24);
            this.llblShowLicenseInfo.TabIndex = 157;
            this.llblShowLicenseInfo.TabStop = true;
            this.llblShowLicenseInfo.Text = "Show License Info";
            this.llblShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblShowNewLicenseInfo_LinkClicked);
            // 
            // llblShowLicenseHistory
            // 
            this.llblShowLicenseHistory.AutoSize = true;
            this.llblShowLicenseHistory.Enabled = false;
            this.llblShowLicenseHistory.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblShowLicenseHistory.Location = new System.Drawing.Point(12, 702);
            this.llblShowLicenseHistory.Name = "llblShowLicenseHistory";
            this.llblShowLicenseHistory.Size = new System.Drawing.Size(225, 24);
            this.llblShowLicenseHistory.TabIndex = 156;
            this.llblShowLicenseHistory.TabStop = true;
            this.llblShowLicenseHistory.Text = "Show License History";
            this.llblShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblShowLicenseHistory_LinkClicked);
            // 
            // btnReleaseLicense
            // 
            this.btnReleaseLicense.Enabled = false;
            this.btnReleaseLicense.Image = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.Release_Detained_License_32;
            this.btnReleaseLicense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReleaseLicense.Location = new System.Drawing.Point(727, 694);
            this.btnReleaseLicense.Name = "btnReleaseLicense";
            this.btnReleaseLicense.Size = new System.Drawing.Size(132, 42);
            this.btnReleaseLicense.TabIndex = 155;
            this.btnReleaseLicense.Text = "   Release";
            this.btnReleaseLicense.UseVisualStyleBackColor = true;
            this.btnReleaseLicense.Click += new System.EventHandler(this.btnReleaseLicense_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(589, 694);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(132, 42);
            this.btnClose.TabIndex = 154;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrlReleaseDetainedLicenseInfo1
            // 
            this.ctrlReleaseDetainedLicenseInfo1.Location = new System.Drawing.Point(1, 494);
            this.ctrlReleaseDetainedLicenseInfo1.Name = "ctrlReleaseDetainedLicenseInfo1";
            this.ctrlReleaseDetainedLicenseInfo1.Size = new System.Drawing.Size(866, 194);
            this.ctrlReleaseDetainedLicenseInfo1.TabIndex = 2;
            // 
            // ctrlDriverLicenseInfo1
            // 
            this.ctrlDriverLicenseInfo1.Location = new System.Drawing.Point(1, 152);
            this.ctrlDriverLicenseInfo1.Name = "ctrlDriverLicenseInfo1";
            this.ctrlDriverLicenseInfo1.Size = new System.Drawing.Size(866, 344);
            this.ctrlDriverLicenseInfo1.TabIndex = 1;
            // 
            // ctrlLicenseFilter1
            // 
            this.ctrlLicenseFilter1.Location = new System.Drawing.Point(1, 2);
            this.ctrlLicenseFilter1.Name = "ctrlLicenseFilter1";
            this.ctrlLicenseFilter1.Size = new System.Drawing.Size(676, 150);
            this.ctrlLicenseFilter1.TabIndex = 0;
            // 
            // frmReleaseDetainedLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 750);
            this.Controls.Add(this.llblShowLicenseInfo);
            this.Controls.Add(this.llblShowLicenseHistory);
            this.Controls.Add(this.btnReleaseLicense);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlReleaseDetainedLicenseInfo1);
            this.Controls.Add(this.ctrlDriverLicenseInfo1);
            this.Controls.Add(this.ctrlLicenseFilter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmReleaseDetainedLicense";
            this.Text = "Release Detained License";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private International.Control.ctrlLicenseFilter ctrlLicenseFilter1;
        private Control.ctrlDriverLicenseInfo ctrlDriverLicenseInfo1;
        private Control.ctrlReleaseDetainedLicenseInfo ctrlReleaseDetainedLicenseInfo1;
        private System.Windows.Forms.LinkLabel llblShowLicenseInfo;
        private System.Windows.Forms.LinkLabel llblShowLicenseHistory;
        private System.Windows.Forms.Button btnReleaseLicense;
        private System.Windows.Forms.Button btnClose;
    }
}