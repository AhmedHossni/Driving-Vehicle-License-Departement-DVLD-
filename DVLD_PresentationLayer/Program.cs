using Driving___Vehicle_License_Departement__DVLD_.People_Forms;
using Driving___Vehicle_License_Departement__DVLD_.User_Forms;
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


            //Application.Run(new frmUsersList());

            frmMain MainScreen;
            frmLogin frmLogin = new frmLogin();
            do
            {
                MainScreen = new frmMain();
                if (frmLogin.ShowDialog() == DialogResult.OK)
                    Application.Run(MainScreen);
            } while (MainScreen.DialogResult == DialogResult.OK);
        }
    }
}
