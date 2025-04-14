using System.ComponentModel.DataAnnotations; 


namespace UniversityApp.Models
{
    public class Student
    {
        [Key]
        public int RecordBookNumber { get; set; }

        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

        public string? Patronymic { get; set; }

        [Required]
        public int GroupID { get; set; }
         
        public Group? Group { get; set; }

        public List<Record> Records { get; set; } = new();
    }

    public class Group
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public required string Specialty { get; set; }

        [Required]
        public required string Abbreviation { get; set; }

        [Required]
        public required string Faculty { get; set; }

        [Required]
        public int YearOfAdmission { get; set; }
         
        public List<Student> Students { get; set; } = new();
    }

    public class Subject
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public required string Designation { get; set; }
         
        public List<Record> Records { get; set; } = new();
    }

    public class Record
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int RecordBookNumber { get; set; }

        [Required]
        public int Semester { get; set; }

        [Required]
        public int SubjectID { get; set; }

        [Required]
        public int Grade { get; set; }

        [Required]
        public bool IsCourseProject { get; set; } 

        public Subject? Subject { get; set; }

        public Student? Student { get; set; }
    }
}
