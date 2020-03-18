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
    public partial class YoneticiSifreDegis : Form
    {
        public YoneticiSifreDegis()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            YoneticiPaneli yp = new YoneticiPaneli();
            yp.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Lütfen kullanıcı adı ve şifrenizi giriniz.");
            }
            else if (textBox3.Text != textBox4.Text)
            {
                MessageBox.Show("Şifreniz uyuşmuyor.");
            }
            else if (textBox3.Text == "" && textBox4.Text == "")
            {
                MessageBox.Show("Lütfen yeni şifrenizi giriniz.");
            }
            else
            {
                try
                {
                    string updateQuery = "UPDATE ders_kayit_sistemi.yonetici SET yonetici_sifre='" + textBox3.Text + "' WHERE yonetici_kullaniciadi='" + textBox1.Text + "' and yonetici_sifre='" + textBox2.Text + "'";
                    MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(updateQuery, connection);
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Şifre değiştirildi.");
                    }
                    else
                    {
                        MessageBox.Show("Şifre değiştirilemedi.");
                    }
                    connection.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Bir hata ile karşılaşıldı:\n" + ex.Message);
                }
            }
            
        }

        private void YoneticiSifreDegis_Load(object sender, EventArgs e)
        {

        }
    }
}
