using Driving___Vehicle_License_Departement__DVLD_.Driver;
using Driving___Vehicle_License_Departement__DVLD_.Person_Forms;
using DVLD_BusinessLogicLayer;
using System;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.License.Local
{
    public partial class frmManageDetainedLicensesList : frmMainStyle
    {
        private Point _point
            = new Point();

        enum enComboBoxSelections
        {
            None,
            DetainID,
            IsReleased,
            NationalNo,
            FullName,
            ReleaseApplicationID
        }

        enum enComboBoxIsActive
        {
            All,
            Yes,
            No
        }

        private DataView _dvDetainedLicensesData
            = new DataView();

        public frmManageDetainedLicensesList()
        {
            InitializeComponent();

            dgvDetainedLicenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            LoadDataInGridDataView();

            cboxSearchBy.SelectedIndex = (int)enComboBoxSelections.None;

            cboxIsReleasedOptions.SelectedIndex = (int)enComboBoxIsActive.All;
        }

        private void GetAndSelectCurrentGridRowId(out int detainID, out int licenseID, 
            out string nationalNo)
        {
            DataGridView.HitTestInfo hitInfo = dgvDetainedLicenses.HitTest(_point.X, _point.Y);

            if (hitInfo.RowIndex != -1)
            {
                dgvDetainedLicenses.ClearSelection();
                dgvDetainedLicenses.Rows[hitInfo.RowIndex].Selected = true;
                dgvDetainedLicenses.CurrentCell = dgvDetainedLicenses.Rows[hitInfo.RowIndex].Cells[0];
                detainID = (int)dgvDetainedLicenses.CurrentCell.Value;
                licenseID = (int)dgvDetainedLicenses.Rows[hitInfo.RowIndex].Cells[1].Value;
                nationalNo = (string)dgvDetainedLicenses.Rows[hitInfo.RowIndex].Cells[6].Value;
            }
            else
            {
                detainID = -1;
                licenseID = -1;
                nationalNo = string.Empty;
            }
        }

        private int GetAndSelectCurrentGridRowId()
        {
            GetAndSelectCurrentGridRowId(out int detainID, out int licenseID,
            out string nationalNo);

            return detainID;
        }

        private int GetCurrentRowLicenseID()
        {
            GetAndSelectCurrentGridRowId(out int detainID, out int licenseID,
            out string nationalNo);

            return licenseID;
        }

        private void dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            _point = dgvDetainedLicenses.PointToClient(Cursor.Position);
        }

        private void tboxSearchBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.DetainID ||
                cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.ReleaseApplicationID)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    e.Handled = true;
            }
        }

        private void cboxSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetValuesWhenCBoxChange();

            if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.None)
            {
                tboxSearch.Visible = false;
                cboxIsReleasedOptions.Visible = false;
            }
            else if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.IsReleased)
            {
                tboxSearch.Visible = false;
                cboxIsReleasedOptions.Visible = true;
                cboxIsReleasedOptions.Focus();
                cboxIsReleased_SelectedIndexChanged(cboxIsReleasedOptions, e);
            }
            else
            {
                cboxIsReleasedOptions.Visible = false;
                tboxSearch.Visible = true;
                tboxSearch.Focus();
            }
        }

        private void cboxIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxIsReleasedOptions.SelectedIndex == (int)enComboBoxIsActive.All)
                SearchFilter(string.Empty);

            else if (cboxIsReleasedOptions.SelectedIndex == (int)enComboBoxIsActive.Yes)
                SearchFilter($"[Is Released] = 1");

            else if (cboxIsReleasedOptions.SelectedIndex == (int)enComboBoxIsActive.No)
                SearchFilter($"[Is Released] = 0");
        }

        private void ResetValuesWhenCBoxChange()
        {
            tboxSearch.Text = string.Empty;
            SearchFilter(string.Empty);
        }

        public void SearchFilter(string filterText) 
            => _dvDetainedLicensesData.RowFilter = filterText;

        private void tboxSearch_TextChanged(object sender, EventArgs e)
        {
            if (tboxSearch.Text == string.Empty)
            {
                SearchFilter(string.Empty);
                return;
            }

            if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.DetainID)
                SearchFilter($"[D.ID] = {tboxSearch.Text}");

            else if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.ReleaseApplicationID)
                SearchFilter($"[Releas App.ID] = {tboxSearch.Text}");

            else if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.NationalNo)
                SearchFilter($"[N.NO.] Like '%{tboxSearch.Text}%'");

            else if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.FullName)
                SearchFilter($"[Full Name] like '%{tboxSearch.Text}%'");
        }

        private async void LoadDataInGridDataView()
        {
            string errorMessage = string.Empty;

            await Task.Run(() =>
            {
                this._dvDetainedLicensesData 
                    = clsDetainedLicense.GetAllDetainedLicenses(out errorMessage).DefaultView;
            });

            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage, "Error Message :(",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            dgvDetainedLicenses.DataSource = this._dvDetainedLicensesData;

            lblNumberOfRecords.Text =
                this._dvDetainedLicensesData.Count.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();

        private void btnReleaseLicense_Click(object sender, EventArgs e)
        {
            new frmReleaseDetainedLicense().ShowDialog();
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            new frmDetainLicense().ShowDialog();
        }

        private void cmsDetainedLicenses_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(GetAndSelectCurrentGridRowId() == -1)
                e.Cancel = true;

            if(clsDetainedLicense.IsLicenseDetained(GetAndSelectCurrentGridRowId(),
                out bool isReleased, out string errorMessage))
            {
                if(!isReleased)
                    releaseToolStripMenuItem.Enabled = true;
            }
            else
            {
                if(!string.IsNullOrEmpty(errorMessage))
                    MessageBox.Show(errorMessage, "Error Message :(",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error);

                releaseToolStripMenuItem.Enabled = false;
            }
        }

        private string GetCurrentRowNationalNo()
        {
            GetAndSelectCurrentGridRowId(out int detainID, out int licenseID,
            out string nationalNo);

            return nationalNo;
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsPerson.GetBy(GetCurrentRowNationalNo(), out string errorMessage)
                    is clsPerson person)
            {
                new frmPersonInfo(person.Id).ShowDialog();
            }
            else
            {
                if(!string.IsNullOrEmpty(errorMessage))
                {
                    MessageBox.Show(errorMessage, "Error Message :(",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"No person with this national number : {GetCurrentRowNationalNo()}.", 
                        "Error Message :(",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetAndSelectCurrentGridRowId(out int detainID,
                out int licenseID, out string nationalNo);

            int applicationID = -1;
            int lDLAppID = -1;
            int licenseClassID = -1;
            int driverID = -1;
            int personID = -1;
            bool IsActive = false;

            if (clsLicense.GetLicenseInfoByID(licenseID, ref applicationID, ref lDLAppID, ref licenseClassID,
                ref driverID, ref IsActive, ref personID, out string errorMessage))
            {
                new frmLocalDriverLicenseInfo(lDLAppID).ShowDialog();
            }
            else
            {
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    MessageBox.Show(errorMessage, "Error Message :(",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"No license with this ID : {licenseID}.",
                        "Error Message :(",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetAndSelectCurrentGridRowId(out int detainID,
                out int licenseID, out string nationalNo);

            new frmDriverLicenseHistory(nationalNo).ShowDialog();
        }

        private void releaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmReleaseDetainedLicense(GetCurrentRowLicenseID()).ShowDialog();
        }
    }
}
