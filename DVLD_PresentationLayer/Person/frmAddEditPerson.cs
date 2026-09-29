using DVLD_BusinessLogicLayer;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.Person_Forms
{
    public partial class frmAddEditPerson : Form
    {
        public delegate void SaveNewOrEditPersonDelegate(int id);
        public event SaveNewOrEditPersonDelegate SaveNewOrExistPersonHandler;

        public frmAddEditPerson(int personId)
        {
            InitializeComponent();

            ctrlAddEdit_person1.LoadPersonDataToForm(personId);

            DisableEditModeIfUserDoNotHaveThePermission(personId);

            ctrlAddEdit_person1.btnSave_Click_Handler += btnSave_Click_Handler;
            ctrlAddEdit_person1.btnClose_Click_Handler += btnClose_Click_Handler;

            lblFormLabel.Text = personId != -1 ? "Edit Person" : "Add Person";

            lblFormLabel.Left = (this.ClientSize.Width - lblFormLabel.Width) / 2;
        }

        private void DisableEditModeIfUserDoNotHaveThePermission(int personId)
        {
            if (clsUser.IsExistByPersonId(personId, out string errorMessage)
                && clsUser.SystemUser.PersonId != personId)
                ctrlAddEdit_person1.Enabled = false;
        }

        private void btnClose_Click_Handler()
        {
            this.Close();
        }

        private void btnSave_Click_Handler(int id)
        {
            SaveNewOrExistPersonHandler?.Invoke(id);
        }
    }
}
