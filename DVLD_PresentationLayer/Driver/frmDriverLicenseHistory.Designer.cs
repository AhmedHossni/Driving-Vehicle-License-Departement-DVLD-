namespace Driving___Vehicle_License_Departement__DVLD_.Driver
{
    partial class frmDriverLicenseHistory
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
            this.ctrlDriverLicenses1 = new Driving___Vehicle_License_Departement__DVLD_.License.Control.ctrlDriverLicenses();
            this.ctrlSearchForPerson1 = new Driving___Vehicle_License_Departement__DVLD_.Person_Forms.ctrlSearchForPerson();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlDriverLicenses1
            // 
            this.ctrlDriverLicenses1.Location = new System.Drawing.Point(2, 439);
            this.ctrlDriverLicenses1.Name = "ctrlDriverLicenses1";
            this.ctrlDriverLicenses1.Size = new System.Drawing.Size(1185, 340);
            this.ctrlDriverLicenses1.TabIndex = 1;
            // 
            // ctrlSearchForPerson1
            // 
            this.ctrlSearchForPerson1.Location = new System.Drawing.Point(252, 12);
            this.ctrlSearchForPerson1.Name = "ctrlSearchForPerson1";
            this.ctrlSearchForPerson1.Size = new System.Drawing.Size(935, 429);
            this.ctrlSearchForPerson1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.PersonLicenseHistory_512;
            this.pictureBox1.Location = new System.Drawing.Point(2, 68);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(244, 328);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // frmDriverLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 780);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ctrlDriverLicenses1);
            this.Controls.Add(this.ctrlSearchForPerson1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDriverLicenseHistory";
            this.Text = "Driver License History";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Person_Forms.ctrlSearchForPerson ctrlSearchForPerson1;
        private License.Control.ctrlDriverLicenses ctrlDriverLicenses1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}