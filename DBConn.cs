using MySqlConnector;
using System.Diagnostics;
namespace cherepashki
{
    internal static class DBConn
    {
        static MySqlConnection connection;
        public static MySqlConnection StartConnection(string auditoriya)
        {
            const string ip_112 = "Server=192.168.56.101;User ID=student;Password=1234567890;Database=test";
            const string ip_306 = "Server=192.168.56.102;User ID=student;Password=1234567890;Database=test";
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
                connection.Open();
                Debug.Print(connection.ServerVersion);
            }
            return connection;
        }
    }
}
