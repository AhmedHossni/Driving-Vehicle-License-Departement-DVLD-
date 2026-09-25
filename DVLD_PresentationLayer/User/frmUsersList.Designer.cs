namespace Driving___Vehicle_License_Departement__DVLD_.User_Forms
{
    partial class frmUsersList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsersList));
            this.pnlFrmBtns = new System.Windows.Forms.Panel();
            this.buttonMinimize = new System.Windows.Forms.Button();
            this.btnFormClose = new System.Windows.Forms.Button();
            this.pnlFormUpper = new System.Windows.Forms.Panel();
            this.cboxIsActiveOptions = new System.Windows.Forms.ComboBox();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.tboxSearch = new System.Windows.Forms.TextBox();
            this.lblFilterBy = new System.Windows.Forms.Label();
            this.cboxSearchBy = new System.Windows.Forms.ComboBox();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.pbFormMainImage = new System.Windows.Forms.PictureBox();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.cmsOperationsOnUser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBigCloseForm = new System.Windows.Forms.Button();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.lblRecods = new System.Windows.Forms.Label();
            this.pnlFrmBtns.SuspendLayout();
            this.pnlFormUpper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFormMainImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.cmsOperationsOnUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFrmBtns
            // 
            this.pnlFrmBtns.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(16)))), ((int)(((byte)(25)))));
            this.pnlFrmBtns.Controls.Add(this.buttonMinimize);
            this.pnlFrmBtns.Controls.Add(this.btnFormClose);
            this.pnlFrmBtns.Location = new System.Drawing.Point(-7, -1);
            this.pnlFrmBtns.Name = "pnlFrmBtns";
            this.pnlFrmBtns.Size = new System.Drawing.Size(1175, 56);
            this.pnlFrmBtns.TabIndex = 2;
            // 
            // buttonMinimize
            // 
            this.buttonMinimize.BackColor = System.Drawing.Color.White;
            this.buttonMinimize.BackgroundImage = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.icons8_minimize_96;
            this.buttonMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonMinimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(24)))), ((int)(((byte)(34)))));
            this.buttonMinimize.Location = new System.Drawing.Point(1055, 12);
            this.buttonMinimize.Name = "buttonMinimize";
            this.buttonMinimize.Size = new System.Drawing.Size(37, 34);
            this.buttonMinimize.TabIndex = 5;
            this.buttonMinimize.UseVisualStyleBackColor = false;
            this.buttonMinimize.Click += new System.EventHandler(this.buttonMinimize_Click);
            // 
            // btnFormClose
            // 
            this.btnFormClose.BackColor = System.Drawing.Color.White;
            this.btnFormClose.BackgroundImage = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.close;
            this.btnFormClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFormClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(24)))), ((int)(((byte)(34)))));
            this.btnFormClose.Location = new System.Drawing.Point(1098, 12);
            this.btnFormClose.Name = "btnFormClose";
            this.btnFormClose.Size = new System.Drawing.Size(37, 34);
            this.btnFormClose.TabIndex = 6;
            this.btnFormClose.UseVisualStyleBackColor = false;
            this.btnFormClose.Click += new System.EventHandler(this.btnFormClose_Click);
            // 
            // pnlFormUpper
            // 
            this.pnlFormUpper.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlFormUpper.Controls.Add(this.cboxIsActiveOptions);
            this.pnlFormUpper.Controls.Add(this.btnAddPerson);
            this.pnlFormUpper.Controls.Add(this.tboxSearch);
            this.pnlFormUpper.Controls.Add(this.lblFilterBy);
            this.pnlFormUpper.Controls.Add(this.cboxSearchBy);
            this.pnlFormUpper.Controls.Add(this.lblFormTitle);
            this.pnlFormUpper.Controls.Add(this.pbFormMainImage);
            this.pnlFormUpper.Location = new System.Drawing.Point(-7, 51);
            this.pnlFormUpper.Name = "pnlFormUpper";
            this.pnlFormUpper.Size = new System.Drawing.Size(1175, 176);
            this.pnlFormUpper.TabIndex = 3;
            // 
            // cboxIsActiveOptions
            // 
            this.cboxIsActiveOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxIsActiveOptions.FormattingEnabled = true;
            this.cboxIsActiveOptions.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cboxIsActiveOptions.Location = new System.Drawing.Point(324, 142);
            this.cboxIsActiveOptions.Name = "cboxIsActiveOptions";
            this.cboxIsActiveOptions.Size = new System.Drawing.Size(95, 24);
            this.cboxIsActiveOptions.TabIndex = 8;
            this.cboxIsActiveOptions.SelectedIndexChanged += new System.EventHandler(this.cboxIsActiveOptions_SelectedIndexChanged);
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(202)))), ((int)(((byte)(155)))));
            this.btnAddPerson.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddPerson.BackgroundImage")));
            this.btnAddPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddPerson.Location = new System.Drawing.Point(1047, 103);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(75, 63);
            this.btnAddPerson.TabIndex = 7;
            this.btnAddPerson.UseVisualStyleBackColor = false;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // tboxSearch
            // 
            this.tboxSearch.Location = new System.Drawing.Point(324, 142);
            this.tboxSearch.Name = "tboxSearch";
            this.tboxSearch.Size = new System.Drawing.Size(181, 24);
            this.tboxSearch.TabIndex = 4;
            this.tboxSearch.TextChanged += new System.EventHandler(this.tboxSearch_TextChanged);
            this.tboxSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tboxSearchBy_KeyPress);
            // 
            // lblFilterBy
            // 
            this.lblFilterBy.AutoSize = true;
            this.lblFilterBy.Font = new System.Drawing.Font("Unispace", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblFilterBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(202)))), ((int)(((byte)(155)))));
            this.lblFilterBy.Location = new System.Drawing.Point(12, 146);
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
            "UserID",
            "UserName",
            "PersonID",
            "Full Name",
            "Is Active"});
            this.cboxSearchBy.Location = new System.Drawing.Point(137, 142);
            this.cboxSearchBy.Name = "cboxSearchBy";
            this.cboxSearchBy.Size = new System.Drawing.Size(181, 24);
            this.cboxSearchBy.TabIndex = 2;
            this.cboxSearchBy.SelectedIndexChanged += new System.EventHandler(this.cboxSearchBy_SelectedIndexChanged);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(202)))), ((int)(((byte)(155)))));
            this.lblFormTitle.Location = new System.Drawing.Point(503, 103);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(154, 24);
            this.lblFormTitle.TabIndex = 1;
            this.lblFormTitle.Text = "Manage Users";
            // 
            // pbFormMainImage
            // 
            this.pbFormMainImage.Image = ((System.Drawing.Image)(resources.GetObject("pbFormMainImage.Image")));
            this.pbFormMainImage.Location = new System.Drawing.Point(499, 12);
            this.pbFormMainImage.Name = "pbFormMainImage";
            this.pbFormMainImage.Size = new System.Drawing.Size(162, 88);
            this.pbFormMainImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFormMainImage.TabIndex = 0;
            this.pbFormMainImage.TabStop = false;
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.ContextMenuStrip = this.cmsOperationsOnUser;
            this.dgvUsers.Location = new System.Drawing.Point(1, 233);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersWidth = 51;
            this.dgvUsers.RowTemplate.Height = 26;
            this.dgvUsers.Size = new System.Drawing.Size(1160, 245);
            this.dgvUsers.TabIndex = 4;
            this.dgvUsers.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPeople_CellMouseDown);
            // 
            // cmsOperationsOnUser
            // 
            this.cmsOperationsOnUser.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsOperationsOnUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.addNewUserToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.changePasswordToolStripMenuItem});
            this.cmsOperationsOnUser.Name = "cmsOperationsOnUser";
            this.cmsOperationsOnUser.Size = new System.Drawing.Size(198, 134);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showDetailsToolStripMenuItem.Image")));
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.showDetailsToolStripMenuItem.Text = "Show Details";
            this.showDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // addNewUserToolStripMenuItem
            // 
            this.addNewUserToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addNewUserToolStripMenuItem.Image")));
            this.addNewUserToolStripMenuItem.Name = "addNewUserToolStripMenuItem";
            this.addNewUserToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.addNewUserToolStripMenuItem.Text = "Add";
            this.addNewUserToolStripMenuItem.Click += new System.EventHandler(this.CMS_Click_Add);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editToolStripMenuItem.Image")));
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.CMS_Click_Edit);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripMenuItem.Image")));
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.CMS_Click_UserInfo);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Image = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.Password_32;
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.CMS_Click_ChangePassword);
            // 
            // btnBigCloseForm
            // 
            this.btnBigCloseForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(202)))), ((int)(((byte)(155)))));
            this.btnBigCloseForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBigCloseForm.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBigCloseForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(24)))), ((int)(((byte)(34)))));
            this.btnBigCloseForm.Location = new System.Drawing.Point(1048, 484);
            this.btnBigCloseForm.Name = "btnBigCloseForm";
            this.btnBigCloseForm.Size = new System.Drawing.Size(92, 34);
            this.btnBigCloseForm.TabIndex = 10;
            this.btnBigCloseForm.Text = "Close";
            this.btnBigCloseForm.UseVisualStyleBackColor = false;
            this.btnBigCloseForm.Click += new System.EventHandler(this.btnBigCloseForm_Click);
            // 
            // lblNumberOfRecords
            // 
            this.lblNumberOfRecords.AutoSize = true;
            this.lblNumberOfRecords.Font = new System.Drawing.Font("Unispace", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblNumberOfRecords.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(202)))), ((int)(((byte)(155)))));
            this.lblNumberOfRecords.Location = new System.Drawing.Point(139, 491);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(19, 20);
            this.lblNumberOfRecords.TabIndex = 9;
            this.lblNumberOfRecords.Text = "0";
            // 
            // lblRecods
            // 
            this.lblRecods.AutoSize = true;
            this.lblRecods.Font = new System.Drawing.Font("Unispace", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblRecods.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(202)))), ((int)(((byte)(155)))));
            this.lblRecods.Location = new System.Drawing.Point(4, 491);
            this.lblRecods.Name = "lblRecods";
            this.lblRecods.Size = new System.Drawing.Size(129, 20);
            this.lblRecods.TabIndex = 8;
            this.lblRecods.Text = "# Records : ";
            // 
            // frmUsersList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 530);
            this.Controls.Add(this.btnBigCloseForm);
            this.Controls.Add(this.lblNumberOfRecords);
            this.Controls.Add(this.lblRecods);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.pnlFormUpper);
            this.Controls.Add(this.pnlFrmBtns);
            this.Name = "frmUsersList";
            this.Text = "frmUsersList";
            this.pnlFrmBtns.ResumeLayout(false);
            this.pnlFormUpper.ResumeLayout(false);
            this.pnlFormUpper.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFormMainImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.cmsOperationsOnUser.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlFrmBtns;
        private System.Windows.Forms.Button buttonMinimize;
        private System.Windows.Forms.Button btnFormClose;
        private System.Windows.Forms.Panel pnlFormUpper;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.TextBox tboxSearch;
        private System.Windows.Forms.Label lblFilterBy;
        private System.Windows.Forms.ComboBox cboxSearchBy;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.PictureBox pbFormMainImage;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Button btnBigCloseForm;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.Label lblRecods;
        private System.Windows.Forms.ContextMenuStrip cmsOperationsOnUser;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ComboBox cboxIsActiveOptions;
    }
}