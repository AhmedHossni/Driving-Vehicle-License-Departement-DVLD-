using DVLD_BusinessLogicLayer;
using System;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.Applications.Application_Types
{
    public partial class frmEditAppType : frmMainStyle
    {
        clsApplicationType _applicationType = null;
        public event Action ApplicationTypeDataChangeHandler;

        public frmEditAppType(int id)
        {
            InitializeComponent();
            LoadApplicatioTypeDataToForm(id);
        }

        private void LoadApplicatioTypeDataToForm(int id)
        {
            if (id == -1)
            {                
                tboxAppTypeName.Enabled = false;
                tboxAppTypeFees.Enabled = false;
                btnSave.Enabled = false;
            }

            _applicationType = clsApplicationType.GetBy(id, out string errorMessage);

            if (!(_applicationType is null))
            {
                lblAppTypeIdValue.Text = _applicationType.Id.ToString();
                tboxAppTypeName.Text = _applicationType.Title;
                tboxAppTypeFees.Text = _applicationType.Fees.ToString("0.00");
            }
            else
                HandleErrorMessage(errorMessage);
        }

        private void HandleErrorMessage(string errorMessage)
        {
            if (!string.IsNullOrEmpty(errorMessage))
                MessageBox.Show(errorMessage,
                    "Error Message :(",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();

        private void LoadAppTypeDataFromForm()
        {
            if (_applicationType is null)
                return;

            _applicationType.Title = tboxAppTypeName.Text;
            _applicationType.Fees = Convert.ToDecimal(tboxAppTypeFees.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            LoadAppTypeDataFromForm();

            if (!(_applicationType is null))
            {
                if(_applicationType.Save(out string errorMessage))
                {
                    ApplicationTypeDataChangeHandler?.Invoke();

                    MessageBox.Show("Operation Done Successfully",
                        "Important Message :)",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else 
                    HandleErrorMessage(errorMessage);
            }
        }

        private void tboxAppTypeFees_TextChanged(object sender, EventArgs e)
        {

        }

        private void tboxAppTypeFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            char decimalSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            TextBox txt = sender as TextBox;

            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar))
            {
                return;
            }

            if (e.KeyChar == '.' || e.KeyChar == ',' || e.KeyChar == decimalSeparator)
            {
                if (txt.Text.Contains(".") || txt.Text.Contains(",") || txt.Text.Contains(decimalSeparator.ToString()))
                {
                    e.Handled = true;
                }
                return;
            }

            e.Handled = true;
        }
    }
}
