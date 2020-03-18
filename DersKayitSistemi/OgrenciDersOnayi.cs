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
    public partial class OgrenciDersOnayi : Form
    {
        public OgrenciDersOnayi()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OgrenciPaneli op = new OgrenciPaneli();
            op.Show();
            this.Hide();
        }

        private void OgrenciDersOnayi_Load(object sender, EventArgs e)
        {
            try
            {
                string selectQuery = "SELECT * FROM ders_kayit_sistemi.ogrenci WHERE ogrenci_adsoyad='" + OgrenciPaneli.ogrenci_adsoyad + "'";
                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(selectQuery, connection);
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    label5.Text = dr.GetString("ogrenci_ogrencionay");
                    label6.Text = dr.GetString("ogrenci_danismanonay");
                }
                connection.Close();

                string selectQuery2 = "SELECT * FROM ders_kayit_sistemi.derskayit WHERE derskayit_id=1";
                connection.Open();

                MySqlCommand cmd2 = new MySqlCommand(selectQuery2, connection);
                MySqlDataReader dr2 = cmd2.ExecuteReader();

                if (dr2.Read())
                {
                    label7.Text = dr2.GetString("derskayit_ogrenci");
                    label8.Text = dr2.GetString("derskayit_ogrgor");
                }

                if (label5.Text == "Yapılmadı")
                {
                    button1.Visible = true;
                }
                else
                {
                    button1.Visible = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Bir hata ile karşılaşıldı:\n" + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string updateQuery = "UPDATE ders_kayit_sistemi.ogrenci SET ogrenci_ogrencionay='Yapıldı' WHERE ogrenci_adsoyad='" + OgrenciPaneli.ogrenci_adsoyad + "'";
                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(updateQuery, connection);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Öğrenci onayı yapıldı.");
                    label5.Text = "Yapıldı";
                }
                else
                {
                    MessageBox.Show("Öğrenci onayı yapılamadı.");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata ile karşılaşıldı:\n" + ex.Message);
            }
        }
    }
}
