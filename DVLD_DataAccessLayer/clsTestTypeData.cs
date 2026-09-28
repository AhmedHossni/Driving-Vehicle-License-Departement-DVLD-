using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    public class clsTestTypeData
    {
        public static bool GetIBy(int id, ref string testTypeTitle,
            ref string testTypeDescription, ref decimal fees, out string errorMessage)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM TestTypes " +
                    "WHERE TestTypeID = @id";

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

                                testTypeTitle = (string)reader["TestTypeTitle"];
                                testTypeDescription = (string)reader["TestTypeDescription"];
                                fees = (decimal)reader["TestTypeFees"];

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

        public static bool Update(int id, string testTypeTitle,
            string testTypeDescription, decimal fees, out string errorMessage)
        {

            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "UPDATE TestTypes " +
                                "SET TestTypeTitle = @testTypeTitle , " +
                                "TestTypeDescription = @testTypeDescription , " +
                                "TestTypeFees = @fees " +
                                "WHERE TestTypeID = @id;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@testTypeTitle", testTypeTitle);
                    command.Parameters.AddWithValue("@testTypeDescription", testTypeDescription);
                    command.Parameters.AddWithValue("@fees", fees);

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
            return rowsAffected > 0;
        }

        public static DataTable GetAll(out string errorMessage)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM TestTypes";

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
    }
}
