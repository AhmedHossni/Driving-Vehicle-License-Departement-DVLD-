using DVLD_DataAccessLayer;
using System;
using System.Data;

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

        public static bool DeactivateLicense(int licenseID, out string errorMessage)
        {
            return clsLicenseData.DeactivateLicense(licenseID, out errorMessage);
        }

        public static bool CheckLicenseExpiration(
        int licenseID,
        ref DateTime expirationDate,
        ref bool isExpired,
        out string errorMessage)
        {
            return clsLicenseData.GetLicenseExpirationStatus(
                licenseID,
                ref expirationDate,
                ref isExpired,
                out errorMessage
            );
        }

        public static bool GetLicenseInfoByID(
        int licenseID,
        ref decimal lPaidFees,
        ref decimal appPaidFees,
        ref DateTime applicationDate,
        ref DateTime issueDate,
        ref DateTime expirationDate,
        ref string createBy,
        out string errorMessage)
        {
            return clsLicenseData.GetLicenseDetailsByID(
                licenseID,
                ref lPaidFees,
                ref appPaidFees,
                ref applicationDate,
                ref issueDate,
                ref expirationDate,
                ref createBy,
                out errorMessage
            );
        }

        public static bool IsThisLDLAppHaveLocalDrivingLicense(int localDrivingLicense, out string errorMessage)
        {
            return clsLicenseData.IsThisLDLAppHaveLocalDrivingLicense
                (localDrivingLicense, out errorMessage);
        }

        public static bool GetDriverInfoByLDLAppID(int localDLAppID,
            out int licenseID, out string className, out int driverID,
            out string fullName, out string nationalNo, out string gender,
            out DateTime issueDate, out DateTime expirationDate, out byte issueReason,
            out string notes, out bool isActive, out DateTime dateOfBirth,
            out string imagePath, out string errorMessage)
        {
            licenseID = -1;
            className = string.Empty;
            driverID = -1;
            fullName = string.Empty;
            nationalNo = string.Empty;
            gender = string.Empty;
            issueDate = DateTime.MinValue;
            expirationDate = DateTime.MinValue;
            issueReason = 0;
            notes = string.Empty;
            isActive = false;
            dateOfBirth = DateTime.MinValue;
            imagePath = string.Empty;
            errorMessage = string.Empty;

            return clsLicenseData.GetLicenseInfoByLDLAppID(
                localDLAppID,
                out licenseID,
                out className,
                out driverID,
                out fullName,
                out nationalNo,
                out gender,
                out issueDate,
                out expirationDate,
                out issueReason,
                out notes,
                out isActive,
                out dateOfBirth,
                out imagePath,
                out errorMessage
            );
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

        public static DataTable GetLicensesByDriverID(int driverID, out string errorMessage)
        {
            return clsLicenseData.GetLicensesByDriverID(driverID, out errorMessage);
        }

        public static DataTable GetLicensesByNationalNo(string nationalNo, out string errorMessage)
        {
            return clsLicenseData.GetLicensesByNationalNo(nationalNo, out errorMessage);
        }

        public static bool GetLicenseInfoByID(
            int licenseID,
            ref int applicationID,
            ref int localDrivingLicenseApplicationID,
            ref int licenseClass,
            ref int driverID,
            ref bool isActive,
            ref int personID,
            out string errorMessage)
        {
            return clsLicenseData.GetLicenseInfoByID(
                licenseID,
                ref applicationID,
                ref localDrivingLicenseApplicationID,
                ref licenseClass,
                ref driverID,
                ref isActive,
                ref personID,
                out errorMessage
            );
        }
    }
}

