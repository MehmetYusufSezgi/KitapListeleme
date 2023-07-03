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
using System.Data.SQLite;
namespace KitapListeleme
{
    public partial class FormEkle : Form
    {
        //Tüm formlarda önce bağlantı kurulur.
        SQLiteConnection SQLiteConnection = new SQLiteConnection(@"Data Source=C:\Users\msezg\OneDrive\Masaüstü\KitapListeleme\KitapListeleme\DATABASE\DataBaseKitaplar.db;Version=3;");
        public FormEkle()
        {
            // Kitaplar listelenir.
            InitializeComponent();
            SQLiteConnection.Open();
            SQLiteCommand sQLiteCommand = new SQLiteCommand("SELECT * FROM TableKitaplar", SQLiteConnection);
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(sQLiteCommand);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridViewEkle.DataSource = dataTable;
            dataGridViewEkle.Columns["ID"].Visible = false;
            dataGridViewEkle.Columns[5].DefaultCellStyle.Format = "yyyy-MM-dd";
            dataGridViewEkle.Columns[6].DefaultCellStyle.Format = "yyyy-MM-dd";
            dataGridViewEkle.Columns[7].DefaultCellStyle.Format = "yyyy-MM-dd";
            SQLiteConnection.Close();
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
            SQLiteConnection.Open();
            try
            {
                // Kitap değişikliği için önce uygun kitap silinir.
                // Ardından kitabın verilere textboxa alındığı için yeniden düzenlenip eklenebilir.
                SQLiteCommand sQLiteCommand = new SQLiteCommand("INSERT INTO TableKitaplar (KitapAdi, YazarAdi, SayfaSayisi, OkunmaTarihi, BasimTarihi, OduncVerilen, OduncTarihi) " +
                    "VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7)", SQLiteConnection);
                sQLiteCommand.Parameters.AddWithValue("@p1", textKitapAdi.Text);
                sQLiteCommand.Parameters.AddWithValue("@p2", textYazarAdi.Text);
                sQLiteCommand.Parameters.AddWithValue("@p3", textSayfaSayisi.Text);

                // Tarih verileri için doğru girişlerin yapılması kontrol edilir.
                // Boş olup olmadıkları kontrol edilir.
                if (string.IsNullOrEmpty(textOkunmaTarihi.Text))
                {
                    sQLiteCommand.Parameters.AddWithValue("@p4", DBNull.Value);
                }
                else
                {
                    sQLiteCommand.Parameters.AddWithValue("@p4", textOkunmaTarihi.Text);
                }

                if (string.IsNullOrEmpty(textBasimTarih.Text))
                {
                    sQLiteCommand.Parameters.AddWithValue("@p5", DBNull.Value);
                }
                else
                {
                    sQLiteCommand.Parameters.AddWithValue("@p5", textBasimTarih.Text);
                }

                sQLiteCommand.Parameters.AddWithValue("@p6", textOduncIsim.Text);

                if (string.IsNullOrEmpty(textOduncTarih.Text))
                {
                    sQLiteCommand.Parameters.AddWithValue("@p7", DBNull.Value);
                }
                else
                {
                    sQLiteCommand.Parameters.AddWithValue("@p7", textOduncTarih.Text);
                }

                sQLiteCommand.ExecuteNonQuery();
                MessageBox.Show("Kitap başarıyla eklendi.");
            }
            catch (Exception ex)
            {
                // Uygun değerler olmaması durumunda hata mesajı verilir.
                MessageBox.Show("Lütfen geçerli değerler giriniz.");
            }
            // Kitaplar yeniden listelenir.
            SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * FROM TableKitaplar", SQLiteConnection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridViewEkle.DataSource = table;
            SQLiteConnection.Close();
        }
    }
}
