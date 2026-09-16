using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    public class clsCountryData
    {
        public static DataTable GetAll(out string errorMessage)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Countries";

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

        public static bool GetBy(int id, ref string countryName, out string errorMessage)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Countries WHERE CountryID = @id";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            countryName = (string)reader["CountryName"];
                        }

                        reader.Close();
                    }
                }

                catch (Exception ex)
                {
                    errorMessage = ex.Message;
                    return false;
                }

            }
            errorMessage = string.Empty;
            return true;
        }

        public static bool GetBy(ref string name, ref int id, out string errorMessage)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT * FROM Countries C
                                    WHERE C.CountryName COLLATE Latin1_General_CI_AI LIKE @name;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                id = (int)reader["CountryID"];
                                name = (string)reader["CountryName"];
                                errorMessage = string.Empty;
                                return true;
                            }
                            else
                            {
                                errorMessage = "Country is not founded!!";
                                id = -1;
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                id = -1;
                errorMessage = ex.Message;
            }

            return false;
        }
    }
}
