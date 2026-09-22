namespace Driving___Vehicle_License_Departement__DVLD_.User_Forms
{
    partial class frmAddEditUser
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
            this.tctrlAddEditUser = new System.Windows.Forms.TabControl();
            this.tpagePersonInfo = new System.Windows.Forms.TabPage();
            this.btnNextTab = new System.Windows.Forms.Button();
            this.tpageLoginInfo = new System.Windows.Forms.TabPage();
            this.btnPreviousTab = new System.Windows.Forms.Button();
            this.lblUserIdValue = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chboxIsActive = new System.Windows.Forms.CheckBox();
            this.tboxUserName = new System.Windows.Forms.TextBox();
            this.tboxConfirmPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tboxPassword = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrlSearchForPerson1 = new Driving___Vehicle_License_Departement__DVLD_.Person_Forms.ctrlSearchForPerson();
            this.tctrlAddEditUser.SuspendLayout();
            this.tpagePersonInfo.SuspendLayout();
            this.tpageLoginInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tctrlAddEditUser
            // 
            this.tctrlAddEditUser.Controls.Add(this.tpagePersonInfo);
            this.tctrlAddEditUser.Controls.Add(this.tpageLoginInfo);
            this.tctrlAddEditUser.Location = new System.Drawing.Point(2, 2);
            this.tctrlAddEditUser.Name = "tctrlAddEditUser";
            this.tctrlAddEditUser.SelectedIndex = 0;
            this.tctrlAddEditUser.Size = new System.Drawing.Size(949, 515);
            this.tctrlAddEditUser.TabIndex = 0;
            // 
            // tpagePersonInfo
            // 
            this.tpagePersonInfo.Controls.Add(this.btnNextTab);
            this.tpagePersonInfo.Controls.Add(this.ctrlSearchForPerson1);
            this.tpagePersonInfo.Location = new System.Drawing.Point(4, 25);
            this.tpagePersonInfo.Name = "tpagePersonInfo";
            this.tpagePersonInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpagePersonInfo.Size = new System.Drawing.Size(941, 486);
            this.tpagePersonInfo.TabIndex = 0;
            this.tpagePersonInfo.Text = "Person Info";
            this.tpagePersonInfo.UseVisualStyleBackColor = true;
            // 
            // btnNextTab
            // 
            this.btnNextTab.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNextTab.Image = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.arrow_right__1_;
            this.btnNextTab.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNextTab.Location = new System.Drawing.Point(808, 441);
            this.btnNextTab.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNextTab.Name = "btnNextTab";
            this.btnNextTab.Size = new System.Drawing.Size(126, 37);
            this.btnNextTab.TabIndex = 120;
            this.btnNextTab.Text = "Next";
            this.btnNextTab.UseVisualStyleBackColor = true;
            this.btnNextTab.Click += new System.EventHandler(this.btnPersonInfoNext_Click);
            // 
            // tpageLoginInfo
            // 
            this.tpageLoginInfo.Controls.Add(this.btnPreviousTab);
            this.tpageLoginInfo.Controls.Add(this.lblUserIdValue);
            this.tpageLoginInfo.Controls.Add(this.label4);
            this.tpageLoginInfo.Controls.Add(this.chboxIsActive);
            this.tpageLoginInfo.Controls.Add(this.tboxUserName);
            this.tpageLoginInfo.Controls.Add(this.tboxConfirmPassword);
            this.tpageLoginInfo.Controls.Add(this.label1);
            this.tpageLoginInfo.Controls.Add(this.label3);
            this.tpageLoginInfo.Controls.Add(this.label2);
            this.tpageLoginInfo.Controls.Add(this.tboxPassword);
            this.tpageLoginInfo.Location = new System.Drawing.Point(4, 25);
            this.tpageLoginInfo.Name = "tpageLoginInfo";
            this.tpageLoginInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpageLoginInfo.Size = new System.Drawing.Size(941, 486);
            this.tpageLoginInfo.TabIndex = 1;
            this.tpageLoginInfo.Text = "Login Info";
            this.tpageLoginInfo.UseVisualStyleBackColor = true;
            // 
            // btnPreviousTab
            // 
            this.btnPreviousTab.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPreviousTab.Image = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.arrow_left;
            this.btnPreviousTab.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPreviousTab.Location = new System.Drawing.Point(7, 441);
            this.btnPreviousTab.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPreviousTab.Name = "btnPreviousTab";
            this.btnPreviousTab.Size = new System.Drawing.Size(126, 37);
            this.btnPreviousTab.TabIndex = 139;
            this.btnPreviousTab.Text = "     Previous";
            this.btnPreviousTab.UseVisualStyleBackColor = true;
            this.btnPreviousTab.Click += new System.EventHandler(this.btnPreviousTab_Click);
            // 
            // lblUserIdValue
            // 
            this.lblUserIdValue.AutoSize = true;
            this.lblUserIdValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserIdValue.Location = new System.Drawing.Point(491, 156);
            this.lblUserIdValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserIdValue.Name = "lblUserIdValue";
            this.lblUserIdValue.Size = new System.Drawing.Size(48, 25);
            this.lblUserIdValue.TabIndex = 138;
            this.lblUserIdValue.Text = "???";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(375, 156);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 25);
            this.label4.TabIndex = 137;
            this.label4.Text = "UserID:";
            // 
            // chboxIsActive
            // 
            this.chboxIsActive.AutoSize = true;
            this.chboxIsActive.Checked = true;
            this.chboxIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chboxIsActive.Location = new System.Drawing.Point(496, 312);
            this.chboxIsActive.Name = "chboxIsActive";
            this.chboxIsActive.Size = new System.Drawing.Size(81, 21);
            this.chboxIsActive.TabIndex = 136;
            this.chboxIsActive.Text = "Is Active";
            this.chboxIsActive.UseVisualStyleBackColor = true;
            // 
            // tboxUserName
            // 
            this.tboxUserName.Location = new System.Drawing.Point(468, 193);
            this.tboxUserName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tboxUserName.MaxLength = 50;
            this.tboxUserName.Name = "tboxUserName";
            this.tboxUserName.Size = new System.Drawing.Size(167, 24);
            this.tboxUserName.TabIndex = 130;
            // 
            // tboxConfirmPassword
            // 
            this.tboxConfirmPassword.Location = new System.Drawing.Point(468, 265);
            this.tboxConfirmPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tboxConfirmPassword.MaxLength = 50;
            this.tboxConfirmPassword.Name = "tboxConfirmPassword";
            this.tboxConfirmPassword.PasswordChar = '*';
            this.tboxConfirmPassword.Size = new System.Drawing.Size(167, 24);
            this.tboxConfirmPassword.TabIndex = 134;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(340, 192);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 25);
            this.label1.TabIndex = 132;
            this.label1.Text = "UserName:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(266, 264);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 25);
            this.label3.TabIndex = 135;
            this.label3.Text = "Confirm Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(347, 228);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 25);
            this.label2.TabIndex = 133;
            this.label2.Text = "Password:";
            // 
            // tboxPassword
            // 
            this.tboxPassword.Location = new System.Drawing.Point(468, 229);
            this.tboxPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tboxPassword.MaxLength = 50;
            this.tboxPassword.Name = "tboxPassword";
            this.tboxPassword.PasswordChar = '*';
            this.tboxPassword.Size = new System.Drawing.Size(167, 24);
            this.tboxPassword.TabIndex = 131;
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(821, 525);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 37);
            this.btnSave.TabIndex = 121;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(687, 525);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 37);
            this.btnClose.TabIndex = 122;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrlSearchForPerson1
            // 
            this.ctrlSearchForPerson1.Location = new System.Drawing.Point(3, 6);
            this.ctrlSearchForPerson1.Name = "ctrlSearchForPerson1";
            this.ctrlSearchForPerson1.Size = new System.Drawing.Size(935, 429);
            this.ctrlSearchForPerson1.TabIndex = 0;
            // 
            // frmAddEditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 570);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tctrlAddEditUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddEditUser";
            this.Text = "frmAddEditUser";
            this.tctrlAddEditUser.ResumeLayout(false);
            this.tpagePersonInfo.ResumeLayout(false);
            this.tpageLoginInfo.ResumeLayout(false);
            this.tpageLoginInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tctrlAddEditUser;
        private System.Windows.Forms.TabPage tpagePersonInfo;
        private System.Windows.Forms.TabPage tpageLoginInfo;
        private Person_Forms.ctrlSearchForPerson ctrlSearchForPerson1;
        private System.Windows.Forms.Button btnNextTab;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblUserIdValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chboxIsActive;
        private System.Windows.Forms.TextBox tboxUserName;
        private System.Windows.Forms.TextBox tboxConfirmPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tboxPassword;
        private System.Windows.Forms.Button btnPreviousTab;
    }
}