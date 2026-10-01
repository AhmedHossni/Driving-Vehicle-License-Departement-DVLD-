using DVLD_DataAccessLayer;
using System.Data;


namespace DVLD_BusinessLogicLayer
{
    public class clsLicenseClass
    {

        public static DataTable GetAll(out string errorMessage)
            => clsLicenseClassData.GetAll(out errorMessage);

    }
}
