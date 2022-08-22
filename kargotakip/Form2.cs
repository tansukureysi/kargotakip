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

namespace kargotakip
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("server=LAPTOP-B7T40IKF\\SQLEXPRESS01; Initial Catalog=kargo; Integrated Security =True");

        private void veri()
        {
            baglan.Open();
            string getir = "select * from kargotakip";
            SqlDataAdapter da = new SqlDataAdapter(getir, baglan);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();
           
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            veri();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand ekle = new SqlCommand("insert into kargotakip (isim,soyisim,telefon,adres,durum) values(@isim,@soyisim,@telefon,@adres,@durum)", baglan);
            ekle.Parameters.AddWithValue("@isim", textBox2.Text);
            ekle.Parameters.AddWithValue("@soyisim", textBox3.Text);
            ekle.Parameters.AddWithValue("@telefon", textBox4.Text);
            ekle.Parameters.AddWithValue("@adres", textBox5.Text);
            ekle.Parameters.AddWithValue("@durum", textBox6.Text);
            ekle.ExecuteNonQuery();
            baglan.Close();
            veri();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand guncelle = new SqlCommand("update kargotakip set isim=@isim,soyisim=@soyisim,telefon=@telefon,adres=@adres,durum=@durum", baglan);
            guncelle.Parameters.AddWithValue("@isim", textBox2.Text);
            guncelle.Parameters.AddWithValue("@soyisim", textBox3.Text);
            guncelle.Parameters.AddWithValue("@telefon", textBox4.Text);
            guncelle.Parameters.AddWithValue("@adres", textBox5.Text);
            guncelle.Parameters.AddWithValue("@durum", textBox6.Text);
            guncelle.ExecuteNonQuery();
            baglan.Close();
            veri();

            MessageBox.Show("güncelleme tamamlandı.");
        }


        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from kargotakip where durum='yolda'", baglan);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from kargotakip", baglan);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from kargotakip where durum='teslim'", baglan);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();

        }
    }
}
