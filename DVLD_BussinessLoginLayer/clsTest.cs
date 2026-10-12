using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLogicLayer
{
    public class clsTest
    {
        public static bool AddResultRow(int testAppointmentID,
            bool testResult, string notes, int createdByUserID,
            out int testID, out string errorMessage)
        {
            return clsTestData.AddResultRow(testAppointmentID,
                testResult, notes, createdByUserID , out testID, out errorMessage);
        }
    }
}
