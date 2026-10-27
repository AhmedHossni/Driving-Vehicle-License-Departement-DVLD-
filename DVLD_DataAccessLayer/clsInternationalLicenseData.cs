using System;
using System.Data;
using System.Data.SqlClient;


namespace DVLD_DataAccessLayer
{
    public class clsInternationalLicenseData
    {

        public static DataTable GetAllInternationalLicenses(out string errorMessage)
        {
            errorMessage = string.Empty;
            DataTable dt = new DataTable();

            string query = @"SELECT
                                ILs.InternationalLicenseID,
                                ILs.ApplicationID,
                                ILs.DriverID,
                                ILs.IssuedUsingLocalLicenseID,
                                ILs.IssueDate,
    	                        ILs.ExpirationDate,
                                ILs.IsActive,
                                D.PersonID 
                            FROM InternationalLicenses ILs
                            INNER JOIN Drivers D
                                ON ILs.DriverID = D.DriverID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
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

        public static bool GetInternationalLicenseInfoByID(
        int internationalLicenseID,
        ref int applicationID,
        ref int driverID,
        ref int issuedUsingLocalLicenseID,
        ref DateTime issueDate,
        ref DateTime expirationDate,
        ref bool isActive,
        ref string fullName,
        ref string nationalNo,
        ref string gender,
        ref DateTime dateOfBirth,
        ref string imageName,
        out string errorMessage)
        {
            bool isFound = false;
            errorMessage = string.Empty;

            string query = @"SELECT
                            CONCAT(P.FirstName, ' ', P.SecondName, ' ', P.ThirdName, ' ', P.LastName) AS [Fullname],
                            ILs.InternationalLicenseID,
                            ILs.IssuedUsingLocalLicenseID,
                            P.NationalNo,
                            CASE P.Gender
                                WHEN 0 THEN 'Male'
                                ELSE 'Female'
                            END AS Gender,
                            ILs.IssueDate,
                            ILs.ApplicationID,
                            ILs.IsActive,
                            P.DateOfBirth,
                            ILs.DriverID,
                            ILs.ExpirationDate,
                            P.ImagePath
                        FROM InternationalLicenses ILs
                        INNER JOIN Applications APPs 
                            ON ILs.ApplicationID = APPs.ApplicationID
                        INNER JOIN People P 
                            ON APPs.ApplicationPersonID = P.PersonID
                        WHERE ILs.InternationalLicenseID = @InternationalLicenseID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@InternationalLicenseID", internationalLicenseID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                fullName = reader["Fullname"] != DBNull.Value ? (string)reader["Fullname"] : "";
                                internationalLicenseID = (int)reader["InternationalLicenseID"];
                                issuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                                nationalNo = reader["NationalNo"] != DBNull.Value ? (string)reader["NationalNo"] : "";
                                gender = reader["Gender"] != DBNull.Value ? (string)reader["Gender"] : "";
                                issueDate = (DateTime)reader["IssueDate"];
                                applicationID = (int)reader["ApplicationID"];
                                isActive = (bool)reader["IsActive"];
                                dateOfBirth = (DateTime)reader["DateOfBirth"];
                                driverID = (int)reader["DriverID"];
                                expirationDate = (DateTime)reader["ExpirationDate"];

                                object imgPathObject = reader["ImagePath"];

                                imageName = imgPathObject != DBNull.Value ?
                                    (string)imgPathObject : string.Empty;
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

        public static bool GetInternationalLicenseInfoByDriverID(
            int driverID,
            out int internationalLicenseID,
            out int applicationID,
            out int issuedUsingLocalLicenseID,
            out DateTime issueDate,
            out DateTime expirationDate,
            out bool isActive,
            out int createdByUserID,
            out string errorMessage)
        {
            bool isFound = false;

            internationalLicenseID = -1;
            applicationID = -1;
            issuedUsingLocalLicenseID = -1;
            issueDate = DateTime.MinValue;
            expirationDate = DateTime.MinValue;
            isActive = false;
            createdByUserID = -1;
            errorMessage = string.Empty;

            string query = @"
            SELECT TOP 1 
                IL.InternationalLicenseID,
                IL.ApplicationID,
                IL.IssuedUsingLocalLicenseID,
                IL.IssueDate,
                IL.ExpirationDate,
                IL.IsActive,
                IL.CreatedByUserID
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
                            if (reader.Read())
                            {
                                isFound = true;
                                internationalLicenseID = (int)reader["InternationalLicenseID"];
                                applicationID = (int)reader["ApplicationID"];
                                issuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                                issueDate = (DateTime)reader["IssueDate"];
                                expirationDate = (DateTime)reader["ExpirationDate"];
                                isActive = (bool)reader["IsActive"];
                                createdByUserID = (int)reader["CreatedByUserID"];
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

        public static bool GetInternationalLicenseIDInfoByDriverID(
            int driverID,
            out int internationalLicenseID,
            out string errorMessage)
        {
            bool isFound = false;

            internationalLicenseID = -1;
            errorMessage = string.Empty;

            string query = @"
            SELECT TOP 1 
                IL.InternationalLicenseID
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
                            if (reader.Read())
                            {
                                isFound = true;
                                internationalLicenseID = (int)reader["InternationalLicenseID"];
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

        public static bool GetInternationalLicenseInfoByNationalNo(
            string nationalNo,
            out int internationalLicenseID,
            out int applicationID,
            out int driverID,
            out int issuedUsingLocalLicenseID,
            out DateTime issueDate,
            out DateTime expirationDate,
            out bool isActive,
            out int createdByUserID,
            out string errorMessage)
        {
            bool isFound = false;

            internationalLicenseID = -1;
            applicationID = -1;
            driverID = -1;
            issuedUsingLocalLicenseID = -1;
            issueDate = DateTime.MinValue;
            expirationDate = DateTime.MinValue;
            isActive = false;
            createdByUserID = -1;
            errorMessage = string.Empty;

            string query = @"
            SELECT TOP 1 
                IL.InternationalLicenseID,
                IL.ApplicationID,
                IL.DriverID,
                IL.IssuedUsingLocalLicenseID,
                IL.IssueDate,
                IL.ExpirationDate,
                IL.IsActive,
                IL.CreatedByUserID
            FROM InternationalLicenses IL
            INNER JOIN Applications Apps
                ON IL.ApplicationID = Apps.ApplicationID
            INNER JOIN LocalDrivingLicenseApplications LDLApps 
                ON IL.IssuedUsingLocalLicenseID = LDLApps.LocalDrivingLicenseApplicationID
            INNER JOIN People P 
                ON Apps.ApplicationPersonID = P.PersonID
            WHERE P.NationalNo = @nationalNo;";

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
                            if (reader.Read())
                            {
                                isFound = true;
                                internationalLicenseID = (int)reader["InternationalLicenseID"];
                                applicationID = (int)reader["ApplicationID"];
                                driverID = (int)reader["DriverID"];
                                issuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                                issueDate = (DateTime)reader["IssueDate"];
                                expirationDate = (DateTime)reader["ExpirationDate"];
                                isActive = (bool)reader["IsActive"];
                                createdByUserID = (int)reader["CreatedByUserID"];
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

        public static bool IsInternationalLicenseExistByDriverID(int driverID, out string errorMessage)
        {
            bool isExists = false;
            errorMessage = string.Empty;

            string query = "SELECT Found = 1 FROM InternationalLicenses WHERE DriverID = @driverID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@driverID", driverID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            isExists = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                        isExists = false;
                    }
                }
            }

            return isExists;
        }

        public static bool IsInternationalLicenseExistByNationalNo(string nationalNo, out string errorMessage)
        {
            bool isExists = false;
            errorMessage = string.Empty;

            string query = @"
        SELECT TOP 1 1 
        FROM InternationalLicenses IL
        INNER JOIN Applications Apps
            ON IL.ApplicationID = Apps.ApplicationID
        INNER JOIN People P 
            ON Apps.ApplicationPersonID = P.PersonID
        WHERE P.NationalNo = @nationalNo;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nationalNo", nationalNo);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            isExists = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                        isExists = false;
                    }
                }
            }

            return isExists;
        }

        public static DataTable GetInternationalLicensesByDriverID(
            int driverID,
            out string errorMessage)
        {
            DataTable dt = new DataTable();
            errorMessage = string.Empty;

            string query = @"
        SELECT 
            IL.InternationalLicenseID AS [Int.License ID],
            IL.ApplicationID AS [Application ID],
            IL.IssuedUsingLocalLicenseID AS [Local License ID],
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
                            {
                                dt.Load(reader);
                            }
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

        public static DataTable GetInternationalLicensesByNationalNo(
            string nationalNo,
            out string errorMessage)
        {
            DataTable dt = new DataTable();
            errorMessage = string.Empty;

            string query = @"
        SELECT 
            IL.InternationalLicenseID AS [Int.License ID],
            IL.ApplicationID AS [Application ID],
            IL.IssuedUsingLocalLicenseID AS [Local License ID],
            IL.IssueDate AS [Issue Date],
            IL.ExpirationDate AS [Expiration Date],
            IL.IsActive AS [Is Active]
        FROM InternationalLicenses IL
        INNER JOIN Applications Apps
            ON IL.ApplicationID = Apps.ApplicationID
        INNER JOIN People P 
            ON Apps.ApplicationPersonID = P.PersonID
        WHERE P.NationalNo = @nationalNo;";

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
                            {
                                dt.Load(reader);
                            }
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
