using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Softst.DatabaseContext;
using Softst.Models;
using Softst.StudentRepository;

namespace Softst.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentContext stucon;
        private readonly IStudentRepo _studata;

        public StudentController(StudentContext stucon,IStudentRepo studata)
        {
            this.stucon = stucon;
            _studata = studata;
        }
        public IActionResult Index()
        {
          
            return View();
        }


        public IActionResult StudentRegister()
        {
            ViewBag.data=stucon.Courses.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult StudentRegister(Student stu)
        {
            _studata.Addstudent(stu);
            return RedirectToAction("StudentsDetails");
        }

        public async Task<IActionResult> StudentsDetails()
        {
            var res = await _studata.getstudent();
            return View(res);
        }
        public async Task<IActionResult> Details(int Id)
        {
            var res = await _studata.getStudentDetails(Id);
            
            return View(res);
        }
        public async Task<IActionResult> Edit(int Id)
        {
            var res = await _studata.getStudentDetails(Id);
            ViewBag.data = stucon.Courses.ToList();
            return View(res);
        }
        public  IActionResult UpdateStudent(Student stdata)
        {
            _studata.UpdateStudent(stdata);
            return RedirectToAction("StudentsDetails");
        }
        public IActionResult DeleteStudent(int Id)
        {
            _studata.DeleteStudent(Id);
            return RedirectToAction("StudentsDetails");
        }




        

    }
}
