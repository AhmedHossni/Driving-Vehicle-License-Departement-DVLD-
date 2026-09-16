using CommonUseThings;
using DVLD_BusinessLogicLayer;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_._person_Forms
{
    public partial class ctrlAddEdit_person : UserControl
    {
        clsPerson _person = new clsPerson();

        public event Action btnClose_Click_Handler;

        public event Action btnSave_Click_Handler;

        string oldImageName = null;

        public ctrlAddEdit_person()
        {
            InitializeComponent();

            rbtnMale.Checked = true;

            dtpDateOfBirth.MaxDate = DateTime.Today.AddYears(-18);

            LoadCBoxCountriesDataSource();

        }

        private void FillRandomPersonData()
        {
            string[] firstNames = { "Ahmed", "Mohamed", "Mahmoud", "Ali", "Ibrahim", "Youssef", "Fatima", "Maryam", "Aisha", "Zeinab" };
            string[] secondNames = { "Hassan", "Hussein", "Mostafa", "Abdullah", "Rahman", "Khaled", "Saeed", "Salem" };
            string[] thirdNames = { "Ismail", "Mahmoud", "Ali", "Ahmed", "Hamed", "Salah", "Gamal" };
            string[] lastNames = { "El-Masry", "El-Sherif", "Al-Najjar", "Al-Khatib", "Omar", "Soliman", "Barakat" };
            string[] cities = { "Cairo", "Alexandria", "Giza", "Mansoura", "Aswan", "Luxor" };

            Random rand = new Random();

            int RandonFirstNameIndex = rand.Next(firstNames.Length);

            tboxFirstName.Text = firstNames[RandonFirstNameIndex];
            tboxSecondName.Text = secondNames[rand.Next(secondNames.Length)];
            tboxThirdName.Text = thirdNames[rand.Next(thirdNames.Length)];
            tboxLastName.Text = lastNames[rand.Next(lastNames.Length)];

            long randomNationalNo = 29901010000000 + rand.Next(1000000, 9999999);
            tboxNationalNo.Text = "N" + randomNationalNo.ToString();

            string firstNameEn = "user" + rand.Next(100, 999);
            tboxEmail.Text = $"{firstNameEn}@example.com";
            tboxPhone.Text = "01" + rand.Next(0, 3) + rand.Next(10000000, 99999999);

            rtboxAddress.Text = $"Al Nile Road {rand.Next(1, 50)}, {cities[rand.Next(cities.Length)]}";

            if (RandonFirstNameIndex <= 5)
            {
                rbtnMale.Checked = true;
            }
            else
            {
                rbtnFemale.Checked = true;
            }

            int randomYears = rand.Next(20, 50);
            dtpDateOfBirth.Value = DateTime.Now.AddYears(-randomYears).AddDays(rand.Next(1, 365));

            if (cboxCountryName.Items.Count > 0)
            {
                cboxCountryName.SelectedIndex = rand.Next(cboxCountryName.Items.Count);
            }

            _person.FirstName = tboxFirstName.Text;
            _person.SecondName = tboxSecondName.Text;
            _person.ThirdName = tboxThirdName.Text;
            _person.LastName = tboxLastName.Text;

            _person.NationalNo = tboxNationalNo.Text;
            _person.Email = tboxEmail.Text;
            _person.Address = rtboxAddress.Text;
            _person.Gender = rbtnMale.Checked ? enPersonGender.Male : enPersonGender.Female;

            _person.DateOfBirth = dtpDateOfBirth.Value;
            _person.Phone = tboxPhone.Text;
            _person.NationalCountryName = cboxCountryName.Text;

            if (cboxCountryName.SelectedValue != null)
            {
                _person.NationalCountryID = Convert.ToInt32(cboxCountryName.SelectedValue);
            }
        }

        public void LoadCBoxCountriesDataSource()
        {
            DataTable Countries = clsCountries.GetAll(out string errorMessage);

            if (string.IsNullOrEmpty(errorMessage))
            {
                cboxCountryName.DataSource = Countries;

                cboxCountryName.DisplayMember = "CountryName";

                cboxCountryName.ValueMember = "CountryID";
            }
            else
                MessageBox.Show(errorMessage,
                    "Error Message :(",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }

        public void Load_personData(int id)
        {
            if(id == -1)
            {
                Load_personImage("", enPersonGender.Male);
                FillRandomPersonData();
                return;
            }

            _person = clsPerson.GetById(id, out string errorMessage);

            if (_person != null)
            {
                lblPersonIdValue.Text = _person.Id.ToString();
                tboxFirstName.Text = _person.FirstName.ToString();
                tboxSecondName.Text = _person.SecondName.ToString();
                tboxThirdName.Text = _person.ThirdName.ToString();
                tboxLastName.Text = _person.LastName.ToString();


                if (_person.Gender == enPersonGender.Male) rbtnMale.Checked = true;
                else rbtnFemale.Checked = true;

                tboxEmail.Text = _person.Email;
                rtboxAddress.Text = _person.Address;

                dtpDateOfBirth.Value = _person.DateOfBirth;
                tboxPhone.Text = _person.Phone;
                tboxNationalNo.Text = _person.NationalNo;

                cboxCountryName.SelectedValue = _person.NationalCountryID;

                Load_personImage(_person.ImageName, _person.Gender);
            }
            else
            {
                MessageBox.Show(errorMessage,
                    "Error Message :(",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void Load_personImage(string imageName, enPersonGender gender)
        {
            string ImgFullPath = null;

            try
            {
                string imagesPath = clsProjectSetting.ImageDefaultPath;

                if (!string.IsNullOrEmpty(imageName))
                {
                    ImgFullPath = $"{imagesPath}\\{imageName}";

                    pboxPersonImage.Image = Image.FromFile(ImgFullPath);
                }
                else
                {
                    ImgFullPath = gender == enPersonGender.Male ?
                        $@"{imagesPath}\Default_Male_Img.png" :
                        $@"{imagesPath}\Default_Female_Img.png";

                    llblRemovePersonImage.Enabled = false;

                    pboxPersonImage.Image = Image.FromFile(ImgFullPath);
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

        private void btnClose_Click(object sender, EventArgs e)
            => btnClose_Click_Handler.Invoke();

        private void LoadPersonDataFromForm()
        {
            _person.FirstName = tboxFirstName.Text;
            _person.SecondName = tboxSecondName.Text;
            _person.ThirdName = tboxThirdName.Text;
            _person.LastName = tboxLastName.Text;

            _person.NationalNo = tboxNationalNo.Text;
            _person.Email = tboxEmail.Text;
            _person.Address = rtboxAddress.Text;
            _person.Gender = rbtnMale.Checked ? enPersonGender.Male : enPersonGender.Female;

            _person.DateOfBirth = dtpDateOfBirth.Value;
            _person.Phone = tboxPhone.Text;
            _person.NationalCountryName = cboxCountryName.Text;

            if (cboxCountryName.SelectedValue != null)
                _person.NationalCountryID = 
                    Convert.ToInt32(cboxCountryName.SelectedValue);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string errorMessage = string.Empty;

            LoadPersonDataFromForm();

            string CopiedImageFullName = _person.ImageName;

            _person.ImageName = Guid.NewGuid().ToString() +
                    Path.GetExtension(_person.ImageName);

            _person.Save(out errorMessage, out int id);

            if(string.IsNullOrEmpty(errorMessage))
            {
                btnSave_Click_Handler.Invoke();

                if (!string.IsNullOrEmpty(oldImageName))
                {
                    File.Copy(CopiedImageFullName,
                        clsProjectSetting.ImageDefaultPath + "\\" + _person.ImageName);

                    if(File.Exists(clsProjectSetting.ImageDefaultPath + "\\" + oldImageName))
                    { 
                        File.Delete(clsProjectSetting.ImageDefaultPath + "\\" + oldImageName);
                        oldImageName = null;
                    }
                }

                MessageBox.Show("The operation has been completed successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                lblPersonIdValue.Text = id.ToString();
            }
            else
            {
                MessageBox.Show(errorMessage,
                    "Error Message :(",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void llblSetPersonImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select Image";

                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                string oldImagePath = _person.ImageName;

                string oldDirectory = "";

                if (!string.IsNullOrEmpty(oldImagePath) && File.Exists(oldImagePath))
                {
                    oldDirectory = Path.GetDirectoryName(oldImagePath);

                    openFileDialog.InitialDirectory = oldDirectory;

                    openFileDialog.CheckFileExists = true;
                    openFileDialog.CheckPathExists = true;

                }

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    oldImageName = _person.ImageName;

                    _person.ImageName = openFileDialog.FileName;

                    MessageBox.Show("Image is selected successfully\nImage Path : " + _person.ImageName,
                        "Selected Image",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    pboxPersonImage.Image = Image.FromFile(_person.ImageName);

                    llblRemovePersonImage.Enabled = true;
                }
            }
        }

        private void llblRemovePersonImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            llblRemovePersonImage.Enabled = false;
            oldImageName = _person?.ImageName;
            _person.ImageName = "";
            pboxPersonImage.Image = null;

        }
    }
}
