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
//Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\msezg\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\DataBaseKitaplar.mdf"";Integrated Security=True;Connect Timeout=30
{
    public partial class FormDuzenle : Form
    {
        DateTime dateTime;
        //Tüm formlarda önce bağlantı kurulur.
        SQLiteConnection SQLiteConnection = new SQLiteConnection(@"Data Source=C:\Users\msezg\OneDrive\Masaüstü\KitapListeleme\KitapListeleme\DATABASE\DataBaseKitaplar.db;Version=3;");
        public FormDuzenle()
        {
            //Kitaplar listelenir.
            InitializeComponent();
            SQLiteConnection.Open();
            SQLiteCommand sQLiteCommand = new SQLiteCommand("Select * from TableKitaplar", SQLiteConnection);
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(sQLiteCommand);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridViewDuzenle.DataSource = dataTable;
            dataGridViewDuzenle.Columns["ID"].Visible = false;
            dataGridViewDuzenle.Columns[5].DefaultCellStyle.Format = "yyyy-MM-dd";
            dataGridViewDuzenle.Columns[6].DefaultCellStyle.Format = "yyyy-MM-dd";
            dataGridViewDuzenle.Columns[7].DefaultCellStyle.Format = "yyyy-MM-dd";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonDegistir_Click(object sender, EventArgs e)
        {
            try
            {
                //UPDATE metodu.
                SQLiteCommand updateCommand = new SQLiteCommand("UPDATE TableKitaplar SET YazarAdi = @p2, SayfaSayisi = @p3, OkunmaTarihi = @p4, BasimTarihi = @p5, OduncVerilen = @p6, OduncTarihi = @p7 WHERE KitapAdi = @p1", SQLiteConnection);
                updateCommand.Parameters.AddWithValue("@p1", textKitapAdi.Text);
                updateCommand.Parameters.AddWithValue("@p2", textYazarAdi.Text);
                updateCommand.Parameters.AddWithValue("@p3", textSayfaSayisi.Text);

                //Tarih değerlerinin düzenlenmesi.
                updateCommand.Parameters.AddWithValue("@p4", string.IsNullOrEmpty(textOkunmaTarihi.Text) ? DBNull.Value : (object)textOkunmaTarihi.Text);
                updateCommand.Parameters.AddWithValue("@p5", string.IsNullOrEmpty(textBasimTarih.Text) ? DBNull.Value : (object)textBasimTarih.Text);

                updateCommand.Parameters.AddWithValue("@p6", textOduncIsim.Text);
                updateCommand.Parameters.AddWithValue("@p7", string.IsNullOrEmpty(textOduncTarih.Text) ? DBNull.Value : (object)textOduncTarih.Text);

                //Metodun çalıştırılması
                int rowsAffected = updateCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Kitap başarıyla düzenlendi.");
                }
                else
                {
                    MessageBox.Show("Kitap bulunamadı veya güncellenemedi.");
                }
            }
            catch (Exception ex)
            {
                //Hata mesajı.
                MessageBox.Show("Lütfen geçerli değerler giriniz.");
            }

            //Kitaplar yeniden listelenir.
            SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * FROM TableKitaplar", SQLiteConnection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridViewDuzenle.DataSource = table;;
            SQLiteConnection.Close();
        }

        private void dataGridViewDuzenle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridView aracına tıklanması durumunda veriler direkt olarak textboxlara aktarılır.
            textKitapAdi.Text = dataGridViewDuzenle.Rows[e.RowIndex].Cells[1].Value.ToString();
            textYazarAdi.Text = dataGridViewDuzenle.Rows[e.RowIndex].Cells[2].Value.ToString();
            textOduncIsim.Text = dataGridViewDuzenle.Rows[e.RowIndex].Cells[3].Value.ToString();
            textSayfaSayisi.Text = dataGridViewDuzenle.Rows[e.RowIndex].Cells[4].Value.ToString();
            //Tarih textboxlarına sadece tarih verileri gönderilir.
            if (DateTime.TryParse(dataGridViewDuzenle.Rows[e.RowIndex].Cells[5].Value.ToString(), out DateTime okunmaTarihi))
            {
                textOkunmaTarihi.Text = okunmaTarihi.ToString("yyyy-MM-dd");
            }
            else
            {
                textOkunmaTarihi.Text = string.Empty;
            }
            if (DateTime.TryParse(dataGridViewDuzenle.Rows[e.RowIndex].Cells[6].Value.ToString(), out DateTime oduncTarih))
            {
                textOduncTarih.Text = oduncTarih.ToString("yyyy-MM-dd");
            }
            else
            {
                textOduncTarih.Text = string.Empty;
            }
            if (DateTime.TryParse(dataGridViewDuzenle.Rows[e.RowIndex].Cells[7].Value.ToString(), out DateTime basimTarih))
            {
                textBasimTarih.Text = basimTarih.ToString("yyyy-MM-dd");
            }
            else
            {
                textBasimTarih.Text = string.Empty;
            }
            SQLiteConnection.Close();
        }

        private void textKitapAdi_TextChanged(object sender, EventArgs e)
        {

        }
        //Arama textboxuna girilen en yakın değer datagridview'dan işaretlenir.
        private void textArananKitap_TextChanged(object sender, EventArgs e)
        {
            string arananDeger = textArananKitap.Text.Trim();
            dataGridViewDuzenle.ClearSelection();
            //Textbox boş mu kontrol edilir.
            if (string.IsNullOrEmpty(arananDeger))
                return;
            //DataGridView aranır.
            foreach (DataGridViewRow row in dataGridViewDuzenle.Rows)
            {
                //Her satır tekrar aranır.
                foreach (DataGridViewCell cell in row.Cells)
                {
                    //Aranan değer ile karşılaştırılır.
                    if (cell.Value != null && cell.Value.ToString().Contains(arananDeger))
                    {
                        //Bulunma durumunda satır işaretlenir.
                        row.Selected = true;
                        break;
                    }
                }
            }
        }

        private void textOkunmaTarihi_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
