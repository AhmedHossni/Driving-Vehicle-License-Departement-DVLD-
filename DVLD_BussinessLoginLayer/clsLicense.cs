using DVLD_DataAccessLayer;
using System;

namespace DVLD_BusinessLogicLayer
{
    public class clsLicense
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClassID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal PaidFees { get; set; }

        public string Notes { get; set; }
        public bool IsActive { get; set; }
        public byte IssueReason { get; set; }
        public int CreatedByUserID { get; set; }

        public clsLicense()
        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClassID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.PaidFees = 0;
            this.Notes = "";
            this.IsActive = true;
            this.IssueReason = 1;
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        private bool _AddNewLicense()
        {
            int newID = -1;

            bool isSuccess = clsLicenseData.AddNewLDLicense(
                this.ApplicationID,
                this.DriverID,
                this.LicenseClassID,
                this.IssueDate,
                this.Notes,
                this.IsActive,
                this.IssueReason,
                this.CreatedByUserID,
                ref newID, out string errorMessage
            );

            if (isSuccess)
            {
                this.LicenseID = newID;
            }

            return isSuccess;
        }

        public static bool IsThisLDLAppHaveLocalDrivingIssue(int localDrivingLicense, out string errorMessage)
        {
            return clsLicenseData.IsThisLDLAppHaveLocalDrivingIssue
                (localDrivingLicense, out errorMessage);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicense())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return false;
            }

            return false;
        }
    }
}

