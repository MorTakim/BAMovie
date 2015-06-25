using System.Web.Mvc;
using ProjectTemplate.Core.Abstractions.Service;
using ProjectTemplate.Core.Entities;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IServiceStudent _serviceStudent;

        public HomeController(IServiceStudent serviceStudent)
        {
            _serviceStudent = serviceStudent;
        }

        public ViewResult Index()
        {
            var list = _serviceStudent.GetAll();
            return View(list);
        }

        [HttpPost]
        public ActionResult Edit(ModelStudent model)
        {
            var stu = new Student
            {
                Id = model.Id,
                Firstname = model.Firstname,
                Lastname = model.Lastname
            };

            if (model.Id > 0)
                _serviceStudent.Update(stu);
            else
                _serviceStudent.Insert(stu);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ModelStudent viewModel = new ModelStudent();

            if (id > 0)
            {
                var student = _serviceStudent.GetById(id);

                viewModel.Id = student.Id;
                viewModel.Firstname = student.Firstname;
                viewModel.Lastname = student.Lastname;
            }
            else
            {
                viewModel.Id = 0;
            }

            return View("Edit", viewModel);
        }

        //[AcceptVerbs(HttpVerbs.Delete)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id)
        {
            var stud = _serviceStudent.GetById(id);
            _serviceStudent.Delete(stud);

            return RedirectToAction("Index");
        }


        public ActionResult GetStudentsBySurname()
        {
            return View("GetStudentsBySurname");
        }

        [HttpPost]
        public ActionResult GetBySurname(string lastname)
        {
            var students = _serviceStudent.GetStudentsByLastname(lastname);
            return View("Index", students);
        }
    }
}