using System.Data;

namespace ADO.Net
{
    public class DataRelationLearn
    {
        public static void Main(string[] args)
        {
            DataSet ds = new DataSet();

            DataTable studentTable = new DataTable("Student");

            studentTable.Columns.AddRange(new DataColumn[]
            {
                new DataColumn() { ColumnName = "StudentId", DataType = typeof(int) },
                new DataColumn() { ColumnName = "StudentName", DataType =  typeof(string) },
                new DataColumn() { ColumnName = "CollageId", DataType = typeof(int) }
            });

            studentTable.Rows.Add(1, "Dhruvil Dobariya", 1);
            studentTable.Rows.Add(2, "Dhhaval Dobariya", 2);
            studentTable.Rows.Add(3, "Bhargav Vachhani", 2);
            studentTable.Rows.Add(4, "Jenil Vasoya", 1);
            studentTable.Rows.Add(5, "Dhruv Rathod", 2);

            DataTable collageTable = new DataTable("Collage");

            collageTable.Columns.AddRange(new DataColumn[]
            {
                new DataColumn() { ColumnName = "CollageId", DataType = typeof(int)},
                new DataColumn() { ColumnName = "CollageName", DataType = typeof(string) }
            });

            collageTable.Rows.Add(1, "Darshan");
            collageTable.Rows.Add(2, "Marwadi");

            ds.Tables.Add(studentTable);
            ds.Tables.Add(collageTable);

            DataRelation dataRelation = new DataRelation("StudentCollageRelationship", ds.Tables["Collage"].Columns["CollageId"], ds.Tables["Student"].Columns["CollageId"]);

            ds.Relations.Add(dataRelation);

            foreach(DataRow element in ds.Tables["Collage"].Rows)
            {
                foreach (DataRow childElement in element.GetChildRows(dataRelation))
                {
                    Console.WriteLine("StudentName: " + childElement["StudentName"] + ", CollageName: " + element["CollageName"]);
                }
            }
        }
    }
}
