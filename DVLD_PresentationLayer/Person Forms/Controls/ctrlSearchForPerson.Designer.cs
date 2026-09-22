namespace Driving___Vehicle_License_Departement__DVLD_.Person_Forms
{
    partial class ctrlSearchForPerson
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
            this.gboxSearchForPerson = new System.Windows.Forms.GroupBox();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.btnSearchForPerson = new System.Windows.Forms.Button();
            this.tboxSearch = new System.Windows.Forms.TextBox();
            this.cboxSearchBy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlPersonInfo1 = new Driving___Vehicle_License_Departement__DVLD_.Person_Forms.ctrlPersonInfo();
            this.gboxSearchForPerson.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboxSearchForPerson
            // 
            this.gboxSearchForPerson.Controls.Add(this.btnAddNewPerson);
            this.gboxSearchForPerson.Controls.Add(this.btnSearchForPerson);
            this.gboxSearchForPerson.Controls.Add(this.tboxSearch);
            this.gboxSearchForPerson.Controls.Add(this.cboxSearchBy);
            this.gboxSearchForPerson.Controls.Add(this.label1);
            this.gboxSearchForPerson.Location = new System.Drawing.Point(3, 3);
            this.gboxSearchForPerson.Name = "gboxSearchForPerson";
            this.gboxSearchForPerson.Size = new System.Drawing.Size(930, 100);
            this.gboxSearchForPerson.TabIndex = 0;
            this.gboxSearchForPerson.TabStop = false;
            this.gboxSearchForPerson.Text = "Search";
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.BackgroundImage = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.person_boy;
            this.btnAddNewPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddNewPerson.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddNewPerson.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewPerson.Location = new System.Drawing.Point(585, 32);
            this.btnAddNewPerson.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(44, 37);
            this.btnAddNewPerson.TabIndex = 22;
            this.btnAddNewPerson.UseVisualStyleBackColor = true;
            // 
            // btnSearchForPerson
            // 
            this.btnSearchForPerson.BackgroundImage = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.person_boy_Search;
            this.btnSearchForPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearchForPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchForPerson.Location = new System.Drawing.Point(534, 32);
            this.btnSearchForPerson.Name = "btnSearchForPerson";
            this.btnSearchForPerson.Size = new System.Drawing.Size(44, 37);
            this.btnSearchForPerson.TabIndex = 21;
            this.btnSearchForPerson.UseVisualStyleBackColor = true;
            this.btnSearchForPerson.Click += new System.EventHandler(this.btnSearchForPerson_Click);
            // 
            // tboxSearch
            // 
            this.tboxSearch.Location = new System.Drawing.Point(323, 45);
            this.tboxSearch.Name = "tboxSearch";
            this.tboxSearch.Size = new System.Drawing.Size(181, 24);
            this.tboxSearch.TabIndex = 1;
            this.tboxSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tboxSearchBy_KeyPress);
            // 
            // cboxSearchBy
            // 
            this.cboxSearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSearchBy.FormattingEnabled = true;
            this.cboxSearchBy.Items.AddRange(new object[] {
            "None",
            "National No.",
            "PersonID"});
            this.cboxSearchBy.Location = new System.Drawing.Point(136, 45);
            this.cboxSearchBy.Name = "cboxSearchBy";
            this.cboxSearchBy.Size = new System.Drawing.Size(181, 24);
            this.cboxSearchBy.TabIndex = 0;
            this.cboxSearchBy.SelectedIndexChanged += new System.EventHandler(this.cboxSearchBy_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label1.Location = new System.Drawing.Point(19, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search By :";
            // 
            // ctrlPersonInfo1
            // 
            this.ctrlPersonInfo1.Location = new System.Drawing.Point(3, 109);
            this.ctrlPersonInfo1.Name = "ctrlPersonInfo1";
            this.ctrlPersonInfo1.Size = new System.Drawing.Size(930, 319);
            this.ctrlPersonInfo1.TabIndex = 2;
            // 
            // ctrlSearchForPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlPersonInfo1);
            this.Controls.Add(this.gboxSearchForPerson);
            this.Name = "ctrlSearchForPerson";
            this.Size = new System.Drawing.Size(935, 429);
            this.gboxSearchForPerson.ResumeLayout(false);
            this.gboxSearchForPerson.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxSearchForPerson;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboxSearchBy;
        private ctrlPersonInfo ctrlPersonInfo1;
        private System.Windows.Forms.TextBox tboxSearch;
        private System.Windows.Forms.Button btnAddNewPerson;
        private System.Windows.Forms.Button btnSearchForPerson;
    }
}
