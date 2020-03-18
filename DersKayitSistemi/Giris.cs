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
    public partial class Giris : Form
    {
        public static string yonetici_kullaniciadi = null;
        public static string ogrgor_eposta = null;
        public static string ogrenci_no = null;

        public Giris()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Giris_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "" && textBox6.Text == "")
            {
                MessageBox.Show("Lütfen kullanıcı adınızı ve şifrenizi giriniz.");
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("Lütfen kullanıcı adınızı giriniz.");
            }
            else if (textBox6.Text == "")
            {
                MessageBox.Show("Lütfen şifrenizi giriniz.");
            }
            else
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
                    int i = 0;
                    connection.Open();
                    MySqlCommand cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from ders_kayit_sistemi.yonetici where yonetici_kullaniciadi='" + textBox5.Text + "' and yonetici_sifre='" + textBox6.Text + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    connection.Close();
               
                    i = int.Parse(dt.Rows.Count.ToString());

                    if (i == 0)
                    {
                        MessageBox.Show("Kullanıcı adı ya da şifre geçersizdir.");
                    }
                    else
                    {
                        yonetici_kullaniciadi = textBox5.Text;
                        YoneticiPaneli yp = new YoneticiPaneli();
                        yp.Show();
                        this.Hide();
                    }
                }catch(Exception ex)
                {
                    MessageBox.Show("Bir hata ile karşılaşıldı: \n" + ex.Message);
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" && textBox4.Text == "")
            {
                MessageBox.Show("Lütfen e posta adresinizi ve şifrenizi giriniz.");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Lütfen e posta adresinizi giriniz.");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Lütfen şifrenizi giriniz.");
            }
            else
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
                    int i = 0;
                    connection.Open();
                    MySqlCommand cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from ders_kayit_sistemi.ogrgor where ogrgor_eposta='" + textBox3.Text + "' and ogrgor_sifre='" + textBox4.Text + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    i = int.Parse(dt.Rows.Count.ToString());

                    if (i == 0)
                    {
                        MessageBox.Show("E posta adresi ya da şifre geçersizdir.");
                    }
                    else
                    {
                        ogrgor_eposta = textBox3.Text;
                        OgrGorPaneli op = new OgrGorPaneli();
                        op.Show();
                        this.Hide();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata ile karşılaşıldı: \n" + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("Lütfen öğrenci numaranızı ve şifrenizi giriniz.");
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen öğrenci numaranızı giriniz.");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Lütfen şifrenizi giriniz.");
            }
            else
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=);
                    int i = 0;
                    connection.Open();
                    MySqlCommand cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from ders_kayit_sistemi.ogrenci where ogrenci_no='" + textBox1.Text + "' and ogrenci_sifre='" + textBox2.Text + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    i = int.Parse(dt.Rows.Count.ToString());

                    if (i == 0)
                    {
                        MessageBox.Show("Öğrenci numarası ya da şifre geçersizdir.");
                    }
                    else
                    {
                        ogrenci_no = textBox1.Text;
                        OgrenciPaneli op = new OgrenciPaneli();
                        op.Show();
                        this.Hide();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata ile karşılaşıldı: \n" + ex.Message);
                }
            }
        }
    }
}
