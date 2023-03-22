using System.Data;

namespace ADO.Net
{
    public class MergeDatatable
    {
        public static void Main(string[] args)
        {
            // User Table
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

            DataRow drUser = userTable.NewRow();
            drUser[0] = 1;
            drUser["Name"] = "Dhruvil Dobariya";
            userTable.Rows.Add(drUser);

            // Student Table
            DataTable studentTable = new DataTable("User");

            studentTable.Columns.Add(new DataColumn()
            {
                DataType = typeof(int),
                ColumnName = "Id",
                Unique = true,
                AllowDBNull = false,
                AutoIncrement = true,
                AutoIncrementSeed = 0,
                AutoIncrementStep = 1,
                Caption = "Id of Student",
                ReadOnly = true
            });
            studentTable.Columns.Add(new DataColumn()
            {
                DataType = typeof(string),
                ColumnName = "Name",
                AllowDBNull = true,
                MaxLength = 250,
                DefaultValue = null,
                Prefix = "Name",
            });

            DataColumn[] studentPrimaryKeys = new DataColumn[1];
            studentPrimaryKeys[0] = studentTable.Columns["Id"];
            studentTable.PrimaryKey = studentPrimaryKeys;

            DataRow drStudent = studentTable.NewRow();
            studentTable.Rows.Add(1, "Dhaval Dobariya");

            Console.WriteLine("User Table");
            foreach (DataRow element in userTable.Rows)
            {
                Console.WriteLine("Id: " + element[0] + ", Name: " + element["Name"]);
            }

            Console.WriteLine("Student Table");
            foreach (DataRow element in studentTable.Rows)
            {
                Console.WriteLine("Id: " + element[0] + ", Name: " + element["Name"]);
            }

            Console.WriteLine("User Table after merge with student table");

            userTable.Merge(studentTable);
            // When  we merge two table, sequence of column name and datatype must be same in both table.

            foreach (DataRow element in userTable.Rows)
            {
                Console.WriteLine("Id: " + element[0] + ", Name: " + element["Name"]);
            }
        }
    }
}
