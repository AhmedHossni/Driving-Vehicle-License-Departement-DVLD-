using CommonUseThings;
using DVLD_BusinessLogicLayer;
using System;
using System.Data;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.Applications
{
    public partial class frmAddEditLocalDrivingLicenseApplication : frmMainStyle
    {
        clsLocalDrivingLicenseApplication _formLDLApplication;
        clsApplication _formApplication;
        public event Action AddOrUpdateNewAppicationHandler;

        public frmAddEditLocalDrivingLicenseApplication(int localDrivingLicenseId)
        {
            InitializeComponent();

            LoadComboBoxData();

            HandleIsFormInAddOrUpdateMode(localDrivingLicenseId);

            ctrlSearchForPerson1.SearchResultHandler
                += CtrlSearchForPerson1_SearchResultHandler;
        }

        private void LoadComboBoxData()
        {
            DataTable dataTable 
                = clsLicenseClass.GetAll(out string errorMessage);

            if(dataTable is null)
            {
                HandleErrorMessage(ref errorMessage);
                return;
            }

            cbLicenseClass.DataSource = dataTable;
            cbLicenseClass.DisplayMember = "ClassName";
            cbLicenseClass.ValueMember = "LicenseClassID";
        }

        private void HandleIsFormInAddOrUpdateMode(int localDrivingLicenseId)
        {
            LoadApplicationTypeDataToForm();

            if (localDrivingLicenseId != -1)
            {
                ChangeFormTextToEditMode();
                LoadLDLDataToForm(localDrivingLicenseId);
                LoadApplicationDataToForm(_formLDLApplication.ApplicationId);
            }
            else
            {
                InitializeNewModeForm();
            }
        }

        private void InitializeNewModeForm()
        {
            lblApplicationDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblCreatedByUser.Text = clsUser.SystemUser?.Username;

            _formApplication = new clsApplication();
            _formLDLApplication = new clsLocalDrivingLicenseApplication();

            this.Text = "Add New Local Driving License Application";
            lblFormLabel.Text = "New Local Driving License Appication";
        }

        public void ChangeFormTextToEditMode()
        {
            this.Text = "Edit Local Driving License Application";
            lblFormLabel.Text = "Update Local Driving License Appication";
        }

        private void LoadApplicationTypeDataToForm()
        {
            if (clsApplicationType.GetBy((int)enApplicationTypes.NewLocalDrivingLicenseService,
                out string errorMessage) is clsApplicationType applicationType
                && !(applicationType is null))
            {
                lblFees.Text = applicationType.Fees.ToString("0");
            }

            HandleErrorMessage(ref errorMessage);
        }

        private void LoadLDLDataToForm(int localDrivingLicenseAppId)
        {
            if (clsLocalDrivingLicenseApplication.GetBy
                (localDrivingLicenseAppId, out string errorMessage)
                is clsLocalDrivingLicenseApplication localDrivingLicenseApplication
                && !(localDrivingLicenseApplication is null))
            {
                _formLDLApplication = localDrivingLicenseApplication;

                lblLocalDrivingLicebseApplicationID.Text 
                    = _formLDLApplication.LocalDrivingLicenseApplicationId.ToString();

                cbLicenseClass.SelectedValue = _formLDLApplication.LicenseClassId;

            }

            HandleErrorMessage(ref errorMessage);
        }

        private void HandleErrorMessage(ref string errorMessage)
        {
            if(!string.IsNullOrEmpty(errorMessage))
                MessageBox.Show(errorMessage,
                    "Error Message :(", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }

        private void LoadApplicationDataToForm(int applicationId)
        {
            string getUserErrorMessage = string.Empty;

            if (clsApplication.GetBy
                (applicationId, out string getApplicationError)
                is clsApplication application
                && !(application is null))
            {
                _formApplication = application;

                lblCreatedByUser.Text =
                    clsUser.GetBy(_formApplication.CreatedByUserID, out getUserErrorMessage)?.Username;               

                lblFees.Text = _formApplication.PaidFees.ToString("0");

                lblApplicationDate.Text
                    = _formApplication.ApplicationDate.ToString("dd/MM/yyyy");

                ctrlSearchForPerson1.LoadPersonDetails(_formApplication.PersonId);
            }

            HandleErrorMessage(ref getApplicationError);
            HandleErrorMessage(ref getUserErrorMessage);
        }

        private bool LoadDataFromForm(out string errorMessage)
        {
            _formLDLApplication.LicenseClassId
                = (int)cbLicenseClass.SelectedValue;

            clsApplicationType applicationType 
                = clsApplicationType.GetBy((int)enApplicationTypes.NewLocalDrivingLicenseService, out errorMessage);

            if (applicationType is null)
                return false;

            if(_formApplication.Id == -1)
            {
                _formApplication.ApplicationDate = DateTime.Now;
                _formApplication.LastStatusDate = DateTime.Now;
                _formApplication.ApplicaionTypeID = applicationType.Id;
                _formApplication.ApplicaionStatus = enApplicationStatus.New;
                _formApplication.PaidFees = applicationType.Fees;
                _formApplication.CreatedByUserID = clsUser.SystemUser.Id;
            }

            return true;
        }

        private void CtrlSearchForPerson1_SearchResultHandler(int personId)
            => _formApplication.PersonId = personId;

        private bool IsPersonHaveSameLicenseClassApplication()
        {
            bool result = clsApplication.
                IsPersonHaveAllreadySameOpenApplication(_formApplication.PersonId,
                (int)cbLicenseClass.SelectedValue, out string errorMessage);

            HandleErrorMessage(ref errorMessage);

            return result && string.IsNullOrEmpty(errorMessage);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(_formLDLApplication.LocalDrivingLicenseApplicationId == -1
                && IsPersonHaveSameLicenseClassApplication())
            {
                MessageBox.Show($"This person with ID ({_formApplication.PersonId}) already has " +
                    $"an active license application for this local driving license class " +
                    $"\n({cbLicenseClass.GetItemText(cbLicenseClass.SelectedItem)}).",
                    "Saving Failed", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning); 

                return;
            }

            if (!LoadDataFromForm(out string errorMessage))
            {
                if (errorMessage != string.Empty)
                    MessageBox.Show(errorMessage, "Error Message :(",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Failed to load data from the form.", "Error Message :(",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (_formApplication.Save(out errorMessage))
            {
                _formLDLApplication.ApplicationId = _formApplication.Id;

                if (_formLDLApplication.Save(out errorMessage))
                {
                    lblLocalDrivingLicebseApplicationID.Text
                        = _formLDLApplication.LocalDrivingLicenseApplicationId.ToString();

                    ChangeFormTextToEditMode();

                    MessageBox.Show("The operation has been completed successfully.",
                        "Success :)",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    AddOrUpdateNewAppicationHandler?.Invoke();
                }
                
            }
            else
            {
                HandleErrorMessage(ref errorMessage);
            }
        }

        private void btnNextTab_Click(object sender, EventArgs e)
            => tctrlLicenseApplicationInfo.SelectedTab = tctrlLicenseApplicationInfo.TabPages[1];

        private void btnPreviousTab_Click(object sender, EventArgs e)
            => tctrlLicenseApplicationInfo.SelectedTab = tctrlLicenseApplicationInfo.TabPages[0];

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();
    }
}
