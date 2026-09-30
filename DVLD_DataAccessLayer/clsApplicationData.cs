using CommonUseThings;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    public static class clsApplicationData
    {
        public static bool Add(int personId, DateTime applicationDate, 
            int applicationTypeId, DateTime lastStatusUpdate,
            decimal paidFees, int createdByUserId, 
            out string errorMessage, out int applicationId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "INSERT INTO [Applications] VALUES " +
                        "(@personId, @applicationDate, " +
                        "@applicationTypeId, @applicationStatus, " +
                        "@lastStatusUpdateDate, @paidFees, @createdByUserId) " +
                        "SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@personId", personId);
                        command.Parameters.AddWithValue("@applicationDate", applicationDate);
                        command.Parameters.AddWithValue("@applicationTypeId", applicationTypeId);
                        command.Parameters.AddWithValue("@applicationStatus", (int)enApplicationStatus.New);

                        command.Parameters.AddWithValue("@lastStatusUpdate", lastStatusUpdate);
                        command.Parameters.AddWithValue("@paidFees", paidFees);
                        command.Parameters.AddWithValue("@createdByUserId", createdByUserId);

                        connection.Open();

                        if (command.ExecuteScalar() is object obj &&
                            obj != null &&
                            obj != DBNull.Value)
                            applicationId = Convert.ToInt32(obj);
                        else
                            applicationId = -1;
                    }
                }
                errorMessage = string.Empty;

                return true;
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                applicationId = -1;
                return false;
            }
        }

        public static bool GetBy(int id, ref int personId, ref DateTime applicationDate, ref enApplicationTypes applicationTypeId, 
            ref enApplicationStatus applicationStatus, ref DateTime lastStatusUpdate, ref decimal paidFees, ref int createdByUserId
            , out string errorMessage)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Applications WHERE AppicationID = @id";

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

                                personId = (int)reader["PersonID"];
                                applicationDate = (DateTime)reader["ApplicationDate"];
                                applicationTypeId = (enApplicationTypes)reader["ApplicationTypeId"];
                                applicationStatus = (enApplicationStatus)reader["ApplicationStatus"];

                                lastStatusUpdate = (DateTime)reader["LastStatusUpdate"];
                                paidFees = (decimal)reader["PaidFees"];
                                createdByUserId = (int)reader["CreatedByUserId"];
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

        public static bool Update(int id, ref int personId, ref enApplicationTypes applicationTypeId,
            ref enApplicationStatus applicationStatus, ref DateTime lastStatusUpdate,
            ref decimal paidFees
            , out string errorMessage)
        {

            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE [dbo].[Applications]
                                   SET [ApplicantPersonID] = @personId
                                      ,[ApplicationTypeID] = @applicationTypeId
                                      ,[ApplicationStatus] = @applicationStatus
                                      ,[LastStatusDate] = @lastStatusUpdate
                                      ,[PaidFees] = @paidFees
                                 WHERE ApplicatioID = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@personId", personId);
                    command.Parameters.AddWithValue("@applicationTypeId", (int)applicationTypeId);
                    command.Parameters.AddWithValue("@applicationStatus", (int)applicationStatus);

                    command.Parameters.AddWithValue("@lastStatusUpdate", lastStatusUpdate);
                    command.Parameters.AddWithValue("@paidFees", paidFees);

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

        public static DataTable GetAll(out string errorMessage)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Application";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dt.Load(reader);
                        }

                        reader.Close();
                    }
                }

                catch (Exception ex)
                {
                    errorMessage = ex.Message;
                }

            }
            errorMessage = string.Empty;
            return dt;
        }

        public static bool Delete(int id, out string errorMessage)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"Delete Application where ApplicationID = @id";

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

        public static bool IsPersonHaveAllreadySameOpenApplication(int personId, 
            enApplicationTypes applicationTypeId, out string errorMessage)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT Found = 1 FROM Users WHERE " +
                    "ApplicationPersonID = @personId AND " +
                    "ApplicationTypeID == @applicationTypeID AND " +
                    "ApplicationStatus = @applicaionStatus";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@personId", personId);
                    command.Parameters.AddWithValue("@applicationTypeID", applicationTypeId);
                    command.Parameters.AddWithValue("@applicaionStatus", enApplicationStatus.New);

                    try
                    {
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        isFound = reader.HasRows;

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                        isFound = false;
                    }
                }
            }

            errorMessage = string.Empty;
            return isFound;
        }
    }
}
