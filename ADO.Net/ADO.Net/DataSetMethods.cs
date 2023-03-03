using System.Data;

namespace ADO.Net
{
    public class DataSetMethods
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

            DataTableReader datatableReader = userDataSet.CreateDataReader(); // It will create datatable reader of dataset.

            // userDataSet.Merge(DataRows[] datarows); it will append row in dataset of first table
            // userDataSet.Merge(DataTable datatable); // it will append datatable in dataset
            // userDataSet.Merge(DataSet dataset); // it will extends dataset with existing dataset

            DataSet cloneDataSet = userDataSet.Clone(); // It will clone structure of dataset.
            DataSet copyDataSet = userDataSet.Copy(); // It will copy structure as well as data of dataset.

            userDataSet.Reset(); // It will cleared all the table, relation and constrains betwwen table.
            userDataSet.Clear(); // It will clear dataset.
        }
    }
}
