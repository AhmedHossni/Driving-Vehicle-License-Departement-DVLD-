using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Driving___Vehicle_License_Departement__DVLD_
{
    public class frmMainStyle : Form
    {
        private int cornerRadius = 20;

        public frmMainStyle()
        {

            // Change form border style and radius
            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;

            ApplyFormRegion();
        }

        #region Change Form Position Without Form Borders
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        protected void frm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion

        private void ApplyFormRegion()
        {
            using (GraphicsPath path = GetRoundedPath(new Rectangle(0, 0, this.Width, this.Height), cornerRadius))
            {
                this.Region = new Region(path);
            }
        }

        // إعادة تطبيق القص عند تغيير حجم النافذة
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ApplyFormRegion();
        }

        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float diameter = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            return path;
        }
    }
}
