using System;
using DVLD_DataAccessLayer;
using System.Data;

namespace DVLD_BusinessLogicLayer
{
    public class clsInternationalLicense
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int InternationalLicenseID { get; set; }
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

        public static DataTable GetInternationalLicensesByDriverID(int driverID, out string errorMessage)
        {
            return clsInternationalLicenseData.
                GetInternationalLicensesByDriverID(driverID, out errorMessage);
        }

        public static DataTable GetInternationalLicensesByNationalNo(string nationalNo, out string errorMessage)
        {
            return clsInternationalLicenseData.
                GetInternationalLicensesByNationalNo(nationalNo, out errorMessage);
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
    }
}
