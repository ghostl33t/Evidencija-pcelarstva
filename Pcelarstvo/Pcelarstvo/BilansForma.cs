using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace Pcelarstvo
{
    public partial class Okvir : Form
    {
        
        public float TempGubitak = 0;
        public float TempDobitak = 0;
        public float bilansKonacno = 0;
        public float promjenjivaVarijablaZaCitanjePodataka = 0;
        public float promjenjivaVarijablaZaZbrajanje = 0;
        public string PrvoUString;
        public Okvir()
        {
            InitializeComponent();
        }
        public void AnulirajVrijednosti()
        {
            promjenjivaVarijablaZaCitanjePodataka = 0;
            promjenjivaVarijablaZaZbrajanje = 0;
            PrvoUString = "";
        }
        private void KonekcijaCitanje(string query, Label IDLABELA)
        {
            OleDbConnection msAccessKonekcija = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source = bazaPodataka.accdb");
            OleDbDataReader CitacPodataka;
            OleDbCommand komanda;
            komanda = new OleDbCommand(query, msAccessKonekcija);
            msAccessKonekcija.Open();
            CitacPodataka = komanda.ExecuteReader();
            try
            {
                if (CitacPodataka.HasRows)
                {
                    while (CitacPodataka.Read())
                    {
                        PrvoUString = CitacPodataka.GetString(4);
                        promjenjivaVarijablaZaCitanjePodataka = float.Parse(PrvoUString);
                        promjenjivaVarijablaZaZbrajanje += promjenjivaVarijablaZaCitanjePodataka;
                    }
                    PrvoUString = promjenjivaVarijablaZaZbrajanje.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if(PrvoUString == "")
            {
                PrvoUString = "0.00";
            }
            Label ulaganjauOpremu = IDLABELA;
            ulaganjauOpremu.Text = PrvoUString + " KM";
        }

        private void GetDataButton_Click(object sender, EventArgs e)
        {
            /* iskljuci mogucnosti getanja vise puta jednih te istih podataka */
            GetDataButton.Click -= GetDataButton_Click;
            /* racunanje gubitka */
            KonekcijaCitanje("SELECT * FROM oprema", UUO);
            TempGubitak += promjenjivaVarijablaZaZbrajanje;
            AnulirajVrijednosti();
            KonekcijaCitanje("SELECT * FROM lijekovi", NL);
            TempGubitak += promjenjivaVarijablaZaZbrajanje;
            AnulirajVrijednosti();
            KonekcijaCitanje("SELECT * FROM prihrana", NPIA);
            TempGubitak += promjenjivaVarijablaZaZbrajanje;
            AnulirajVrijednosti();
            KonekcijaCitanje("SELECT * FROM prevoz", TT);
            TempGubitak += promjenjivaVarijablaZaZbrajanje;
            AnulirajVrijednosti();
            KonekcijaCitanje("SELECT * FROM potrosnimaterijali", NOPM);
            TempGubitak += promjenjivaVarijablaZaZbrajanje;
            AnulirajVrijednosti();
            KonekcijaCitanje("SELECT * FROM literatura", NLIT);
            TempGubitak += promjenjivaVarijablaZaZbrajanje;
            AnulirajVrijednosti();
            KonekcijaCitanje("SELECT * FROM ostalitroskovi", OT);
            TempGubitak += promjenjivaVarijablaZaZbrajanje;
            AnulirajVrijednosti();
            KonekcijaCitanje("SELECT * FROM gubitci", GUB);
            TempGubitak += promjenjivaVarijablaZaZbrajanje;
            AnulirajVrijednosti();
            /*racunanje dobitka */
            KonekcijaCitanje("SELECT * FROM med", VPM);
            TempDobitak += promjenjivaVarijablaZaZbrajanje;
            AnulirajVrijednosti();
            KonekcijaCitanje("SELECT * FROM rojevi", VURM);
            TempDobitak += promjenjivaVarijablaZaZbrajanje;
            AnulirajVrijednosti();
            KonekcijaCitanje("SELECT * FROM drugi", VOP);
            TempDobitak += promjenjivaVarijablaZaZbrajanje;
            AnulirajVrijednosti();
            /* konacni proracun balansa.... */
            Label ukupniTroskovi = UT;
            ukupniTroskovi.Text = TempGubitak.ToString() + " KM";

            Label ukupniDobitak = UP;
            ukupniDobitak.Text = TempDobitak.ToString() + " KM";

            Label gubitakDobitak = GUBDOB;
            float razlika = TempDobitak - TempGubitak;
            gubitakDobitak.Text = razlika.ToString() + " KM";

            Label gubitakIlidobitak = GUBDOBOVISNO;
            if (razlika > 0)
            {
                gubitakIlidobitak.Text = "DOBITAK:";
            }
            else if(razlika < 0)
            {
                gubitakIlidobitak.Text = "GUBITAK:";
            }
            else
            {
                gubitakIlidobitak.Text = "NULA:";
            }
            
        }

        private void NazadButton_Click(object sender, EventArgs e)
        {
            var PostaviFormu = new ProvjeraStanjaForma();
            this.Hide();
            PostaviFormu.Show();
        }

        private void Izlaz_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Okvir_Load(object sender, EventArgs e)
        {
            TopMost = true;
        }
    }
}
