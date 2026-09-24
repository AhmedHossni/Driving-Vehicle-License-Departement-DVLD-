namespace Driving___Vehicle_License_Departement__DVLD_.User_Forms
{
    partial class frmChangeUserPassword
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
            this.tboxCurrentPassword = new System.Windows.Forms.TextBox();
            this.tboxConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblCurrentPassword = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tboxNewPassword = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.epMainError = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrlUserInfo1 = new Driving___Vehicle_License_Departement__DVLD_.User_Forms.ctrlUserInfo();
            this.ctrlPersonInfo1 = new Driving___Vehicle_License_Departement__DVLD_.Person_Forms.ctrlPersonInfo();
            ((System.ComponentModel.ISupportInitialize)(this.epMainError)).BeginInit();
            this.SuspendLayout();
            // 
            // tboxCurrentPassword
            // 
            this.tboxCurrentPassword.Location = new System.Drawing.Point(476, 495);
            this.tboxCurrentPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tboxCurrentPassword.MaxLength = 50;
            this.tboxCurrentPassword.Name = "tboxCurrentPassword";
            this.tboxCurrentPassword.PasswordChar = '*';
            this.tboxCurrentPassword.Size = new System.Drawing.Size(167, 24);
            this.tboxCurrentPassword.TabIndex = 1;
            this.tboxCurrentPassword.Tag = "Username";
            this.tboxCurrentPassword.Leave += new System.EventHandler(this.PasswordsTBox_Leave);
            // 
            // tboxConfirmPassword
            // 
            this.tboxConfirmPassword.Location = new System.Drawing.Point(476, 567);
            this.tboxConfirmPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tboxConfirmPassword.MaxLength = 50;
            this.tboxConfirmPassword.Name = "tboxConfirmPassword";
            this.tboxConfirmPassword.PasswordChar = '*';
            this.tboxConfirmPassword.Size = new System.Drawing.Size(167, 24);
            this.tboxConfirmPassword.TabIndex = 3;
            this.tboxConfirmPassword.Tag = "Password";
            this.tboxConfirmPassword.Leave += new System.EventHandler(this.tboxConfirmPassword_Leave);
            // 
            // lblCurrentPassword
            // 
            this.lblCurrentPassword.AutoSize = true;
            this.lblCurrentPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPassword.Location = new System.Drawing.Point(277, 494);
            this.lblCurrentPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrentPassword.Name = "lblCurrentPassword";
            this.lblCurrentPassword.Size = new System.Drawing.Size(191, 25);
            this.lblCurrentPassword.TabIndex = 138;
            this.lblCurrentPassword.Text = "Current Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(226, 566);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(242, 25);
            this.label3.TabIndex = 141;
            this.label3.Text = "Confirm New Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(307, 530);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 25);
            this.label2.TabIndex = 139;
            this.label2.Text = "New Password:";
            // 
            // tboxNewPassword
            // 
            this.tboxNewPassword.Location = new System.Drawing.Point(476, 531);
            this.tboxNewPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tboxNewPassword.MaxLength = 50;
            this.tboxNewPassword.Name = "tboxNewPassword";
            this.tboxNewPassword.PasswordChar = '*';
            this.tboxNewPassword.Size = new System.Drawing.Size(167, 24);
            this.tboxNewPassword.TabIndex = 2;
            this.tboxNewPassword.Tag = "Password";
            this.tboxNewPassword.Leave += new System.EventHandler(this.PasswordsTBox_Leave);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.Location = new System.Drawing.Point(342, 616);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 37);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(476, 616);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 37);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // epMainError
            // 
            this.epMainError.ContainerControl = this;
            // 
            // ctrlUserInfo1
            // 
            this.ctrlUserInfo1.Location = new System.Drawing.Point(2, 327);
            this.ctrlUserInfo1.Name = "ctrlUserInfo1";
            this.ctrlUserInfo1.Size = new System.Drawing.Size(929, 141);
            this.ctrlUserInfo1.TabIndex = 1;
            // 
            // ctrlPersonInfo1
            // 
            this.ctrlPersonInfo1.Location = new System.Drawing.Point(1, 2);
            this.ctrlPersonInfo1.Name = "ctrlPersonInfo1";
            this.ctrlPersonInfo1.Size = new System.Drawing.Size(930, 319);
            this.ctrlPersonInfo1.TabIndex = 0;
            // 
            // frmChangeUserPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 658);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tboxCurrentPassword);
            this.Controls.Add(this.tboxConfirmPassword);
            this.Controls.Add(this.lblCurrentPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tboxNewPassword);
            this.Controls.Add(this.ctrlUserInfo1);
            this.Controls.Add(this.ctrlPersonInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmChangeUserPassword";
            this.Text = "Change Password";
            ((System.ComponentModel.ISupportInitialize)(this.epMainError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Person_Forms.ctrlPersonInfo ctrlPersonInfo1;
        private ctrlUserInfo ctrlUserInfo1;
        private System.Windows.Forms.TextBox tboxCurrentPassword;
        private System.Windows.Forms.TextBox tboxConfirmPassword;
        private System.Windows.Forms.Label lblCurrentPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tboxNewPassword;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider epMainError;
    }
}