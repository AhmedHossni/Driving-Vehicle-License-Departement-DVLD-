using DVLD_BusinessLogicLayer;
using System;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.Test.Test_Type
{
    public partial class frmEditTestType : Form
    {
        clsTestType _TestType = null;
        public event Action ApplicationTypeDataChangeHandler;

        public frmEditTestType(int id)
        {
            InitializeComponent();
            LoadApplicatioTypeDataToForm(id);
        }

        private void LoadApplicatioTypeDataToForm(int id)
        {
            if (id == -1)
            {
                tboxTestTypeName.Enabled = false;
                tboxTestTypeDescription.Enabled = false;
                tboxTestTypeFees.Enabled = false;
                btnSave.Enabled = false;
            }

            _TestType = clsTestType.GetBy(id, out string errorMessage);

            if (!(_TestType is null))
            {
                lblAppTypeIdValue.Text = _TestType.Id.ToString();
                tboxTestTypeName.Text = _TestType.Title;
                tboxTestTypeDescription.Text = _TestType.Description;
                tboxTestTypeFees.Text = _TestType.Fees.ToString("0.00");
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
            if (_TestType is null)
                return;

            _TestType.Title = tboxTestTypeName.Text;
            _TestType.Description = tboxTestTypeDescription.Text;
            _TestType.Fees = Convert.ToDecimal(tboxTestTypeFees.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            LoadAppTypeDataFromForm();

            if (!(_TestType is null))
            {
                if (_TestType.Save(out string errorMessage))
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

        private void tboxAppTypeFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            char decimalSeparator = 
                System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            
            TextBox txt = sender as TextBox;

            if (char.IsControl(e.KeyChar) 
                || char.IsDigit(e.KeyChar))
            {
                return;
            }

            if (e.KeyChar == '.' || e.KeyChar == ',' || e.KeyChar == decimalSeparator)
            {
                if (txt.Text.Contains(".") 
                    || txt.Text.Contains(",") 
                    || txt.Text.Contains(decimalSeparator.ToString()))
                {
                    e.Handled = true;
                }
                return;
            }

            e.Handled = true;
        }
    }
}
