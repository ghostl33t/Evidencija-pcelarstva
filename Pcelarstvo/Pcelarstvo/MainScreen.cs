using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pcelarstvo
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }
        
        private void UnosPodataka_Click(object sender, EventArgs e)
        {
            var PostaviFormu = new UnosPodataka();
            this.Hide();
            PostaviFormu.Show();
        }
        private void ProvjeraStanja_Click_1(object sender, EventArgs e)
        {
            var PostaviFormu = new ProvjeraStanjaForma();
            this.Hide();
            PostaviFormu.Show();
        }
    }
}
