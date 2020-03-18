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

namespace DersKayitSistemi
{
    public partial class YoneticiPaneli : Form
    {
        public YoneticiPaneli()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            YoneticiSifreDegis ysd = new YoneticiSifreDegis();
            ysd.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            YoneticiDersler yd = new YoneticiDersler();
            yd.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            YoneticiDersProgramlari ydp = new YoneticiDersProgramlari();
            ydp.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            YoneticiOgrGorListele yol = new YoneticiOgrGorListele();
            yol.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            YoneticiKayitOnayTarihi ykot = new YoneticiKayitOnayTarihi();
            ykot.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            YoneticiOgrenciListele yol = new YoneticiOgrenciListele();
            yol.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            YoneticiHesapKayit yhk = new YoneticiHesapKayit();
            yhk.Show();
            this.Hide();
        }

        private void YoneticiPaneli_Load(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM ders_kayit_sistemi.yonetici WHERE yonetici_kullaniciadi='" + Giris.yonetici_kullaniciadi + "'";
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(selectQuery, connection);
            MySqlDataReader dr = cmd.ExecuteReader();
            
            if (dr.Read())
            {
                textBox1.Text = dr.GetString("yonetici_adsoyad");
                textBox2.Text = dr.GetString("yonetici_kullaniciadi");
            }

            connection.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Giris giris = new Giris();
            giris.Show();
            this.Hide();
        }
    }
}
