using CommonUseThings;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    public class clsTestAppointmentData
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

        public static bool UpdateDate(int testAppointmentID, DateTime appointmentDate,
            out string errorMessage)
        {

            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE TestAppointments set
                                AppointmentDate = @appointmentDate
                                WHERE TestAppointmentID = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", testAppointmentID);
                    command.Parameters.AddWithValue("@appointmentDate", appointmentDate);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                        return false;
                    }
                }
            }

            errorMessage = string.Empty;
            return (rowsAffected > 0);
        }

        public static bool Add(int testTypeID, int localDrivingLicenseID, 
            DateTime appointmentDate, decimal paidFees,
            int createdByUserID,
            out string errorMessage, out int appointemntID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "INSERT INTO TestAppointments VALUES (@testTypeID, @localDrivingLicenseID," +
                        "@appointmentDate, @paidFees, " +
                        "@createdByUserID, @isLocked);" +
                        "SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@testTypeID", testTypeID);
                        command.Parameters.AddWithValue("@localDrivingLicenseID", localDrivingLicenseID);
                        command.Parameters.AddWithValue("@appointmentDate", appointmentDate);
                        command.Parameters.AddWithValue("@paidFees", paidFees);
                        command.Parameters.AddWithValue("@createdByUserID", createdByUserID);
                        command.Parameters.AddWithValue("@isLocked", 0);

                        connection.Open();

                        if (command.ExecuteScalar() is object obj && obj != null && obj != DBNull.Value)
                            appointemntID = Convert.ToInt32(obj);
                        else
                            appointemntID = -1;
                    }
                }
                errorMessage = string.Empty;

                return true;
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                appointemntID = -1;
                return false;
            }
        }

        public static bool LockAppointment(int testAppointmentID,
            out string errorMessage)
        {

            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE TestAppointments set
                                IsLocked = 1
                                WHERE TestAppointmentID = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", testAppointmentID);
                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                        return false;
                    }
                }
            }

            errorMessage = string.Empty;
            return (rowsAffected > 0);
        }

        public static bool GetTestAppointmentDetails(
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
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM dbo.GetTestAppointmentDetails(@TestAppointmentID);";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                localDLAppId = (int)reader["LocalDLAppId"];
                                className = reader["ClassName"].ToString();
                                fullName = reader["Full Name"].ToString();
                                trials = (int)reader["Trials"];
                                date = (DateTime)reader["Date"];
                                testTypeFees = Convert.ToDecimal(reader["TestTypeFees"]);

                                rtAppID = reader["RTAppID"] == DBNull.Value ? (int?)null : (int)reader["RTAppID"];
                                rtFees = Convert.ToDecimal(reader["RTFees"]);
                                isLocked = Convert.ToBoolean(reader["IsLocked"]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                        isFound = false;
                    }
                }
            }

            return isFound;
        }

        public static bool GetBy(int testAppointmentID, ref enTestTypes testTypes, ref int localDLAppID, 
            ref DateTime appointmentDate, ref decimal paidFees, ref int createdByUserID, 
            ref bool isLocked, out string errorMessage)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT * FROM TestAppointments WHERE TestAppointmentID = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", testAppointmentID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                isFound = true;

                                testTypes = (enTestTypes)reader["TestTypeID"];
                                localDLAppID = (int)reader["LocalDrivingLicenseApplicationID"];
                                appointmentDate = (DateTime)reader["AppointmentDate"];
                                paidFees = Convert.ToDecimal(reader["PaidFees"]);
                                createdByUserID = (int)reader["CreatedByUserID"];
                                isLocked = Convert.ToBoolean(reader["DateOfBirth"]);
                            }
                            else
                            {
                                // The record was not found
                                isFound = false;
                            }
                        }

                        errorMessage = string.Empty;
                    }
                    catch (Exception ex)
                    {
                        isFound = false;
                        errorMessage = ex.Message;
                    }

                    return isFound;
                }
            }
        }

        public static DataTable GetAllPersonTestAppointmentsBy(int localDLAppID, enTestTypes testTypes
            , out string errorMessage)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT * FROM TestAppointments 
WHERE LocalDrivingLicenseApplicationID = @localDLAppID AND TestTypeID = @testTypes;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@localDLAppID", localDLAppID);
                    command.Parameters.AddWithValue("@testTypes", testTypes);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                dataTable.Load(reader);
                            else
                                dataTable = null;
                        }

                        errorMessage = string.Empty;
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                    }

                    return dataTable;
                }
            }
        }     
    }
}
