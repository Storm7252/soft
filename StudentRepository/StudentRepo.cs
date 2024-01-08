using Microsoft.EntityFrameworkCore;
using Softst.DatabaseContext;
using Softst.Models;

namespace Softst.StudentRepository
{
    public class StudentRepo:IStudentRepo
    {
        private readonly StudentContext _context;

        public StudentRepo(StudentContext context)
        {
            _context = context;
        }

        //-----------------------course data---------------------------------------

        public async void AddCourse(Course cor)
        {
            _context.Courses.Add(cor);
            _context.SaveChanges();
        }





        //--------------------------------student data----------------------------------------
        public async void Addstudent(Student cor)
        {
            _context.Students.Add(cor);
            _context.SaveChanges();
        }
        public async Task<List<Student>> getstudent()
        {
            var res = _context.Students.ToList();
            return res;
        }
        public  List<Student> getStudentDetails(int Id)
        {
            var res = _context.Students.Where(opt => opt.StudentId == Id).Include(Course=>Course.Course).ToList();
            return res;
        }

        public async void UpdateStudent(Student stu)
        {
            _context.Students.Update(stu);
            _context.SaveChanges();
        }
        public async void DeleteStudent(int Id)
        {
            var personn=_context.Students.Where(opt=>opt.StudentId==Id).FirstOrDefault();
            _context.Students.Remove(personn);
            _context.SaveChanges();
        }
    }
}
