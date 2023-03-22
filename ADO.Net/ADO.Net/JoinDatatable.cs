using System.Data;
using System.Linq;

namespace ADO.Net
{
    public class JoinDatatable
    {
        public static void Main(string[] args)
        {
            DataTable studentTable = new DataTable();

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

            DataTable collageTable = new DataTable();

            collageTable.Columns.AddRange(new DataColumn[]
            {
                new DataColumn() { ColumnName = "CollageId", DataType = typeof(int)},
                new DataColumn() { ColumnName = "CollageName", DataType = typeof(string) }
            });

            collageTable.Rows.Add(1, "Darshan");
            collageTable.Rows.Add(2, "Marwadi");

            var result = (from student in studentTable.AsEnumerable()
                          join collage in collageTable.AsEnumerable()
                          on student.Field<int>("CollageId") equals collage.Field<int>("CollageId")
                          select new Student
                          {
                              Id = student.Field<int>("StudentId"),
                              Name = student.Field<string>("StudentName"),
                              CollageId = student.Field<int>("CollageId"),
                              Collage = new Collage { 
                                  CollageId = collage.Field<int>("CollageId"), 
                                  CollageName = collage.Field<string>("CollageName")
                              }
                          }).ToList();

            result.ForEach((x) =>
            {
                Console.WriteLine("Name: " + x.Name + ", Collage: " + x.Collage.CollageName);
            });
        }
    }
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CollageId { get; set; }
        public Collage Collage { get; set; }
    }
    public class Collage
    {
        public int CollageId { get; set; }
        public string CollageName { get; set; }
        public List<Student> Students { get; set;}
    }
}
