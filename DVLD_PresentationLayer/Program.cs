using Driving___Vehicle_License_Departement__DVLD_.Applications;
using System;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_
{

    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Application.Run(new frmAddEditLocalDrivingLicenseApplication(37));
            frmLogin frmLogin = new frmLogin();
            frmMain MainScreen;
            do
            {
                MainScreen = new frmMain();
                if (frmLogin.ShowDialog() == DialogResult.OK)
                    Application.Run(MainScreen);
            } while (MainScreen.DialogResult == DialogResult.OK);
        }
    }
}
