using CommonUseThings;
using Driving___Vehicle_License_Departement__DVLD_.Applications;
using Driving___Vehicle_License_Departement__DVLD_.Driver;
using Driving___Vehicle_License_Departement__DVLD_.License;
using Driving___Vehicle_License_Departement__DVLD_.Test.Tests;
using DVLD_BusinessLogicLayer;
using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.Local_Driving_License.Applications
{
    public partial class frmLocalDrivingLicenseApplicationsList : frmMainStyle
    {
        private Point _point
            = new Point();
        enum enComboBoxSelections
        {
            None,
            LDLAppID,
            NationalNo,
            FullName,
            Status
        }

        private DataView _dvLocalDrivingLicenseApplicationsData
            = new DataView();
        public frmLocalDrivingLicenseApplicationsList()
        {
            InitializeComponent();

            dgvLocalDrivingLicenseApplicationsData.AutoSizeColumnsMode 
                = DataGridViewAutoSizeColumnsMode.Fill;

            LoadDataInGridDataView();

            cboxSearchBy.SelectedIndex
                = (int)enComboBoxSelections.None;

            cboxApplicationStatus.SelectedIndex
                = (int)enApplicationStatus.All;
        }

        private void UpdateTestSchedulingUI(int localDLAppId, int preTestTypeId,
            ToolStripMenuItem menuItem)
        {
            if (clsTestAppointment.DidExamineePass(localDLAppId, 1, out string errorMessage))
            {
                menuItem.Enabled = true;
            }
            else
            {
                if (string.IsNullOrEmpty(errorMessage))
                    menuItem.Enabled = false;
                else
                    HandleErrorMessage(ref errorMessage);
            }
        }

        private void ManagingAvailableTests(int localDLAppId)
        {
            string localDLAppStatus = GetCurrentDGVStatus();
            if (localDLAppStatus == enApplicationStatus.Cancel.ToString() ||
                localDLAppStatus == enApplicationStatus.Complete.ToString())
            {
                secduleToolStripMenuItem.Enabled = false;
                return;
            }
            else
                secduleToolStripMenuItem.Enabled = true;


            int selectedPassedTest = GetSelectedItemPassedTests();

            secduleToolStripMenuItem.Enabled = true;

            if (selectedPassedTest == 0)
            {
                scheduleVisionTestToolStripMenuItem.Enabled = true;
                scheduleWrittenTestToolStripMenuItem.Enabled = false;
                scheduleStreetTestToolStripMenuItem.Enabled = false;
            }
            else if (selectedPassedTest == 1)
            {
                scheduleVisionTestToolStripMenuItem.Enabled = false;
                UpdateTestSchedulingUI(localDLAppId, (int)enTestTypes.VisionTest,
                    scheduleWrittenTestToolStripMenuItem);
                scheduleStreetTestToolStripMenuItem.Enabled = false;
            }
            else if (selectedPassedTest == 2)
            {
                scheduleVisionTestToolStripMenuItem.Enabled = false;
                scheduleWrittenTestToolStripMenuItem.Enabled = false;
                UpdateTestSchedulingUI(localDLAppId, (int)enTestTypes.WrittenTest, 
                    scheduleStreetTestToolStripMenuItem);
            }
            else if (selectedPassedTest == 3) 
            {
                secduleToolStripMenuItem.Enabled = false;
            }
        }
        
        private void IssueLicenseAvailability(int localDLAppId)
        {
            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;

            if (GetSelectedItemPassedTests() != 3)
                return;

            if (!clsLicense.IsThisLDLAppHaveLocalDrivingLicense(localDLAppId, out string errorMessage))
            {
                if (string.IsNullOrEmpty(errorMessage))
                    issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = true;
                else
                    frmMainStyle.HandleErrorMessage(ref errorMessage, "error Message :(");
            }
        }

        private void GetAndSelectCurrentGridRowId(out int LDLAppId, 
            out string NationalNo, out int passedTests,
            out string applicatioStatus)
        {
            DataGridView.HitTestInfo hitInfo = 
                dgvLocalDrivingLicenseApplicationsData.HitTest(_point.X, _point.Y);

            if (hitInfo.RowIndex != -1)
            {
                dgvLocalDrivingLicenseApplicationsData.ClearSelection();
                dgvLocalDrivingLicenseApplicationsData.Rows[hitInfo.RowIndex].Selected = true;
                dgvLocalDrivingLicenseApplicationsData.CurrentCell = dgvLocalDrivingLicenseApplicationsData.Rows[hitInfo.RowIndex].Cells[0];
                LDLAppId = (int)dgvLocalDrivingLicenseApplicationsData.CurrentCell.Value;
                NationalNo = (string)dgvLocalDrivingLicenseApplicationsData.Rows[hitInfo.RowIndex].Cells[2].Value;
                passedTests = (int)dgvLocalDrivingLicenseApplicationsData.Rows[hitInfo.RowIndex].Cells[5].Value;
                applicatioStatus = (string)dgvLocalDrivingLicenseApplicationsData.Rows[hitInfo.RowIndex].Cells[6].Value;
            }
            else
            {
                LDLAppId = -1;
                NationalNo = string.Empty;
                passedTests = 0;
                applicatioStatus = string.Empty;
            }

        }

        private int GetSelectedItemPassedTests()
        {
            GetAndSelectCurrentGridRowId(out int LDLAppId, out string NationalNo,
                out int passedTests, out string applicationStatus);

            return passedTests;
        }

        private int GetAndSelectCurrentGridRowId()
        {
            GetAndSelectCurrentGridRowId(out int LDLAppId, out string NationalNo,
                out int passedTests, out string applicationStatus);

            return LDLAppId;
        }

        private void dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            _point = dgvLocalDrivingLicenseApplicationsData.PointToClient(Cursor.Position);
        }

        private void tboxSearchBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.LDLAppID)
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
                cboxApplicationStatus.Visible = false;
            }
            else if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.Status)
            {
                tboxSearch.Visible = false;
                cboxApplicationStatus.Visible = true;
                cboxApplicationStatus.Focus();
                cboxApplicationStatus_SelectedIndexChanged(cboxApplicationStatus, e);
            }
            else
            {
                cboxApplicationStatus.Visible = false;
                tboxSearch.Visible = true;
                tboxSearch.Focus();
            }
        }
        
        private void cboxApplicationStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboxApplicationStatus.SelectedIndex == (int)enApplicationStatus.All)
                SearchFilter(string.Empty);

            else if (cboxApplicationStatus.SelectedIndex == (int)enApplicationStatus.New)
                SearchFilter($"Status like '{enApplicationStatus.New.ToString()}'");

            else if (cboxApplicationStatus.SelectedIndex == (int)enApplicationStatus.Cancel)
                SearchFilter($"Status like '{enApplicationStatus.Cancel.ToString()}'");

            else if (cboxApplicationStatus.SelectedIndex == (int)enApplicationStatus.Complete)
                SearchFilter($"Status like '{enApplicationStatus.Complete.ToString()}'");

        }

        private void ResetValuesWhenCBoxChange()
        {
            tboxSearch.Text = string.Empty;

            SearchFilter(string.Empty);
        }

        public void SearchFilter(string filterText)
        {
            _dvLocalDrivingLicenseApplicationsData.RowFilter = filterText;

            lblRecordsCount.Text = _dvLocalDrivingLicenseApplicationsData.Count.ToString();
        } 

        private void tboxSearch_TextChanged(object sender, EventArgs e)
        {
            if (tboxSearch.Text == string.Empty)
            {
                SearchFilter(string.Empty);
                return;
            }

            if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.LDLAppID)
                SearchFilter($"L.D.L.AppID = {tboxSearch.Text}");

            else if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.NationalNo)
                SearchFilter($"[National No.] like '%{tboxSearch.Text}%'");

            else if (cboxSearchBy.SelectedIndex == (int)enComboBoxSelections.FullName)
                SearchFilter($"[Full Name] like '%{tboxSearch.Text}%'");
        }

        private async void LoadDataInGridDataView()
        {
            string ErrorMessage = string.Empty;

            await Task.Run(() =>
            {
                this._dvLocalDrivingLicenseApplicationsData 
                    = clsLocalDrivingLicenseApplication.GetAllDataForFormDGV(out ErrorMessage).DefaultView;
            });

            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                MessageBox.Show(ErrorMessage, "Error Message :(",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            dgvLocalDrivingLicenseApplicationsData.DataSource 
                = this._dvLocalDrivingLicenseApplicationsData;

            lblRecordsCount.Text =
                this._dvLocalDrivingLicenseApplicationsData.Count.ToString();
        }

        private int GetApplicationIdByLDLAppId(int localDLAppID)
        {
            clsLocalDrivingLicenseApplication localDrivingLicenseApplication
                = clsLocalDrivingLicenseApplication.GetBy(localDLAppID, out string errorMessage);

            if (!(localDrivingLicenseApplication is null))
                return localDrivingLicenseApplication.ApplicationId;
            
            HandleErrorMessage(ref errorMessage);

            return -1;
        }

        private void CMS_Click_DeleteLDLApplication(object sender, EventArgs e)
        {
            int currentLDLAppId = GetAndSelectCurrentGridRowId();

            if (MessageBox.Show($"Are you sure you want to delete local driving license application with id equals ({currentLDLAppId})",
                    "Warning Message",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error) == DialogResult.No)
                return;

            int applicationId = GetApplicationIdByLDLAppId(currentLDLAppId);
            if (applicationId == -1)
                return;

            if (clsLocalDrivingLicenseApplication.Delete(currentLDLAppId, out string errorMessage))
            {
                if (clsApplication.Delete(applicationId, out errorMessage))
                {
                    MessageBox.Show($"Local driving license application with id equals ({currentLDLAppId}) is deleted successfully",
                        "Operation Done Successfully :)",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    
                    LoadDataInGridDataView();
                }
                else
                    HandleErrorMessage(ref errorMessage);
            }
            else
            {
                HandleErrorMessage(ref errorMessage);
            }

        }

        private void CMS_Click_EditLDLApplication(object sender, EventArgs e)
            => CallAddEditLocalDrivingLicenseForm(GetAndSelectCurrentGridRowId());

        private void CMS_Click_CancelLDLApplication(object sender, EventArgs e)
        {
            int currentLDLApplicationId = GetAndSelectCurrentGridRowId();

            if(clsApplication.UpdateStatusByLDLAppID(currentLDLApplicationId, enApplicationStatus.Cancel,
                DateTime.Now, out string errorMessage))
            {
                MessageBoxOperationDoneSuccessfully($"Cancel application with id equal ({currentLDLApplicationId}) " +
                    $"is done successfully.");

                LoadDataInGridDataView();
            }
            else
                HandleErrorMessage(ref errorMessage);
        }
        
        private void CMS_Click_ShowLDLApplicationDetails(object sender, EventArgs e)
        {
            new frmShowLDLAppInfo(GetAndSelectCurrentGridRowId()).ShowDialog();
        }

        private void MessageBoxOperationDoneSuccessfully(string text)
        {
            MessageBox.Show(text, "Operation Done Successfully :)",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void HandleErrorMessage(ref string errorMessage)
        {
            if (!string.IsNullOrEmpty(errorMessage))
                MessageBox.Show(errorMessage,"Error Message :(",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CallAddEditLocalDrivingLicenseForm(int LDLAppId)
        {
            frmAddEditLocalDrivingLicenseApplication addEditLDLApp
                = new frmAddEditLocalDrivingLicenseApplication(LDLAppId);

            addEditLDLApp.AddOrUpdateNewAppicationHandler += LoadDataInGridDataView;

            addEditLDLApp.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();

        private void btnAddPerson_Click(object sender, EventArgs e)
            => CallAddEditLocalDrivingLicenseForm(-1);

        private void cmsLDLApplication_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int localDLAppID = GetAndSelectCurrentGridRowId();

            if(localDLAppID == -1)
            {
                e.Cancel = true;
                return;
            }

            ManagingAvailableTests(localDLAppID);

            IssueLicenseAvailability(localDLAppID);

            CanShowDriverLicenseInfo();

            UpdateApplicationEditDeleteMenuItemsState(localDLAppID);
            
            UpdateCancelApplicationMenuItemState(GetCurrentDGVStatus());
        }

        private void UpdateApplicationEditDeleteMenuItemsState(int localDLAppID)
        {
            if(clsTestAppointment.HaveAnyTestAppointment(localDLAppID, (int)enTestTypes.VisionTest
                , out string errorMessage))
            {
                editApplicationToolStripMenuItem.Enabled = false;
                deleteApplicationToolStripMenuItem.Enabled = false;
            }
            else
            {
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    frmMainStyle.HandleErrorMessage(ref errorMessage, "errorMessage");
                    return;
                }

                editApplicationToolStripMenuItem.Enabled = true;
                deleteApplicationToolStripMenuItem.Enabled = true;
            }
        }

        private void UpdateCancelApplicationMenuItemState(string status)
        {
            if (status == enApplicationStatus.Complete.ToString())
                cancelApplicationToolStripMenuItem.Enabled = false;
            else
            {
                cancelApplicationToolStripMenuItem.Enabled = true;
            }
        }

        private string GetCurrentDGVStatus()
        {
            GetAndSelectCurrentGridRowId(out int localDLAppID, out string nationalNo,
                out int passedTests, out string status);

            return status;
        }
        private string GetCurrentRowNationalNo()
        {
            GetAndSelectCurrentGridRowId(out int localDLAppID, out string nationalNo,
                out int passedTests, out string status);

            return nationalNo;
        }

        private void CanShowDriverLicenseInfo()
        {
            string status = GetCurrentDGVStatus();

            if (status == enApplicationStatus.Complete.ToString())
                showLicenseToolStripMenuItem.Enabled = true;
            else
                showLicenseToolStripMenuItem.Enabled = false;

        }

        private void OpenTestAppointmentsForm(enTestTypes testType, int localDLAppID)
        {
            frmTestAppointments frmTestAppointments
                = new frmTestAppointments(testType,
                localDLAppID);

            frmTestAppointments.ShowDialog();

            LoadDataInGridDataView();
        }

        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int localDLAppID = GetAndSelectCurrentGridRowId();

            OpenTestAppointmentsForm(enTestTypes.VisionTest, localDLAppID);
        }

        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int localDLAppID = GetAndSelectCurrentGridRowId();

            OpenTestAppointmentsForm(enTestTypes.WrittenTest, localDLAppID);
        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int localDLAppID = GetAndSelectCurrentGridRowId();

            OpenTestAppointmentsForm(enTestTypes.PracticalTest, localDLAppID);
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueLicense frmIssueLicense
                = new frmIssueLicense(GetAndSelectCurrentGridRowId());

            frmIssueLicense.ShowDialog();

            LoadDataInGridDataView();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmDriverLicenseInfo(GetAndSelectCurrentGridRowId()).ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nationalNo = GetCurrentRowNationalNo();

            frmDriverLicenseHistory frmDriverLicenseHistory
                = new frmDriverLicenseHistory(nationalNo);

            frmDriverLicenseHistory.ShowDialog();
        }
    }
}