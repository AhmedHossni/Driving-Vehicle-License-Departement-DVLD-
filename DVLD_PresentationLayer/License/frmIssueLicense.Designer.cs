namespace Driving___Vehicle_License_Departement__DVLD_.License
{
    partial class frmIssueLicense
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
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnIssue = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrlApplicationFullInfo1 = new Driving___Vehicle_License_Departement__DVLD_.Application.Control.ctrlApplicationFullInfo();
            this.ctrlLocalDrivingLicenseApplicationBasicInfo1 = new Driving___Vehicle_License_Departement__DVLD_.Local_Driving_License.Control.ctrlLocalDrivingLicenseApplicationBasicInfo();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 461);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Notes :";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Location = new System.Drawing.Point(92, 465);
            this.richTextBox1.MaxLength = 500;
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(807, 210);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // btnIssue
            // 
            this.btnIssue.Image = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.IssueDrivingLicense_321;
            this.btnIssue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssue.Location = new System.Drawing.Point(767, 694);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(132, 43);
            this.btnIssue.TabIndex = 147;
            this.btnIssue.Text = "Issue";
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(629, 694);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(132, 43);
            this.btnClose.TabIndex = 146;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrlApplicationFullInfo1
            // 
            this.ctrlApplicationFullInfo1.Location = new System.Drawing.Point(3, 214);
            this.ctrlApplicationFullInfo1.Name = "ctrlApplicationFullInfo1";
            this.ctrlApplicationFullInfo1.Size = new System.Drawing.Size(905, 229);
            this.ctrlApplicationFullInfo1.TabIndex = 1;
            // 
            // ctrlLocalDrivingLicenseApplicationBasicInfo1
            // 
            this.ctrlLocalDrivingLicenseApplicationBasicInfo1.Location = new System.Drawing.Point(3, 3);
            this.ctrlLocalDrivingLicenseApplicationBasicInfo1.Name = "ctrlLocalDrivingLicenseApplicationBasicInfo1";
            this.ctrlLocalDrivingLicenseApplicationBasicInfo1.Size = new System.Drawing.Size(905, 205);
            this.ctrlLocalDrivingLicenseApplicationBasicInfo1.TabIndex = 0;
            // 
            // frmIssueLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 749);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlApplicationFullInfo1);
            this.Controls.Add(this.ctrlLocalDrivingLicenseApplicationBasicInfo1);
            this.Name = "frmIssueLicense";
            this.Text = "Issue Driving License For First Time";
            this.Load += new System.EventHandler(this.frmIssueLicense_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Local_Driving_License.Control.ctrlLocalDrivingLicenseApplicationBasicInfo ctrlLocalDrivingLicenseApplicationBasicInfo1;
        private Application.Control.ctrlApplicationFullInfo ctrlApplicationFullInfo1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.Button btnClose;
    }
}