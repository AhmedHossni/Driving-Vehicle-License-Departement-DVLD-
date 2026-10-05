using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsTestAppointmentsData
    {
        public static bool DidExamineePass(int localDLAppID, 
            int testTypeId, out string errorMessage)
        {
            errorMessage = string.Empty;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT CASE
                                WHEN EXISTS (SELECT * FROM TestAppointments TA
                                            INNER JOIN Tests T ON TA.TestAppointmentID = T.TestAppointmentID
                                            WHERE LocalDrivingLicenseApplicationID = @localDLAppID
                                            AND @testTypeId = 1 AND IsLocked = 1 AND TestResult = 1)
                                THEN 1
                                ELSE 0 
                                END AS Result;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@localDLAppID", localDLAppID);
                    command.Parameters.AddWithValue("@testTypeId", testTypeId);

                    try
                    {
                        connection.Open();

                        object result =  command.ExecuteScalar();

                        return Convert.ToInt32(result) == 1;
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                        return false;
                    }
                }
            }
        }
    }
}
