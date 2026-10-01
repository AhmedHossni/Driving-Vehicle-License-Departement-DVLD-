using CommonUseThings;
using DVLD_DataAccessLayer;
using System;
using System.Data;

namespace DVLD_BusinessLogicLayer
{
    public class clsApplication
    {
        private int _id;
        public int Id => _id;
        public int PersonId { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int ApplicaionTypeID { get; set; }
        public enApplicationStatus ApplicaionStatus { get; set; }
        public DateTime LastStatusDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }

        public clsApplication()
        {
            _id = -1;
            PersonId = -1;
            ApplicationDate = DateTime.Now;
            ApplicaionStatus = enApplicationStatus.None;
            LastStatusDate = DateTime.Now;
            PaidFees = -1;
            CreatedByUserID = -1;
        }

        private clsApplication(int id, int personId, DateTime applicationDate, int applicaionTypeID, 
            enApplicationStatus applicaionStatus, DateTime lastStatusDate, decimal paidFees, int createdByUserID)
        {
            _id = id;
            PersonId = personId;
            ApplicationDate = applicationDate;
            ApplicaionTypeID = applicaionTypeID;
            ApplicaionStatus = applicaionStatus;
            LastStatusDate = lastStatusDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
        }

        public static clsApplication GetBy(int applicationId, out string errorMessage)
        {
            int personId = -1;
            DateTime applicationDate = new DateTime();
            int applicaionTypeID = -1;
            enApplicationStatus applicaionStatus = enApplicationStatus.New;
            DateTime lastStatusDate = new DateTime();
            decimal paidFees = 0;
            int createdByUserID = -1;

            if (clsApplicationData.GetBy(applicationId, ref personId, ref applicationDate, ref applicaionTypeID
            , ref applicaionStatus, ref lastStatusDate, ref paidFees, ref createdByUserID, out errorMessage))
                return new clsApplication(applicationId, personId, applicationDate, applicaionTypeID,
                    applicaionStatus, lastStatusDate, paidFees, createdByUserID);
            else
                return null;
        }

        public bool Save(out string errorMessage)
        {
            errorMessage = string.Empty;
            bool result = false;

            if (_id == -1)
            {
                DateTime applicationDate = DateTime.Now;
                DateTime lastStatusUpdate = DateTime.Now;
                int applicationTypeId = (int)ApplicaionTypeID;
                decimal paidFees = PaidFees;
                int createdByUserId = CreatedByUserID;

                result = clsApplication.Add(PersonId, ApplicationDate, ApplicaionTypeID,
                    LastStatusDate, PaidFees, CreatedByUserID, out errorMessage, out _id);
            }
            else
            {
                int personIdTemp = PersonId;
                int appTypeTemp = ApplicaionTypeID;
                enApplicationStatus appStatusTemp = ApplicaionStatus;
                DateTime lastStatusDateTemp = LastStatusDate;
                decimal paidFeesTemp = PaidFees;

                result = clsApplicationData.Update(_id, ref personIdTemp, ref appTypeTemp,
                    ref appStatusTemp, ref lastStatusDateTemp, ref paidFeesTemp, out errorMessage);

                if (result)
                {
                    PersonId = personIdTemp;
                    ApplicaionTypeID = appTypeTemp;
                    ApplicaionStatus = appStatusTemp;
                    LastStatusDate = lastStatusDateTemp;
                    PaidFees = paidFeesTemp;
                }
            }

            return result;
        }

        public static bool Add(int personId, DateTime applicationDate,
            int applicationTypeId, DateTime lastStatusUpdate,
            decimal paidFees, int createdByUserId,
            out string errorMessage, out int applicationId)
        {
            return clsApplicationData.Add(personId, applicationDate,
                applicationTypeId, lastStatusUpdate,
                paidFees, createdByUserId,
                out errorMessage, out applicationId);
        }

        public static bool Delete(int applicationId, out string errorMessage)
        {
            return clsApplicationData.Delete(applicationId, out errorMessage);
        }

        public static bool IsPersonHaveAllreadySameOpenApplication(int personId, int applicationTypesId, out string errorMessage)
        {
            return clsApplicationData.IsPersonHaveAllreadySameOpenApplication(personId, applicationTypesId, out errorMessage);
        }

        public static DataTable GetAll(out string errorMessage)
            => clsApplicationData.GetAll(out errorMessage);
    }
}
