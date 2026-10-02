using Driving___Vehicle_License_Departement__DVLD_.User_Forms;
using Driving___Vehicle_License_Departement__DVLD_.Application;
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
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            System.Windows.Forms.Application.Run(new frmAddEditLocalDrivingLicenseApplication(-1));
            //frmLogin frmLogin = new frmLogin();
            //frmMain MainScreen;
            //do
            //{
            //    MainScreen = new frmMain();
            //    if (frmLogin.ShowDialog() == DialogResult.OK)
            //        System.Windows.Forms.Application.Run(MainScreen);
            //} while (MainScreen.DialogResult == DialogResult.OK);
        }
    }
}
