using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DersKayitSistemi
{
    public partial class OgrGorPaneli : Form
    {
        public OgrGorPaneli()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OgrGorSifreDegis osd = new OgrGorSifreDegis();
            osd.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OgrGorOgrenciler oo = new OgrGorOgrenciler();
            oo.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OgrGorDersler od = new OgrGorDersler();
            od.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OgrGorDersProgrami odp = new OgrGorDersProgrami();
            odp.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OgrGorOgrenciDersOnayi oodo = new OgrGorOgrenciDersOnayi();
            oodo.Show();
            this.Hide();
        }

        private void OgrGorPaneli_Load(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM ders_kayit_sistemi.ogrgor WHERE ogrgor_eposta='" + Giris.ogrgor_eposta + "'";
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(selectQuery, connection);
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                textBox1.Text = dr.GetString("ogrgor_adsoyad");
                textBox2.Text = dr.GetString("ogrgor_eposta");
                textBox3.Text = dr.GetString("ogrgor_bolum");
            }

            connection.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Giris giris = new Giris();
            giris.Show();
            this.Hide();
        }
    }
}
