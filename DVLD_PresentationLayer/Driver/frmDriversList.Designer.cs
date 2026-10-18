namespace Driving___Vehicle_License_Departement__DVLD_.Driver
{
    partial class frmDriversList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tboxSearch = new System.Windows.Forms.TextBox();
            this.lblFilterBy = new System.Windows.Forms.Label();
            this.cboxSearchBy = new System.Windows.Forms.ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvDriversData = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbMainImage = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDriversData)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMainImage)).BeginInit();
            this.SuspendLayout();
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
            "Driver ID",
            "Person ID",
            "National No.",
            "Full Name"});
            this.cboxSearchBy.Location = new System.Drawing.Point(133, 283);
            this.cboxSearchBy.Name = "cboxSearchBy";
            this.cboxSearchBy.Size = new System.Drawing.Size(181, 24);
            this.cboxSearchBy.TabIndex = 120;
            this.cboxSearchBy.SelectedIndexChanged += new System.EventHandler(this.cboxSearchBy_SelectedIndexChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(202)))), ((int)(((byte)(155)))));
            this.lblTitle.Location = new System.Drawing.Point(379, 169);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(296, 55);
            this.lblTitle.TabIndex = 118;
            this.lblTitle.Text = "Manage Drivers";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(202)))), ((int)(((byte)(155)))));
            this.lblRecordsCount.Location = new System.Drawing.Point(132, 710);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(30, 21);
            this.lblRecordsCount.TabIndex = 150;
            this.lblRecordsCount.Text = "??";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(202)))), ((int)(((byte)(155)))));
            this.label2.Location = new System.Drawing.Point(10, 707);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 25);
            this.label2.TabIndex = 149;
            this.label2.Text = "# Records:";
            // 
            // dgvDriversData
            // 
            this.dgvDriversData.AllowUserToAddRows = false;
            this.dgvDriversData.AllowUserToDeleteRows = false;
            this.dgvDriversData.AllowUserToResizeRows = false;
            this.dgvDriversData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDriversData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDriversData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvDriversData.Location = new System.Drawing.Point(11, 328);
            this.dgvDriversData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvDriversData.MultiSelect = false;
            this.dgvDriversData.Name = "dgvDriversData";
            this.dgvDriversData.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDriversData.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDriversData.RowHeadersWidth = 51;
            this.dgvDriversData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDriversData.Size = new System.Drawing.Size(1028, 354);
            this.dgvDriversData.TabIndex = 148;
            this.dgvDriversData.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tboxSearch);
            this.panel1.Controls.Add(this.lblFilterBy);
            this.panel1.Controls.Add(this.cboxSearchBy);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.pbMainImage);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1046, 318);
            this.panel1.TabIndex = 147;
            // 
            // pbMainImage
            // 
            this.pbMainImage.Image = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.Driver_Main;
            this.pbMainImage.Location = new System.Drawing.Point(359, 0);
            this.pbMainImage.Name = "pbMainImage";
            this.pbMainImage.Size = new System.Drawing.Size(333, 166);
            this.pbMainImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMainImage.TabIndex = 117;
            this.pbMainImage.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(202)))), ((int)(((byte)(155)))));
            this.btnClose.Image = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(907, 701);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(132, 43);
            this.btnClose.TabIndex = 151;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmDriversList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 751);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvDriversData);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDriversList";
            this.Text = "Drivers List";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDriversData)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMainImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tboxSearch;
        private System.Windows.Forms.Label lblFilterBy;
        private System.Windows.Forms.ComboBox cboxSearchBy;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pbMainImage;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvDriversData;
        private System.Windows.Forms.Panel panel1;
    }
}