using CommonUseThings;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DVLD_DataAccessLayer
{
    public class clsPersonData
    {
        public static bool Add( string firstName, string secondName, string thirdName, string lastName,
            string nationalNo, DateTime dateOfBirth, enPersonGender gender, string address, string phone,
            string email, int nationalityCountryId, string imagePath,
            out string errorMessage, out int personId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "INSERT INTO People VALUES (@nationalNo, @firstName, @secondName, @thirdName, " +
                        "@lastName, @dateOfBirth, @gender, @address, @phone, @email, @nationalityCountryId, @imagePath); " +
                        "SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nationalNo", nationalNo);

                        command.Parameters.AddWithValue("@firstName", firstName);
                        command.Parameters.AddWithValue("@secondName", secondName);
                        command.Parameters.AddWithValue("@thirdName", thirdName);
                        command.Parameters.AddWithValue("@lastName", lastName);

                        command.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
                        command.Parameters.AddWithValue("@gender", gender);
                        command.Parameters.AddWithValue("@address", address);
                        command.Parameters.AddWithValue("@phone", phone);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@nationalityCountryId", nationalityCountryId);
                        
                        if (!string.IsNullOrEmpty(imagePath))
                            command.Parameters.AddWithValue("@imagePath", imagePath);
                        else
                            command.Parameters.AddWithValue("@imagePath", DBNull.Value);

                        connection.Open();

                        if (command.ExecuteScalar() is object obj && obj != null && obj != DBNull.Value)
                            personId = Convert.ToInt32(obj);
                        else
                            personId = -1;
                    }
                }
                errorMessage = string.Empty;

                return true;
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                personId = -1;
                return false;
            }
        }

        public static bool GetInfoByUserId(int id, ref string firstName, ref string secondName,
            ref string thirdName, ref string lastName,
            ref string nationalNo, ref DateTime dateOfBirth, ref enPersonGender gender,
            ref string address, ref string phone,
            ref string email, ref int nationalityCountryId, ref string countryName, ref string imagePath,
            out string errorMessage)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT P.PersonID, " +
                    "P.NationalNo, P.FirstName, " +
                    "P.SecondName,P.ThirdName, " +
                    "P.LastName, P.DateOfBirth, " +
                    "CASE P.Gender " +
                    "WHEN 0 THEN 'Male' " +
                    "ELSE 'Female' END AS Gender, " +
                    "P.Address, p.NationalityCountryID, " +
                    "C.CountryName, P.Phone, P.Email, P.ImagePath FROM People AS P " +
                    "INNER JOIN Countries AS C ON P.NationalityCountryID = C.CountryID " +
                    "WHERE P.PersonID = @id;";

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

                                firstName = (string)reader["FirstName"];
                                secondName = (string)reader["SecondName"];
                                thirdName = (string)reader["ThirdName"];
                                lastName = (string)reader["LastName"];
                                nationalNo = (string)reader["NationalNo"];

                                dateOfBirth = (DateTime)reader["DateOfBirth"];

                                gender = (string)reader["Gender"] == "Male" ? 
                                    enPersonGender.Male : enPersonGender.Female;

                                address = (string)reader["Address"];
                                phone = (string)reader["Phone"];
                                email = (string)reader["Email"];
                                nationalityCountryId = (int)reader["NationalityCountryId"];
                                countryName = (string)reader["countryName"];

                                object imgPathObject = reader["ImagePath"];

                                imagePath = imgPathObject != DBNull.Value ?
                                    (string)imgPathObject : string.Empty;

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

        public static bool Update(int id, string firstName, string secondName, string thirdName, string lastName,
            string nationalNo, DateTime dateOfBirth, enPersonGender gender, string address, string phone,
            string email, int nationalityCountryId, string imagePath,
            out string errorMessage)
        {

            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"Update People set
                                NationalNo= @nationalNo,
                                FirstName = @firstName,
                                SecondName = @secondName,
                                ThirdName = @thirdName,
                                LastName = @lastName,
                                DateOfBirth = @dateOfBirth,
                                Gender = @gender,
                                Address = @address,
                                Phone = @phone,
                                Email = @email,
                                NationalityCountryId = @nationalityCountryId,
                                ImagePath = @imagePath
                                where PersonID = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    command.Parameters.AddWithValue("@nationalNo", nationalNo);

                    command.Parameters.AddWithValue("@firstName", firstName);
                    command.Parameters.AddWithValue("@secondName", secondName);
                    command.Parameters.AddWithValue("@thirdName", thirdName);
                    command.Parameters.AddWithValue("@lastName", lastName);

                    command.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
                    command.Parameters.AddWithValue("@gender", gender);
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@phone", phone);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@nationalityCountryId", nationalityCountryId);
                    
                    if (!string.IsNullOrEmpty(imagePath))
                        command.Parameters.AddWithValue("@imagePath", imagePath);
                    else
                        command.Parameters.AddWithValue("@imagePath", DBNull.Value);

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

            string query = "SELECT * FROM People";

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
        public static DataTable GetAllDataForFormDGV(out string errorMessage)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM PeopleWithCountryName";

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

        public static bool Delete(int id, out string errorMessage)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"Delete People where personID = @id";

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

        public static bool IsExistBy(int id, out string errorMessage)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT Found = 1 FROM People WHERE PersonID = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

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

        public static bool IsExistBy(string nationalNo, out string errorMessage)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT Found = 1 FROM People WHERE NationalNo = @nationalNo";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nationalNo", nationalNo);

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
