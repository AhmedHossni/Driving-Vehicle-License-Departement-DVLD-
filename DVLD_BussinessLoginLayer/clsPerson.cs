using CommonUseThings;
using DVLD_DataAccessLayer;
using System;
using System.Data;
using System.Runtime.Remoting.Messaging;

namespace DVLD_BusinessLogicLayer
{
    public class clsPerson
    {
        private int _id;
        public int Id => _id;
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public enPersonGender Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalCountryID { get; set; }
        public string NationalCountryName { get; set; } = string.Empty;
        public string ImageName { get; set; }

        public clsPerson()
        {
            _id = -1;
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            Gender = enPersonGender.Male;
            Address = "";
            Phone = "";
            Email = "";
            NationalCountryID = -1;
            ImageName = "";
        }

        private clsPerson(int id, string nationalNo, string firstName, string secondName, 
            string thirdName, string lastName, DateTime dateOfBirth, enPersonGender gender,
            string address, string phone, string email, int nationalCountryID, string imagePath)
        {
            _id = id;
            NationalNo = nationalNo;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Address = address;
            Phone = phone;
            Email = email;
            NationalCountryID = nationalCountryID;
            ImageName = imagePath;
        }

        public bool Save(out string errorMessage, out int id)
        {
            if (Id == -1)
            {
                clsPersonData.Add(FirstName, SecondName, ThirdName, LastName, NationalNo
                    , DateOfBirth, Gender, Address, Phone, Email, NationalCountryID,
                    ImageName, out errorMessage, out _id);
            }
            else
            {
                clsPersonData.Update(Id, FirstName, SecondName, ThirdName, LastName, NationalNo
                    , DateOfBirth, Gender, Address, Phone, Email, NationalCountryID,
                    ImageName, out errorMessage);
            }

            id = _id;

            return string.IsNullOrEmpty(errorMessage);
        }

        public static bool Add(string nationalNo, string firstName, string secondName,
            string thirdName, string lastName, DateTime dateOfBirth, enPersonGender gender,
            string address, string phone, string email, int nationalCountryID, string imagePath, out int newRecordId)
        {
            string errorMessage = string.Empty;

            clsPersonData.Add(firstName, secondName, thirdName, lastName, nationalNo
                , dateOfBirth, gender, address, phone, email, nationalCountryID,
                imagePath, out errorMessage, out newRecordId);

            return string.IsNullOrEmpty(errorMessage);
        }

        public static bool Delete(int id, out string errorMessage)
        {
            clsPersonData.Delete(id, out errorMessage);

            return string.IsNullOrEmpty(errorMessage);
        }

        public static bool IsExistBy(int id, out string errorMessage)
        {
            clsUserData.IsExistByUserId(id, out errorMessage);

            return string.IsNullOrEmpty(errorMessage);
        }

        public static bool IsExistBy(string nationalNo, out string errorMessage)
        {
            clsPersonData.IsExistBy(nationalNo, out errorMessage);

            return string.IsNullOrEmpty(errorMessage);
        }

        public static clsPerson GetBy(int id, out string errorMessage)
        {
            clsPerson person = new clsPerson();

            string firstName = string.Empty;
            string secondName = string.Empty;
            string thirdName = string.Empty;
            string lastName = string.Empty;

            string nationalNo = string.Empty;
            DateTime dateOfBirth = default;
            enPersonGender gender = 0;

            string address = string.Empty;
            string phone = string.Empty;
            string email = string.Empty;
            int nationalCountryID = 0;
            string CountryName = "";
            string imagePath = string.Empty;

            bool isFound = clsPersonData.GetInfoBy(
                id,
                ref firstName,
                ref secondName,
                ref thirdName,
                ref lastName,
                ref nationalNo,
                ref dateOfBirth,
                ref gender,
                ref address,
                ref phone,
                ref email,
                ref nationalCountryID,
                ref CountryName,
                ref imagePath,
                out errorMessage
            );

            if (isFound)
            {
                person._id = id;
                person.FirstName = firstName;
                person.SecondName = secondName;
                person.ThirdName = thirdName;
                person.LastName = lastName;
                person.NationalNo = nationalNo;
                person.DateOfBirth = dateOfBirth;
                person.Gender = (enPersonGender)gender;
                person.Address = address;
                person.Phone = phone;
                person.Email = email;
                person.NationalCountryID = nationalCountryID;
                person.NationalCountryName = CountryName;
                person.ImageName = imagePath;

                return person;
            }

            return null;
        }

        public static clsPerson GetBy(string nationalNo, out string errorMessage)
        {
            clsPerson person = new clsPerson();

            int personId = -1;

            string firstName = string.Empty;
            string secondName = string.Empty;
            string thirdName = string.Empty;
            string lastName = string.Empty;

            DateTime dateOfBirth = default;
            enPersonGender gender = 0;

            string address = string.Empty;
            string phone = string.Empty;
            string email = string.Empty;
            int nationalCountryID = 0;
            string CountryName = "";
            string imagePath = string.Empty;

            bool isFound = clsPersonData.GetInfoBy(
                nationalNo,
                ref personId,
                ref firstName,
                ref secondName,
                ref thirdName,
                ref lastName,
                ref dateOfBirth,
                ref gender,
                ref address,
                ref phone,
                ref email,
                ref nationalCountryID,
                ref CountryName,
                ref imagePath,
                out errorMessage
            );

            if (isFound)
            {
                person._id = personId;
                person.FirstName = firstName;
                person.SecondName = secondName;
                person.ThirdName = thirdName;
                person.LastName = lastName;
                person.NationalNo = nationalNo;
                person.DateOfBirth = dateOfBirth;
                person.Gender = (enPersonGender)gender;
                person.Address = address;
                person.Phone = phone;
                person.Email = email;
                person.NationalCountryID = nationalCountryID;
                person.NationalCountryName = CountryName;
                person.ImageName = imagePath;

                return person;
            }

            return null;
        }

        public string FullName () => 
            $"{FirstName}  {SecondName}  {ThirdName}  {LastName}";

        public static DataTable GetAll(out string errorMessage)
            => clsPersonData.GetAll(out errorMessage);

        public static DataTable GetAllDataForFormDGV(out string errorMessage)
            => clsPersonData.GetAllDataForFormDGV(out errorMessage);
    }
}
