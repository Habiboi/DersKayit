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
    public partial class OgrenciSifreDegis : Form
    {
        public OgrenciSifreDegis()
        {
            InitializeComponent();
        }

        private void OgrenciSifreDegis_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OgrenciPaneli op = new OgrenciPaneli();
            op.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Lütfen öğrenci numaranızı ve şifrenizi giriniz.");
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
                    string updateQuery = "UPDATE ders_kayit_sistemi.ogrenci SET ogrenci_sifre='" + textBox3.Text + "' WHERE ogrenci_no='" + textBox1.Text + "' and ogrenci_sifre='" + textBox2.Text + "'";
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
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata ile karşılaşıldı:\n" + ex.Message);
                }
            }
        }
    }
}
