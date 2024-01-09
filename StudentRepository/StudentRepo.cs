using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using Softst.DatabaseContext;
using Softst.Models;
using System.Runtime.ConstrainedExecution;

namespace Softst.StudentRepository
{
    public class StudentRepo:IStudentRepo
    {
        private readonly StudentContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public StudentRepo(StudentContext context,IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this._webHostEnvironment = webHostEnvironment;
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
            var student = new Student()
            {
                StudentId = cor.StudentId,
                Name = cor.Name,
                Address = cor.Address,
                Email = cor.Email,
                FathersName = cor.FathersName,
                DOB = cor.DOB,
                AdhaarNo = cor.AdhaarNo,
                DateOfRegister = cor.DateOfRegister,
                CourseId = cor.CourseId,
                profileUrl = cor.profileUrl
            };
            _context.Students.Add(student);
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
        public Student StudentDetail(int Id)
        { 
            var stu = _context.Students.Include(course => course.Course).Where(opt => opt.StudentId == Id).FirstOrDefault();
            return stu;
        }

        public async void UpdateStudent(Student cor)
        {
           
            var newstudent = new Student()
            {
                StudentId = cor.StudentId,
                Name = cor.Name,
                Address = cor.Address,
                Email = cor.Email,
                FathersName = cor.FathersName,
                DOB = cor.DOB,
                AdhaarNo = cor.AdhaarNo,
                DateOfRegister = cor.DateOfRegister,
                CourseId = cor.CourseId,
                profileUrl = cor.profileUrl
            };
                _context.Students.Update(newstudent);
                _context.SaveChanges();

            //--------delete old photo from static folder--------------------------


             var olddata = _context.Students.Where(opt => opt.StudentId == cor.StudentId).FirstOrDefault();
            string oldprofileurl = _webHostEnvironment + olddata.profileUrl;
            
                
                if (System.IO.File.Exists(oldprofileurl))
                {
                    System.IO.File.Delete(oldprofileurl);
                }
        }
           
        
        public async void DeleteStudent(int Id)
        {
            var personn=_context.Students.Where(opt=>opt.StudentId==Id).FirstOrDefault();
            _context.Students.Remove(personn);
            _context.SaveChanges();
        }
    }
}
