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
    public partial class YoneticiKayitOnayTarihi : Form
    {
        public YoneticiKayitOnayTarihi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            YoneticiPaneli yp = new YoneticiPaneli();
            yp.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string updateQuery = "UPDATE ders_kayit_sistemi.derskayit SET derskayit_ogrenci='" + dateTimePicker1.Text + "', derskayit_ogrgor='" + dateTimePicker2.Text + "' WHERE derskayit_id=1";
                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(updateQuery, connection);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Ders kaydı onay tarihi belirlendi.");
                }
                else
                {
                    MessageBox.Show("Ders kayıt tarihi belirlenemedi");
                }
                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Bir hata oluştu:\n" + ex.Message);
            }
            
        }

        private void YoneticiKayitOnayTarihi_Load(object sender, EventArgs e)
        {

        }
    }
}
