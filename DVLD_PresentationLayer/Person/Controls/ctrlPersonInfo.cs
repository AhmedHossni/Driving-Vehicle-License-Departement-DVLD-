using CommonUseThings;
using DVLD_BusinessLogicLayer;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_.Person_Forms
{
    public partial class ctrlPersonInfo : UserControl
    {
        private int _personId = -1;

        public event Action PersonDataChangedHandler;

        public ctrlPersonInfo()
        {
            InitializeComponent();
        }

        private void ResetDiffultyValues()
        {
            lblPersonIdValue.Text = "N\\A";
            lblPersonNameValue.Text = "N\\A";
            lblPersonNationalNoValue.Text = "N\\A";
            lblPersonGenderValue.Text = "N\\A";
            lblPersonEmailValue.Text = "N\\A";
            lblPersonAddressValue.Text = "N\\A";
            lblPersonDateOfBirthValue.Text = "N\\A";
            lblPersonPhoneValue.Text = "N\\A";
            lblblPersonCountryValue.Text = "N\\A";
        }

        public void LoadPersonData(int id)
        {
            if (id == -1)
            {
                llblEditPerson.Enabled = false;

                if(_personId != -1)
                    ResetDiffultyValues();

                return;
            }

            _personId = id;

            clsPerson person = clsPerson.GetBy(id, out string errorMessage);

            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage,
                    "Error Message :(",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            if (person != null)
            {
                lblPersonIdValue.Text = person.Id.ToString();
                lblPersonNameValue.Text = person.FullName();
                lblPersonNationalNoValue.Text = person.NationalNo;

                lblPersonGenderValue.Text = person.Gender.ToString();
                lblPersonEmailValue.Text = person.Email;
                lblPersonAddressValue.Text = person.Address;

                lblPersonDateOfBirthValue.Text = person.DateOfBirth.ToString("d");
                lblPersonPhoneValue.Text = person.Phone;
                lblblPersonCountryValue.Text = person.NationalCountryName;

                LoadPersonImage(person.ImageName, person.Gender);
            }
            
        }

        private void LoadPersonImage(string imageName, enPersonGender gender)
        {
            string ImgFullPath = null;
            try
            {
                string imagesPath = clsProjectSetting.ImageDefaultPath;

                if (!string.IsNullOrEmpty(imageName))
                {
                    ImgFullPath = $"{imagesPath}\\{imageName}";

                    using (var image = Image.FromFile(ImgFullPath))
                    {
                        pboxPersonImage.Image = new Bitmap(image);
                    }
                }
                else
                {
                    ImgFullPath = gender == enPersonGender.Male ?
                        $@"{imagesPath}\Default_Male_Img.png" :
                        $@"{imagesPath}\Default_Female_Img.png";

                    using (var image = Image.FromFile(ImgFullPath))
                    {
                        pboxPersonImage.Image = new Bitmap(image);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show($"Image Path : {ex.Message}",
                    "Image Not Found :(",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"{ex.Message}" +
                    $"\nImage Path : {(ImgFullPath == string.Empty ? "Empty Path" : ImgFullPath)}",
                    "Error Message :(",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void llblEditPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPerson addEditPersonForm = 
                new frmAddEditPerson(_personId);

            addEditPersonForm.SaveNewOrExistPersonHandler +=
                AddEditPersonForm_SaveNewOrExistPersonHandler;

            addEditPersonForm.ShowDialog();
        }

        private void AddEditPersonForm_SaveNewOrExistPersonHandler(int id)
        {
            LoadPersonData(id);

            PersonDataChangedHandler?.Invoke();
        }
    }
}