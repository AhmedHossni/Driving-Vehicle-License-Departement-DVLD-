using DVLD_DataAccessLayer;
using System.Data;

namespace DVLD_BusinessLogicLayer
{
    public class clsTestType
    {
            private int _id;
            public int Id
            {
                get { return _id; }
                private set { _id = value; }
            }
            public string Title { get; set; }
            public string Description { get; set; }
            public decimal Fees { get; set; }

            private clsTestType(int id, string title, string descrption, decimal fees)
            {
                _id = id;
                Title = title;
                Fees = fees;
                Description = descrption;
            }

            public static clsTestType GetBy(int id, out string errorMessage)
            {
                string title = "";
                string descrption = "";
                decimal fees = 0;

                if (clsTestTypeData.GetIBy(id, ref title, ref descrption, ref fees,  out errorMessage))
                    return new clsTestType(id, title, descrption, fees);
                else
                    return null;
            }

            public bool Save(out string errorMessage)
            {
                clsTestTypeData.Update(_id, Title, Description, Fees, out errorMessage);

                return string.IsNullOrEmpty(errorMessage);
            }

            public static DataTable GetAll(out string errorMessage)
                => clsTestTypeData.GetAll(out errorMessage);
    }
}
