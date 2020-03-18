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
    public partial class OgrGorDersler : Form
    {
        public OgrGorDersler()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OgrGorPaneli op = new OgrGorPaneli();
            op.Show();
            this.Hide();
        }

        private void OgrGorDersler_Load(object sender, EventArgs e)
        {
            try
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

                connection.Open();
                DataSet ds = new DataSet();
                string selectQuery2 = "SELECT ders_kod, ders_ad, ders_bolum, ders_akts, ders_donem, ders_sinif, ders_sube,  ders_saat, ders_gunsaat FROM ders_kayit_sistemi.ders WHERE ders_ogrgor='" + ogrgor + "'";
                MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery2, connection);
                adapter.Fill(ds, "ders");
                dataGridView1.DataSource = ds.Tables["ders"];
                connection.Close();

                connection.Open();
                MySqlCommand cmd2 = new MySqlCommand(selectQuery2, connection);
                MySqlDataReader dr2 = cmd2.ExecuteReader();

                int i = 1;
                while (dr2.Read())
                {
                    if(i % 2 == 1)
                    {
                        comboBox1.Items.Add(dr2.GetString("ders_ad"));
                    }
                    i++;
                }

                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Bir hata ile karşılaşıldı:\n" + ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string updateQuery = "UPDATE ders_kayit_sistemi.ders SET ders_gunsaat='" + comboBox2.Text + " " + comboBox3.Text + ".00' WHERE ders_ad='" + comboBox1.Text + "' and ders_sube='" + comboBox4.Text + "'";
                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(updateQuery, connection);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Ders günü ve saati kaydedildi.");
                }
                else
                {
                    MessageBox.Show("Kaydedilemedi.");
                }
                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Bir hata ile karşılaşıldı:\n" + ex.Message);
            }
        }
    }
}
