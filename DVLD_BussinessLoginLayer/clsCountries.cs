using DVLD_DataAccessLayer;
using System.Data;

namespace DVLD_BusinessLogicLayer
{
    public class clsCountries
    {
        public static DataTable GetAll(out string errorMessage) 
            => clsCountryData.GetAll(out errorMessage);

        public static bool GetBy(int id, ref string countryName, out string errorMessage)
            => clsCountryData.GetBy(id, ref countryName, out errorMessage);

        public static bool GetBy(string countryName, ref int id, out string errorMessage)
            => clsCountryData.GetBy(ref countryName, ref id, out errorMessage);
    }
}
