using DVLD_BusinessLogicLayer;
using System;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.Person_Forms
{
    public partial class ctrlSearchForPerson : UserControl
    {
        enum enComboBoxSearchBy
        {
            None,
            NationalNo,
            PersonID
        }

        public delegate void HandleSearchResultDelegate(int personIdResult);
        public event HandleSearchResultDelegate SearchResultHandler;


        public ctrlSearchForPerson()
        {
            InitializeComponent();
            cboxSearchBy.SelectedIndex = 0;
        }

        public void DisableSearchFeature(bool disable)
            => gboxSearchForPerson.Enabled = !disable;


        public void LoadPersonDetails(int personId)
        {
            ctrlPersonInfo1.LoadPersonData(personId);
        }

        private void ResetValuesWhenCBoxChange()
        {
            tboxSearch.Text = string.Empty;
        }


        private void cboxSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetValuesWhenCBoxChange();

            if (cboxSearchBy.SelectedIndex == (int)enComboBoxSearchBy.None)
            {
                tboxSearch.Visible = false;
            }
            else
            {
                tboxSearch.Visible = true;
                tboxSearch.Focus();
            }
        }


        private void btnSearchForPerson_Click(object sender, EventArgs e)
        {
            clsPerson person = null;

            if (cboxSearchBy.SelectedIndex == (int)enComboBoxSearchBy.PersonID)
                person = Search(enComboBoxSearchBy.PersonID, tboxSearch.Text);

            else if (cboxSearchBy.SelectedIndex == (int)enComboBoxSearchBy.NationalNo)
                person = Search(enComboBoxSearchBy.NationalNo, tboxSearch.Text);
            
            else
            {
                MessageBox.Show("Please select a search filter to proceed.",
                    "Error Message :(", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            HandleSearchResult(person is null ? -1 : person.Id);
        }

        private void HandleSearchResult(int personId)
        {
            ctrlPersonInfo1.LoadPersonData(personId);

            SearchResultHandler?.Invoke(personId);
        }

        private clsPerson Search(enComboBoxSearchBy searchBy, string value)
        {
            clsPerson person = null;
            string errorMessage = string.Empty;

            if (searchBy == enComboBoxSearchBy.NationalNo)
            {
                person = clsPerson.GetBy(value, out errorMessage);
            }
            else if (searchBy == enComboBoxSearchBy.PersonID)
            {
                if (int.TryParse(value, out int result))
                    person = clsPerson.GetBy(result, out errorMessage);
            }

            if (person == null)
            {
                if (!string.IsNullOrEmpty(errorMessage))
                    MessageBox.Show(errorMessage,
                        "Error Message :(", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                else
                    MessageBox.Show(
                        "No matching person found with the provided details.",
                        "Not Found",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
            }

            return person;
        }

        private void tboxSearchBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cboxSearchBy.SelectedIndex == (int)enComboBoxSearchBy.PersonID)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

    }
}
