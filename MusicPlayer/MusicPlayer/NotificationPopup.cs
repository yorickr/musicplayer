using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer
{
    public partial class NotificationPopup : Form
    {
        MainForm f;
        public NotificationPopup(MainForm f)
        {
            InitializeComponent();
            this.f = f;
        }

        private void NotificationPopup_Shown(object sender, EventArgs e)
        {
            System.Drawing.Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;
            this.Left = workingRectangle.Width - this.Width -10;
            this.Top = workingRectangle.Height - this.Height -10;
            this.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            f.WindowState = FormWindowState.Normal;
        }
    }
}
