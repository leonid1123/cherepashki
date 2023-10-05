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
            string request = "SELECT password FROM users WHERE login=";
            request = request + "'" + textBox1.Text.Trim() + "'";
            MySqlCommand command = new MySqlCommand(request, DBConn.GetConnection());
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                listBox1.Items.Add(reader.GetString(0));
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
