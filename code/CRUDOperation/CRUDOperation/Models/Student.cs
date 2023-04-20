namespace CRUDOperation.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }

        public int CollageId { get; set; }
        public Collage Collage { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }
    }
}
