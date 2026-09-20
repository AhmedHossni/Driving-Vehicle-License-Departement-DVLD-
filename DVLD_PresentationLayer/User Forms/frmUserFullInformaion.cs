using System;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.User_Forms
{
    public partial class frmUserFullInformaion : Form
    {
        readonly int _userId = -1;
        readonly int _personId = -1;

        public event Action _userDataChangedHandler;
        public event Action _personDataChangedHandler;

        public frmUserFullInformaion(int userId, int personId, 
            Action userDataChangedHandler, Action personDataChangedHandler)
        {
            InitializeComponent();

            ctrlUserInfo1.LoadUserInfo(userId);

            _userId = userId;
            _personId = personId;

            _userDataChangedHandler = userDataChangedHandler;
            _personDataChangedHandler = personDataChangedHandler;

            CtrlPersonInfo1_PersonDataChangedHandler();

            ctrlPersonInfo1.PersonDataChangedHandler += CtrlPersonInfo1_PersonDataChangedHandler;
        }

        private void CtrlPersonInfo1_PersonDataChangedHandler()
        {
            ctrlPersonInfo1.LoadPersonData(_personId);

            _personDataChangedHandler.Invoke();
        }
    }
}
