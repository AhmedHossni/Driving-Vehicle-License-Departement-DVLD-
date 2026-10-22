using DVLD_BusinessLogicLayer;
using System.Data;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.License.Control
{
    public partial class ctrlDriverLicenses : UserControl
    {
        private DataView _dgvDriverLocalLicenses
            = new DataView();

        private DataView _dgvDriverInternationalLicenses
            = new DataView();

        public ctrlDriverLicenses()
        {
            InitializeComponent();
        }

        public void LoadDriverLicensesBy(string nationalNo)
        {
            LoadDGVAndSaveData(ref dgvLocalLicensesHistory, ref _dgvDriverLocalLicenses,
                clsLicense.GetLicensesByNationalNo(nationalNo, out string errorMessage).DefaultView,
                ref lblLocalLicensesRecords);

            LoadDGVAndSaveData(ref dgvInternationalLicensesHistory, ref _dgvDriverInternationalLicenses,
                clsInternationalLicense.
                GetInternationalLicensesByNationalNo(nationalNo, out errorMessage).DefaultView,
                ref lblInternationalLicensesRecords);
        }

        public void LoadDriverLicensesBy(int driverID)
        {
            LoadDGVAndSaveData(ref dgvLocalLicensesHistory, ref _dgvDriverLocalLicenses,
                clsLicense.GetLicensesByDriverID(driverID, out string errorMessage).DefaultView,
                ref lblLocalLicensesRecords);

            LoadDGVAndSaveData(ref dgvInternationalLicensesHistory, ref _dgvDriverInternationalLicenses,
                clsInternationalLicense.
                GetInternationalLicensesByDriverID(driverID, out errorMessage).DefaultView,
                ref lblInternationalLicensesRecords);
        }

        private void LoadDGVAndSaveData(ref DataGridView dgv,
            ref DataView storageView, DataView dataSourse,
            ref Label rowsCount)
        {
            string ErrorMessage = string.Empty;

            storageView = dataSourse;

            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                MessageBox.Show(ErrorMessage, "Error Message :(",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            dgv.DataSource = storageView;

            rowsCount.Text =
                storageView.Count.ToString();
        }
    }
}
