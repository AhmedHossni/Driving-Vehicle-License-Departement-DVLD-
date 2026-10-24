using DVLD_DataAccessLayer;
using System.Data;


namespace DVLD_BusinessLogicLayer
{
    public class clsLicenseClass
    {
        public int LicenseClassID { set; get; }
        public string ClassName { set; get; }
        public string ClassDescription { set; get; }
        public byte MinimumAllowedAge { set; get; }
        public byte DefaultValidityLength { set; get; }
        public decimal ClassFees { set; get; }

        public static clsLicenseClass Find(int licenseClassID)
        {
            string className = string.Empty;
            string classDescription = string.Empty;
            byte minimumAllowedAge = 0;
            byte defaultValidityLength = 0;
            decimal classFees = 0;
            string errorMessage = string.Empty;

            bool isFound = clsLicenseClassData.GetLicenseClassInfoByID(
                licenseClassID,
                ref className,
                ref classDescription,
                ref minimumAllowedAge,
                ref defaultValidityLength,
                ref classFees,
                out errorMessage
            );

            if (isFound)
            {
                clsLicenseClass licenseClass = new clsLicenseClass();
                licenseClass.LicenseClassID = licenseClassID;
                licenseClass.ClassName = className;
                licenseClass.ClassDescription = classDescription;
                licenseClass.MinimumAllowedAge = minimumAllowedAge;
                licenseClass.DefaultValidityLength = defaultValidityLength;
                licenseClass.ClassFees = classFees;

                return licenseClass;
            }
            else
            {
                return null;
            }
        }

        public static bool IsAgeAllowedForLicense(int personID, int licenseClassID, out string errorMessage)
        {
            return clsPersonData.IsPersonAllowedForLicenseClass(personID, licenseClassID, out errorMessage);
        }

        public static DataTable GetAll(out string errorMessage)
            => clsLicenseClassData.GetAll(out errorMessage);

    }
}
