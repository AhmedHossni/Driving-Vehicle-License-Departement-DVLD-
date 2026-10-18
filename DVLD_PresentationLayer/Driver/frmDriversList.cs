using CommonUseThings;
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
    public partial class frmDriversList : frmMainStyle
    {
        private Point _point
            = new Point();
        enum enComboBoxSelections
        {
            None,
            DriverID,
            PersonID,
            NationalNO,
            Fullname
        }

        private DataView _dvDriversData
            = new DataView();
        public frmDriversList()
        {
            InitializeComponent();

            dgvDriversData.AutoSizeColumnsMode
                = DataGridViewAutoSizeColumnsMode.Fill;

            LoadDataInGridDataView();

            cboxSearchBy.SelectedIndex
                = (int)enComboBoxSelections.None;
        }

        private int GetAndSelectCurrentGridRowId()
        {
            DataGridView.HitTestInfo hitInfo =
                dgvDriversData.HitTest(_point.X, _point.Y);
            int driverID = -1;

            if (hitInfo.RowIndex != -1)
            {
                dgvDriversData.ClearSelection();
                dgvDriversData.Rows[hitInfo.RowIndex].Selected = true;
                dgvDriversData.CurrentCell = dgvDriversData.Rows[hitInfo.RowIndex].Cells[0];
                driverID = (int)dgvDriversData.CurrentCell.Value;
            }

            return driverID;
        }

        private void dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            _point = dgvDriversData.PointToClient(Cursor.Position);
        }

        private void tboxSearchBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.DriverID
                || cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.PersonID)
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
            }
            else
            {
                tboxSearch.Visible = true;
                tboxSearch.Focus();
            }
        }

        private void ResetValuesWhenCBoxChange()
        {
            tboxSearch.Text = string.Empty;

            SearchFilter(string.Empty);
        }


        private void tboxSearch_TextChanged(object sender, EventArgs e)
        {
            if (tboxSearch.Text == string.Empty)
            {
                SearchFilter(string.Empty);
                return;
            }

            if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.DriverID)
                SearchFilter($"[Driver ID] = {tboxSearch.Text}");
            else if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.PersonID)
                SearchFilter($"[Person ID] = {tboxSearch.Text}");
            else if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.NationalNO)
                SearchFilter($"[National No] like '%{tboxSearch.Text}%'");
            else if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.Fullname)
                SearchFilter($"[Full Name] like '%{tboxSearch.Text}%'");
        }

        private async void LoadDataInGridDataView()
        {
            string ErrorMessage = string.Empty;

            await Task.Run(() =>
            {
                this._dvDriversData
                    = clsDriver.GetAllDriversWithImportantInfo(out ErrorMessage).DefaultView;
            });

            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                MessageBox.Show(ErrorMessage, "Error Message :(",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            dgvDriversData.DataSource
                = this._dvDriversData;

            lblRecordsCount.Text =
                this._dvDriversData.Count.ToString();
        }

        public void SearchFilter(string filterText)
        {
            _dvDriversData.RowFilter = filterText;

            lblRecordsCount.Text = _dvDriversData.Count.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();
    }
}
