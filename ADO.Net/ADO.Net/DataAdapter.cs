using MySqlConnector;
using System.Data;

namespace ADO.Net
{
    public class DataAdapter
    {
        public static void Main(string[] args)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost; database=bookdb; user=root; password=Admin");
            MySqlDataAdapter adapter = new MySqlDataAdapter("Select * from user", connection);

            DataTable dt = new DataTable();

            adapter.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine(row["Name"]);
            }
        }
    }
}
