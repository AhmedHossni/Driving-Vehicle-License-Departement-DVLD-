namespace Driving___Vehicle_License_Departement__DVLD_.Test.Tests
{
    partial class frmTestAppointments
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
            this.ctrlLocalDrivingLicenseApplicationBasicInfo1 = new Driving___Vehicle_License_Departement__DVLD_.Local_Driving_License.Control.ctrlLocalDrivingLicenseApplicationBasicInfo();
            this.ctrlApplicationFullInfo1 = new Driving___Vehicle_License_Departement__DVLD_.Application.Control.ctrlApplicationFullInfo();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvAppointmentsList = new System.Windows.Forms.DataGridView();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddScheduleTest = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cmsAppointmentList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointmentsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.cmsAppointmentList.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlLocalDrivingLicenseApplicationBasicInfo1
            // 
            this.ctrlLocalDrivingLicenseApplicationBasicInfo1.Location = new System.Drawing.Point(3, 121);
            this.ctrlLocalDrivingLicenseApplicationBasicInfo1.Name = "ctrlLocalDrivingLicenseApplicationBasicInfo1";
            this.ctrlLocalDrivingLicenseApplicationBasicInfo1.Size = new System.Drawing.Size(905, 180);
            this.ctrlLocalDrivingLicenseApplicationBasicInfo1.TabIndex = 0;
            // 
            // ctrlApplicationFullInfo1
            // 
            this.ctrlApplicationFullInfo1.Location = new System.Drawing.Point(3, 307);
            this.ctrlApplicationFullInfo1.Name = "ctrlApplicationFullInfo1";
            this.ctrlApplicationFullInfo1.Size = new System.Drawing.Size(905, 229);
            this.ctrlApplicationFullInfo1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 551);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "Appointments:";
            // 
            // dgvAppointmentsList
            // 
            this.dgvAppointmentsList.AllowUserToAddRows = false;
            this.dgvAppointmentsList.AllowUserToDeleteRows = false;
            this.dgvAppointmentsList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAppointmentsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointmentsList.ContextMenuStrip = this.cmsAppointmentList;
            this.dgvAppointmentsList.Location = new System.Drawing.Point(3, 597);
            this.dgvAppointmentsList.Name = "dgvAppointmentsList";
            this.dgvAppointmentsList.ReadOnly = true;
            this.dgvAppointmentsList.RowHeadersWidth = 51;
            this.dgvAppointmentsList.RowTemplate.Height = 26;
            this.dgvAppointmentsList.Size = new System.Drawing.Size(905, 162);
            this.dgvAppointmentsList.TabIndex = 10;
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(202)))), ((int)(((byte)(155)))));
            this.lblRecordsCount.Location = new System.Drawing.Point(134, 778);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(22, 17);
            this.lblRecordsCount.TabIndex = 123;
            this.lblRecordsCount.Text = "??";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(202)))), ((int)(((byte)(155)))));
            this.label2.Location = new System.Drawing.Point(12, 774);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 25);
            this.label2.TabIndex = 122;
            this.label2.Text = "# Records:";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(202)))), ((int)(((byte)(155)))));
            this.lblTitle.Location = new System.Drawing.Point(261, 85);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(389, 42);
            this.lblTitle.TabIndex = 125;
            this.lblTitle.Text = "Vision Test Appointments";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.Image = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(776, 765);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(132, 43);
            this.btnClose.TabIndex = 47;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddScheduleTest
            // 
            this.btnAddScheduleTest.BackColor = System.Drawing.Color.White;
            this.btnAddScheduleTest.BackgroundImage = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.AddAppointment_32;
            this.btnAddScheduleTest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddScheduleTest.Location = new System.Drawing.Point(825, 542);
            this.btnAddScheduleTest.Name = "btnAddScheduleTest";
            this.btnAddScheduleTest.Size = new System.Drawing.Size(75, 49);
            this.btnAddScheduleTest.TabIndex = 8;
            this.btnAddScheduleTest.UseVisualStyleBackColor = false;
            this.btnAddScheduleTest.Click += new System.EventHandler(this.btnAddScheduleTest_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.Vision_512;
            this.pictureBox2.Location = new System.Drawing.Point(412, 8);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(87, 74);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 126;
            this.pictureBox2.TabStop = false;
            // 
            // cmsAppointmentList
            // 
            this.cmsAppointmentList.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.cmsAppointmentList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editTestToolStripMenuItem,
            this.takeTestToolStripMenuItem});
            this.cmsAppointmentList.Name = "cmsAppointmentList";
            this.cmsAppointmentList.Size = new System.Drawing.Size(241, 76);
            // 
            // editTestToolStripMenuItem
            // 
            this.editTestToolStripMenuItem.Image = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.edit_32;
            this.editTestToolStripMenuItem.Name = "editTestToolStripMenuItem";
            this.editTestToolStripMenuItem.Size = new System.Drawing.Size(240, 36);
            this.editTestToolStripMenuItem.Text = "Edit Test Appointment";
            // 
            // takeTestToolStripMenuItem
            // 
            this.takeTestToolStripMenuItem.Image = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.Test_32;
            this.takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            this.takeTestToolStripMenuItem.Size = new System.Drawing.Size(240, 36);
            this.takeTestToolStripMenuItem.Text = "Take Test";
            // 
            // frmTestAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 812);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvAppointmentsList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddScheduleTest);
            this.Controls.Add(this.ctrlApplicationFullInfo1);
            this.Controls.Add(this.ctrlLocalDrivingLicenseApplicationBasicInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmTestAppointments";
            this.Text = "Test Appointments";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointmentsList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.cmsAppointmentList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Local_Driving_License.Control.ctrlLocalDrivingLicenseApplicationBasicInfo ctrlLocalDrivingLicenseApplicationBasicInfo1;
        private Application.Control.ctrlApplicationFullInfo ctrlApplicationFullInfo1;
        private System.Windows.Forms.Button btnAddScheduleTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvAppointmentsList;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ContextMenuStrip cmsAppointmentList;
        private System.Windows.Forms.ToolStripMenuItem editTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem;
    }
}