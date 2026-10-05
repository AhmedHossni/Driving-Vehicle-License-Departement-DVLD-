using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLogicLayer
{
    public class clsTestAppointments
    {
        
        public static bool DidExamineePass(int localDLAppId, int testTypeId,
            out string errorMessage)
        {
            return clsTestAppointmentsData.DidExamineePass(localDLAppId, testTypeId, out errorMessage);
        }
    }
}
