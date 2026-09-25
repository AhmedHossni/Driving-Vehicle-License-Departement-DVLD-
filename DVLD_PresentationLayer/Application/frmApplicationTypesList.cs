using DVLD_BusinessLogicLayer;
using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.Application
{
    public partial class frmApplicationTypesList : Form
    {
        private DataView _dvApplicationTypesData
            = new DataView();

        private Point _point = new Point();

        public frmApplicationTypesList()
        {
            InitializeComponent();

            LoadDataInGridDataView();
        }

        private int GetAndSelectCurrentGridRowId()
        {
            DataGridView.HitTestInfo hitInfo = dgvApplicationTypes.HitTest(_point.X, _point.Y);

            if (hitInfo.RowIndex != -1)
            {
                dgvApplicationTypes.ClearSelection();
                dgvApplicationTypes.Rows[hitInfo.RowIndex].Selected = true;
                dgvApplicationTypes.CurrentCell = dgvApplicationTypes.Rows[hitInfo.RowIndex].Cells[0];
                return (int)dgvApplicationTypes.CurrentCell.Value;
            }
            else
            {
                return -1;
            }
        }

        private void dgvPeople_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
            => _point = dgvApplicationTypes.PointToClient(Cursor.Position);

        private void btnFormClose_Click(object sender, EventArgs e) 
            => this.Close();

        public void SearchFilter(string filterText) 
            => _dvApplicationTypesData.RowFilter = filterText;

        private void CMS_Click_EditPersonDetails(object sender, EventArgs e)
            => OpenAddEditPersonFormAndHandleChanges(GetAndSelectCurrentGridRowId());

        private void OpenAddEditPersonFormAndHandleChanges(int id)
        {
            // open edit applcation type data not add new
        }

        private void AddEditPersonForm_SaveNewOrExistPersonHandler(int id)
            => LoadDataInGridDataView();

        private async void LoadDataInGridDataView()
        {
            string ErrorMessage = string.Empty;

            await Task.Run(() =>
            {
                _dvApplicationTypesData = clsApplicationType.GetAll(out ErrorMessage).DefaultView;
            });

            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                MessageBox.Show(ErrorMessage, "Error Message :(",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            dgvApplicationTypes.DataSource = this._dvApplicationTypesData;

            lblRecordsCount.Text =
                this._dvApplicationTypesData.Count.ToString();
        }
    }
}
