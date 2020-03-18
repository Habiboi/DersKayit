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
    public partial class YoneticiHesapKayit : Form
    {
        public YoneticiHesapKayit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            YoneticiPaneli yp = new YoneticiPaneli();
            yp.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox12.Text == "" || textBox13.Text == "" || textBox14.Text == "")
            {
                MessageBox.Show("Lütfen tüm zorunlu bilgileri giriniz.");
            }
            else
            {
                try
                {
                    string insertQuery = "INSERT INTO ders_kayit_sistemi.yonetici(yonetici_adsoyad,yonetici_kullaniciadi,yonetici_sifre) VALUES('" + textBox12.Text + "','" + textBox13.Text + "','" + textBox14.Text + "')";
                    MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(insertQuery, connection);

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Yeni yönetici hesabı veritabanına kaydedildi.");
                    }
                    else
                    {
                        MessageBox.Show("Hesap kaydedilemedi");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Bir hata ile karşılaşıldı:\n" + ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox8.Text == "" || textBox9.Text == "" || textBox10.Text == "" || textBox11.Text=="")
            {
                MessageBox.Show("Lütfen tüm zorunlu bilgileri giriniz.");
            }
            else
            {
                try
                {
                    string insertQuery = "INSERT INTO ders_kayit_sistemi.ogrgor(ogrgor_adsoyad,ogrgor_bolum,ogrgor_eposta,ogrgor_ogrenciler,ogrgor_dersler,ogrgor_sifre) VALUES('" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + richTextBox2.Text + "','" + richTextBox3.Text + "','" + textBox11.Text + "')";
                    MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(insertQuery, connection);

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Yeni öğretim görevlisi hesabı veritabanına kaydedildi.");
                    }
                    else
                    {
                        MessageBox.Show("Hesap kaydedilemedi");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata ile karşılaşıldı:\n" + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox15.Text == "")
            {
                MessageBox.Show("Lütfen tüm zorunlu bilgileri giriniz.");
            }
            else
            {
                try
                {
                    string insertQuery = "INSERT INTO ders_kayit_sistemi.ogrenci(ogrenci_adsoyad,ogrenci_no,ogrenci_tc,ogrenci_ort,ogrenci_bolum,ogrenci_sinif,ogrenci_kaldigidersler,ogrenci_sifre, ogrenci_danisman) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + richTextBox1.Text + "','" + textBox7.Text + "'," + textBox15.Text + "')";
                    MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(insertQuery, connection);

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Yeni öğrenci hesabı veritabanına kaydedildi.");
                    }
                    else
                    {
                        MessageBox.Show("Hesap kaydedilemedi");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata ile karşılaşıldı:\n" + ex.Message);
                }
            }
        }

        private void YoneticiHesapKayit_Load(object sender, EventArgs e)
        {

        }
    }
}
