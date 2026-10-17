using DVLD_BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.Driver
{
    public partial class frmDriverLicenseHistory : frmMainStyle
    {
        public frmDriverLicenseHistory(int driverID)
        {
            InitializeComponent();

            int personID = clsDriver.FindByDriverID(driverID, out string errorMessage)
                is clsDriver driver ? driver.PersonID : -1;
            ctrlSearchForPerson1.LoadPersonDetails(personID);

            ctrlSearchForPerson1.DisableSearchFeature(true);

            ctrlDriverLicenses1.LoadDriverLicensesBy(driverID);
        }

        public frmDriverLicenseHistory(string nationalNo)
        {
            InitializeComponent();

            int personID = clsPerson.GetBy(nationalNo, out string errorMessage)
                is clsPerson person ? person.Id : -1;

            ctrlSearchForPerson1.LoadPersonDetails(personID);

            ctrlSearchForPerson1.DisableSearchFeature(true);

            ctrlDriverLicenses1.LoadDriverLicensesBy(nationalNo);
        }
    }
}
