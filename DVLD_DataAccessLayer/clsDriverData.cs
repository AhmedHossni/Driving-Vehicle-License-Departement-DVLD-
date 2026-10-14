using System;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    public class clsDriverData
    {
        public static bool GetDriverInfoByDriverID(
            int driverID,
            ref int personID,
            ref int createdByUserID,
            ref DateTime createdDate,
            out string errorMessage)
        {
            bool isFound = false;
            errorMessage = string.Empty;
            string query = "SELECT * FROM Drivers WHERE DriverID = @DriverID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DriverID", driverID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                personID = (int)reader["PersonID"];
                                createdByUserID = (int)reader["CreatedByUserID"];
                                createdDate = (DateTime)reader["CreatedDate"];
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
        public static bool GetDriverInfoByPersonID(
            int personID,
            ref int driverID,
            ref int createdByUserID,
            ref DateTime createdDate,
            out string errorMessage)
        {
            bool isFound = false;
            errorMessage = string.Empty;
            string query = "SELECT * FROM Drivers WHERE PersonID = @PersonID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", personID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                driverID = (int)reader["DriverID"];
                                createdByUserID = (int)reader["CreatedByUserID"];
                                createdDate = (DateTime)reader["CreatedDate"];
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

        public static int AddNewDriver(
            int personID,
            int createdByUserID,
            out string errorMessage)
        {
            int driverID = -1;
            errorMessage = string.Empty;
            string query = @"INSERT INTO Drivers (PersonID, CreatedByUserID, CreatedDate)
                         VALUES (@PersonID, @CreatedByUserID, GETDATE());
                         SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", personID);
                    command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            driverID = insertedID;
                        }
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                        driverID = -1;
                    }
                }
            }
            return driverID;
        }
        public static bool UpdateDriver(
            int driverID,
            int personID,
            int createdByUserID,
            out string errorMessage)
        {
            int rowsAffected = 0;
            errorMessage = string.Empty;
            string query = @"UPDATE Drivers 
                         SET PersonID = @PersonID, 
                             CreatedByUserID = @CreatedByUserID 
                         WHERE DriverID = @DriverID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DriverID", driverID);
                    command.Parameters.AddWithValue("@PersonID", personID);
                    command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                        rowsAffected = 0;
                    }
                }
            }
            return (rowsAffected > 0);
        }

        public static bool DeleteDriver(int driverID, out string errorMessage)
        {
            int rowsAffected = 0;
            errorMessage = string.Empty;
            string query = "DELETE FROM Drivers WHERE DriverID = @DriverID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DriverID", driverID);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                        rowsAffected = 0;
                    }
                }
            }
            return (rowsAffected > 0);
        }
    }
}
