using System;
using System.Data;
using System.Data.SqlClient;


namespace DVLD_DataAccessLayer
{
    public class clsInternationalLicenseData
    {
        public static DataTable GetInternationalLicensesByDriverID(int driverID,
            out string errorMessage)
        {
            DataTable dt = new DataTable();
            errorMessage = string.Empty;

            string query = @"
            SELECT 
                IL.InternationalLicenseID AS [Int.License ID],
                IL.ApplicationID AS [Application ID],
                IL.IssuedUsingLocalLicenseID AS [Issue Date],
                IL.IssueDate AS [Issue Date],
                IL.ExpirationDate AS [Expiration Date],
                IL.IsActive AS [Is Active]
            FROM InternationalLicenses IL
            WHERE IL.DriverID = @driverID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@driverID", driverID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                dt.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                    }
                }
            }

            return dt;
        }

        public static DataTable GetInternationalLicensesByNationalNo
            (string nationalNo, out string errorMessage)
        {
            DataTable dt = new DataTable();
            errorMessage = string.Empty;

            string query = @"
            SELECT 
                IL.InternationalLicenseID AS [Int.License ID],
                IL.ApplicationID AS [Application ID],
                IL.IssuedUsingLocalLicenseID AS [Issue Date],
                IL.IssueDate AS [Issue Date],
                IL.ExpirationDate AS [Expiration Date],
                IL.IsActive AS [Is Active]
            FROM InternationalLicenses IL
            INNER JOIN Applications Apps
                ON IL.ApplicationID = Apps.ApplicationID
            INNER JOIN LocalDrivingLicenseApplications LDLApps 
                ON IL.IssuedUsingLocalLicenseID = LDLApps.LocalDrivingLicenseApplicationID
            INNER JOIN People P 
                ON Apps.ApplicationPersonID = P.PersonID
            WHERE P.NationalNo LIKE @nationalNo;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nationalNo", nationalNo);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                dt.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                    }
                }
            }

            return dt;
        }

        public static bool AddNewInternationalLicense(
            int applicationID,
            int driverID,
            int issuedUsingLocalLicenseID,
            DateTime issueDate,
            DateTime expirationDate,
            bool isActive,
            int createdByUserID,
            ref int internationalLicenseID,
            out string errorMessage)
        {
            bool isInserted = false;
            errorMessage = string.Empty;

            string query = @"
            INSERT INTO [dbo].[InternationalLicenses] (
                [ApplicationID],
                [DriverID],
                [IssuedUsingLocalLicenseID],
                [IssueDate],
                [ExpirationDate],
                [IsActive],
                [CreatedByUserID]
            )
            VALUES (
                @ApplicationID,
                @DriverID,
                @IssuedUsingLocalLicenseID,
                @IssueDate,
                @ExpirationDate,
                @IsActive,
                @CreatedByUserID
            );
            SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", applicationID);
                    command.Parameters.AddWithValue("@DriverID", driverID);
                    command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", issuedUsingLocalLicenseID);
                    command.Parameters.AddWithValue("@IssueDate", issueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", expirationDate);
                    command.Parameters.AddWithValue("@IsActive", isActive);
                    command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            internationalLicenseID = insertedID; 
                            isInserted = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                        isInserted = false;
                    }
                }
            }

            return isInserted;
        }
    }
}
