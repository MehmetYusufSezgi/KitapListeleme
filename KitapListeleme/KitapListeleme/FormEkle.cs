using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace KitapListeleme
{
    public partial class FormEkle : Form
    {
        //Tüm formlarda önce bağlantı kurulur.
        SqlConnection SqlConnection = new SqlConnection(@"server=(localdb)\mssqllocaldb;initial catalog=DataBaseKitaplar;integrated security=true");
        public FormEkle()
        {
            //Kitaplar listelenir.
            InitializeComponent();
            SqlCommand sqlCommand = new SqlCommand("Select * from TableKitaplar", SqlConnection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridViewEkle.DataSource = dataTable;
            dataGridViewEkle.Columns["ID"].Visible = false;
            dataGridViewEkle.Columns[5].DefaultCellStyle.Format = "yyyy-MM-dd";
            dataGridViewEkle.Columns[6].DefaultCellStyle.Format = "yyyy-MM-dd";
            dataGridViewEkle.Columns[7].DefaultCellStyle.Format = "yyyy-MM-dd";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormEkle_Load(object sender, EventArgs e)
        {

        }

        private void textKitapAdi_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonEkle_Click(object sender, EventArgs e)
        {
            SqlConnection.Open();
            try
            {
                //Kitap değişikliği için önce uygun kitap silinir.
                //Ardından kitabın verilere textboxa alındığı için yeniden düzenlenip eklenebilir.
                SqlCommand sqlCommand = new SqlCommand("insert into TableKitaplar (KitapAdi, YazarAdi, SayfaSayisi, OkunmaTarihi, BasimTarihi, OduncVerilen, OduncTarihi) " +
                "values (@p1, @p2, @p3, @p4, @p5, @p6, @p7)", SqlConnection);
                sqlCommand.Parameters.AddWithValue("@p1", textKitapAdi.Text);
                sqlCommand.Parameters.AddWithValue("@p2", textYazarAdi.Text);
                sqlCommand.Parameters.AddWithValue("@p3", textSayfaSayisi.Text);
                //Tarih verileri için doğru girişlerin yapılması kontrol edilir.
                //Boş olup olmadıkları kontrol edilir.
                if (string.IsNullOrEmpty(textOkunmaTarihi.Text))
                {
                    sqlCommand.Parameters.AddWithValue("@p4", DBNull.Value);
                }
                else
                {
                    sqlCommand.Parameters.AddWithValue("@p4", textOkunmaTarihi.Text);
                }
                if (string.IsNullOrEmpty(textBasimTarih.Text))
                {
                    sqlCommand.Parameters.AddWithValue("@p5", DBNull.Value);
                }
                else
                {
                    sqlCommand.Parameters.AddWithValue("@p5", textBasimTarih.Text);
                }
                sqlCommand.Parameters.AddWithValue("@p6", textOduncIsim.Text);
                if (string.IsNullOrEmpty(textOduncTarih.Text))
                {
                    sqlCommand.Parameters.AddWithValue("@p7", DBNull.Value);
                }
                else
                {
                    sqlCommand.Parameters.AddWithValue("@p7", textOduncTarih.Text);
                }

                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Kitap başarıyla eklendi.");
            }
            catch (Exception ex)
            {
                //Uygun değerler olmaması durumunda hata mesajı verilir.
                MessageBox.Show("Lütfen geçerli değerler giriniz.");
            }
            //Kitaplar yeniden listelenir.
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM TableKitaplar", SqlConnection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridViewEkle.DataSource = table;
            SqlConnection.Close();
        }
    }
}
