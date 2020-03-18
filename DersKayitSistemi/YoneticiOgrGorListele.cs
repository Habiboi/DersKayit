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
    public partial class YoneticiOgrGorListele : Form
    {
        public YoneticiOgrGorListele()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            YoneticiPaneli yp = new YoneticiPaneli();
            yp.Show();
            this.Hide();
        }

        private void YoneticiOgrGorListele_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
                //MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM ders_kayit_sistemi.ders", connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT ogrgor_adsoyad, ogrgor_bolum, ogrgor_eposta, ogrgor_dersler, ogrgor_ogrenciler FROM ders_kayit_sistemi.ogrgor", connection);

                connection.Open();

                DataSet ds = new DataSet();
                adapter.Fill(ds, "ogrgor");
                dataGridView1.DataSource = ds.Tables["ogrgor"];

                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata ile karşılaşıldı: \n" + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
