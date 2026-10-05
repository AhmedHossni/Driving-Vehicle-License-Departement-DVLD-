namespace Driving___Vehicle_License_Departement__DVLD_.Test.Tests
{
    partial class frmVisionTestAppointments
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
            this.ctrlLocalDrivingLicenseApplicationBasicInfo1 = new Driving___Vehicle_License_Departement__DVLD_.Local_Driving_License.Control.ctrlLocalDrivingLicenseApplicationBasicInfo();
            this.ctrlApplicationFullInfo1 = new Driving___Vehicle_License_Departement__DVLD_.Application.Control.ctrlApplicationFullInfo();
            this.SuspendLayout();
            // 
            // ctrlLocalDrivingLicenseApplicationBasicInfo1
            // 
            this.ctrlLocalDrivingLicenseApplicationBasicInfo1.Location = new System.Drawing.Point(3, 3);
            this.ctrlLocalDrivingLicenseApplicationBasicInfo1.Name = "ctrlLocalDrivingLicenseApplicationBasicInfo1";
            this.ctrlLocalDrivingLicenseApplicationBasicInfo1.Size = new System.Drawing.Size(905, 205);
            this.ctrlLocalDrivingLicenseApplicationBasicInfo1.TabIndex = 0;
            // 
            // ctrlApplicationFullInfo1
            // 
            this.ctrlApplicationFullInfo1.Location = new System.Drawing.Point(3, 215);
            this.ctrlApplicationFullInfo1.Name = "ctrlApplicationFullInfo1";
            this.ctrlApplicationFullInfo1.Size = new System.Drawing.Size(905, 229);
            this.ctrlApplicationFullInfo1.TabIndex = 1;
            // 
            // frmVisionTestAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 500);
            this.Controls.Add(this.ctrlApplicationFullInfo1);
            this.Controls.Add(this.ctrlLocalDrivingLicenseApplicationBasicInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmVisionTestAppointments";
            this.Text = "Vision Test Appointments";
            this.ResumeLayout(false);

        }

        #endregion

        private Local_Driving_License.Control.ctrlLocalDrivingLicenseApplicationBasicInfo ctrlLocalDrivingLicenseApplicationBasicInfo1;
        private Application.Control.ctrlApplicationFullInfo ctrlApplicationFullInfo1;
    }
}