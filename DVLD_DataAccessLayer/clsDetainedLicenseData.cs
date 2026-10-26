using System;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    public class clsDetainedLicenseData
    {
        public static bool GetDetainedLicenseInfoByLicenseID(
        int licenseID,
        ref int detainID,
        ref DateTime detainDate,
        ref decimal fineFees,
        ref int createdByUserID,
        ref bool isReleased,
        ref DateTime? releaseDate,
        ref int? releasedByUserID,
        ref int? releaseApplicationID,
        out string errorMessage)
        {
            bool isFound = false;
            errorMessage = string.Empty;

            string query = @"SELECT TOP 1 * 
                         FROM DetainedLicenses 
                         WHERE LicenseID = @LicenseID 
                         ORDER BY DetainID DESC;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", licenseID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                detainID = Convert.ToInt32(reader["DetainID"]);
                                detainDate = Convert.ToDateTime(reader["DetainDate"]);
                                fineFees = Convert.ToDecimal(reader["FineFees"]);
                                createdByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                                isReleased = Convert.ToBoolean(reader["IsReleased"]);

                                releaseDate = reader["ReleaseDate"] != DBNull.Value
                                    ? (DateTime?)reader["ReleaseDate"] : null;
                                releasedByUserID = reader["ReleasedByUserID"] != DBNull.Value 
                                    ? (int?)reader["ReleasedByUserID"] : null;
                                releaseApplicationID = reader["ReleaseApplicationID"] != DBNull.Value 
                                    ? (int?)reader["ReleaseApplicationID"] : null;
                            }
                            else
                            {
                                errorMessage = "Detained license record not found for this license ID.";
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

        public static bool IsLicenseDetained(int licenseID, out string errorMessage)
        {
            bool isDetained = false;
            errorMessage = string.Empty;

            string query = @"SELECT 
                        IsDetained = CASE 
                            WHEN IsReleased = 0 THEN 1
                            ELSE 0
                        END 
                     FROM DetainedLicenses 
                     WHERE LicenseID = @LicenseID 
                     ORDER BY DetainID DESC;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", licenseID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            isDetained = Convert.ToBoolean(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        isDetained = false;
                        errorMessage = ex.Message;
                    }
                }
            }

            return isDetained;
        }

        public static int AddNewDetainedLicense(
        int licenseID,
        DateTime detainDate,
        decimal fineFees,
        int createdByUserID,
        out string errorMessage)
        {
            int detainID = -1;
            errorMessage = string.Empty;

            string query = @"INSERT INTO DetainedLicenses 
                         (LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased)
                         VALUES 
                         (@LicenseID, @DetainDate, @FineFees, @CreatedByUserID, 0);
                         SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", licenseID);
                    command.Parameters.AddWithValue("@DetainDate", detainDate);
                    command.Parameters.AddWithValue("@FineFees", fineFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            detainID = insertedID;
                        }
                    }
                    catch (Exception ex)
                    {
                        detainID = -1;
                        errorMessage = ex.Message;
                    }
                }
            }
            
            return detainID;
        }

        public static bool ReleaseDetainedLicense(
            int detainID,
            int releasedByUserID,
            int releaseApplicationID,
            out string errorMessage)
        {
            bool isUpdated = false;
            errorMessage = string.Empty;

            string query = @"UPDATE DetainedLicenses 
                         SET IsReleased = 1,
                             ReleaseDate = @ReleaseDate,
                             ReleasedByUserID = @ReleasedByUserID,
                             ReleaseApplicationID = @ReleaseApplicationID
                         WHERE DetainID = @DetainID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DetainID", detainID);
                    command.Parameters.AddWithValue("@ReleaseDate", DateTime.Now);
                    command.Parameters.AddWithValue("@ReleasedByUserID", releasedByUserID);
                    command.Parameters.AddWithValue("@ReleaseApplicationID", releaseApplicationID);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        isUpdated = (rowsAffected > 0);

                        if (!isUpdated)
                        {
                            errorMessage = "Detained license record not found or update failed.";
                        }
                    }
                    catch (Exception ex)
                    {
                        isUpdated = false;
                        errorMessage = ex.Message;
                    }
                }
            }

            return isUpdated;
        }
    }
}
