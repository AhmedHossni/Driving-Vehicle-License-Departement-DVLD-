using CommonUseThings;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    public static class clsLocalDrivingLicenseApplicationData
    {
        public static DataTable GetAll(out string errorMessage)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string query = "SELECT * FROM LocalDrivingLicenseApplications";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();

                            if (reader.HasRows)
                                dataTable.Load(reader);

                            errorMessage = string.Empty;

                            return dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            return null;
            
        }

        public static DataTable GetAllDataForFormDGV(out string errorMessage)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string query = "SELECT * FROM LocalDrivingLicenseAppicationListDetails";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();

                            if (reader.HasRows)
                                dataTable.Load(reader);

                            errorMessage = string.Empty;

                            return dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            return null;
            
        }

        public static bool Add(int applicationID, int licenseClassID,
            out string errorMessage, out int localDrivingLicenseApplicationID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "INSERT INTO LocalDrivingLicenseApplications " +
                        "VALUES (@applicationID, @licenseClassID); " +
                        "SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@applicationID", applicationID);

                        command.Parameters.AddWithValue("@licenseClassID", licenseClassID);

                        connection.Open();

                        if (command.ExecuteScalar() is object obj && obj != null && obj != DBNull.Value)
                            localDrivingLicenseApplicationID = Convert.ToInt32(obj);
                        else
                            localDrivingLicenseApplicationID = -1;
                    }
                }
                errorMessage = string.Empty;

                return true;
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                localDrivingLicenseApplicationID = -1;
                return false;
            }
        }

        public static bool GetBy(int id, ref int applicationID, ref int licenseClassID,
            out string errorMessage)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM LocalDrivingLicenseApplications WHERE " +
                                "LocalDrivingLicenseApplicationID = @id;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                isFound = true;

                                applicationID = (int)reader["ApplicationID"];
                                licenseClassID = (int)reader["LicenseClassID"];
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

        public static bool GetBasicInfoBy(int localDLAppId, ref string appliedForLicense,
            ref int passedTests, out string errorMessage)
        {
            bool isFound = false;
            errorMessage = string.Empty;

            appliedForLicense = string.Empty;
            passedTests = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM dbo.GetLocalDrivingLicenseAppBasicDetails(@LocalDrivingLicenseApplicationID)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDLAppId);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                appliedForLicense = reader["Driving Class"] != DBNull.Value
                                    ? (string)reader["Driving Class"] : string.Empty;

                                passedTests = reader["Passed Tests"] != DBNull.Value
                                    ? Convert.ToInt32(reader["Passed Tests"]) : 0;
                            }
                            else
                            {
                                isFound = false;
                            }
                        }
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

        public static bool GetDrivingLicenseAppScheduleTestInfo(
            int localDrivingLicenseApplicationID,
            enTestTypes testType,
            ref string className,
            ref string fullName,
            ref decimal fees,
            ref int trials,
            out string errorMessage)
        {
            errorMessage = string.Empty;
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT *
FROM GetDrivingLicenseAppScheduleTestInfo(@LocalDrivingLicenseApplicationID,@TestTypeID);";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", 
                        localDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TestTypeID", (int)testType);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                className = reader["ClassName"].ToString();
                                fees = Convert.ToDecimal(reader["Fees"]);
                                fullName = Convert.ToString(reader["Full Name"]);
                                trials = Convert.ToInt32(reader["Trials"]);
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

        public static bool Update(int id, int applicationID, int licenseClassID,
            out string errorMessage)
        {

            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"Update [LocalDrivingLicenseApplications] SET
                                [ApplicationID] = @applicationID,
                                [LicenseClassID] = @licenseClassID
                                WHERE [LocalDrivingLicenseApplicationID] = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@applicationID", applicationID);
                    command.Parameters.AddWithValue("@licenseClassID", licenseClassID);

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
        public static bool UpdateStatus(int id, int applicationID, int licenseClassID,
            out string errorMessage)
        {

            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"Update [LocalDrivingLicenseApplications] SET
                                [ApplicationID] = @applicationID,
                                [LicenseClassID] = @licenseClassID
                                WHERE [LocalDrivingLicenseApplicationID] = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@applicationID", applicationID);
                    command.Parameters.AddWithValue("@licenseClassID", licenseClassID);

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

        public static bool Delete(int id, out string errorMessage)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"DELETE LocalDrivingLicenseApplications WHERE localDrivingLicenseApplicationID = @id";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", id);

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

            errorMessage = string.Empty;
            return (rowsAffected > 0);

        }
    }
}
