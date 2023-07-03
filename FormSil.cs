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
    public partial class FormSil : Form
    {
        // Tüm formlarda önce bağlantı kurulur.
        SQLiteConnection SQLiteConnection = new SQLiteConnection(@"Data Source=C:\Users\msezg\OneDrive\Masaüstü\KitapListeleme\KitapListeleme\DATABASE\DataBaseKitaplar.db;Version=3;");

        public FormSil()
        {
            // Form ilk açıldığında veriler gösterilir.
            InitializeComponent();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * FROM TableKitaplar", SQLiteConnection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridViewSil.DataSource = table;
            dataGridViewSil.Columns["ID"].Visible = false;
            dataGridViewSil.Columns[5].DefaultCellStyle.Format = "yyyy-MM-dd";
            dataGridViewSil.Columns[6].DefaultCellStyle.Format = "yyyy-MM-dd";
            dataGridViewSil.Columns[7].DefaultCellStyle.Format = "yyyy-MM-dd";
            SQLiteConnection.Close();
        }

        // Ana menüye dönüş butonu.
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSil_Click(object sender, EventArgs e)
        {
            // Silinecek olan kitabın adı aratılır.
            // Eğer böyle bir kitap yoksa veri bulunamadı mesajı verilir.
            SQLiteConnection.Open();
            int satirSayisi = 0;
            SQLiteCommand countCommand = new SQLiteCommand("SELECT COUNT(*) FROM TableKitaplar WHERE KitapAdi = @p1", SQLiteConnection);
            countCommand.Parameters.AddWithValue("@p1", textSilinecek.Text);

            // KitapAdi sütununda aranan değerin olduğu satırlar sayılır.
            // Eğer satır sayısı 0 ise yani kitap yoksa mesaj gönderilir.
            satirSayisi = Convert.ToInt32(countCommand.ExecuteScalar());

            if (satirSayisi == 0)
            {
                MessageBox.Show("Veri bulunamadı.");
                SQLiteConnection.Close();
            }
            else
            {
                // Kitap silinir.
                SQLiteCommand deleteCommand = new SQLiteCommand("DELETE FROM TableKitaplar WHERE KitapAdi = @p1", SQLiteConnection);
                deleteCommand.Parameters.AddWithValue("@p1", textSilinecek.Text);
                deleteCommand.ExecuteNonQuery();
                SQLiteConnection.Close();
                MessageBox.Show("Silme işlemi başarılı.");
            }

            // Silinme sonrası kitaplar yenilenir.
            SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * FROM TableKitaplar", SQLiteConnection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridViewSil.DataSource = table;
            SQLiteConnection.Close();
        }

        private void textSilinecek_TextChanged(object sender, EventArgs e)
        {

        }

        private void textArananKitap_TextChanged(object sender, EventArgs e)
        {
            string arananDeger = textArananKitap.Text.Trim();
            dataGridViewSil.ClearSelection();

            // Textbox boş mu kontrol edilir.
            if (string.IsNullOrEmpty(arananDeger))
                return;

            // DataGridView aranır.
            foreach (DataGridViewRow row in dataGridViewSil.Rows)
            {
                // Her satır tekrar aranır.
                foreach (DataGridViewCell cell in row.Cells)
                {
                    // Aranan değer ile karşılaştırılır.
                    if (cell.Value != null && cell.Value.ToString().Contains(arananDeger))
                    {
                        // Bulunma durumunda satır işaretlenir.
                        row.Selected = true;
                        break;
                    }
                }
            }
        }

        private void dataGridViewSil_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // DataGridView tıklanması halinde veri textboxa aktarılır.
            textSilinecek.Text = dataGridViewSil.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}