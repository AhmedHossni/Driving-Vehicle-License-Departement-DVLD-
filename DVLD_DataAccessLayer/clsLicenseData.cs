using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    public class clsLicenseData
    {
        //public static void GetByApplicationId(int applicationID,
        //    out string errorMessage)
        //{
        //    bool isFound = false;

        //    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        //    {
        //        string query = "SELECT TOP 1 * FROM Licenses WHERE ApplicationID = @applicationID;";

        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@applicationID", applicationID);

        //            try
        //            {
        //                connection.Open();
        //                using (SqlDataReader reader = command.ExecuteReader())
        //                {
        //                    if (reader.Read())
        //                    {
        //                        // The record was found
        //                        isFound = true;

        //                        firstName = (string)reader["FirstName"];
        //                        secondName = (string)reader["SecondName"];
        //                        thirdName = (string)reader["ThirdName"];
        //                        lastName = (string)reader["LastName"];
        //                        nationalNo = (string)reader["NationalNo"];

        //                        dateOfBirth = (DateTime)reader["DateOfBirth"];

        //                        gender = (string)reader["Gender"] == "Male" ?
        //                            enPersonGender.Male : enPersonGender.Female;

        //                        address = (string)reader["Address"];
        //                        phone = (string)reader["Phone"];
        //                        email = (string)reader["Email"];
        //                        nationalityCountryId = (int)reader["NationalityCountryId"];
        //                        countryName = (string)reader["countryName"];

        //                        object imgPathObject = reader["ImagePath"];

        //                        imagePath = imgPathObject != DBNull.Value ?
        //                            (string)imgPathObject : string.Empty;

        //                    }
        //                    else
        //                    {
        //                        // The record was not found
        //                        isFound = false;
        //                    }
        //                }

        //                errorMessage = string.Empty;
        //            }
        //            catch (Exception ex)
        //            {
        //                isFound = false;
        //                errorMessage = ex.Message;
        //            }

        //            return isFound;
        //        }
        //    }
        //}

        public static bool GetLicenseInfoByID(
        int licenseID,
        ref int applicationID,
        ref int localDrivingLicenseApplicationID,
        ref int licenseClass,
        ref int driverID,
        ref bool isActive,
        ref int personID,
        out string errorMessage)
        {
            bool isFound = false;
            errorMessage = string.Empty;

            string query = @"
            SELECT 
                L.LicenseID,
                L.ApplicationID,
                LDLApps.LocalDrivingLicenseApplicationID,
                L.LicenseClass,
                L.DriverID,
                L.IsActive,
                P.PersonID
            FROM Licenses L
            INNER JOIN LocalDrivingLicenseApplications LDLApps 
                ON L.ApplicationID = LDLApps.ApplicationID
            INNER JOIN Applications Apps 
                ON LDLApps.ApplicationID = Apps.ApplicationID
            INNER JOIN People P 
                ON Apps.ApplicationPersonID = P.PersonID
            WHERE L.LicenseID = @LicenseID;";

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

                                applicationID = (int)reader["ApplicationID"];
                                localDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                                licenseClass = (int)reader["LicenseClass"];
                                driverID = (int)reader["DriverID"];
                                isActive = (bool)reader["IsActive"];
                                personID = (int)reader["PersonID"];
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

        public static bool IsThisLDLAppHaveLocalDrivingLicense(int localDLAppID,
            out string errorMessage)
        {
            errorMessage = string.Empty;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT dbo.IsThisLDLAppHaveLocalDrivingIssue(@localDLAppID) AS Result;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@localDLAppID", localDLAppID);

                    try
                    {
                        connection.Open();

                        object result 
                            = command.ExecuteScalar();

                        return Convert.ToInt32(result) == 1;
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;

                        return false;
                    }
                }
            }
        }

        public static DataTable GetLicensesByDriverID(int driverID, out string errorMessage)
        {
            DataTable dt = new DataTable();
            errorMessage = string.Empty;

            string query = @"
            SELECT 
                L.LicenseID AS [Lic.ID],
                L.ApplicationID AS [App.ID],
                LC.ClassName AS [Class Name],
                L.IssueDate AS [Issue Date],
                L.ExpirationDate AS [Expiration Date],
                L.IsActive AS [Is Active]
            FROM Licenses L
            INNER JOIN Applications Apps 
                ON L.ApplicationID = Apps.ApplicationID
            INNER JOIN LocalDrivingLicenseApplications LDLApps 
                ON L.ApplicationID = LDLApps.ApplicationID
            INNER JOIN LicenseClasses LC 
                ON LDLApps.LicenseClassID = LC.LicenseClassID
            WHERE L.DriverID = @DriverID;";

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

        public static DataTable GetLicensesByNationalNo
            (string nationalNo, out string errorMessage)
        {
            DataTable dt = new DataTable();
            errorMessage = string.Empty;

            string query = @"
            SELECT
	            LicenseID AS [Lic.ID],
	            L.ApplicationID AS [App.ID],
	            LC.ClassName AS [Class Name],
	            L.IssueDate AS [Issue Date],
	            L.ExpirationDate AS [Expiration Date],
	            L.IsActive AS [Is Active]
            FROM Licenses L
            INNER JOIN Applications Apps 
                ON  L.ApplicationID = Apps.ApplicationID
            INNER JOIN LocalDrivingLicenseApplications LDLApps 
                ON  L.ApplicationID = LDLApps.ApplicationID
            INNER JOIN LicenseClasses LC 
                ON  LDLApps.LicenseClassID = LC.LicenseClassID
            INNER JOIN People P 
                ON  Apps.ApplicationPersonID = P.PersonID
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

        public static bool GetLicenseInfoByLDLAppID(int localDLAppID,
            out int licenseID, out string className, out int driverID,
            out string fullName, out string nationalNo, out string gender,
            out DateTime issueDate, out DateTime expirationDate, out byte issueReason,
            out string notes, out bool isActive, out DateTime dateOfBirth,
            out string imagePath, out string errorMessage)
        {
            licenseID = 0;
            className = string.Empty;
            driverID = 0;
            fullName = string.Empty;
            nationalNo = string.Empty;
            gender = string.Empty;
            issueDate = DateTime.MinValue;
            expirationDate = DateTime.MinValue;
            issueReason = 0;
            notes = string.Empty;
            isActive = false;
            dateOfBirth = DateTime.MinValue;
            imagePath = string.Empty;
            errorMessage = string.Empty;

            bool isFound = false;

            string query = "SELECT * FROM dbo.GetDriverLicenseInfoByLDLAppID(@LocalDLAppID)";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LocalDLAppID", localDLAppID);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                licenseID = (int)reader["LicenseID"];
                                className = (string)reader["ClassName"];
                                driverID = (int)reader["DriverID"];
                                fullName = (string)reader["Full Name"];
                                nationalNo = (string)reader["NationalNo"];
                                gender = (string)reader["Gender"];
                                issueDate = (DateTime)reader["IssueDate"];
                                expirationDate = (DateTime)reader["ExpirationDate"];
                                issueReason = (byte)reader["IssueReason"];

                                notes = reader["Notes"] 
                                    != DBNull.Value ? (string)reader["Notes"] : string.Empty;

                                isActive = (bool)reader["IsActive"];
                                dateOfBirth = (DateTime)reader["DateOfBirth"];

                                imagePath = reader["ImagePath"] 
                                    != DBNull.Value ? (string)reader["ImagePath"] : string.Empty;
                            }
                            else
                            {
                                isFound = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                isFound = false;
            }

            return isFound;
        }

        public static bool AddNewLDLicense(
            int applicationID, int driverID, int licenseClass,
            DateTime issueDate, string notes,
            bool isActive, byte issueReason,
            int createdByUserID, ref int licenseID,
            out string errorMessage)
        {
            bool isInserted = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_AddNewLocalDrivingLicense", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ApplicationID", applicationID);
                    command.Parameters.AddWithValue("@DriverID", driverID);
                    command.Parameters.AddWithValue("@LicenseClass", licenseClass);
                    command.Parameters.AddWithValue("@IssueDate", issueDate);

                    if (string.IsNullOrEmpty(notes))
                        command.Parameters.AddWithValue("@Notes", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@Notes", notes);

                    command.Parameters.AddWithValue("@IsActive", isActive);
                    command.Parameters.AddWithValue("@IssueReason", issueReason);
                    command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

                    SqlParameter outputIdParam = new SqlParameter("@LicenseID", SqlDbType.Int);
                    outputIdParam.Direction = ParameterDirection.Output;
                    command.Parameters.Add(outputIdParam);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();

                        if (outputIdParam.Value != DBNull.Value)
                        {
                            licenseID = Convert.ToInt32(outputIdParam.Value);
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
            errorMessage = string.Empty;
            return isInserted;
        }
    }
}
