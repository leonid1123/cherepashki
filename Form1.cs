using MySqlConnector;
using System;
using System.Windows.Forms;

namespace cherepashki
{
    public partial class Form1 : Form
    {
        MySqlConnection conn;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {//кнопка логина с кривым запросом
            DBConn.StartConnection();
            //SELECT * FROM users WHERE login='user1' AND password='pass1';

            string request = "SELECT * FROM users WHERE login=";
            request = request + "'" + textBox1.Text.Trim() + "'";
            request = request + "AND password='" + textBox2.Text.Trim() + "'";

            MySqlCommand command = new MySqlCommand(request, DBConn.GetConnection());
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                listBox1.Items.Add("логин успешен");
            } else
            {
                listBox1.Items.Add("ошибка логина или пароля");
            }

            DBConn.CloseConn();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {//кнопка подключения
            label5.Text = "Подключение...";
            DBConn.StartConnection();
            label5.Text = DBConn.GetState();
        }
    }
}
