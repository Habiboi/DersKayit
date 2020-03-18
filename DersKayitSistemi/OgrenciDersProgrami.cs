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
    public partial class OgrenciDersProgrami : Form
    {
        public OgrenciDersProgrami()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OgrenciPaneli op = new OgrenciPaneli();
            op.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void OgrenciDersProgrami_Load(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");

            MySqlDataAdapter adapter1 = new MySqlDataAdapter("SELECT ders_kod, ders_ad, ders_bolum, ders_ogrgor, ders_akts, ders_sinif, ders_sube, ders_saat, ders_gunsaat FROM ders_kayit_sistemi.ders WHERE ders_ogrenci LIKE'%" + OgrenciPaneli.ogrenci_adsoyad + "%' and ders_gunsaat LIKE 'Pazartesi%'", connection);
            connection.Open();
            DataSet ds1 = new DataSet();
            adapter1.Fill(ds1, "ders");
            dataGridView1.DataSource = ds1.Tables["ders"];
            connection.Close();

            MySqlDataAdapter adapter2 = new MySqlDataAdapter("SELECT ders_kod, ders_ad, ders_bolum, ders_ogrgor, ders_akts, ders_sinif, ders_sube, ders_saat, ders_gunsaat FROM ders_kayit_sistemi.ders WHERE ders_ogrenci LIKE'%" + OgrenciPaneli.ogrenci_adsoyad + "%' and ders_gunsaat LIKE 'Salı%'", connection);
            connection.Open();
            DataSet ds2 = new DataSet();
            adapter2.Fill(ds2, "ders");
            dataGridView2.DataSource = ds2.Tables["ders"];
            connection.Close();

            MySqlDataAdapter adapter3 = new MySqlDataAdapter("SELECT ders_kod, ders_ad, ders_bolum, ders_ogrgor, ders_akts, ders_sinif, ders_sube, ders_saat, ders_gunsaat FROM ders_kayit_sistemi.ders WHERE ders_ogrenci LIKE'%" + OgrenciPaneli.ogrenci_adsoyad + "%' and ders_gunsaat LIKE 'Çarşamba%'", connection);
            connection.Open();
            DataSet ds3 = new DataSet();
            adapter3.Fill(ds3, "ders");
            dataGridView3.DataSource = ds3.Tables["ders"];
            connection.Close();

            MySqlDataAdapter adapter4 = new MySqlDataAdapter("SELECT ders_kod, ders_ad, ders_bolum, ders_ogrgor, ders_akts, ders_sinif, ders_sube, ders_saat, ders_gunsaat FROM ders_kayit_sistemi.ders WHERE ders_ogrenci LIKE'%" + OgrenciPaneli.ogrenci_adsoyad + "%' and ders_gunsaat LIKE 'Perşembe%'", connection);
            connection.Open();
            DataSet ds4 = new DataSet();
            adapter4.Fill(ds4, "ders");
            dataGridView4.DataSource = ds4.Tables["ders"];
            connection.Close();

            MySqlDataAdapter adapter5 = new MySqlDataAdapter("SELECT ders_kod, ders_ad, ders_bolum, ders_ogrgor, ders_akts, ders_sinif, ders_sube, ders_saat, ders_gunsaat FROM ders_kayit_sistemi.ders WHERE ders_ogrenci LIKE'%" + OgrenciPaneli.ogrenci_adsoyad + "%' and ders_gunsaat LIKE 'Cuma%'", connection);
            connection.Open();
            DataSet ds5 = new DataSet();
            adapter5.Fill(ds5, "ders");
            dataGridView5.DataSource = ds5.Tables["ders"];
            connection.Close();
        }

        public void geriButonuGizle()
        {
            button2.Visible = false;
        }
    }
}
