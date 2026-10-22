namespace Driving___Vehicle_License_Departement__DVLD_.License.International.Control
{
    partial class ctrlLicenseFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblLicenseID = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.lblLicenseID);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(899, 143);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.License_View_32;
            this.btnSearch.Location = new System.Drawing.Point(554, 50);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 50);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(254, 59);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(262, 26);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tboxSearchBy_KeyPress);
            // 
            // lblLicenseID
            // 
            this.lblLicenseID.AutoSize = true;
            this.lblLicenseID.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseID.Location = new System.Drawing.Point(87, 61);
            this.lblLicenseID.Name = "lblLicenseID";
            this.lblLicenseID.Size = new System.Drawing.Size(129, 24);
            this.lblLicenseID.TabIndex = 0;
            this.lblLicenseID.Text = "License ID :";
            // 
            // ctrlLicenseFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ctrlLicenseFilter";
            this.Size = new System.Drawing.Size(908, 150);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblLicenseID;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnSearch;
    }
}
