using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    public class clsTestData
    {
        public static bool AddResultRow(int testAppointmentID,
            bool testResult, string notes, int createdByUserID
            , out int testID, out string errorMessage)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "INSERT INTO Tests " +
                        "VALUES (@testAppointmentID, @testResult, @notes, @createdByUserID)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@testAppointmentID", testAppointmentID);
                        command.Parameters.AddWithValue("@testResult", testResult);
                        command.Parameters.AddWithValue("@notes", notes);
                        command.Parameters.AddWithValue("@createdByUserID", createdByUserID);

                        connection.Open();

                        if (command.ExecuteScalar() is object obj && obj != null && obj != DBNull.Value)
                            testID = Convert.ToInt32(obj);
                        else
                            testID = -1;
                    }
                }
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                testID = -1;
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

    }
}
