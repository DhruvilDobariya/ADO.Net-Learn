using MySqlConnector;
using System.Data;

namespace ADO.Net
{
    public class DataReader
    {
        public static void Main(string[] args)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost; database=bookdb; user=root; password=Admin");

            if(connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            MySqlCommand command = new MySqlCommand("Select * from user", connection);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("{ Id: " + reader.GetInt32(0) + ", Name: " + reader["Name"] + ", Email: " + reader.GetString(2) + " }");
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
