using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Авторизация
{
    public partial class Form1 : Form
    {
        Timer timer1 = new Timer();
        int k = 0;       
        public Form1()
        {
            InitializeComponent();           
        }
        int i=0;
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void com()
        {
            if (k==3)
            {           
                timer1.Start();
                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Interval = 1000;
            }
            else if (k>3)
            {
                timer1.Start();
                timer1.Interval = 1000;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            {              
                SqlConnection con = new SqlConnection(@"Data Source=sqlstud;Initial Catalog=16is3;Persist Security Info=True;User ID=16is3;Password=16is3");//строка подключения
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From Users Where Users.Логин='" + textBox1.Text + "' and Users.Пароль = '" + textBox2.Text + "' and Роль='Manager'", con);
            DataTable table = new DataTable();
            sda.Fill(table);
            //Очень легкий цикл
            if ( textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Заполните все строки");
            }
            else
            {
                    if (table.Rows[0][0].ToString() == "1")
                    {
                        MessageBox.Show("Manager");
                    }
                    else
                    {
                        SqlDataAdapter sdaA = new SqlDataAdapter("Select Count(*) From Users Where Логин='" + textBox1.Text + "' and Пароль = '" + textBox2.Text + "' and Роль='admin'", con);
                        sdaA.Fill(table);
                        if (table.Rows[1][0].ToString() == "1")
                        {
                            Hide();
                            Form2 f2 = new Form2();
                            f2.Show();
                        }
                        else 
                        {
                            k++;
                            MessageBox.Show("Вы ошиблись с вводом данных","Ошибка!");
                                com();
                        }    
                    }     
                }   
        }
            }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (i == 15)
            {
                button1.Enabled = true;
                //Hide();
                //Form1 f4 = new Form1();
                //f4.Show();
                timer1.Stop();
                i = -1;
                this.button1.Text = (++i).ToString();
                this.button1.Text = "Войти";
            }
            else
            {
                button1.Enabled = false;
               
               this.button1.Text = (++i).ToString();
            }
            
        }
    }
    }


