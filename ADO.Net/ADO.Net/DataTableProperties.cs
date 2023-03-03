using System.Data;

namespace ADO.Net
{
    public class DataTableProperties
    {
        public static void Main(string[] args)
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

            Console.WriteLine(userTable.DataSet.DataSetName);
            Console.WriteLine(userTable.TableName);
            Console.WriteLine(userTable.PrimaryKey[0]);
            Console.WriteLine(userTable.MinimumCapacity);
            Console.WriteLine(userTable.DefaultView);
            Console.WriteLine(userTable.HasErrors);

            foreach (Constraint element in userTable.Constraints)
            {
                Console.WriteLine(element.ConstraintName);
            }
            foreach (DataRow element in userTable.Rows)
            {
                Console.WriteLine(element);
            }
        }
    }
}
