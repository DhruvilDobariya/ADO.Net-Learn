using System.Data;

namespace ADO.Net
{
    public class DataTableMethods
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

            userTable.AcceptChanges(); // it commit all changes which done on this table.
            userTable.RejectChanges(); // it reject all changes which done on this table.
            userTable.GetChanges(); // It will return all changes from load datatable or last AcceptChanges() called.

            DataTable cloneDataTable = userTable.Clone(); // clone structure of datatable
            DataTable copyDatatable = userTable.Copy(); // Copy all data as well as structure of datatable

            DataTableReader dtr = userTable.CreateDataReader(); // create instance of DataTableReader with data

            DataRow dr = userTable.NewRow(); // Creates a new row, which is later added by calling the Rows.Add method

            DataRow[] dataRows = userTable.Select(); // Get array of rows based on criteria

            DataRow[] dtErrors = userTable.GetErrors(); // give array of datarows which have some errors

            // userTable.Load(objDataReader); // load data from data reader
            // userTable.Merge(objDataTable); // merge two datatable

            userTable.Reset(); // Reset all original state of datatable.
            userTable.Clear(); // it clear all data of table

        }
    }
}
