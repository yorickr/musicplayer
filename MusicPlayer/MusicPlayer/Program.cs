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
            NetworkHandler nw = new NetworkHandler("http://www.imegumii.nl");
            APIHandler api = new APIHandler(nw);
            Console.WriteLine(api.GetSongURLByID("102"));
            api.GetArtists().ForEach(a =>
            {
                Console.WriteLine(a.naam);
            });
            api.GetYears().ForEach(y =>
            {
                Console.WriteLine(y.year);
            });
            api.GetAlbums().ForEach(a =>
            {
                Console.WriteLine(a.albumnaam);
            });
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
