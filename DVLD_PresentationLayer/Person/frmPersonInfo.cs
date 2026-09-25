using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.Person_Forms
{
    public partial class frmPersonInfo : Form
    {
        public event Action PersonDataChangedHandler;

        public frmPersonInfo(int personId)
        {
            InitializeComponent();

            if (personId != -1)
                ctrlPersonInfo1.LoadPersonData(personId);

            ctrlPersonInfo1.PersonDataChangedHandler += CtrlPersonInfo1_PersonDataChangedHandler;
        }

        private void CtrlPersonInfo1_PersonDataChangedHandler()
        {
            PersonDataChangedHandler.Invoke();
        }
    }
}
