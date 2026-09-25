using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    public class clsApplicationTypeData
    {
        public static bool GetIBy(int id, ref string appicationTitle, ref decimal fees, out string errorMessage)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM ApplicationTypes " +
                    "WHERE ApplicationTypeID = @id";

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

                                appicationTitle = (string)reader["AppicationTitle"];
                                fees = (decimal)reader["ApplicationFees"];

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

        public static bool Update(int id, string appicationTitle, decimal fees, out string errorMessage)
        {

            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "UPDATE ApplicationTypes" +
                                "SET ApplicationTypeTitle = @title," +
                                "ApplicationFees = @fees" +
                                "WHERE ApplicationTypeID = @id;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@title", appicationTitle);
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

            string query = "SELECT * FROM ApplicationTypes";

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
