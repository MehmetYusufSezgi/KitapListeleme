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
    public partial class FormListele : Form
    {
        //Tüm formlarda önce bağlantı kurulur.
        SqlConnection SqlConnection = new SqlConnection(@"server=(localdb)\mssqllocaldb;initial catalog=DBKitaplar;integrated security=true");

        public FormListele()
        {
            //Kitaplar listelenir.
            InitializeComponent();
            SqlCommand sqlCommand = new SqlCommand("Select * from TBLKitaplar", SqlConnection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
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
            //Kapatma tuşuna basılarak ana menüye dönülür.
            this.Close();
        }

        private void dataGridViewListele_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
