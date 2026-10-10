using CommonUseThings;
using DVLD_DataAccessLayer;
using System;
using System.Data;

namespace DVLD_BusinessLogicLayer
{
    public class clsTestAppointment
    {
        private int _id = -1;
        public int Id { get { return _id; } }
        public enTestTypes TestType { set;  get; }
        public int LocalDrivingLicenseApplicationID { set;  get; }
        public DateTime AppointmentDate { set;  get; }
        public decimal PaidFees { set;  get; }
        public int CreatedByUserID { set;  get; }
        public bool IsLocked { set;  get; }

        private clsTestAppointment(int id, enTestTypes testTypeID, int localDrivingLicenseApplicationID,
            DateTime appointmentDate, decimal paidFees, int createdByUserID, bool isLocked)
        {
            _id = id;
            TestType = testTypeID;
            LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            AppointmentDate = appointmentDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
            IsLocked = isLocked;
        }
        public clsTestAppointment()
        {
            _id = -1;
            TestType = default;
            LocalDrivingLicenseApplicationID = -1;
            AppointmentDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = -1;
            IsLocked = false;
        }

        public bool Save(out string errorMessage)
        {
            bool result = false;
            errorMessage = string.Empty;

            if (Id == -1)
            {
                result = clsTestAppointmentData.Add( (int)TestType,
                    LocalDrivingLicenseApplicationID,
                    AppointmentDate,
                    PaidFees,
                    CreatedByUserID
                    , out errorMessage, 
                    out _id);
            }

            return result;
        }

        public static clsTestAppointment GetBy(int testAppointmentID)
        {
            enTestTypes testTypeID = default;
            int localDLAppID = -1;
            DateTime appointmentDate = DateTime.MinValue;
            decimal paidFees = 0;
            int createdByUserID = -1;
            bool isLocked = false;
            string errorMessage = string.Empty;

            bool isFound = clsTestAppointmentData.GetBy(
                testAppointmentID,
                ref testTypeID,
                ref localDLAppID,
                ref appointmentDate,
                ref paidFees,
                ref createdByUserID,
                ref isLocked,
                out errorMessage
            );

            if (isFound)
            {
                return new clsTestAppointment(
                    testAppointmentID,
                    testTypeID,
                    localDLAppID,
                    appointmentDate,
                    paidFees,
                    createdByUserID,
                    isLocked
                );
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetAllPersonTestAppointmentsBy(int localDLAppID, enTestTypes testType,
            out string errorMessage)
            => clsTestAppointmentData.GetAllPersonTestAppointmentsBy(localDLAppID, testType, out errorMessage);


        public static bool UpdateDate(int testAppointmentID, DateTime appointmentDate
            , out string errorMessage)
        {
            return clsTestAppointmentData.UpdateDate(testAppointmentID, appointmentDate, out errorMessage);
        }

        public static bool GetFullTestAppointmentDetails(
            int testAppointmentID,
            ref int localDLAppId,
            ref string className,
            ref string fullName,
            ref int trials,
            ref DateTime date,
            ref decimal testTypeFees,
            ref int? rtAppID,
            ref decimal rtFees,
            ref bool isLocked,
            out string errorMessage)
        {
            errorMessage = string.Empty;

            clsTestAppointment testAppointments 
                = new clsTestAppointment();

            return clsTestAppointmentData.GetTestAppointmentDetails(
                testAppointmentID,
                ref localDLAppId,
                ref className,
                ref fullName,
                ref trials,
                ref date,
                ref testTypeFees,
                ref rtAppID,
                ref rtFees,
                ref isLocked,
                out errorMessage
            );
        }

        public static bool LockAppointment(int testAppointmentID,
            out string errorMessage)
        {
            return clsTestAppointmentData.LockAppointment(testAppointmentID, out errorMessage);
        }

        public static bool DidExamineePass(int localDLAppId, int testTypeId,
            out string errorMessage)
        {
            return clsTestAppointmentData.DidExamineePass(localDLAppId, testTypeId, out errorMessage);
        }
    }
}
