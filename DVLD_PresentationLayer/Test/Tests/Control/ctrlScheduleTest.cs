using System;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.Test.Tests.Control
{
    public partial class ctrlScheduleTest : UserControl
    {
        public string testName 
            { get { return gbBoxTestName.Text; } set { gbBoxTestName.Text = value; } }

        public ctrlScheduleTest()
        {
            InitializeComponent();

            DefaultStartValues();
        }

        private void DefaultStartValues()
        {
            dateTimePicker1.MinDate = DateTime.Now.AddDays(1);
        }
    }
}
