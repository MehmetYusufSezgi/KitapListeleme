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
    public partial class FormListele : Form
    {
        // Tüm formlarda önce bağlantı kurulur.
        SQLiteConnection SQLiteConnection = new SQLiteConnection(@"Data Source=C:\Users\msezg\OneDrive\Masaüstü\KitapListeleme\KitapListeleme\DATABASE\DataBaseKitaplar.db;Version=3;");

        public FormListele()
        {
            // Kitaplar listelenir.
            InitializeComponent();
            SQLiteCommand sQLiteCommand = new SQLiteCommand("Select * from TableKitaplar", SQLiteConnection);
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(sQLiteCommand);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridViewListele.DataSource = dataTable;
            dataGridViewListele.Columns["ID"].Visible = false;
            dataGridViewListele.Columns[5].DefaultCellStyle.Format = "yyyy-MM-dd";
            dataGridViewListele.Columns[6].DefaultCellStyle.Format = "yyyy-MM-dd";
            dataGridViewListele.Columns[7].DefaultCellStyle.Format = "yyyy-MM-dd";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Kapatma tuşuna basılarak ana menüye dönülür.
            this.Close();
        }

        private void dataGridViewListele_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}