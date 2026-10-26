namespace Driving___Vehicle_License_Departement__DVLD_.License.Local
{
    partial class frmReplacementForDamagedOrLostLicense
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
            this.ctrlDriverLicenseInfo1 = new Driving___Vehicle_License_Departement__DVLD_.License.Control.ctrlDriverLicenseInfo();
            this.ctrlLicenseFilter1 = new Driving___Vehicle_License_Departement__DVLD_.License.International.Control.ctrlLicenseFilter();
            this.ctrlApplicationInfoForLicenseReplacement1 = new Driving___Vehicle_License_Departement__DVLD_.Local_Driving_License.Control.ctrlApplicationInfoForLicenseReplacement();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnLostLicense = new System.Windows.Forms.RadioButton();
            this.rbtnDamagedLicense = new System.Windows.Forms.RadioButton();
            this.llblShowNewLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.llblShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.btnIssueReplacement = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlDriverLicenseInfo1
            // 
            this.ctrlDriverLicenseInfo1.Location = new System.Drawing.Point(20, 153);
            this.ctrlDriverLicenseInfo1.Name = "ctrlDriverLicenseInfo1";
            this.ctrlDriverLicenseInfo1.Size = new System.Drawing.Size(866, 341);
            this.ctrlDriverLicenseInfo1.TabIndex = 3;
            // 
            // ctrlLicenseFilter1
            // 
            this.ctrlLicenseFilter1.Location = new System.Drawing.Point(2, 3);
            this.ctrlLicenseFilter1.Name = "ctrlLicenseFilter1";
            this.ctrlLicenseFilter1.Size = new System.Drawing.Size(677, 150);
            this.ctrlLicenseFilter1.TabIndex = 2;
            // 
            // ctrlApplicationInfoForLicenseReplacement1
            // 
            this.ctrlApplicationInfoForLicenseReplacement1.Location = new System.Drawing.Point(4, 488);
            this.ctrlApplicationInfoForLicenseReplacement1.Name = "ctrlApplicationInfoForLicenseReplacement1";
            this.ctrlApplicationInfoForLicenseReplacement1.Size = new System.Drawing.Size(905, 180);
            this.ctrlApplicationInfoForLicenseReplacement1.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnLostLicense);
            this.groupBox1.Controls.Add(this.rbtnDamagedLicense);
            this.groupBox1.Location = new System.Drawing.Point(685, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(201, 135);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Replacement For:";
            // 
            // rbtnLostLicense
            // 
            this.rbtnLostLicense.AutoSize = true;
            this.rbtnLostLicense.Location = new System.Drawing.Point(6, 88);
            this.rbtnLostLicense.Name = "rbtnLostLicense";
            this.rbtnLostLicense.Size = new System.Drawing.Size(103, 21);
            this.rbtnLostLicense.TabIndex = 1;
            this.rbtnLostLicense.Text = "Lost License";
            this.rbtnLostLicense.UseVisualStyleBackColor = true;
            this.rbtnLostLicense.CheckedChanged += new System.EventHandler(this.rbtnLostLicense_CheckedChanged);
            // 
            // rbtnDamagedLicense
            // 
            this.rbtnDamagedLicense.AutoSize = true;
            this.rbtnDamagedLicense.Checked = true;
            this.rbtnDamagedLicense.Location = new System.Drawing.Point(6, 41);
            this.rbtnDamagedLicense.Name = "rbtnDamagedLicense";
            this.rbtnDamagedLicense.Size = new System.Drawing.Size(136, 21);
            this.rbtnDamagedLicense.TabIndex = 0;
            this.rbtnDamagedLicense.TabStop = true;
            this.rbtnDamagedLicense.Text = "Damaged License";
            this.rbtnDamagedLicense.UseVisualStyleBackColor = true;
            this.rbtnDamagedLicense.CheckedChanged += new System.EventHandler(this.rbtnDamagedLicense_CheckedChanged);
            // 
            // llblShowNewLicenseInfo
            // 
            this.llblShowNewLicenseInfo.AutoSize = true;
            this.llblShowNewLicenseInfo.Enabled = false;
            this.llblShowNewLicenseInfo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblShowNewLicenseInfo.Location = new System.Drawing.Point(239, 677);
            this.llblShowNewLicenseInfo.Name = "llblShowNewLicenseInfo";
            this.llblShowNewLicenseInfo.Size = new System.Drawing.Size(247, 24);
            this.llblShowNewLicenseInfo.TabIndex = 157;
            this.llblShowNewLicenseInfo.TabStop = true;
            this.llblShowNewLicenseInfo.Text = "Show New License Info";
            this.llblShowNewLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblShowNewLicenseInfo_LinkClicked);
            // 
            // llblShowLicenseHistory
            // 
            this.llblShowLicenseHistory.AutoSize = true;
            this.llblShowLicenseHistory.Enabled = false;
            this.llblShowLicenseHistory.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblShowLicenseHistory.Location = new System.Drawing.Point(8, 677);
            this.llblShowLicenseHistory.Name = "llblShowLicenseHistory";
            this.llblShowLicenseHistory.Size = new System.Drawing.Size(225, 24);
            this.llblShowLicenseHistory.TabIndex = 156;
            this.llblShowLicenseHistory.TabStop = true;
            this.llblShowLicenseHistory.Text = "Show License History";
            this.llblShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblShowLicenseHistory_LinkClicked);
            // 
            // btnIssueReplacement
            // 
            this.btnIssueReplacement.Enabled = false;
            this.btnIssueReplacement.Image = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.Renew_Driving_License_32;
            this.btnIssueReplacement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssueReplacement.Location = new System.Drawing.Point(691, 674);
            this.btnIssueReplacement.Name = "btnIssueReplacement";
            this.btnIssueReplacement.Size = new System.Drawing.Size(214, 42);
            this.btnIssueReplacement.TabIndex = 155;
            this.btnIssueReplacement.Text = "Issue Replacement";
            this.btnIssueReplacement.UseVisualStyleBackColor = true;
            this.btnIssueReplacement.Click += new System.EventHandler(this.btnIssueReplacemene_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(547, 674);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(132, 42);
            this.btnClose.TabIndex = 154;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmReplacementForDamagedOrLostLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 725);
            this.Controls.Add(this.llblShowNewLicenseInfo);
            this.Controls.Add(this.llblShowLicenseHistory);
            this.Controls.Add(this.btnIssueReplacement);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctrlApplicationInfoForLicenseReplacement1);
            this.Controls.Add(this.ctrlDriverLicenseInfo1);
            this.Controls.Add(this.ctrlLicenseFilter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmReplacementForDamagedOrLostLicense";
            this.Text = "Replacement For Damaged Or Lost License";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Control.ctrlDriverLicenseInfo ctrlDriverLicenseInfo1;
        private International.Control.ctrlLicenseFilter ctrlLicenseFilter1;
        private Local_Driving_License.Control.ctrlApplicationInfoForLicenseReplacement ctrlApplicationInfoForLicenseReplacement1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnLostLicense;
        private System.Windows.Forms.RadioButton rbtnDamagedLicense;
        private System.Windows.Forms.LinkLabel llblShowNewLicenseInfo;
        private System.Windows.Forms.LinkLabel llblShowLicenseHistory;
        private System.Windows.Forms.Button btnIssueReplacement;
        private System.Windows.Forms.Button btnClose;
    }
}