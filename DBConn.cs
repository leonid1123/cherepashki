using MySqlConnector;
using System.Diagnostics;
namespace cherepashki
{
    internal static class DBConn
    {
        static MySqlConnection connection;
        static string state = "";
        public static string GetState()
        {
            return state;
        }
        public static MySqlConnection StartConnection(string auditoriya)
        {
            const string ip_112 = "Server=192.168.56.101;User ID=student;" +
                "Password=1234567890;Database=test";
            const string ip_306 = "Server=192.168.56.102;User ID=student;" +
                "Password=1234567890;Database=test";
            switch (auditoriya)
            {
                case "112":
                    connection = new MySqlConnection(ip_112);
                    break;
                case "306":
                    connection = new MySqlConnection(ip_306);
                    break;
                default:
                    connection = null;
                    break;
            }
            if (connection != null)
            {
                try
                {
                    connection.Open();
                    Debug.WriteLine("Подключение прошло");
                    state = "Подключение к БД успешно";
                }
                catch (MySqlException ex) 
                {
                    connection = null;
                    if (ex.Message== "Connect Timeout expired.")
                    {
                        Debug.WriteLine("Ошибка подключения");
                        state = "Подключение не удалось";
                    }
                }
            }
            return connection;
        }
    }
}
