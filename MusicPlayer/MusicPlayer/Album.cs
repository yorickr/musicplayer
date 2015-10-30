
using System.Drawing;

namespace MusicPlayer
{
    public class Album
    {
        public string albumnaam { get; set; }
        public Image cover;

        public Album(string albumnaam, Image c)
        {
            this.albumnaam = albumnaam;
            this.cover = c;
        }
    }
}