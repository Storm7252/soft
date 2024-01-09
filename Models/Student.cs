using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Softst.Models
{
    public class Student
    {
        public Student()
        {
            this.DateOfRegister = DateTime.Now;
        }
        [Key]
        [Required]
        public int StudentId { get; set; }


        [Required]
        public string Name { get; set; }


        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string FathersName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required]
        
        public string AdhaarNo { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfRegister { get; set; }

        [NotMapped]
        public IFormFile ProfilePic { get; set; }

        public string profileUrl { get; set; }
        [Required]
        public int CourseId { get; set; }


        public Course Course { get; set; }




    }
}
