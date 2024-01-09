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

        List<Student> getStudentDetails(int Id);
        Student StudentDetail(int Id);
        void UpdateStudent(Student cor);

        void DeleteStudent(int Id);
    }
}
