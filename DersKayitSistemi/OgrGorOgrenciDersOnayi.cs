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
    public partial class OgrGorOgrenciDersOnayi : Form
    {
        public OgrGorOgrenciDersOnayi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OgrGorPaneli op = new OgrGorPaneli();
            op.Show();
            this.Hide();
        }

        private void OgrGorOgrenciDersOnayi_Load(object sender, EventArgs e)
        {
            try
            {
                string[] ogrenciler=null;
                string selectQuery = "SELECT * FROM ders_kayit_sistemi.ogrgor WHERE ogrgor_eposta='" + Giris.ogrgor_eposta + "'";
                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(selectQuery, connection);
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    ogrenciler = dr.GetString("ogrgor_ogrenciler").Split(',');
                }
                for (int i = 0; i < ogrenciler.Length; i++)
                {
                    comboBox1.Items.Add(ogrenciler[i]);
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata ile karşılaşıldı:\n" + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string selectQuery = "SELECT * FROM ders_kayit_sistemi.ogrenci WHERE ogrenci_adsoyad='" + comboBox1.Text + "'";
                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(selectQuery, connection);
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    label4.Text = dr.GetString("ogrenci_ogrencionay");
                    label5.Text = dr.GetString("ogrenci_danismanonay");
                }

                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;

                if (label4.Text == "Yapıldı" && label5.Text == "Yapılmadı")
                {
                    button3.Visible = true;
                    button4.Visible = true;
                }
                else if(label4.Text == "Yapıldı" && label5.Text == "Yapıldı")
                {
                    button3.Visible = false;
                    button4.Visible = true;
                }
                else
                {
                    button3.Visible = false;
                    button4.Visible = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Bir hata ile karşılaşıldı:\n" + ex.Message);
            }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string updateQuery = "UPDATE ders_kayit_sistemi.ogrenci SET ogrenci_danismanonay='Yapıldı' WHERE ogrenci_adsoyad='" + comboBox1.Text + "'";
                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(updateQuery, connection);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Danışman onayı yapıldı.");
                }
                else
                {
                    MessageBox.Show("Danışman onayı yapılamadı.");
                }
                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Bir hata ile karşılaşıldı:\n" + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OgrenciDersProgrami odp = new OgrenciDersProgrami();
            OgrenciPaneli.ogrenci_adsoyad = comboBox1.Text;
            odp.geriButonuGizle();
            odp.ShowDialog();
        }
    }
}
