using DVLD_DataAccessLayer;
using System.Data;

namespace DVLD_BusinessLogicLayer
{
    public class clsLocalDrivingLicenseApplication
    {
        int _id;
        public int LocalDrivingLicenseApplicationId { get { return _id; } }
        public int ApplicationId { get; set; }
        public int LicenseClassId { get; set; }

        public clsLocalDrivingLicenseApplication()
        {
            _id = -1;
            ApplicationId = -1;
            LicenseClassId = -1;
        }

        private clsLocalDrivingLicenseApplication(int id, int applicationId, int licenseClassId)
        {
            _id = id;
            ApplicationId = applicationId;
            LicenseClassId = licenseClassId;
        }

        public bool Save(out string errorMessage)
        {        
            if (_id == -1)
                return Add(ApplicationId, LicenseClassId, out _id, out errorMessage);
            else
                return Update(_id, ApplicationId, LicenseClassId, out errorMessage);
        }

        public static clsLocalDrivingLicenseApplication GetBy(int localDrivingLicenseAppId, out string errorMessage)
        {
            int applicationId = -1;
            int licenseClasssId = -1;

            if (clsLocalDrivingLicenseApplicationData.GetBy
                (localDrivingLicenseAppId, ref applicationId, ref licenseClasssId, out errorMessage))
                return new clsLocalDrivingLicenseApplication(localDrivingLicenseAppId, applicationId, licenseClasssId);
            else
                return null;
        }
        public static bool GetBasicInfoBy(int localDrivingLicenseAppId,
            ref string appliedForLicense, ref int passedTests, out string errorMessage)
        {
            return clsLocalDrivingLicenseApplicationData.GetBasicInfoBy
                (localDrivingLicenseAppId, ref appliedForLicense, ref passedTests, out errorMessage);
        }

        public static DataTable GetAll(out string errorMessage)
            => clsLocalDrivingLicenseApplicationData.GetAll(out errorMessage);

        public static DataTable GetAllDataForFormDGV(out string errorMessage)
            => clsLocalDrivingLicenseApplicationData.GetAllDataForFormDGV(out errorMessage);

        public static bool Add(int applicationId, int licenseClassId, out int localDrivingLicenseId, out string errorMessage)
            => clsLocalDrivingLicenseApplicationData.Add(applicationId, licenseClassId, out errorMessage, out localDrivingLicenseId);

        public static bool Delete(int localDrivingLicenseId, out string errorMessage)
            => clsLocalDrivingLicenseApplicationData.Delete(localDrivingLicenseId, out errorMessage);

        public static bool Update(int localDrivingLicenseId, int applicationId, int licenseClassId, out string errorMessage)
            => clsLocalDrivingLicenseApplicationData.Update(localDrivingLicenseId, applicationId, licenseClassId, out errorMessage);
    }
}
