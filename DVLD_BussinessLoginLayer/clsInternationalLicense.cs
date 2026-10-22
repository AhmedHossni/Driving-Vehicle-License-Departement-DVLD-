using System;
using DVLD_DataAccessLayer;
using System.Data;

namespace DVLD_BusinessLogicLayer
{
    public class clsInternationalLicense
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int InternationalLicenseID { get; private set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }

        public clsInternationalLicense()
        {
            this.InternationalLicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.IssuedUsingLocalLicenseID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.IsActive = true;
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        public static bool Find(
        int internationalLicenseID,
        ref int applicationID,
        ref int driverID,
        ref int issuedUsingLocalLicenseID,
        ref DateTime issueDate,
        ref DateTime expirationDate,
        ref bool isActive,
        ref string fullName,
        ref string nationalNo,
        ref string gender,
        ref DateTime dateOfBirth,
        ref string imageName,
        out string errorMessage)
        {
            return clsInternationalLicenseData.GetInternationalLicenseInfoByID(
                internationalLicenseID,
                ref applicationID,
                ref driverID,
                ref issuedUsingLocalLicenseID,
                ref issueDate,
                ref expirationDate,
                ref isActive,
                ref fullName,
                ref nationalNo,
                ref gender,
                ref dateOfBirth,
                ref imageName,
                out errorMessage
            );
        }

        public static bool IsExistByDriverID(int driverID, out string errorMessage)
        {
            return clsInternationalLicenseData.IsInternationalLicenseExistByDriverID(driverID, out errorMessage);
        }

        public static bool IsExistByNationalNo(string nationalNo, out string errorMessage)
        {
            return clsInternationalLicenseData.IsInternationalLicenseExistByNationalNo(nationalNo, out errorMessage);
        }

        public static bool GetInternationalLicenseInfoByDriverID(
            int driverID,
            out int internationalLicenseID,
            out int applicationID,
            out int issuedUsingLocalLicenseID,
            out DateTime issueDate,
            out DateTime expirationDate,
            out bool isActive,
            out int createdByUserID,
            out string errorMessage)
        {
            return clsInternationalLicenseData.GetInternationalLicenseInfoByDriverID(
                driverID,
                out internationalLicenseID,
                out applicationID,
                out issuedUsingLocalLicenseID,
                out issueDate,
                out expirationDate,
                out isActive,
                out createdByUserID,
                out errorMessage
            );
        }
        public static bool GetInternationalLicenseIDByDriverID(
            int driverID,
            out int internationalLicenseID,
            out string errorMessage)
        {
            return clsInternationalLicenseData.GetInternationalLicenseIDInfoByDriverID(
                driverID,
                out internationalLicenseID,
                out errorMessage
            );
        }

        public static bool GetInternationalLicenseInfoByNationalNo(
            string nationalNo,
            out int internationalLicenseID,
            out int applicationID,
            out int driverID,
            out int issuedUsingLocalLicenseID,
            out DateTime issueDate,
            out DateTime expirationDate,
            out bool isActive,
            out int createdByUserID,
            out string errorMessage)
        {
            return clsInternationalLicenseData.GetInternationalLicenseInfoByNationalNo(
                nationalNo,
                out internationalLicenseID,
                out applicationID,
                out driverID,
                out issuedUsingLocalLicenseID,
                out issueDate,
                out expirationDate,
                out isActive,
                out createdByUserID,
                out errorMessage
            );
        }

        private bool _AddNewInternationalLicense()
        {
            int newID = -1;

            bool isSuccess = clsInternationalLicenseData.AddNewInternationalLicense(
                this.ApplicationID,
                this.DriverID,
                this.IssuedUsingLocalLicenseID,
                this.IssueDate,
                this.ExpirationDate,
                this.IsActive,
                this.CreatedByUserID,
                ref newID,
                out string err
            );

            if (isSuccess)
            {
                this.InternationalLicenseID = newID;
            }

            return isSuccess;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewInternationalLicense())
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

        public static DataTable GetInternationalLicensesByDriverID(int driverID, out string errorMessage)
        {
            return clsInternationalLicenseData
                .GetInternationalLicensesByDriverID(driverID, out errorMessage);
        }

        public static DataTable GetInternationalLicensesByNationalNo(string nationalNo, out string errorMessage)
        {
            return clsInternationalLicenseData
                .GetInternationalLicensesByNationalNo(nationalNo, out errorMessage);
        }

        public static DataTable GetAllInternationalLicenses(out string errorMessage)
        {
            return clsInternationalLicenseData.GetAllInternationalLicenses(out errorMessage);
        }
    }
}
