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

        public class clsDriverLicenseInfoDTO
        {
            public int LicenseID { get; set; }
            public int ApplicationID { get; set; }
            public string ClassName { get; set; }
            public int DriverID { get; set; }
            public string FullName { get; set; }
            public string NationalNo { get; set; }
            public string Gender { get; set; }
            public DateTime IssueDate { get; set; }
            public DateTime ExpirationDate { get; set; }
            public byte IssueReason { get; set; }
            public string Notes { get; set; }
            public bool IsActive { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string ImagePath { get; set; }
            public bool IsDetained { get; set; }
        }

        public static clsDriverLicenseInfoDTO GetDriverLicenseInfoByApplicationID(int applicationID,
            out string errorMessage)
        {
            int licenseID = -1;
            string className = "";
            int driverID = -1;
            string fullName = "";
            string nationalNo = "";
            string gender = "";
            DateTime issueDate = DateTime.MinValue;
            DateTime expirationDate = DateTime.MinValue;
            byte issueReason = 0;
            string notes = "";
            bool isActive = false;
            DateTime dateOfBirth = DateTime.MinValue;
            string imagePath = "";
            bool isDetained = false;

            bool isFound = clsLicenseData.GetDriverLicenseInfoByApplicationID(
                applicationID,
                ref licenseID,
                ref className,
                ref driverID,
                ref fullName,
                ref nationalNo,
                ref gender,
                ref issueDate,
                ref expirationDate,
                ref issueReason,
                ref notes,
                ref isActive,
                ref dateOfBirth,
                ref imagePath,
                ref isDetained,
                out errorMessage
            );

            if (isFound)
            {
                return new clsDriverLicenseInfoDTO
                {
                    LicenseID = licenseID,
                    ApplicationID = applicationID,
                    ClassName = className,
                    DriverID = driverID,
                    FullName = fullName,
                    NationalNo = nationalNo,
                    Gender = gender,
                    IssueDate = issueDate,
                    ExpirationDate = expirationDate,
                    IssueReason = issueReason,
                    Notes = notes,
                    IsActive = isActive,
                    DateOfBirth = dateOfBirth,
                    ImagePath = imagePath,
                    IsDetained = isDetained
                };
            }
            else
            {
                return null;
            }
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
            out string imagePath, out bool isDetained,  out string errorMessage)
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
            isDetained = false;
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
                out isDetained,
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

