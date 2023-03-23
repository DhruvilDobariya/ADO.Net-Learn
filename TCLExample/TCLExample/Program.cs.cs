using MySqlConnector;
using System.Data;

namespace TCLExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MySqlConnection objConnection = new MySqlConnection("server=localhost; database=studentdb; username=root; password=Admin");
            MySqlTransaction objTransaxtion = null; // transaction start
            try
            {
                if (objConnection.State != ConnectionState.Open)
                {
                    objConnection.Open();
                }

                objTransaxtion = objConnection.BeginTransaction();

                MySqlCommand objCommand = new MySqlCommand("Insert into student (Name, RollNo, Email, ContactNo) values ('Sanjay Vadhiya', 143, 'san@gmail.com', '7845448779')", objConnection, objTransaxtion);
                objTransaxtion.Save("Savepoint 1");
                int result1 = objCommand.ExecuteNonQuery();

                objCommand.CommandText = "Insert into student (Name, RollNo, Email, ContactNo) values ('Shivam Nanda', 145, 'shivam@gmail.com', '7842348779')";
                objTransaxtion.Save("Savepoint 2");
                int result2 = objCommand.ExecuteNonQuery();

                objCommand.CommandText = "Insert into student (Name, RollNo, Email, ContactNo) values ('Dhruvil Dobariya', 21, 'dhruvil@gmail.com', '4528522523')";
                objTransaxtion.Save("Savepoint 3");
                int result3 = objCommand.ExecuteNonQuery();

                objTransaxtion.Rollback("Savepoint 2");
                objTransaxtion.Commit();

                if (objConnection.State != ConnectionState.Closed)
                {
                    objConnection.Close();
                }
            }
            catch (Exception ex)
            {
                objTransaxtion.Rollback();
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (objConnection.State != ConnectionState.Closed)
                {
                    objConnection.Close();
                }
            }
        }
    }
}
