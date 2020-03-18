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
    public partial class OgrenciPaneli : Form
    {
        public static string ogrenci_adsoyad;
        public static string ogrenci_bolum;
        public static string ogrenci_sinif;
        public static float ogrenci_ort;
        public static string[] ogrenci_kaldigidersler;

        public OgrenciPaneli()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OgrenciSifreDegis osd = new OgrenciSifreDegis();
            osd.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OgrenciDersEkleBirak odeb = new OgrenciDersEkleBirak();
            odeb.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OgrenciDersProgrami odp = new OgrenciDersProgrami();
            odp.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OgrenciDersOnayi odo = new OgrenciDersOnayi();
            odo.Show();
            this.Hide();
        }

        private void OgrenciPaneli_Load(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM ders_kayit_sistemi.ogrenci WHERE ogrenci_no='" + Giris.ogrenci_no + "'";
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(selectQuery, connection);
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                textBox1.Text = dr.GetString("ogrenci_adsoyad");
                textBox2.Text = dr.GetString("ogrenci_no");
                textBox3.Text = dr.GetString("ogrenci_tc");
                textBox4.Text = dr.GetString("ogrenci_bolum");
                textBox5.Text = dr.GetString("ogrenci_sinif");
                textBox6.Text = dr.GetFloat("ogrenci_ort").ToString();
                ogrenci_ort = dr.GetFloat("ogrenci_ort");
                label7.Text += dr.GetString("ogrenci_ogrencionay");
                label8.Text += dr.GetString("ogrenci_danismanonay");
                ogrenci_kaldigidersler = dr.GetString("ogrenci_kaldigidersler").Split(',');
            }
            
            connection.Close();
            ogrenci_adsoyad = textBox1.Text;
            ogrenci_bolum = textBox4.Text;
            ogrenci_sinif = textBox5.Text;
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Giris giris = new Giris();
            giris.Show();
            this.Hide();
        }
    }
}
