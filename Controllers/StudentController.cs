using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Softst.DatabaseContext;
using Softst.Models;
using Softst.StudentRepository;
using System.Runtime.ConstrainedExecution;

namespace Softst.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentContext stucon;
        private readonly IStudentRepo _studata;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public StudentController(StudentContext stucon,IStudentRepo studata,IWebHostEnvironment webHostEnvironment)
        {
            this.stucon = stucon;
            _studata = studata;
            this._webHostEnvironment = webHostEnvironment;
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
        public async Task<IActionResult> StudentRegister(Student stu)
        {
            string path = "student/pics/";
            path += Guid.NewGuid().ToString() + "_" + stu.ProfilePic.FileName;

            string serverpath = Path.Combine(_webHostEnvironment.WebRootPath,path);
            await stu.ProfilePic.CopyToAsync(new FileStream(serverpath, FileMode.Create));
            stu.profileUrl = "/"+path;
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
            List<Student> res = _studata.getStudentDetails(Id);
            
            return View(res);
        }
        public async Task<IActionResult> Edit(int Id)
        {

            var res = _studata.StudentDetail(Id);
            ViewBag.data = stucon.Courses.ToList();
            return View(res);
        }


        public  async Task<IActionResult> UpdateStudent(Student stdata, IFormFile newPhoto)
        {
            if (newPhoto == null)
            {
                return View(stdata);
            }
            else
            {
               
                string path = "student/pics/";
                path += Guid.NewGuid().ToString() + "_" + newPhoto.FileName;
                string serverpath = Path.Combine(_webHostEnvironment.WebRootPath, path);
                await newPhoto.CopyToAsync(new FileStream(serverpath, FileMode.Create));
                stdata.profileUrl = "/" + path;
                _studata.UpdateStudent(stdata);
                return RedirectToAction("StudentsDetails");
            }
            

        }
        public IActionResult DeleteStudent(int Id)
        {
            _studata.DeleteStudent(Id);
            return RedirectToAction("StudentsDetails");
        }




        

    }
}
