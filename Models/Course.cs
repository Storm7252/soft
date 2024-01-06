using System.ComponentModel.DataAnnotations;

namespace Softst.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        public string CourseName { get; set; }

       /* [Required]
        public int CourseFee { get;}
        [Required]*/
       // public IFormFile CoursePdf { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
