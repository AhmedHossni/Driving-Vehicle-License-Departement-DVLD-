using DVLD_BusinessLogicLayer;
using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.User_Forms
{
    public partial class frmUsersList : frmMainStyle
    {
        private Point _point 
            = new Point();
        enum enComboBoxSelections
        {
            None,
            UserID,
            UserName,
            PersonID,
            FullName,
            IsActive
        }
        enum enComboBoxIsActive
        {
            All,
            Yes,
            No
        }

        private DataView _dvUsersData
            = new DataView();

        public frmUsersList()
        {
            InitializeComponent();

            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            LoadDataInGridDataView();       

            pnlFrmBtns.MouseDown += frm_MouseDown;
            pnlFormUpper.MouseDown += frm_MouseDown;

            cboxSearchBy.SelectedIndex = (int)enComboBoxSelections.None;
            cboxIsActiveOptions.SelectedIndex = (int)enComboBoxIsActive.All;
        }

        private void btnFormClose_Click(object sender, EventArgs e)
            => this.Close();
        private void btnBigCloseForm_Click(object sender, EventArgs e)
            => this.Close();

        private void buttonMinimize_Click(object sender, EventArgs e)
            => this.WindowState = FormWindowState.Minimized;

        private void GetAndSelectCurrentGridRowId(out int userId, out int PersonId)
        {
            DataGridView.HitTestInfo hitInfo = dgvUsers.HitTest(_point.X, _point.Y);

            if (hitInfo.RowIndex != -1)
            {
                dgvUsers.ClearSelection();
                dgvUsers.Rows[hitInfo.RowIndex].Selected = true;
                dgvUsers.CurrentCell = dgvUsers.Rows[hitInfo.RowIndex].Cells[0];
                userId =  (int)dgvUsers.CurrentCell.Value;
                PersonId = (int)dgvUsers.Rows[hitInfo.RowIndex].Cells[1].Value;
            }
            else
            {
                userId = -1;
                PersonId = -1;
            }

        }
        private int GetAndSelectCurrentGridRowId()
        {
            GetAndSelectCurrentGridRowId(out int userId, out int personId);

            return userId;
        }

        private void dgvPeople_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            _point = dgvUsers.PointToClient(Cursor.Position);
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

                        LoadDataInGridDataView();
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
            if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.UserID ||
                cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.PersonID)
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

        public void SearchFilter(string filterText) => _dvUsersData.RowFilter = filterText;

        private void tboxSearch_TextChanged(object sender, EventArgs e)
        {
            if (tboxSearch.Text == string.Empty)
            {
                SearchFilter(string.Empty);
                return;
            }

            if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.UserID)
                SearchFilter($"UserID = {tboxSearch.Text}");

            else if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.UserName)
                SearchFilter($"UserName like '%{tboxSearch.Text}%'");

            else if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.PersonID)
                SearchFilter($"PersonID = {tboxSearch.Text}");

            else if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.FullName)
                SearchFilter($"[Full Name] like '%{tboxSearch.Text}%'");
        }


        private void CMS_Click_EditUserDetails(object sender, EventArgs e)
            => CallAddEditUserForm(GetAndSelectCurrentGridRowId());

        private async void LoadDataInGridDataView()
        {
            string ErrorMessage = string.Empty;

            await Task.Run(() =>
            {
                this._dvUsersData = clsUser.GetAllDataForFormDGV(out ErrorMessage).DefaultView;
            });

            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                MessageBox.Show(ErrorMessage, "Error Message :(",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            dgvUsers.DataSource = this._dvUsersData;

            lblNumberOfRecords.Text =
                this._dvUsersData.Count.ToString();
        }

        private void CMS_Click_UserInfo(object sender, EventArgs e)
        {
            int currentUserId = GetAndSelectCurrentGridRowId();

            if (!(MessageBox.Show($"Are you sure you want to delete user with id equals ({currentUserId})",
                    "Warning Message",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error) == DialogResult.Yes))
            {
                return;
            }

            if (clsUser.Delete(currentUserId, out string errorMessage))
            {
                MessageBox.Show($"Person with id equals ({currentUserId}) is deleted successfully",
                    "Operation Done Successfully :)",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadDataInGridDataView();

                return;
            }

            if(!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage,
                    "Error Message :(",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"There is no user with this id ({currentUserId})",
                    "Error Message :(",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CMS_Click_Edit(object sender, EventArgs e)
        {
            int currentRowId = GetAndSelectCurrentGridRowId();

            if (currentRowId != -1)
                CallAddEditUserForm(currentRowId);
          
        }

        private void CallAddEditUserForm(int userId)
        {
            frmAddEditUser addEditUser = new frmAddEditUser(userId);

            addEditUser.AddOrEditUserOperationHandler += LoadDataInGridDataView;

            addEditUser.ShowDialog();
        }

        private void CMS_Click_Add(object sender, EventArgs e)
            => CallAddEditUserForm(-1);

        private void CMS_Click_ChangePassword(object sender, EventArgs e)
        {

        }

        private void btnAddPerson_Click(object sender, EventArgs e)
            => CallAddEditUserForm(-1);

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetAndSelectCurrentGridRowId(out int userId, out int personId);

            frmUserFullInformaion userFullInformaion 
                = new frmUserFullInformaion(userId, personId, LoadDataInGridDataView, LoadDataInGridDataView);

            userFullInformaion.ShowDialog();
        }
    }
}
