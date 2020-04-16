using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.OleDb;
namespace Pcelarstvo
{
    public partial class DeveloperInfo1 : Form
    {
        public DeveloperInfo1()
        {
            InitializeComponent();
        }

        private void PotvrdiLogin_Click(object sender, EventArgs e)
        {
            TextBox korisnickoIme = (TextBox)UnosImena;
            TextBox korisnickaSifra = (TextBox)UnosSifre;
            Label IspisGreske = (Label)Greska;
            string imestring = korisnickoIme.Text;
            string sifrastring = korisnickaSifra.Text;
            
            string query = "SELECT * FROM racuni";
            /*************************** MYSQL KONEKCIJA ******************************/
            /*string konekcioniString = "datasource=localhost;port=3306;username=root;password=;database=pcelarstvo";
            MySqlConnection databaseConnection = new MySqlConnection(konekcioniString);
            MySqlCommand commandDatabbase = new MySqlCommand(query, databaseConnection);
            commandDatabbase.CommandTimeout = 60;
            MySqlDataReader reader;*/
            /*************************** MS ACCESS KONEKCIJA ******************************/
            OleDbConnection msAccessKonekcija = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source = bazaPodataka.accdb");
            OleDbCommand komanda = new OleDbCommand(query, msAccessKonekcija);
            OleDbDataReader reader;

            try
            {
                bool greskacheck = false;
                msAccessKonekcija.Open();
                //reader = commandDatabbase.ExecuteReader();
                reader = komanda.ExecuteReader();
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        string registrovanRacun = reader.GetString(1);
                        if(registrovanRacun == imestring)
                        {
                            string registrovanaSifra = reader.GetString(2);
                            if (registrovanRacun == imestring && registrovanaSifra != sifrastring)
                            {
                                greskacheck = true;
                                IspisGreske.Text = "Greska, podaci koje ste unijeli se ne podudaraju!";
                            }
                            if (registrovanaSifra == sifrastring)
                            {
                                
                                var MenuForma = new MainScreen();
                                MenuForma.Show();
                                var LoginForma = new DeveloperInfo1();
                                LoginForma.Hide();
                                greskacheck = false;
                                this.Hide();
                            }
                        }
                        else
                        {
                            
                            greskacheck = true;
                        }
                        
                    }
                    if(greskacheck == true)
                    {
                        IspisGreske.Text = "Greska, podaci koje ste unijeli se ne podudaraju!";
                    }
                }
                else
                {
                    IspisGreske.Text = "Greska, podaci koje ste unjeli se ne podudaraju!";
                }
            }
            catch(Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }

        }

        private void DeveloperInfo1_Load(object sender, EventArgs e)
        {
            TopMost = true;
        }
    }
}
