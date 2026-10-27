using DVLD_DataAccessLayer;
using System;
using System.Data;

namespace DVLD_BusinessLogicLayer
{
    public class clsDetainedLicense
    {
        public int DetainID { private set; get; }
        public int LicenseID { set; get; }
        public DateTime DetainDate { set; get; }
        public decimal FineFees { set; get; }
        public int CreatedByUserID { set; get; }
        public bool IsReleased { set; get; }
        public DateTime? ReleaseDate { set; get; }
        public int? ReleasedByUserID { set; get; }
        public int? ReleaseApplicationID { set; get; }

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode { private set; get; } = enMode.AddNew;

        public clsDetainedLicense()
        {
            this.DetainID = -1;
            this.LicenseID = -1;
            this.DetainDate = DateTime.Now;
            this.FineFees = 0;
            this.CreatedByUserID = -1;
            this.IsReleased = false;
            this.ReleaseDate = null;
            this.ReleasedByUserID = null;
            this.ReleaseApplicationID = null;

            this.Mode = enMode.AddNew;
        }

        public static clsDetainedLicense GetBy(int licenseID, out string errorMessage)
        {
            int detainID = -1;
            DateTime detainDate = DateTime.MinValue;
            decimal fineFees = 0;
            int createdByUserID = -1;
            bool isReleased = false;
            DateTime? releaseDate = null;
            int? releasedByUserID = null;
            int? releaseApplicationID = null;
            errorMessage = string.Empty;

            bool isFound = clsDetainedLicenseData.GetDetainedLicenseInfoByLicenseID(
                licenseID,
                ref detainID,
                ref detainDate,
                ref fineFees,
                ref createdByUserID,
                ref isReleased,
                ref releaseDate,
                ref releasedByUserID,
                ref releaseApplicationID,
                out errorMessage
            );

            if (isFound)
            {
                clsDetainedLicense detainedLicense 
                    = new clsDetainedLicense();

                detainedLicense.DetainID = detainID;
                detainedLicense.LicenseID = licenseID;
                detainedLicense.DetainDate = detainDate;
                detainedLicense.FineFees = fineFees;
                detainedLicense.CreatedByUserID = createdByUserID;
                detainedLicense.IsReleased = isReleased;
                detainedLicense.ReleaseDate = releaseDate;
                detainedLicense.ReleasedByUserID = releasedByUserID;
                detainedLicense.ReleaseApplicationID = releaseApplicationID;
                detainedLicense.Mode = enMode.Update;

                return detainedLicense;
            }
            else
            {
                return null;
            }
        }

        public static bool IsLicenseDetained(int licenseID, out string errorMessage)
        {
            errorMessage = string.Empty;
            return clsDetainedLicenseData.IsLicenseDetained(licenseID, out errorMessage);
        }

        public static bool IsLicenseDetained(int detainID, out bool isReleased, out string errorMessage)
        {
            errorMessage = string.Empty;

            bool isFound = clsDetainedLicenseData
                .IsLicenseDetained(detainID, out isReleased, out errorMessage);

            if (isFound && !isReleased)
            {
                return true;
            }

            return false;
        }

        private bool _AddNewDetainedLicense(out string errorMessage)
        {
            errorMessage = string.Empty;
            this.DetainID = clsDetainedLicenseData.AddNewDetainedLicense(
                this.LicenseID,
                this.DetainDate,
                this.FineFees,
                this.CreatedByUserID,
                out errorMessage
            );

            return (this.DetainID != -1);
        }

        private bool _UpdateDetainedLicense(out string errorMessage)
        {
            errorMessage = string.Empty;
            return clsDetainedLicenseData.ReleaseDetainedLicense(
                this.DetainID,
                this.ReleasedByUserID.Value,
                this.ReleaseApplicationID.Value,
                out errorMessage
            );
        }

        public bool Save(out string errorMessage)
        {
            errorMessage = string.Empty;

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDetainedLicense(out errorMessage))
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateDetainedLicense(out errorMessage);
            }

            return false;
        }

        public static DataTable GetAllDetainedLicenses(out string errorMessage)
        {
            return clsDetainedLicenseData.GetAllDetainedLicenses(out errorMessage);
        }
    }
}