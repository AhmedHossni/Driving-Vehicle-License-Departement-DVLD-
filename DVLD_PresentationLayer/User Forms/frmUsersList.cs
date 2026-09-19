using CommonUseThings;
using Driving___Vehicle_License_Departement__DVLD_.Person_Forms;
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
        }

        private void btnFormClose_Click(object sender, EventArgs e)
            => this.Close();
        private void btnBigCloseForm_Click(object sender, EventArgs e)
        => this.Close();

        private void buttonMinimize_Click(object sender, EventArgs e)
            => this.WindowState = FormWindowState.Minimized;

        private int GetAndSelectCurrentGridRowId()
        {
            DataGridView.HitTestInfo hitInfo = dgvUsers.HitTest(_point.X, _point.Y);

            if (hitInfo.RowIndex != -1)
            {
                dgvUsers.ClearSelection();
                dgvUsers.Rows[hitInfo.RowIndex].Selected = true;
                dgvUsers.CurrentCell = dgvUsers.Rows[hitInfo.RowIndex].Cells[0];
                return (int)dgvUsers.CurrentCell.Value;
            }
            else
            {
                return -1;
            }

        }

        private void dgvPeople_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            _point = dgvUsers.PointToClient(Cursor.Position);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
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
                {
                    e.Handled = true;
                }
            }
        }

        private void cboxSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetValuesWhenCBoxChange();

            if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.None)
            {
                tboxSearch.Visible = false;
            }
            else if(cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.IsActive)
            {
                tboxSearch.Visible = false;
                SearchFilter($"IsActive = 1");
            }
            else
            {
                tboxSearch.Visible = true;
            }


        }

        private void ResetValuesWhenCBoxChange()
        {
            tboxSearch.Text = string.Empty;

            SearchFilter(string.Empty);
        }

        public void SearchFilter(string filterText)
        {
            _dvUsersData.RowFilter = filterText;
        }

        private void tboxSearch_TextChanged(object sender, EventArgs e)
        {
            if (tboxSearch.Text == string.Empty)
            {
                SearchFilter(string.Empty);
                return;
            }

            if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.UserID)
            {
                SearchFilter($"UserID = {tboxSearch.Text}");
            }
            else if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.UserName)
            {
                SearchFilter($"UserName like '%{tboxSearch.Text}%'");
            }
            else if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.PersonID)
            {
                SearchFilter($"PersonID = {tboxSearch.Text}");
            }
            else if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.FullName)
            {
                SearchFilter($"[Full Name] like '%{tboxSearch.Text}%'");
            }
        }

        private void deleteToolStripMenuItem_Click_ShowUserDetails(object sender, EventArgs e)
        {
            int currentRowId = GetAndSelectCurrentGridRowId();

            if (currentRowId != -1)
            {
                //frmPersonInfo personInfo = new frmPersonInfo(currentRowId);
                //personInfo.PersonDataChangedHandler += LoadDataInGridDataView;
                //personInfo.ShowDialog();
            }
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
            => HandleUserChanges(-1);

        private void editToolStripMenuItem_Click_EditUserDetails(object sender, EventArgs e)
            => HandleUserChanges(GetAndSelectCurrentGridRowId());

        private void HandleUserChanges(int id)
        {
            //frmAddEditPerson addEditPersonForm
            //    = new frmAddEditPerson(id);

            //addEditPersonForm.SaveNewOrExistPersonHandler += LoadDataInGridDataView;

            //addEditPersonForm.ShowDialog();
        }

        private async void LoadDataInGridDataView()
        {
            string ErrorMessage = string.Empty;

            await Task.Run(() =>
            {
                _dvUsersData = clsUser.GetAllDataForFormDGV(out ErrorMessage).DefaultView;
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
    }
}
