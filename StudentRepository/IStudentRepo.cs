using Softst.Models;

namespace Softst.StudentRepository
{
    public interface IStudentRepo
    {

        //--------------------------course data----------------------
        void AddCourse(Course cor);






        //-----------------------student data----------------------
        void Addstudent(Student cor);
        Task<List<Student>> getstudent();

        Task<Student> getStudentDetails(int Id);
        void UpdateStudent(Student stu);

        void DeleteStudent(int Id);
    }
}
