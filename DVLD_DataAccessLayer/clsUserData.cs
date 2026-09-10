using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsUserData
    {
        public enum enGettingUserResult { eError, eUserNotFounded, eUserFounded}

        public static bool Add(string username, string password, int personId, bool isActive, 
            out string errorMessage, out int userId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "INSERT INTO Users VALUES (@personId,@username,@password,@isActive)" +
                        "SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("personId", personId);
                        command.Parameters.AddWithValue("username", username);
                        command.Parameters.AddWithValue("password", password);
                        command.Parameters.AddWithValue("isActive", isActive);

                        connection.Open();

                        if( command.ExecuteScalar() is object obj && obj != null && obj != DBNull.Value)
                            userId = (int)obj;
                        else 
                            userId = -1;
                    }
                }
                errorMessage = string.Empty;

                return true;
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                userId = -1;
                return false;
            }
        }

        public static bool GetInfoByUserId(int id, ref int personId,
            ref string username, ref string password, ref bool isActive
            , out string errorMessage)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Users WHERE UserID = @id";

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

                                username = (string)reader["UserName"];
                                password = (string)reader["Password"]; 
                                personId = (int)reader["PersonID"];
                                isActive = (bool)reader["IsActive"];
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
        public static enGettingUserResult GetInfoByUsername(string username, ref int userId,
            ref int personId, ref string password, ref bool isActive
            , out string errorMessage)
        {
            enGettingUserResult result;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Users WHERE UserName = @username";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                userId = (int)reader["UserID"];
                                personId = (int)reader["PersonID"];
                                username = (string)reader["UserName"];
                                password = (string)reader["Password"];
                                isActive = (bool)reader["IsActive"];

                                result = enGettingUserResult.eUserFounded;
                            }
                            else
                            {
                                result = enGettingUserResult.eUserNotFounded;
                            }

                        }

                    }
                    catch (Exception ex)
                    {
                        result = enGettingUserResult.eError;
                        errorMessage = ex.Message;
                        return result;
                    }
                    
                    errorMessage = string.Empty;

                    return result;
                }
            }
        }

        public static bool Update(int id, string username, string password, bool isActive
            , out string errorMessage)
        {

            int rowsAffected = 0;
            using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"Update Users
                            set UserName = @username, 
                                Password = @password, 
                                IsActive = @isActive
                                where UserID = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@isActive", isActive);

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

            string query = "SELECT * FROM Users";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();

                    using(SqlDataReader reader = command.ExecuteReader())
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

            using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"Delete Users where UserID = @id";

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
                }
            }

            errorMessage = string.Empty;
            return (rowsAffected > 0);

        }

        public static bool IsExistByUserId(int UserId, out string errorMessage)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT Found = 1 FROM Users WHERE UserID = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", UserId);

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
        public static bool IsExistByPersonId(int personId, out string errorMessage)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT Found = 1 FROM Users WHERE PersonID = @personId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@personId", personId);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            isFound = reader.HasRows;
                            reader.Close();
                        }
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

        public static bool IsExistByUsername(string username, out string errorMessage)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT Found = 1 FROM Users WHERE UserName = @username";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            isFound = reader.HasRows;
                            reader.Close();
                        }
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
