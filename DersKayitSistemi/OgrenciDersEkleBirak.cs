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
    public partial class OgrenciDersEkleBirak : Form
    {
        string[] eklenenDersler = new string[0];
        bool ayniDers = false;
        int x = 0;
        public OgrenciDersEkleBirak()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OgrenciPaneli op = new OgrenciPaneli();
            op.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void OgrenciDersEkleBirak_Load(object sender, EventArgs e)
        {
            string selectQuery = null;
            if (OgrenciPaneli.ogrenci_ort >= 3f)
            {
                selectQuery = "SELECT * FROM ders_kayit_sistemi.ders WHERE (ders_donem='2' and ders_sinif>='" + OgrenciPaneli.ogrenci_sinif + "' and ders_bolum='" + OgrenciPaneli.ogrenci_bolum + "') or ders_sinif='0'";
            }
            else
            {
                selectQuery = "SELECT * FROM ders_kayit_sistemi.ders WHERE (ders_donem='2' and ders_sube='1' and ders_sinif='" + OgrenciPaneli.ogrenci_sinif + "' and ders_bolum='" + OgrenciPaneli.ogrenci_bolum + "') or ders_sinif='0'";
            }
            
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
            connection.Open();

            MySqlCommand cmd = new MySqlCommand(selectQuery, connection);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr.GetString("ders_ad"));
            }
            connection.Close();

            for (int i = 0; i < OgrenciPaneli.ogrenci_kaldigidersler.Length; i++)
            {
                comboBox1.Items.Add(OgrenciPaneli.ogrenci_kaldigidersler[i]);
            }

            string selectQuery1 = "SELECT ders_kod, ders_ad, ders_bolum, ders_ogrgor, ders_akts, ders_sinif, ders_sube, ders_saat, ders_gunsaat FROM ders_kayit_sistemi.ders WHERE ders_ogrenci LIKE '%" + OgrenciPaneli.ogrenci_adsoyad + "%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery1, connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "ders");
            dataGridView1.DataSource = ds.Tables["ders"];
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < eklenenDersler.Length; i++)
            {
                if (comboBox1.Text == eklenenDersler[i])
                {
                    ayniDers = true;
                }
            }

            if (ayniDers == false)
            {
                string updateQuery = "UPDATE ders_kayit_sistemi.ders SET ders_ogrenci=CONCAT(ders_ogrenci,'" + OgrenciPaneli.ogrenci_adsoyad + ",') WHERE ders_ad='" + comboBox1.Text + " ' and ders_sube='" + comboBox2.Text + "'";
                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(updateQuery, connection);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Ders eklendi.");
                    Array.Resize(ref eklenenDersler, eklenenDersler.Length + 1);
                    eklenenDersler[x] = comboBox1.Text;
                    x++;
                    connection.Close();

                    string selectQuery = "SELECT ders_kod, ders_ad, ders_bolum, ders_ogrgor, ders_akts, ders_sinif, ders_sube, ders_saat, ders_gunsaat FROM ders_kayit_sistemi.ders WHERE ders_ogrenci LIKE '%" + OgrenciPaneli.ogrenci_adsoyad + "%'";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, connection);
                    connection.Open();
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "ders");
                    dataGridView1.DataSource = ds.Tables["ders"];
                    connection.Close();
                }
                else
                {
                    MessageBox.Show("Ders eklenemedi.");
                }
                connection.Close();
            }
            else
            {
                MessageBox.Show("Bu dersi zaten eklediniz.");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string updateQuery = "UPDATE ders_kayit_sistemi.ders SET ders_ogrenci=REPLACE(ders_ogrenci,'" + OgrenciPaneli.ogrenci_adsoyad + ",',''" + ") WHERE ders_ad='" + comboBox1.Text + "'";
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(updateQuery, connection);
            cmd.ExecuteNonQuery();
            connection.Close();

            string selectQuery = "SELECT ders_kod, ders_ad, ders_bolum, ders_ogrgor, ders_akts, ders_sinif, ders_sube, ders_saat, ders_gunsaat FROM ders_kayit_sistemi.ders WHERE ders_ogrenci LIKE '%" + OgrenciPaneli.ogrenci_adsoyad + "%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "ders");
            dataGridView1.DataSource = ds.Tables["ders"];
            connection.Close();
            for (int i = 0; i < eklenenDersler.Length; i++)
            {
                if (eklenenDersler[i] == comboBox1.Text)
                {
                    eklenenDersler[i] = "";
                }
            }
            MessageBox.Show("Ders bırakıldı.");

            
        }
    }
}
