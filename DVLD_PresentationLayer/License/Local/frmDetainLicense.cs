using Driving___Vehicle_License_Departement__DVLD_.Driver;
using DVLD_BusinessLogicLayer;
using System;
using System.Windows.Forms;
using static Driving___Vehicle_License_Departement__DVLD_.License.International.Control.ctrlLicenseFilter;

namespace Driving___Vehicle_License_Departement__DVLD_.License.Local
{
    public partial class frmDetainLicense : frmMainStyle
    {
        SearchEventArgs _searchResult;

        public frmDetainLicense()
        {
            InitializeComponent();

            ctrlLicenseFilter1.OnSearchDone 
                += CtrlLicenseFilter1_OnSearchDone;

            ctrlDetainInfo1.LoadDefaultData();

            ctrlDetainInfo1.EnabledAddFees(false);
        }

        private void CtrlLicenseFilter1_OnSearchDone(object sender, SearchEventArgs searchResult)
        {
            if(searchResult != null)
            {
                if(IsLicenseDetained(searchResult.LocalLicenseID))
                    return;

                _searchResult = searchResult;
                ctrlDriverLicenseInfo1.LoadDriverLicenseInfo(searchResult.LocalDLAppID);
                ctrlDetainInfo1.SetLicenseID(searchResult.LocalLicenseID);
                ctrlDetainInfo1.EnabledAddFees(true);

                btnDetainLicense.Enabled = true;
                llblShowLicenseHistory.Enabled = true;
                llblShowLicenseInfo.Enabled = true;
            }
            else
            {
                btnDetainLicense.Enabled = false;
                ctrlDetainInfo1.EnabledAddFees(false);
                llblShowLicenseHistory.Enabled = false;
                llblShowLicenseInfo.Enabled = false;

                ctrlDetainInfo1.LoadDefaultData();
            }
        }

        private bool IsLicenseDetained(int licenseID)
        {
            string errorMessage = string.Empty;

            if (clsDetainedLicense.IsLicenseDetained(licenseID,
                out errorMessage))
            {
                MessageBox.Show("Selected license is detained. " +
                    "You cannot perform this operation until it is released.",
                                "Detained License",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show($"Error: {errorMessage}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            return false;
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            clsDetainedLicense detainedLicense = new clsDetainedLicense();
            detainedLicense.LicenseID = _searchResult.LocalLicenseID;
            detainedLicense.DetainDate = DateTime.Now;
            detainedLicense.FineFees = ctrlDetainInfo1.DetainFees;
            detainedLicense.CreatedByUserID = clsUser.SystemUser.Id;
            detainedLicense.IsReleased = false;

            if (detainedLicense.Save(out string errorMessage))
            {
                MessageBox.Show($"License Detained Successfully with ID = {detainedLicense.DetainID}",
                    "License Detained",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnDetainLicense.Enabled = false;

                ctrlDriverLicenseInfo1.LoadDriverLicenseInfo(_searchResult.LocalDLAppID);
            }
            else
            {
                if (!string.IsNullOrEmpty(errorMessage))
                    MessageBox.Show($"Error: {errorMessage}", "Database Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();

        private void llblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmLocalDriverLicenseInfo(_searchResult.LocalDLAppID).ShowDialog();
        }

        private void llblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmDriverLicenseHistory(_searchResult.DriverID).ShowDialog();
        }  
    }
}
