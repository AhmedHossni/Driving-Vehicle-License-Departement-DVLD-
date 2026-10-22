namespace Driving___Vehicle_License_Departement__DVLD_.License.International
{
    partial class frmInternationalLicensesList
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
            this.dgvInternationalLicenses = new System.Windows.Forms.DataGridView();
            this.cmsInternationalLicensesList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPersonDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlFormUpper = new System.Windows.Forms.Panel();
            this.cboxIsActiveOptions = new System.Windows.Forms.ComboBox();
            this.tboxSearch = new System.Windows.Forms.TextBox();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.pbSubImage = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pbMainImage = new System.Windows.Forms.PictureBox();
            this.lblFilterBy = new System.Windows.Forms.Label();
            this.cboxSearchBy = new System.Windows.Forms.ComboBox();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.lblRecods = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenses)).BeginInit();
            this.cmsInternationalLicensesList.SuspendLayout();
            this.pnlFormUpper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSubImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMainImage)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvInternationalLicenses
            // 
            this.dgvInternationalLicenses.AllowUserToAddRows = false;
            this.dgvInternationalLicenses.AllowUserToDeleteRows = false;
            this.dgvInternationalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalLicenses.ContextMenuStrip = this.cmsInternationalLicensesList;
            this.dgvInternationalLicenses.Location = new System.Drawing.Point(22, 330);
            this.dgvInternationalLicenses.Name = "dgvInternationalLicenses";
            this.dgvInternationalLicenses.ReadOnly = true;
            this.dgvInternationalLicenses.RowHeadersWidth = 51;
            this.dgvInternationalLicenses.RowTemplate.Height = 26;
            this.dgvInternationalLicenses.Size = new System.Drawing.Size(1139, 291);
            this.dgvInternationalLicenses.TabIndex = 161;
            this.dgvInternationalLicenses.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPeople_CellMouseDown);
            // 
            // cmsInternationalLicensesList
            // 
            this.cmsInternationalLicensesList.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.cmsInternationalLicensesList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPersonDetailsToolStripMenuItem,
            this.showLicenseDetailsToolStripMenuItem,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.cmsInternationalLicensesList.Name = "cmsInternationalLicensesList";
            this.cmsInternationalLicensesList.Size = new System.Drawing.Size(274, 100);
            this.cmsInternationalLicensesList.Opening += new System.ComponentModel.CancelEventHandler(this.cmsInternationalLicensesList_Opening);
            // 
            // showPersonDetailsToolStripMenuItem
            // 
            this.showPersonDetailsToolStripMenuItem.Image = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.PersonDetails_32;
            this.showPersonDetailsToolStripMenuItem.Name = "showPersonDetailsToolStripMenuItem";
            this.showPersonDetailsToolStripMenuItem.Size = new System.Drawing.Size(273, 32);
            this.showPersonDetailsToolStripMenuItem.Text = "Show Person Details";
            this.showPersonDetailsToolStripMenuItem.Click += new System.EventHandler(this.showPersonDetailsToolStripMenuItem_Click);
            // 
            // showLicenseDetailsToolStripMenuItem
            // 
            this.showLicenseDetailsToolStripMenuItem.Image = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.License_View_32;
            this.showLicenseDetailsToolStripMenuItem.Name = "showLicenseDetailsToolStripMenuItem";
            this.showLicenseDetailsToolStripMenuItem.Size = new System.Drawing.Size(273, 32);
            this.showLicenseDetailsToolStripMenuItem.Text = "Show License Details";
            this.showLicenseDetailsToolStripMenuItem.Click += new System.EventHandler(this.showLicenseDetailsToolStripMenuItem_Click);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Image = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.PersonLicenseHistory_32;
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(273, 32);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            this.showPersonLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicenseHistoryToolStripMenuItem_Click);
            // 
            // pnlFormUpper
            // 
            this.pnlFormUpper.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlFormUpper.Controls.Add(this.cboxIsActiveOptions);
            this.pnlFormUpper.Controls.Add(this.tboxSearch);
            this.pnlFormUpper.Controls.Add(this.btnAddPerson);
            this.pnlFormUpper.Controls.Add(this.pbSubImage);
            this.pnlFormUpper.Controls.Add(this.lblTitle);
            this.pnlFormUpper.Controls.Add(this.pbMainImage);
            this.pnlFormUpper.Controls.Add(this.lblFilterBy);
            this.pnlFormUpper.Controls.Add(this.cboxSearchBy);
            this.pnlFormUpper.Location = new System.Drawing.Point(3, 3);
            this.pnlFormUpper.Name = "pnlFormUpper";
            this.pnlFormUpper.Size = new System.Drawing.Size(1175, 321);
            this.pnlFormUpper.TabIndex = 160;
            // 
            // cboxIsActiveOptions
            // 
            this.cboxIsActiveOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxIsActiveOptions.FormattingEnabled = true;
            this.cboxIsActiveOptions.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cboxIsActiveOptions.Location = new System.Drawing.Point(376, 277);
            this.cboxIsActiveOptions.Name = "cboxIsActiveOptions";
            this.cboxIsActiveOptions.Size = new System.Drawing.Size(95, 24);
            this.cboxIsActiveOptions.TabIndex = 128;
            this.cboxIsActiveOptions.SelectedIndexChanged += new System.EventHandler(this.cboxIsActiveOptions_SelectedIndexChanged);
            // 
            // tboxSearch
            // 
            this.tboxSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tboxSearch.Location = new System.Drawing.Point(376, 277);
            this.tboxSearch.Name = "tboxSearch";
            this.tboxSearch.Size = new System.Drawing.Size(181, 24);
            this.tboxSearch.TabIndex = 127;
            this.tboxSearch.TextChanged += new System.EventHandler(this.tboxSearch_TextChanged);
            this.tboxSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tboxSearchBy_KeyPress);
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.BackColor = System.Drawing.Color.White;
            this.btnAddPerson.BackgroundImage = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.add_document;
            this.btnAddPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddPerson.Location = new System.Drawing.Point(1083, 230);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(75, 71);
            this.btnAddPerson.TabIndex = 125;
            this.btnAddPerson.UseVisualStyleBackColor = false;
            // 
            // pbSubImage
            // 
            this.pbSubImage.Image = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.International_32;
            this.pbSubImage.Location = new System.Drawing.Point(499, 9);
            this.pbSubImage.Name = "pbSubImage";
            this.pbSubImage.Size = new System.Drawing.Size(42, 40);
            this.pbSubImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSubImage.TabIndex = 122;
            this.pbSubImage.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(202)))), ((int)(((byte)(155)))));
            this.lblTitle.Location = new System.Drawing.Point(237, 158);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(705, 55);
            this.lblTitle.TabIndex = 121;
            this.lblTitle.Text = "International Driving License Applications";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbMainImage
            // 
            this.pbMainImage.Image = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.file_4722107;
            this.pbMainImage.Location = new System.Drawing.Point(499, 9);
            this.pbMainImage.Name = "pbMainImage";
            this.pbMainImage.Size = new System.Drawing.Size(182, 146);
            this.pbMainImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMainImage.TabIndex = 120;
            this.pbMainImage.TabStop = false;
            // 
            // lblFilterBy
            // 
            this.lblFilterBy.AutoSize = true;
            this.lblFilterBy.Font = new System.Drawing.Font("Unispace", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblFilterBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(202)))), ((int)(((byte)(155)))));
            this.lblFilterBy.Location = new System.Drawing.Point(19, 281);
            this.lblFilterBy.Name = "lblFilterBy";
            this.lblFilterBy.Size = new System.Drawing.Size(119, 20);
            this.lblFilterBy.TabIndex = 3;
            this.lblFilterBy.Text = "Filter By :";
            // 
            // cboxSearchBy
            // 
            this.cboxSearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSearchBy.FormattingEnabled = true;
            this.cboxSearchBy.Items.AddRange(new object[] {
            "None",
            "International License ID",
            "Application ID",
            "Driver ID",
            "Issued Using Local License ID",
            "Is Active"});
            this.cboxSearchBy.Location = new System.Drawing.Point(144, 277);
            this.cboxSearchBy.Name = "cboxSearchBy";
            this.cboxSearchBy.Size = new System.Drawing.Size(226, 24);
            this.cboxSearchBy.TabIndex = 2;
            this.cboxSearchBy.SelectedIndexChanged += new System.EventHandler(this.cboxSearchBy_SelectedIndexChanged);
            // 
            // lblNumberOfRecords
            // 
            this.lblNumberOfRecords.AutoSize = true;
            this.lblNumberOfRecords.Font = new System.Drawing.Font("Unispace", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblNumberOfRecords.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(202)))), ((int)(((byte)(155)))));
            this.lblNumberOfRecords.Location = new System.Drawing.Point(147, 650);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(19, 20);
            this.lblNumberOfRecords.TabIndex = 163;
            this.lblNumberOfRecords.Text = "0";
            // 
            // lblRecods
            // 
            this.lblRecods.AutoSize = true;
            this.lblRecods.Font = new System.Drawing.Font("Unispace", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblRecods.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(202)))), ((int)(((byte)(155)))));
            this.lblRecods.Location = new System.Drawing.Point(12, 650);
            this.lblRecods.Name = "lblRecods";
            this.lblRecods.Size = new System.Drawing.Size(129, 20);
            this.lblRecods.TabIndex = 162;
            this.lblRecods.Text = "# Records : ";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(202)))), ((int)(((byte)(155)))));
            this.btnClose.Image = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1029, 627);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(132, 43);
            this.btnClose.TabIndex = 164;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmInternationalLicensesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 682);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvInternationalLicenses);
            this.Controls.Add(this.pnlFormUpper);
            this.Controls.Add(this.lblNumberOfRecords);
            this.Controls.Add(this.lblRecods);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmInternationalLicensesList";
            this.Text = "International Licenses List";
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenses)).EndInit();
            this.cmsInternationalLicensesList.ResumeLayout(false);
            this.pnlFormUpper.ResumeLayout(false);
            this.pnlFormUpper.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSubImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMainImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvInternationalLicenses;
        private System.Windows.Forms.Panel pnlFormUpper;
        private System.Windows.Forms.Label lblFilterBy;
        private System.Windows.Forms.ComboBox cboxSearchBy;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.Label lblRecods;
        private System.Windows.Forms.PictureBox pbSubImage;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pbMainImage;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.ComboBox cboxIsActiveOptions;
        private System.Windows.Forms.TextBox tboxSearch;
        private System.Windows.Forms.ContextMenuStrip cmsInternationalLicensesList;
        private System.Windows.Forms.ToolStripMenuItem showPersonDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
    }
}