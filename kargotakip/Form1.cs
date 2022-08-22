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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglan; //sql ile bağlantıyı sağlar.
        SqlCommand komut; // C# ile sql kodlarını birleştirir.karşılaştırma
        SqlDataReader oku; //sql verileri okuma işlemi yapar
        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "Select * from login where kullanıcıadı=@kullanıcıadı AND şifre=@şifre";
            baglan = new SqlConnection("server=LAPTOP-B7T40IKF\\SQLEXPRESS01; Initial Catalog=kargo; Integrated Security=True");
            komut = new SqlCommand(sorgu, baglan);
            komut.Parameters.AddWithValue("@kullanıcıadı", textBox1.Text);
            komut.Parameters.AddWithValue("@şifre", textBox2.Text);
            baglan.Open();
            oku = komut.ExecuteReader();//komut içindeki okumalar
            if (oku.Read())
            {
                MessageBox.Show("Başarılı Giriş");
                Form2 f2 = new Form2();
                f2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifreyi yanlış girdiniz");



            }
            baglan.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }
    }
}