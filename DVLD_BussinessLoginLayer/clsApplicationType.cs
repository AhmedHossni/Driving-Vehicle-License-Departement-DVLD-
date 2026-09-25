using DVLD_DataAccessLayer;
using System.Data;

namespace DVLD_BusinessLogicLayer
{
    public class clsApplicationType
    {
        private int _id;
        public int Id { 
            get { return _id; } 
            private set { _id = value; } 
        }
        public string Title { get; set; }
        public decimal Fees { get; set; }

        private clsApplicationType(int id, string title, decimal fees)
        {
            _id = id;
            Title = title;
            Fees = fees;
        }

        public static clsApplicationType GetBy(int id, out string errorMessage)
        {
            string title = "";
            decimal fees = 0;

            if (clsApplicationTypeData.GetIBy(id, ref title, ref fees, out errorMessage))
                return new clsApplicationType(id, title, fees);
            else
                return null;
        }

        public bool Save(out string errorMessage)
        {
            clsApplicationTypeData.Update(_id, Title, Fees, out errorMessage);

            return string.IsNullOrEmpty(errorMessage);
        }

        public static DataTable GetAll(out string errorMessage)
            => clsApplicationTypeData.GetAll(out errorMessage);
    }
}
