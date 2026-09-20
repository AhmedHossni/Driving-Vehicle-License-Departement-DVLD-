namespace Driving___Vehicle_License_Departement__DVLD_.User_Forms
{
    partial class frmUserFullInformaion
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
            this.ctrlUserInfo1 = new Driving___Vehicle_License_Departement__DVLD_.User_Forms.ctrlUserInfo();
            this.ctrlPersonInfo1 = new Driving___Vehicle_License_Departement__DVLD_.Person_Forms.ctrlPersonInfo();
            this.SuspendLayout();
            // 
            // ctrlUserInfo1
            // 
            this.ctrlUserInfo1.Location = new System.Drawing.Point(3, 328);
            this.ctrlUserInfo1.Name = "ctrlUserInfo1";
            this.ctrlUserInfo1.Size = new System.Drawing.Size(930, 141);
            this.ctrlUserInfo1.TabIndex = 2;
            // 
            // ctrlPersonInfo1
            // 
            this.ctrlPersonInfo1.Location = new System.Drawing.Point(3, 3);
            this.ctrlPersonInfo1.Name = "ctrlPersonInfo1";
            this.ctrlPersonInfo1.Size = new System.Drawing.Size(930, 319);
            this.ctrlPersonInfo1.TabIndex = 1;
            // 
            // frmUserFullInformaion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 474);
            this.Controls.Add(this.ctrlUserInfo1);
            this.Controls.Add(this.ctrlPersonInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmUserFullInformaion";
            this.Text = "User Informaion";
            this.ResumeLayout(false);

        }

        #endregion
        private Person_Forms.ctrlPersonInfo ctrlPersonInfo1;
        private ctrlUserInfo ctrlUserInfo1;
    }
}