namespace Driving___Vehicle_License_Departement__DVLD_.People_Forms
{
    partial class frmPeopleList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPeopleList));
            this.pnlFormUpper = new System.Windows.Forms.Panel();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.rbtnFemale = new System.Windows.Forms.RadioButton();
            this.rbtnMale = new System.Windows.Forms.RadioButton();
            this.tboxSearch = new System.Windows.Forms.TextBox();
            this.lblFilterBy = new System.Windows.Forms.Label();
            this.cboxSearchBy = new System.Windows.Forms.ComboBox();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlFrmBtns = new System.Windows.Forms.Panel();
            this.buttonMinimize = new System.Windows.Forms.Button();
            this.btnFormClose = new System.Windows.Forms.Button();
            this.dgvPeople = new System.Windows.Forms.DataGridView();
            this.cmsListFunc = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRecods = new System.Windows.Forms.Label();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.btnBigCloseForm = new System.Windows.Forms.Button();
            this.pnlFormUpper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlFrmBtns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).BeginInit();
            this.cmsListFunc.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFormUpper
            // 
            this.pnlFormUpper.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlFormUpper.Controls.Add(this.btnAddPerson);
            this.pnlFormUpper.Controls.Add(this.rbtnFemale);
            this.pnlFormUpper.Controls.Add(this.rbtnMale);
            this.pnlFormUpper.Controls.Add(this.tboxSearch);
            this.pnlFormUpper.Controls.Add(this.lblFilterBy);
            this.pnlFormUpper.Controls.Add(this.cboxSearchBy);
            this.pnlFormUpper.Controls.Add(this.lblFormTitle);
            this.pnlFormUpper.Controls.Add(this.pictureBox1);
            this.pnlFormUpper.Location = new System.Drawing.Point(2, 60);
            this.pnlFormUpper.Name = "pnlFormUpper";
            this.pnlFormUpper.Size = new System.Drawing.Size(1146, 176);
            this.pnlFormUpper.TabIndex = 0;
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(202)))), ((int)(((byte)(155)))));
            this.btnAddPerson.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddPerson.BackgroundImage")));
            this.btnAddPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddPerson.Location = new System.Drawing.Point(1030, 103);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(75, 63);
            this.btnAddPerson.TabIndex = 7;
            this.btnAddPerson.UseVisualStyleBackColor = false;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // rbtnFemale
            // 
            this.rbtnFemale.AutoSize = true;
            this.rbtnFemale.Location = new System.Drawing.Point(404, 143);
            this.rbtnFemale.Name = "rbtnFemale";
            this.rbtnFemale.Size = new System.Drawing.Size(71, 21);
            this.rbtnFemale.TabIndex = 6;
            this.rbtnFemale.TabStop = true;
            this.rbtnFemale.Text = "Female";
            this.rbtnFemale.UseVisualStyleBackColor = true;
            this.rbtnFemale.CheckedChanged += new System.EventHandler(this.rbtnFemale_CheckedChanged);
            // 
            // rbtnMale
            // 
            this.rbtnMale.AutoSize = true;
            this.rbtnMale.Location = new System.Drawing.Point(343, 143);
            this.rbtnMale.Name = "rbtnMale";
            this.rbtnMale.Size = new System.Drawing.Size(55, 21);
            this.rbtnMale.TabIndex = 5;
            this.rbtnMale.TabStop = true;
            this.rbtnMale.Text = "Male";
            this.rbtnMale.UseVisualStyleBackColor = true;
            this.rbtnMale.CheckedChanged += new System.EventHandler(this.rbtnMale_CheckedChanged);
            // 
            // tboxSearch
            // 
            this.tboxSearch.Location = new System.Drawing.Point(324, 142);
            this.tboxSearch.Name = "tboxSearch";
            this.tboxSearch.Size = new System.Drawing.Size(181, 24);
            this.tboxSearch.TabIndex = 4;
            this.tboxSearch.TextChanged += new System.EventHandler(this.tboxSearch_TextChanged);
            this.tboxSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tboxSearchById_KeyPress);
            // 
            // lblFilterBy
            // 
            this.lblFilterBy.AutoSize = true;
            this.lblFilterBy.Font = new System.Drawing.Font("Unispace", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblFilterBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(202)))), ((int)(((byte)(155)))));
            this.lblFilterBy.Location = new System.Drawing.Point(3, 146);
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
            "PersonID",
            "National No.",
            "First Name",
            "Second Name",
            "Third Name",
            "Last Name",
            "Nationality",
            "Gender",
            "Phone",
            "Email"});
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
            this.lblFormTitle.Location = new System.Drawing.Point(492, 103);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(166, 24);
            this.lblFormTitle.TabIndex = 1;
            this.lblFormTitle.Text = "Manage People";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(494, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(162, 88);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pnlFrmBtns
            // 
            this.pnlFrmBtns.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(16)))), ((int)(((byte)(25)))));
            this.pnlFrmBtns.Controls.Add(this.buttonMinimize);
            this.pnlFrmBtns.Controls.Add(this.btnFormClose);
            this.pnlFrmBtns.Location = new System.Drawing.Point(-11, 0);
            this.pnlFrmBtns.Name = "pnlFrmBtns";
            this.pnlFrmBtns.Size = new System.Drawing.Size(1164, 54);
            this.pnlFrmBtns.TabIndex = 1;
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
            // dgvPeople
            // 
            this.dgvPeople.AllowUserToAddRows = false;
            this.dgvPeople.AllowUserToDeleteRows = false;
            this.dgvPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeople.ContextMenuStrip = this.cmsListFunc;
            this.dgvPeople.Location = new System.Drawing.Point(2, 242);
            this.dgvPeople.Name = "dgvPeople";
            this.dgvPeople.ReadOnly = true;
            this.dgvPeople.RowHeadersWidth = 51;
            this.dgvPeople.RowTemplate.Height = 26;
            this.dgvPeople.Size = new System.Drawing.Size(1146, 245);
            this.dgvPeople.TabIndex = 1;
            this.dgvPeople.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPeople_CellMouseDown);
            // 
            // cmsListFunc
            // 
            this.cmsListFunc.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsListFunc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.deleteToolStripMenuItem1});
            this.cmsListFunc.Name = "cmsListFunc";
            this.cmsListFunc.Size = new System.Drawing.Size(127, 82);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editToolStripMenuItem.Image")));
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(126, 26);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click_EditPersonDetails);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripMenuItem.Image")));
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(126, 26);
            this.deleteToolStripMenuItem.Text = "Show";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click_ShowPersonDetails);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripMenuItem1.Image")));
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(126, 26);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // lblRecods
            // 
            this.lblRecods.AutoSize = true;
            this.lblRecods.Font = new System.Drawing.Font("Unispace", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblRecods.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(202)))), ((int)(((byte)(155)))));
            this.lblRecods.Location = new System.Drawing.Point(5, 513);
            this.lblRecods.Name = "lblRecods";
            this.lblRecods.Size = new System.Drawing.Size(129, 20);
            this.lblRecods.TabIndex = 4;
            this.lblRecods.Text = "# Records : ";
            // 
            // lblNumberOfRecords
            // 
            this.lblNumberOfRecords.AutoSize = true;
            this.lblNumberOfRecords.Font = new System.Drawing.Font("Unispace", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblNumberOfRecords.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(202)))), ((int)(((byte)(155)))));
            this.lblNumberOfRecords.Location = new System.Drawing.Point(140, 513);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(19, 20);
            this.lblNumberOfRecords.TabIndex = 5;
            this.lblNumberOfRecords.Text = "0";
            // 
            // btnBigCloseForm
            // 
            this.btnBigCloseForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(202)))), ((int)(((byte)(155)))));
            this.btnBigCloseForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBigCloseForm.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBigCloseForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(24)))), ((int)(((byte)(34)))));
            this.btnBigCloseForm.Location = new System.Drawing.Point(1032, 507);
            this.btnBigCloseForm.Name = "btnBigCloseForm";
            this.btnBigCloseForm.Size = new System.Drawing.Size(92, 34);
            this.btnBigCloseForm.TabIndex = 7;
            this.btnBigCloseForm.Text = "Close";
            this.btnBigCloseForm.UseVisualStyleBackColor = false;
            this.btnBigCloseForm.Click += new System.EventHandler(this.btnBigCloseForm_Click);
            // 
            // frmPeopleList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 555);
            this.Controls.Add(this.btnBigCloseForm);
            this.Controls.Add(this.lblNumberOfRecords);
            this.Controls.Add(this.lblRecods);
            this.Controls.Add(this.pnlFrmBtns);
            this.Controls.Add(this.dgvPeople);
            this.Controls.Add(this.pnlFormUpper);
            this.Name = "frmPeopleList";
            this.Text = "frmPeopleList";
            this.pnlFormUpper.ResumeLayout(false);
            this.pnlFormUpper.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlFrmBtns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).EndInit();
            this.cmsListFunc.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlFormUpper;
        private System.Windows.Forms.DataGridView dgvPeople;
        private System.Windows.Forms.ContextMenuStrip cmsListFunc;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.Panel pnlFrmBtns;
        private System.Windows.Forms.Button buttonMinimize;
        private System.Windows.Forms.Button btnFormClose;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblFilterBy;
        private System.Windows.Forms.ComboBox cboxSearchBy;
        private System.Windows.Forms.TextBox tboxSearch;
        private System.Windows.Forms.RadioButton rbtnMale;
        private System.Windows.Forms.RadioButton rbtnFemale;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.Label lblRecods;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.Button btnBigCloseForm;
    }
}