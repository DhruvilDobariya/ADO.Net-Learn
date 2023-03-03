using System.Data;

namespace ADO.Net
{
    public class DataSetProperties
    {
        public static void Main()
        {
            DataSet userDataSet = new DataSet("UserDB");
            DataTable userTable = new DataTable("User");

            userTable.Columns.Add(new DataColumn()
            {
                DataType = typeof(int),
                ColumnName = "Id",
                Unique = true,
                AllowDBNull = false,
                AutoIncrement = true,
                AutoIncrementSeed = 0,
                AutoIncrementStep = 1,
                Caption = "Id of Customer",
                ReadOnly = true
            });
            userTable.Columns.Add(new DataColumn()
            {
                DataType = typeof(string),
                ColumnName = "Name",
                AllowDBNull = true,
                MaxLength = 250,
                DefaultValue = null,
                Prefix = "Name",
            });

            DataColumn[] primaryKeys = new DataColumn[1];
            primaryKeys[0] = userTable.Columns["Id"];
            userTable.PrimaryKey = primaryKeys;

            userDataSet.Tables.Add(userTable);

            Console.WriteLine(userDataSet.CaseSensitive);
            Console.WriteLine(userDataSet.HasErrors);
            Console.WriteLine(userDataSet.DataSetName);
            Console.WriteLine(userDataSet.IsInitialized);
            Console.WriteLine(userDataSet.Namespace);

            foreach (DataTable table in userDataSet.Tables)
            {
                Console.WriteLine(table.TableName);
            }
        }
    }
}
