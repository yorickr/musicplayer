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
//            api.GetSongsByArtist("Amon Amarth").ForEach(s =>
//            {
//                Console.WriteLine(s.SongID);
//            });
//            api.GetSongsByYear("2009").ForEach(s =>
//            {
//                Console.WriteLine(s.Name);
//            });
//            api.GetSongsByGenre("Melodic Death Metal").ForEach(s =>
//            {
//                Console.WriteLine(s.Name);
//            });
//            api.GetSongsByAlbum("Stronger").ForEach(s =>
//            {
//                Console.WriteLine(s.Name);
//            });
            MainForm form = new MainForm();
            new Main(nw, api, form);

            Application.Run(form);
        }
    }
}
