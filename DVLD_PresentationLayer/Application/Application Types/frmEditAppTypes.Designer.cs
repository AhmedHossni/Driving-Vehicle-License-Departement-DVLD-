namespace Driving___Vehicle_License_Departement__DVLD_.Applications.Application_Types
{
    partial class frmEditAppType
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
            this.lblAppTypeIdValue = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.tboxAppTypeName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tboxAppTypeFees = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFormLabel = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAppTypeIdValue
            // 
            this.lblAppTypeIdValue.AutoSize = true;
            this.lblAppTypeIdValue.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppTypeIdValue.Location = new System.Drawing.Point(105, 88);
            this.lblAppTypeIdValue.Name = "lblAppTypeIdValue";
            this.lblAppTypeIdValue.Size = new System.Drawing.Size(43, 24);
            this.lblAppTypeIdValue.TabIndex = 5;
            this.lblAppTypeIdValue.Text = "N\\A";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(12, 88);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(41, 24);
            this.lblId.TabIndex = 4;
            this.lblId.Text = "Id :";
            // 
            // tboxAppTypeName
            // 
            this.tboxAppTypeName.Location = new System.Drawing.Point(140, 134);
            this.tboxAppTypeName.Name = "tboxAppTypeName";
            this.tboxAppTypeName.Size = new System.Drawing.Size(271, 24);
            this.tboxAppTypeName.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "Name :";
            // 
            // tboxAppTypeFees
            // 
            this.tboxAppTypeFees.Location = new System.Drawing.Point(140, 180);
            this.tboxAppTypeFees.Name = "tboxAppTypeFees";
            this.tboxAppTypeFees.Size = new System.Drawing.Size(271, 24);
            this.tboxAppTypeFees.TabIndex = 13;
            this.tboxAppTypeFees.TextChanged += new System.EventHandler(this.tboxAppTypeFees_TextChanged);
            this.tboxAppTypeFees.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tboxAppTypeFees_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "Fees :";
            // 
            // lblFormLabel
            // 
            this.lblFormLabel.AutoSize = true;
            this.lblFormLabel.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormLabel.ForeColor = System.Drawing.Color.Red;
            this.lblFormLabel.Location = new System.Drawing.Point(53, 9);
            this.lblFormLabel.Name = "lblFormLabel";
            this.lblFormLabel.Size = new System.Drawing.Size(307, 34);
            this.lblFormLabel.TabIndex = 14;
            this.lblFormLabel.Text = "Update Appication Type";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(59, 227);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(132, 36);
            this.btnClose.TabIndex = 35;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(227, 226);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(127, 37);
            this.btnSave.TabIndex = 34;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.money_32;
            this.pictureBox2.Location = new System.Drawing.Point(93, 180);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(27, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Driving___Vehicle_License_Departement__DVLD_.Properties.Resources.ApplicationTitle;
            this.pictureBox1.Location = new System.Drawing.Point(93, 134);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // frmEditAppTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 275);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblFormLabel);
            this.Controls.Add(this.tboxAppTypeFees);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tboxAppTypeName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAppTypeIdValue);
            this.Controls.Add(this.lblId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmEditAppTypes";
            this.Text = "Update Appication Type";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAppTypeIdValue;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox tboxAppTypeName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tboxAppTypeFees;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFormLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
    }
}