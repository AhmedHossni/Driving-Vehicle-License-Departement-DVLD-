using Driving___Vehicle_License_Departement__DVLD_.Application.Application_Types;
using DVLD_BusinessLogicLayer;
using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.Test.Test_Type
{
    public partial class frmTestTypesList : Form
    {
        private DataView _dvTestTypesData
            = new DataView();

        private Point _point = new Point();

        public frmTestTypesList()
        {
            InitializeComponent();

            LoadDataInGridDataView();
        }

        private int GetAndSelectCurrentGridRowId()
        {
            DataGridView.HitTestInfo hitInfo
                = dgvTestTypes.HitTest(_point.X, _point.Y);

            if (hitInfo.RowIndex != -1)
            {
                dgvTestTypes.ClearSelection();
                dgvTestTypes.Rows[hitInfo.RowIndex].Selected = true;
                dgvTestTypes.CurrentCell = dgvTestTypes.Rows[hitInfo.RowIndex].Cells[0];
                return (int)dgvTestTypes.CurrentCell.Value;
            }
            else
            {
                return -1;
            }
        }

        private void dgvTestTypes_MouseDown(object sender, MouseEventArgs e)
            => _point = dgvTestTypes.PointToClient(Cursor.Position);

        private void btnFormClose_Click(object sender, EventArgs e)
            => this.Close();

        private void OpenAddEditPersonFormAndHandleChanges(int id)
        {
            frmEditTestType editAppTypes
                = new frmEditTestType(id);

            editAppTypes.ApplicationTypeDataChangeHandler
                += LoadDataInGridDataView;

            editAppTypes.ShowDialog();
        }

        private async void LoadDataInGridDataView()
        {
            string ErrorMessage = string.Empty;

            await Task.Run(() =>
            {
                _dvTestTypesData = clsTestType.GetAll(out ErrorMessage).DefaultView;
            });

            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                MessageBox.Show(ErrorMessage, "Error Message :(",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            dgvTestTypes.DataSource = this._dvTestTypesData;

            lblRecordsCount.Text =
                this._dvTestTypesData.Count.ToString();
        }

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int currentId = GetAndSelectCurrentGridRowId();

            OpenAddEditPersonFormAndHandleChanges(currentId);
        }
    }
}
