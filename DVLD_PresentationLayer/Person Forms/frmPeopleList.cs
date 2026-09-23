using CommonUseThings;
using Driving___Vehicle_License_Departement__DVLD_.Person_Forms;
using DVLD_BusinessLogicLayer;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.People_Forms
{
    public partial class frmPeopleList : frmMainStyle
    {
        private Point _point = new Point();
        enum enComboBoxSelections 
        {
            None,
            PersonID,
            NationalNo,
            FirstName,
            SecondName,
            ThirdName,
            LastName,
            Nationality,
            Gender,
            Phone,
            Email
        }

        private DataView _dvPeopleData
            = new DataView();

        public frmPeopleList()
        {
            InitializeComponent();

            LoadDataInGridDataView();

            pnlFormUpper.MouseDown += frm_MouseDown;
            pnlFrmBtns.MouseDown += frm_MouseDown;

            cboxSearchBy.SelectedIndex = (int)enComboBoxSelections.None;
        }

        private int GetAndSelectCurrentGridRowId()
        {
            DataGridView.HitTestInfo hitInfo = dgvPeople.HitTest(_point.X, _point.Y);

            if (hitInfo.RowIndex != -1)
            {
                dgvPeople.ClearSelection();
                dgvPeople.Rows[hitInfo.RowIndex].Selected = true;
                dgvPeople.CurrentCell = dgvPeople.Rows[hitInfo.RowIndex].Cells[0];
                return (int)dgvPeople.CurrentCell.Value;
            }
            else
            {
                return -1;
            }
        }

        private void dgvPeople_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
            => _point = dgvPeople.PointToClient(Cursor.Position);
        

        private void CMS_Click_Delete(object sender, EventArgs e)
        {
            int CurrentRowId = GetAndSelectCurrentGridRowId();

            if (CurrentRowId != -1)
            {
                if (MessageBox.Show($"Are you sure you want to delete person with id = {CurrentRowId}",
                    "Warning!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string personImageFullName = 
                        clsPerson.GetBy(CurrentRowId, out string imageNameErrorMessage).ImageName;
                    
                    if (!string.IsNullOrEmpty(imageNameErrorMessage))
                    {
                        MessageBox.Show(imageNameErrorMessage,
                            "Error Message :(",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        return;
                    }

                    clsPerson.Delete(CurrentRowId, out string errorMessage);

                    if (string.IsNullOrEmpty(errorMessage))
                    {
                        if (personImageFullName != string.Empty)
                            DeletePersonImage(personImageFullName);

                        MessageBox.Show($"Person with id equals ({CurrentRowId}) is deleted successfully",
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

        private void DeletePersonImage(string imageName)
        {
            if (File.Exists(clsProjectSetting.ImageDefaultPath + "\\" +  imageName))
                File.Delete(clsProjectSetting.ImageDefaultPath + "\\" + imageName);
        }

        private void btnFormClose_Click(object sender, EventArgs e) =>
            this.Close();

        private void buttonMinimize_Click(object sender, EventArgs e) =>
            this.WindowState = FormWindowState.Minimized;

        private void tboxSearchBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.PersonID || 
                cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.Phone)
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

            if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.Gender)
            {
                rbtnMale.Visible = true;
                rbtnFemale.Visible = true;

                tboxSearch.Visible = false;
            }
            else if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.None)
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

            rbtnMale.Visible = false;
            rbtnFemale.Visible = false;

            rbtnMale.Checked = false;
            rbtnFemale.Checked = false;
        }

        public void SearchFilter(string filterText) => _dvPeopleData.RowFilter = filterText;

        private void rbtnMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnMale.Checked)
                SearchFilter($"Gender = '{enPersonGender.Male.ToString()}'");
        }

        private void rbtnFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnFemale.Checked)
                SearchFilter($"Gender = '{enPersonGender.Female.ToString()}'");
        }

        private void tboxSearch_TextChanged(object sender, EventArgs e)
        {
            if (tboxSearch.Text == string.Empty)
            { 
                SearchFilter(string.Empty);
                return;
            }

            if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.PersonID)
                SearchFilter($"PersonID = {tboxSearch.Text}");

            else if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.NationalNo)
                SearchFilter($"NationalNo = '{tboxSearch.Text}'");

            else if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.FirstName)
                SearchFilter($"FirstName like '%{tboxSearch.Text}%'");

            else if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.SecondName)
                SearchFilter($"SecondName like '%{tboxSearch.Text}%'");

            else if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.ThirdName)
                SearchFilter($"ThirdName like '%{tboxSearch.Text}%'");

            else if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.LastName)
                SearchFilter($"LastName like '%{tboxSearch.Text}%'");

            else if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.Nationality)
                SearchFilter($"CountryName like '%{tboxSearch.Text}%'");

            else if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.Phone)
                SearchFilter($"Phone like '%{tboxSearch.Text}%'");

            else if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.Email)
                SearchFilter($"Email like '%{tboxSearch.Text}%'");
        }

        private void CMS_Click_ShowPersonDetails(object sender, EventArgs e)
        {
            int currentRowId = GetAndSelectCurrentGridRowId();

            if (currentRowId != -1)
            { 
                frmPersonInfo personInfo = new frmPersonInfo(currentRowId);
                personInfo.PersonDataChangedHandler += LoadDataInGridDataView;
                personInfo.ShowDialog();
            }
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
            => OpenAddEditPersonFormAndHandleChanges(-1);

        private void CMS_Click_EditPersonDetails(object sender, EventArgs e)
            => OpenAddEditPersonFormAndHandleChanges(GetAndSelectCurrentGridRowId());

        private void OpenAddEditPersonFormAndHandleChanges(int id)
        {
            frmAddEditPerson addEditPersonForm
                = new frmAddEditPerson(id);

            addEditPersonForm.SaveNewOrExistPersonHandler += AddEditPersonForm_SaveNewOrExistPersonHandler; ;

            addEditPersonForm.ShowDialog();
        }

        private void AddEditPersonForm_SaveNewOrExistPersonHandler(int id)
            => LoadDataInGridDataView();


        private async void LoadDataInGridDataView()
        {
            string ErrorMessage = string.Empty;

            await Task.Run(() =>
            {
                _dvPeopleData = clsPerson.GetAllDataForFormDGV(out ErrorMessage).DefaultView;
            });

            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                MessageBox.Show(ErrorMessage, "Error Message :(",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            dgvPeople.DataSource = this._dvPeopleData;

            lblNumberOfRecords.Text = 
                this._dvPeopleData.Count.ToString();
        }

        private void btnBigCloseForm_Click(object sender, EventArgs e)
            => this.Close();
    }
}
