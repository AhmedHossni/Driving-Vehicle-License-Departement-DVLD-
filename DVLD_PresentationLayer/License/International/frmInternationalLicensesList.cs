using Driving___Vehicle_License_Departement__DVLD_.Driver;
using Driving___Vehicle_License_Departement__DVLD_.Person_Forms;
using DVLD_BusinessLogicLayer;
using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.License.International
{
    public partial class frmInternationalLicensesList : frmMainStyle
    {
        private Point _point
            = new Point();

        enum enComboBoxSelections
        {
            None,
            InternationalLicenseID,
            ApplicationID,
            DriverID,
            IssuedUsingLocalLicenseID,
            IsActive
        }
        enum enComboBoxIsActive
        {
            All,
            Yes,
            No
        }

        private DataView _dvInternationalLicensesData
            = new DataView();

        public frmInternationalLicensesList()
        {
            InitializeComponent();

            dgvInternationalLicenses.AutoSizeColumnsMode 
                = DataGridViewAutoSizeColumnsMode.Fill;

            LoadInternationalLicensesDataInGridDataView();

            cboxSearchBy.SelectedIndex = (int)enComboBoxSelections.None;

            cboxIsActiveOptions.SelectedIndex = (int)enComboBoxIsActive.All;
        }

        private void GetAndSelectCurrentGridRowId(out int internationalLicenseID, out int applicationID
            , out int driverID, out int lLicenseID, out int personID)
        {
            DataGridView.HitTestInfo hitInfo 
                = dgvInternationalLicenses.HitTest(_point.X, _point.Y);

            if (hitInfo.RowIndex != -1)
            {
                dgvInternationalLicenses.ClearSelection();
                dgvInternationalLicenses.Rows[hitInfo.RowIndex].Selected = true;
                dgvInternationalLicenses.CurrentCell 
                    = dgvInternationalLicenses.Rows[hitInfo.RowIndex].Cells[0];
                
                internationalLicenseID = (int)dgvInternationalLicenses.CurrentCell.Value;
                applicationID = (int)dgvInternationalLicenses.Rows[hitInfo.RowIndex].Cells[1].Value;
                driverID = (int)dgvInternationalLicenses.Rows[hitInfo.RowIndex].Cells[2].Value;
                lLicenseID = (int)dgvInternationalLicenses.Rows[hitInfo.RowIndex].Cells[3].Value;
                personID = (int)dgvInternationalLicenses.Rows[hitInfo.RowIndex].Cells[7].Value;
            }
            else
            {
                internationalLicenseID = -1;
                applicationID = -1;
                lLicenseID = -1;
                driverID = -1;
                personID = -1;
            }

        }

        private int GetAndSelectCurrentGridRowId()
        {
            GetAndSelectCurrentGridRowId(out int internationalLicenseID, out int applicationID
            , out int driverID, out int lLicenseID, out int personID);

            return internationalLicenseID;
        }

        private void dgvPeople_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            _point = dgvInternationalLicenses.PointToClient(Cursor.Position);
        }

        private void CMS_Click_Delete(object sender, EventArgs e)
        {
            int CurrentRowId = GetAndSelectCurrentGridRowId();

            if (CurrentRowId != -1)
            {
                if (MessageBox.Show($"Are you sure you want to delete user with id = {CurrentRowId}",
                    "Warning!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    clsUser.Delete(CurrentRowId, out string errorMessage);

                    if (string.IsNullOrEmpty(errorMessage))
                    {

                        MessageBox.Show($"User with id equals ({CurrentRowId}) is deleted successfully",
                            "Operation Done Successfully :)",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        LoadInternationalLicensesDataInGridDataView();
                    }
                    else
                    {
                        MessageBox.Show(errorMessage,
                            "Error Message :(",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void tboxSearchBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void cboxSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetValuesWhenCBoxChange();

            if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.None)
            {
                tboxSearch.Visible = false;
                cboxIsActiveOptions.Visible = false;
            }
            else if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.IsActive)
            {
                tboxSearch.Visible = false;
                cboxIsActiveOptions.Visible = true;
                cboxIsActiveOptions.Focus();
                cboxIsActiveOptions_SelectedIndexChanged(cboxIsActiveOptions, e);
            }
            else
            {
                cboxIsActiveOptions.Visible = false;
                tboxSearch.Visible = true;
                tboxSearch.Focus();
            }
        }

        private void cboxIsActiveOptions_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboxIsActiveOptions.SelectedIndex == (int)enComboBoxIsActive.All)
                SearchFilter(string.Empty);

            else if (cboxIsActiveOptions.SelectedIndex == (int)enComboBoxIsActive.Yes)
                SearchFilter($"IsActive = 1");

            else if (cboxIsActiveOptions.SelectedIndex == (int)enComboBoxIsActive.No)
                SearchFilter($"IsActive = 0");

        }

        private void ResetValuesWhenCBoxChange()
        {
            tboxSearch.Text = string.Empty;

            SearchFilter(string.Empty);
        }

        public void SearchFilter(string filterText) 
            => _dvInternationalLicensesData.RowFilter = filterText;

        private void tboxSearch_TextChanged(object sender, EventArgs e)
        {
            if (tboxSearch.Text == string.Empty)
            {
                SearchFilter(string.Empty);
                return;
            }

            if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.InternationalLicenseID)
                SearchFilter($"InternationalLicenseID = {tboxSearch.Text}");

            else if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.ApplicationID)
                SearchFilter($"ApplicationID = {tboxSearch.Text}");

            else if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.DriverID)
                SearchFilter($"DriverID = {tboxSearch.Text}");

            else if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.IssuedUsingLocalLicenseID)
                SearchFilter($"IssuedUsingLocalLicenseID = {tboxSearch.Text}");
        }

        private async void LoadInternationalLicensesDataInGridDataView()
        {
            string ErrorMessage = string.Empty;

            await Task.Run(() =>
            {
                this._dvInternationalLicensesData 
                    = clsInternationalLicense.GetAllInternationalLicenses(out ErrorMessage).DefaultView;
            });

            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                MessageBox.Show(ErrorMessage, "Error Message :(",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            dgvInternationalLicenses.DataSource = this._dvInternationalLicensesData;

            ChangeColumnsDisplayName();

            lblNumberOfRecords.Text =
                this._dvInternationalLicensesData.Count.ToString();
        }

        private void ChangeColumnsDisplayName()
        {
            if (dgvInternationalLicenses.Columns["InternationalLicenseID"] != null)
                dgvInternationalLicenses.Columns["InternationalLicenseID"].HeaderText = "Int. License ID";

            if (dgvInternationalLicenses.Columns["ApplicationID"] != null)
                dgvInternationalLicenses.Columns["ApplicationID"].HeaderText = "App ID";

            if (dgvInternationalLicenses.Columns["DriverID"] != null)
                dgvInternationalLicenses.Columns["DriverID"].HeaderText = "Driver ID";

            if (dgvInternationalLicenses.Columns["IssuedUsingLocalLicenseID"] != null)
                dgvInternationalLicenses.Columns["IssuedUsingLocalLicenseID"].HeaderText = "Local License ID";

            if (dgvInternationalLicenses.Columns["IssueDate"] != null)
                dgvInternationalLicenses.Columns["IssueDate"].HeaderText = "Issue Date";

            if (dgvInternationalLicenses.Columns["ExpirationDate"] != null)
                dgvInternationalLicenses.Columns["ExpirationDate"].HeaderText = "Expiration Date";

            if (dgvInternationalLicenses.Columns["IsActive"] != null)
                dgvInternationalLicenses.Columns["IsActive"].HeaderText = "Is Active?";

            if (dgvInternationalLicenses.Columns["PersonID"] != null)
                dgvInternationalLicenses.Columns["PersonID"].HeaderText = "Person ID";
        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetAndSelectCurrentGridRowId(out int internationalLicenseID, out int applicationID
            , out int driverID, out int lLicenseID, out int personID);

            new frmPersonInfo(personID).ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetAndSelectCurrentGridRowId(out int internationalLicenseID, out int applicationID
            , out int driverID, out int lLicenseID, out int personID);

            new frmDriverInternationalLicenseInfo(internationalLicenseID).ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetAndSelectCurrentGridRowId(out int internationalLicenseID, out int applicationID
            , out int driverID, out int lLicenseID, out int personID);

            new frmDriverLicenseHistory(driverID).ShowDialog();
        }

        private void cmsInternationalLicensesList_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(GetAndSelectCurrentGridRowId() == -1)
                e.Cancel = true;
        }
    }
}
