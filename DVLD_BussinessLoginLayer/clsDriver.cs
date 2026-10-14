using System;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLogicLayer
{
    public class clsDriver
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode Mode = enMode.AddNew;

        public int DriverID { get; private set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }

        public clsDriver()
        {
            this.DriverID = -1;
            this.PersonID = -1;
            this.CreatedByUserID = -1;
            this.CreatedDate = DateTime.Now;

            Mode = enMode.AddNew;
        }

        private clsDriver(int driverID, int personID, int createdByUserID, DateTime createdDate)
        {
            this.DriverID = driverID;
            this.PersonID = personID;
            this.CreatedByUserID = createdByUserID;
            this.CreatedDate = createdDate;

            Mode = enMode.Update;
        }

        public static clsDriver FindByDriverID(int driverID, out string errorMessage)
        {
            int personID = -1;
            int createdByUserID = -1;
            DateTime createdDate = DateTime.Now;

            bool isFound = clsDriverData.GetDriverInfoByDriverID(
                driverID,
                ref personID,
                ref createdByUserID,
                ref createdDate,
                out errorMessage
            );

            if (isFound)
            {
                return new clsDriver(driverID, personID, createdByUserID, createdDate);
            }
            else
            {
                return null;
            }
        }

        public static clsDriver FindByPersonID(int personID, out string errorMessage)
        {
            int driverID = -1;
            int createdByUserID = -1;
            DateTime createdDate = DateTime.Now;

            bool isFound = clsDriverData.GetDriverInfoByPersonID(
                personID,
                ref driverID,
                ref createdByUserID,
                ref createdDate,
                out errorMessage
            );

            if (isFound)
            {
                return new clsDriver(driverID, personID, createdByUserID, createdDate);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewDriver(out string errorMessage)
        {
            this.DriverID = clsDriverData.AddNewDriver(this.PersonID, this.CreatedByUserID,
                out errorMessage);

            return (this.DriverID != -1);
        }

        private bool _UpdateDriver(out string errorMessage)
        {
            bool isUpdated = clsDriverData.UpdateDriver(this.DriverID, this.PersonID, this.CreatedByUserID, 
                out errorMessage);
            return isUpdated;
        }

        public bool Save(out string errorMessage)
        {
            errorMessage = string.Empty;
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDriver(out errorMessage))
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateDriver(out errorMessage);
            }

            return false;
        }

        public static bool DeleteDriver(int driverID, out string errorMessage)
        {
            return clsDriverData.DeleteDriver(driverID, out errorMessage);
        }
    }
}
