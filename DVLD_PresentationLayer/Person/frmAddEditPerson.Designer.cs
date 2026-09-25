namespace Driving___Vehicle_License_Departement__DVLD_.Person_Forms
{
    partial class frmAddEditPerson
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
            this.lblFormLabel = new System.Windows.Forms.Label();
            this.ctrlAddEdit_person1 = new Driving___Vehicle_License_Departement__DVLD_._person_Forms.ctrlAddEdit_person();
            this.SuspendLayout();
            // 
            // lblFormLabel
            // 
            this.lblFormLabel.AutoSize = true;
            this.lblFormLabel.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormLabel.ForeColor = System.Drawing.Color.Red;
            this.lblFormLabel.Location = new System.Drawing.Point(458, 9);
            this.lblFormLabel.Name = "lblFormLabel";
            this.lblFormLabel.Size = new System.Drawing.Size(195, 28);
            this.lblFormLabel.TabIndex = 0;
            this.lblFormLabel.Text = "Add Edit Person";
            // 
            // ctrlAddEdit_person1
            // 
            this.ctrlAddEdit_person1.Location = new System.Drawing.Point(2, 40);
            this.ctrlAddEdit_person1.Name = "ctrlAddEdit_person1";
            this.ctrlAddEdit_person1.Size = new System.Drawing.Size(1079, 611);
            this.ctrlAddEdit_person1.TabIndex = 1;
            // 
            // frmAddEditPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 654);
            this.Controls.Add(this.ctrlAddEdit_person1);
            this.Controls.Add(this.lblFormLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddEditPerson";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFormLabel;
        private _person_Forms.ctrlAddEdit_person ctrlAddEdit_person1;
    }
}