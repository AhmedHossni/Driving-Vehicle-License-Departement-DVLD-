using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_
{
    public class frmMainStyle : Form
    {
        public frmMainStyle()
        {
            this.StartPosition = FormStartPosition.CenterParent;
        }

        protected override void WndProc(ref Message m)
        {
            // WM_NCLBUTTONDBLCLK represents a double-click on a non-client area (such as the title bar)
            const int WM_NCLBUTTONDBLCLK = 0x00A3;

            // WM_SYSCOMMAND is used for system-level commands, and SC_MAXIMIZE is the command to maximize the window
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MAXIMIZE = 0xF030;

            // Prevent the window from maximizing when double-clicking the title bar
            if (m.Msg == WM_NCLBUTTONDBLCLK)
            {
                return; // Ignore the double-click event on the title bar border
            }

            // Prevent any other attempts to maximize the window (e.g., via the maximize button or system menu)
            if (m.Msg == WM_SYSCOMMAND && (m.WParam.ToInt32() & 0xFFF0) == SC_MAXIMIZE)
            {
                return; // Block the maximize action
            }

            // Pass all other window messages to the base class handler
            base.WndProc(ref m);
        }
    }
}
