using MySqlConnector;
using System.Data;

namespace ADO.Net
{
    public class DataReader
    {
        public static void Main(string[] args)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost; database=bookdb; user=Admin; password=gs@123");

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            MySqlCommand command = new MySqlCommand("Select * from user", connection);

            MySqlDataReader reader = command.ExecuteReader();

            //if (reader.HasRows)
            //{
            //    while (reader.Read())
            //    {
            //        Console.WriteLine("{ Id: " + reader.GetInt32(0) + ", Name: " + reader["Name"] + ", Email: " + reader.GetString(2) + " }");
            //    }
            //}

            // One's we read datareader then it can't load in datatable.

            // particular element
            DataTable dt = new DataTable();
            dt.Load(reader);
            var name = dt.Rows[4]["Name"];
            Console.WriteLine(name);

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
