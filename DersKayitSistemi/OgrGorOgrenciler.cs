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
    public partial class OgrGorOgrenciler : Form
    {
        public OgrGorOgrenciler()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OgrGorPaneli op = new OgrGorPaneli();
            op.Show();
            this.Hide();
        }

        private void OgrGorOgrenciler_Load(object sender, EventArgs e)
        {
            try
            {
                string ogrgor = null;
                string selectQuery = "SELECT * FROM ders_kayit_sistemi.ogrgor WHERE ogrgor_eposta='" + Giris.ogrgor_eposta + "'";
                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(selectQuery, connection);
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    ogrgor = dr.GetString("ogrgor_adsoyad");
                }
                connection.Close();

                connection.Open();
                DataSet ds = new DataSet();
                string selectQuery2 = "SELECT ogrenci_adsoyad, ogrenci_no, ogrenci_tc, ogrenci_ort, ogrenci_sinif, ogrenci_ogrencionay, ogrenci_danismanonay FROM ders_kayit_sistemi.ogrenci WHERE ogrenci_danisman='" + ogrgor + "'";
                MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery2, connection);
                adapter.Fill(ds, "ders");
                dataGridView1.DataSource = ds.Tables["ders"];
                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Bir hata ile karşılaşıldı:\n" + ex.Message);
            }
        }
    }
}
