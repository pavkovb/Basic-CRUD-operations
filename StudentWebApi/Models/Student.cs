using System.ComponentModel.DataAnnotations;

namespace StudentWebApi.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}