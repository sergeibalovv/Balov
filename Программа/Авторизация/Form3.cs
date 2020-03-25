using System;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Авторизация
{
    public partial class Form3 : Form
    {
        const string connectionString = @"Data Source=sqlstud;Initial Catalog=16is3;Persist Security Info=True;User ID=16is3;Password=16is3";
        public Form3()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "insert into Users (Логин, Пароль, Роль) values ('" + textBox1.Text + "','" + textBox2.Text + " ','" + comboBox1.Text + "')";
                MessageBox.Show(sql);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cp = new SqlCommand(sql, connection);
                    cp.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
               MessageBox.Show("Данный логин уже существует","Ошибка");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
