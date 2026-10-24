using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    public class clsLicenseClassData
    {
        public static bool GetLicenseClassInfoByID(
        int licenseClassID,
        ref string className,
        ref string classDescription,
        ref byte minimumAllowedAge,
        ref byte defaultValidityLength,
        ref decimal classFees,
        out string errorMessage)
        {
            bool isFound = false;
            errorMessage = string.Empty;

            string query = @"SELECT 
                            LicenseClassID,
                            ClassName,
                            ClassDescription,
                            MinimumAllowedAge,
                            DefaultValidityLength,
                            ClassFees
                         FROM LicenseClasses 
                         WHERE LicenseClassID = @LicenseClassID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseClassID", licenseClassID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                className = reader["ClassName"] != DBNull.Value ? (string)reader["ClassName"] : string.Empty;
                                classDescription = reader["ClassDescription"] != DBNull.Value ? (string)reader["ClassDescription"] : string.Empty;
                                minimumAllowedAge = reader["MinimumAllowedAge"] != DBNull.Value ? Convert.ToByte(reader["MinimumAllowedAge"]) : (byte)0;
                                defaultValidityLength = reader["DefaultValidityLength"] != DBNull.Value ? Convert.ToByte(reader["DefaultValidityLength"]) : (byte)0;
                                classFees = reader["ClassFees"] != DBNull.Value ? Convert.ToDecimal(reader["ClassFees"]) : 0;
                            }
                            else
                            {
                                errorMessage = "License Class not found.";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        isFound = false;
                        errorMessage = ex.Message;
                    }
                }
            }

            return isFound;
        }

        public static DataTable GetAll(out string errorMessage)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM LicenseClasses";

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
