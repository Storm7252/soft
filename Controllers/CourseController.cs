using Microsoft.AspNetCore.Mvc;
using Softst.Models;
using Softst.StudentRepository;

namespace Softst.Controllers
{
    public class CourseController : Controller
    {
        private readonly IStudentRepo _srepo;

        public CourseController(IStudentRepo srepo)
        {
            _srepo = srepo;
        }
        public IActionResult AddCourse()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult AddCourse(Course courses)
        {
            _srepo.AddCourse(courses);
            return View();
        }
    }
}
