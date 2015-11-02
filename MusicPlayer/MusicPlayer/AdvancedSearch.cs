using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer
{
    public partial class AdvancedSearch : Form
    {
        private Main main;

        public AdvancedSearch(Main main)
        {
            this.main = main;
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if(SearchTermTextBox.Text.Length > 1)
            {
                SearchTermTextBox.ForeColor = Color.Black;
                main.AdvancedSearchFilter(SearchTermTextBox.Text, AlbumTextBox.Text, ArtistTextBox.Text, GenreTextBox.Text);
                this.Close();
            }
            else
            {
                SearchTermTextBox.ForeColor = Color.Red;
            }
        }
    }
}
