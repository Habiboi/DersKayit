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
    public partial class YoneticiOgrenciListele : Form
    {
        public YoneticiOgrenciListele()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            YoneticiPaneli yp = new YoneticiPaneli();
            yp.Show();
            this.Hide();
        }

        private void YoneticiOgrenciListele_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
                //MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM ders_kayit_sistemi.ders", connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT ogrenci_adsoyad, ogrenci_no, ogrenci_tc, ogrenci_bolum, ogrenci_danisman, ogrenci_sinif, ogrenci_ort, ogrenci_kaldigidersler FROM ders_kayit_sistemi.ogrenci", connection);

                connection.Open();

                DataSet ds = new DataSet();
                adapter.Fill(ds, "ogrenci");
                dataGridView1.DataSource = ds.Tables["ogrenci"];

                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata ile karşılaşıldı: \n" + ex.Message);
            }
        }
    }
}
