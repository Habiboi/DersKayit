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
    public partial class OgrGorDersProgrami : Form
    {
        public OgrGorDersProgrami()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OgrGorPaneli op = new OgrGorPaneli();
            op.Show();
            this.Hide();
        }

        private void OgrGorDersProgrami_Load(object sender, EventArgs e)
        {
            string ogrgor = null;
            string selectQuery = "SELECT * FROM ders_kayit_sistemi.ogrgor WHERE ogrgor_eposta='" + Giris.ogrgor_eposta + "'";
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(selectQuery, connection);
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                ogrgor = dr.GetString("ogrgor_adsoyad");
            }
            connection.Close();
            
            MySqlDataAdapter adapter1 = new MySqlDataAdapter("SELECT ders_kod, ders_ad, ders_bolum, ders_ogrgor, ders_akts, ders_sinif, ders_sube, ders_saat, ders_gunsaat FROM ders_kayit_sistemi.ders WHERE ders_ogrgor='"+ogrgor+"' and ders_gunsaat LIKE 'Pazartesi%'", connection);
            connection.Open();
            DataSet ds1 = new DataSet();
            adapter1.Fill(ds1,"ders");
            dataGridView1.DataSource = ds1.Tables["ders"];
            connection.Close();

            MySqlDataAdapter adapter2 = new MySqlDataAdapter("SELECT ders_kod, ders_ad, ders_bolum, ders_ogrgor, ders_akts, ders_sinif, ders_sube, ders_saat, ders_gunsaat FROM ders_kayit_sistemi.ders WHERE ders_ogrgor='" + ogrgor + "' and ders_gunsaat LIKE 'Salı%'", connection);
            connection.Open();
            DataSet ds2 = new DataSet();
            adapter2.Fill(ds2, "ders");
            dataGridView2.DataSource = ds2.Tables["ders"];
            connection.Close();

            MySqlDataAdapter adapter3 = new MySqlDataAdapter("SELECT ders_kod, ders_ad, ders_bolum, ders_ogrgor, ders_akts, ders_sinif, ders_sube, ders_saat, ders_gunsaat FROM ders_kayit_sistemi.ders WHERE ders_ogrgor='" + ogrgor + "' and ders_gunsaat LIKE 'Çarşamba%'", connection);
            connection.Open();
            DataSet ds3 = new DataSet();
            adapter3.Fill(ds3, "ders");
            dataGridView3.DataSource = ds3.Tables["ders"];
            connection.Close();

            MySqlDataAdapter adapter4 = new MySqlDataAdapter("SELECT ders_kod, ders_ad, ders_bolum, ders_ogrgor, ders_akts, ders_sinif, ders_sube, ders_saat, ders_gunsaat FROM ders_kayit_sistemi.ders WHERE ders_ogrgor='" + ogrgor + "' and ders_gunsaat LIKE 'Perşembe%'", connection);
            connection.Open();
            DataSet ds4 = new DataSet();
            adapter4.Fill(ds4, "ders");
            dataGridView4.DataSource = ds4.Tables["ders"];
            connection.Close();

            MySqlDataAdapter adapter5 = new MySqlDataAdapter("SELECT ders_kod, ders_ad, ders_bolum, ders_ogrgor, ders_akts, ders_sinif, ders_sube, ders_saat, ders_gunsaat FROM ders_kayit_sistemi.ders WHERE ders_ogrgor='" + ogrgor + "' and ders_gunsaat LIKE 'Cuma%'", connection);
            connection.Open();
            DataSet ds5 = new DataSet();
            adapter5.Fill(ds5, "ders");
            dataGridView5.DataSource = ds5.Tables["ders"];
            connection.Close();
        }
    }
}
