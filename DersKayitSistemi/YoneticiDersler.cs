using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DersKayitSistemi
{
    public partial class YoneticiDersler : Form
    {
        public YoneticiDersler()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            YoneticiPaneli yp = new YoneticiPaneli();
            yp.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void YoneticiDersler_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
                //MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM ders_kayit_sistemi.ders", connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT ders_kod, ders_ad, ders_bolum, ders_ogrgor, ders_akts, ders_sinif, ders_sube,  ders_saat, ders_gunsaat FROM ders_kayit_sistemi.ders", connection);

                connection.Open();

                DataSet ds = new DataSet();
                adapter.Fill(ds, "ders");
                dataGridView1.DataSource = ds.Tables["ders"];

                connection.Close();

            }catch(Exception ex)
            {
                MessageBox.Show("Bir hata ile karşılaşıldı: \n" + ex.Message);
            }
        }
    }
}
