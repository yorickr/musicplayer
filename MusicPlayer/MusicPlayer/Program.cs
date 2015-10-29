using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            NetworkHandler nw = new NetworkHandler("http://www.imegumii.nl");
            APIHandler api = new APIHandler(nw);
            MainForm form = new MainForm();
            new Main(nw, api, form);

            Application.Run(form);
        }
    }
}
