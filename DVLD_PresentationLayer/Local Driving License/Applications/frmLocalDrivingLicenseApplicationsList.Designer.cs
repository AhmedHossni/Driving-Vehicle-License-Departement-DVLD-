namespace Driving___Vehicle_License_Departement__DVLD_.Local_Driving_License.Applications
{
    partial class frmLocalDrivingLicenseApplicationsList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.cboxApplicationStatus = new System.Windows.Forms.ComboBox();
            this.tboxSearch = new System.Windows.Forms.TextBox();
            this.lblFilterBy = new System.Windows.Forms.Label();
            this.cboxSearchBy = new System.Windows.Forms.ComboBox();
            this.pbSubImage = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pbMainImage = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvLocalDrivingLicenseApplicationsData = new System.Windows.Forms.DataGridView();
            this.cmsLDLApplication = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showApplicationDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleVisionTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleWrittenTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleStreetTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issueDrivingLicenseFirstTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSubImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMainImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicenseApplicationsData)).BeginInit();
            this.cmsLDLApplication.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAddPerson);
            this.panel1.Controls.Add(this.cboxApplicationStatus);
            this.panel1.Controls.Add(this.tboxSearch);
            this.panel1.Controls.Add(this.lblFilterBy);
            this.panel1.Controls.Add(this.cboxSearchBy);
            this.panel1.Controls.Add(this.pbSubImage);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.pbMainImage);
            this.panel1.Location = new System.Drawing.Point(4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1046, 318);
            this.panel1.TabIndex = 0;
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.BackColor = System.Drawing.Color.White;
            this.btnAddPerson.BackgroundImage = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.add_document;
            this.btnAddPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddPerson.Location = new System.Drawing.Point(948, 236);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(75, 71);
            this.btnAddPerson.TabIndex = 124;
            this.btnAddPerson.UseVisualStyleBackColor = false;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // cboxApplicationStatus
            // 
            this.cboxApplicationStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxApplicationStatus.FormattingEnabled = true;
            this.cboxApplicationStatus.Items.AddRange(new object[] {
            "All",
            "New",
            "Cancel",
            "Complete"});
            this.cboxApplicationStatus.Location = new System.Drawing.Point(320, 283);
            this.cboxApplicationStatus.Name = "cboxApplicationStatus";
            this.cboxApplicationStatus.Size = new System.Drawing.Size(95, 24);
            this.cboxApplicationStatus.TabIndex = 123;
            this.cboxApplicationStatus.SelectedIndexChanged += new System.EventHandler(this.cboxApplicationStatus_SelectedIndexChanged);
            // 
            // tboxSearch
            // 
            this.tboxSearch.Location = new System.Drawing.Point(320, 283);
            this.tboxSearch.Name = "tboxSearch";
            this.tboxSearch.Size = new System.Drawing.Size(181, 24);
            this.tboxSearch.TabIndex = 122;
            this.tboxSearch.TextChanged += new System.EventHandler(this.tboxSearch_TextChanged);
            // 
            // lblFilterBy
            // 
            this.lblFilterBy.AutoSize = true;
            this.lblFilterBy.Font = new System.Drawing.Font("Unispace", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblFilterBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(202)))), ((int)(((byte)(155)))));
            this.lblFilterBy.Location = new System.Drawing.Point(8, 287);
            this.lblFilterBy.Name = "lblFilterBy";
            this.lblFilterBy.Size = new System.Drawing.Size(119, 20);
            this.lblFilterBy.TabIndex = 121;
            this.lblFilterBy.Text = "Filter By :";
            // 
            // cboxSearchBy
            // 
            this.cboxSearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSearchBy.FormattingEnabled = true;
            this.cboxSearchBy.Items.AddRange(new object[] {
            "None",
            "L.D.L.AppID",
            "National No.",
            "Full Name",
            "Status"});
            this.cboxSearchBy.Location = new System.Drawing.Point(133, 283);
            this.cboxSearchBy.Name = "cboxSearchBy";
            this.cboxSearchBy.Size = new System.Drawing.Size(181, 24);
            this.cboxSearchBy.TabIndex = 120;
            this.cboxSearchBy.SelectedIndexChanged += new System.EventHandler(this.cboxSearchBy_SelectedIndexChanged);
            // 
            // pbSubImage
            // 
            this.pbSubImage.Image = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.Local_321;
            this.pbSubImage.Location = new System.Drawing.Point(436, 20);
            this.pbSubImage.Name = "pbSubImage";
            this.pbSubImage.Size = new System.Drawing.Size(42, 40);
            this.pbSubImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSubImage.TabIndex = 119;
            this.pbSubImage.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(202)))), ((int)(((byte)(155)))));
            this.lblTitle.Location = new System.Drawing.Point(221, 169);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(613, 55);
            this.lblTitle.TabIndex = 118;
            this.lblTitle.Text = "Local Driving License Applications";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbMainImage
            // 
            this.pbMainImage.Image = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.file_4722107;
            this.pbMainImage.Location = new System.Drawing.Point(436, 20);
            this.pbMainImage.Name = "pbMainImage";
            this.pbMainImage.Size = new System.Drawing.Size(182, 146);
            this.pbMainImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMainImage.TabIndex = 117;
            this.pbMainImage.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.AutoEllipsis = true;
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(202)))), ((int)(((byte)(155)))));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(906, 699);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(135, 36);
            this.btnClose.TabIndex = 116;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(202)))), ((int)(((byte)(155)))));
            this.lblRecordsCount.Location = new System.Drawing.Point(134, 717);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(22, 17);
            this.lblRecordsCount.TabIndex = 119;
            this.lblRecordsCount.Text = "??";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(202)))), ((int)(((byte)(155)))));
            this.label2.Location = new System.Drawing.Point(12, 710);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 25);
            this.label2.TabIndex = 118;
            this.label2.Text = "# Records:";
            // 
            // dgvLocalDrivingLicenseApplicationsData
            // 
            this.dgvLocalDrivingLicenseApplicationsData.AllowUserToAddRows = false;
            this.dgvLocalDrivingLicenseApplicationsData.AllowUserToDeleteRows = false;
            this.dgvLocalDrivingLicenseApplicationsData.AllowUserToResizeRows = false;
            this.dgvLocalDrivingLicenseApplicationsData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLocalDrivingLicenseApplicationsData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalDrivingLicenseApplicationsData.ContextMenuStrip = this.cmsLDLApplication;
            this.dgvLocalDrivingLicenseApplicationsData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvLocalDrivingLicenseApplicationsData.Location = new System.Drawing.Point(13, 331);
            this.dgvLocalDrivingLicenseApplicationsData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvLocalDrivingLicenseApplicationsData.MultiSelect = false;
            this.dgvLocalDrivingLicenseApplicationsData.Name = "dgvLocalDrivingLicenseApplicationsData";
            this.dgvLocalDrivingLicenseApplicationsData.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLocalDrivingLicenseApplicationsData.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLocalDrivingLicenseApplicationsData.RowHeadersWidth = 51;
            this.dgvLocalDrivingLicenseApplicationsData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLocalDrivingLicenseApplicationsData.Size = new System.Drawing.Size(1028, 354);
            this.dgvLocalDrivingLicenseApplicationsData.TabIndex = 117;
            this.dgvLocalDrivingLicenseApplicationsData.TabStop = false;
            this.dgvLocalDrivingLicenseApplicationsData.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_CellMouseDown);
            // 
            // cmsLDLApplication
            // 
            this.cmsLDLApplication.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.cmsLDLApplication.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApplicationDetailsToolStripMenuItem,
            this.editApplicationToolStripMenuItem,
            this.deleteApplicationToolStripMenuItem,
            this.cancelApplicationToolStripMenuItem,
            this.secduleToolStripMenuItem,
            this.issueDrivingLicenseFirstTimeToolStripMenuItem,
            this.showLicenseToolStripMenuItem,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.cmsLDLApplication.Name = "cmsLDLApplication";
            this.cmsLDLApplication.Size = new System.Drawing.Size(309, 308);
            this.cmsLDLApplication.Opening += new System.ComponentModel.CancelEventHandler(this.cmsLDLApplication_Opening);
            // 
            // showApplicationDetailsToolStripMenuItem
            // 
            this.showApplicationDetailsToolStripMenuItem.Image = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.Applications;
            this.showApplicationDetailsToolStripMenuItem.Name = "showApplicationDetailsToolStripMenuItem";
            this.showApplicationDetailsToolStripMenuItem.Size = new System.Drawing.Size(308, 38);
            this.showApplicationDetailsToolStripMenuItem.Text = "Show Application Details";
            this.showApplicationDetailsToolStripMenuItem.Click += new System.EventHandler(this.CMS_Click_ShowLDLApplicationDetails);
            // 
            // editApplicationToolStripMenuItem
            // 
            this.editApplicationToolStripMenuItem.Image = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.edit_32;
            this.editApplicationToolStripMenuItem.Name = "editApplicationToolStripMenuItem";
            this.editApplicationToolStripMenuItem.Size = new System.Drawing.Size(308, 38);
            this.editApplicationToolStripMenuItem.Text = "Edit Application";
            this.editApplicationToolStripMenuItem.Click += new System.EventHandler(this.CMS_Click_EditLDLApplication);
            // 
            // deleteApplicationToolStripMenuItem
            // 
            this.deleteApplicationToolStripMenuItem.Image = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.Delete_32_2;
            this.deleteApplicationToolStripMenuItem.Name = "deleteApplicationToolStripMenuItem";
            this.deleteApplicationToolStripMenuItem.Size = new System.Drawing.Size(308, 38);
            this.deleteApplicationToolStripMenuItem.Text = "Delete Application";
            this.deleteApplicationToolStripMenuItem.Click += new System.EventHandler(this.CMS_Click_DeleteLDLApplication);
            // 
            // cancelApplicationToolStripMenuItem
            // 
            this.cancelApplicationToolStripMenuItem.Image = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.Delete_32;
            this.cancelApplicationToolStripMenuItem.Name = "cancelApplicationToolStripMenuItem";
            this.cancelApplicationToolStripMenuItem.Size = new System.Drawing.Size(308, 38);
            this.cancelApplicationToolStripMenuItem.Text = "Cancel Application";
            this.cancelApplicationToolStripMenuItem.Click += new System.EventHandler(this.CMS_Click_CancelLDLApplication);
            // 
            // secduleToolStripMenuItem
            // 
            this.secduleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scheduleVisionTestToolStripMenuItem,
            this.scheduleWrittenTestToolStripMenuItem,
            this.scheduleStreetTestToolStripMenuItem});
            this.secduleToolStripMenuItem.Image = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.Schedule_Test_32;
            this.secduleToolStripMenuItem.Name = "secduleToolStripMenuItem";
            this.secduleToolStripMenuItem.Size = new System.Drawing.Size(308, 38);
            this.secduleToolStripMenuItem.Text = "Schedule Tests";
            // 
            // scheduleVisionTestToolStripMenuItem
            // 
            this.scheduleVisionTestToolStripMenuItem.Image = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.Vision_Test_Schdule;
            this.scheduleVisionTestToolStripMenuItem.Name = "scheduleVisionTestToolStripMenuItem";
            this.scheduleVisionTestToolStripMenuItem.Size = new System.Drawing.Size(235, 26);
            this.scheduleVisionTestToolStripMenuItem.Text = "Schedule Vision Test";
            // 
            // scheduleWrittenTestToolStripMenuItem
            // 
            this.scheduleWrittenTestToolStripMenuItem.Enabled = false;
            this.scheduleWrittenTestToolStripMenuItem.Image = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.Written_Test_32_Sechdule;
            this.scheduleWrittenTestToolStripMenuItem.Name = "scheduleWrittenTestToolStripMenuItem";
            this.scheduleWrittenTestToolStripMenuItem.Size = new System.Drawing.Size(235, 26);
            this.scheduleWrittenTestToolStripMenuItem.Text = "Schedule Written Test";
            // 
            // scheduleStreetTestToolStripMenuItem
            // 
            this.scheduleStreetTestToolStripMenuItem.Enabled = false;
            this.scheduleStreetTestToolStripMenuItem.Image = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.Street_Test_32;
            this.scheduleStreetTestToolStripMenuItem.Name = "scheduleStreetTestToolStripMenuItem";
            this.scheduleStreetTestToolStripMenuItem.Size = new System.Drawing.Size(235, 26);
            this.scheduleStreetTestToolStripMenuItem.Text = "Schedule Street Test";
            // 
            // issueDrivingLicenseFirstTimeToolStripMenuItem
            // 
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Image = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.IssueDrivingLicense_32;
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Name = "issueDrivingLicenseFirstTimeToolStripMenuItem";
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Size = new System.Drawing.Size(308, 38);
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Text = "Issue Driving License (First Time)";
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Enabled = false;
            this.showLicenseToolStripMenuItem.Image = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.License_View_32;
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(308, 38);
            this.showLicenseToolStripMenuItem.Text = "Show License";
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Image = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.PersonLicenseHistory_32;
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(308, 38);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            // 
            // frmLocalDrivingLicenseApplicationsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 753);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvLocalDrivingLicenseApplicationsData);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmLocalDrivingLicenseApplicationsList";
            this.Text = "Local Driving License Applications List";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSubImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMainImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicenseApplicationsData)).EndInit();
            this.cmsLDLApplication.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbSubImage;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pbMainImage;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvLocalDrivingLicenseApplicationsData;
        private System.Windows.Forms.ComboBox cboxApplicationStatus;
        private System.Windows.Forms.TextBox tboxSearch;
        private System.Windows.Forms.Label lblFilterBy;
        private System.Windows.Forms.ComboBox cboxSearchBy;
        private System.Windows.Forms.ContextMenuStrip cmsLDLApplication;
        private System.Windows.Forms.ToolStripMenuItem showApplicationDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem secduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issueDrivingLicenseFirstTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.ToolStripMenuItem scheduleVisionTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleWrittenTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleStreetTestToolStripMenuItem;
    }
}