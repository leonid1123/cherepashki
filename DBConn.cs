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
        public static MySqlConnection GetConnection()
        {//метод может вернуть подключение со значением null!!!
         //необходима проверка
            return connection;
        }
        public static void CloseConn()
        {
            connection.Close();
        }
        public static MySqlConnection StartConnection()
        {
            const string ip_112 = "Server=192.168.56.101;User ID=student;" +
                "Password=1234567890;Database=test";
            connection = new MySqlConnection(ip_112);
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
                    Debug.WriteLine("Подключение не произошло");
                    Debug.WriteLine(ex.Message);
                    Debug.WriteLine(ex.ErrorCode);
                    state = "Подлючение не произошло";
                }
            }
            return connection;
        }
    }
}
