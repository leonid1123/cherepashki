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
            string request = "SELECT integer FROM testTable1 WHERE name=";
            request += textBox1.Text.Trim();
            
            MySqlCommand cmd = new MySqlCommand(request);
            MySqlDataReader reader = cmd.ExecuteReader();
            listBox1.Items.Add(reader.GetString(0));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {//кнопка подключения
            label5.Text = "Подключение...";
            DBConn.StartConnection(comboBox1.Text);
            label5.Text = DBConn.GetState();
        }
    }
}
