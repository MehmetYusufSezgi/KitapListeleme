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
//Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="C:\Users\msezg\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\DataBaseKitaplar.mdf";Integrated Security=True;Connect Timeout=30

namespace KitapListeleme
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //Form geçişlerinde eski formları kapatıp yeniyi açmak yerine ana formun içinde alt formlar açılır.
        //Bir sıralama yöntemi ile tıklanan form çağırımı en üst sıraya konur.
        private Form mevcutForm = null;
        private void formDegistir(Form altForm)
        {
            if (mevcutForm != null)
            {
                mevcutForm.Close();
            }
            mevcutForm = altForm;
            altForm.TopLevel = false;
            altForm.FormBorderStyle = FormBorderStyle.None;
            altForm.Dock = DockStyle.Fill;
            panelAltForm.Controls.Add(altForm);
            panelAltForm.Tag = altForm;
            altForm.BringToFront();
            altForm.Show(); 
        }
        //Butonlarla alt formlar çağırılır.
        private void buttonCikis_Click(object sender, EventArgs e)
        {
            formDegistir(new FormListele());
        }

        private void buttonSil_Click(object sender, EventArgs e)
        {
            formDegistir(new FormSil());
        }

        private void buttonEkle_Click(object sender, EventArgs e)
        {
            formDegistir(new FormEkle());

        }

        private void buttonListele_Click(object sender, EventArgs e)
        {
            formDegistir(new FormDuzenle());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
