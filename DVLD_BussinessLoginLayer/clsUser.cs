using DVLD_DataAccessLayer;

namespace DVLD_BusinessLogicLayer
{
    public class clsUser
    {
        private int _id;
        private int _personId;
        private bool _isActive;
        public int Id => _id;
        public int PersonId => _personId;
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get { return _isActive; } set { _isActive = value; } }
        public static clsUser SystemUser { get; set; }

        public clsUser()
        {
            Username = "";
            Password = "";
            _isActive = false;
            _id = -1;
            _personId = -1;
        }

        private clsUser(int id, int personId, string username, string password, bool isActive)
        {
            Username = username;
            Password = password;
            _id = id;
            _personId = personId;
            _isActive = isActive;
        }

        public static bool CheckUsernameAndPassword(string username, string password,
            out string errorMessage)
        {
            int userId = -1;
            int personId = -1;
            string databasePassword = "";
            bool isActive = false;

            clsUserData.enGettingUserResult searchResult =
                clsUserData.GetInfoByUsername(username, ref userId, ref personId, ref databasePassword
                , ref isActive, out errorMessage);

            if (searchResult == clsUserData.enGettingUserResult.eUserFounded)
            {
                if (password == databasePassword) 
                {
                    if (isActive)
                    {
                        SystemUser = new clsUser(userId, personId, username, password, isActive);
                        return true;
                    }
                    else
                    {
                        errorMessage = "The username and password are correct, but the account is inactive.";
                    }
                }

            }

            return false;
        }

        public bool Save(out string errorMessage)
        {
            if(Id == -1)
                clsUserData.Add(Username, Password, PersonId, IsActive, out errorMessage, out _id);
            else
                clsUserData.Update(Id, Username, Password, IsActive, out errorMessage);

            return string.IsNullOrEmpty(errorMessage);
        }

        public static bool Add(int personId, string username, string password, bool isActive,
            out string errorMessage, out int NewUserId)
        {
            clsUserData.Add(username, password, personId, isActive, out errorMessage, out NewUserId);

            return string.IsNullOrEmpty(errorMessage);
        }

        public static bool Delete(int userId, out string errorMessage)
        {
            clsUserData.Delete(userId, out errorMessage);

            return string.IsNullOrEmpty(errorMessage);
        }

        public bool IsExistByUserId(int userId, out string errorMessage) 
        {
            clsUserData.IsExistByUserId(userId, out errorMessage);

            return string.IsNullOrEmpty(errorMessage);
        }

        public bool IsExistByPersonId(int personId, out string errorMessage)
        {
            clsUserData.IsExistByPersonId(personId, out errorMessage);

            return string.IsNullOrEmpty(errorMessage);
        }     

    }
}
