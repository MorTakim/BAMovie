using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectTemplate.Core.Abstractions.Service;
using ProjectTemplate.Core.Entities;
using BilgeMVC.Controllers;



namespace BilgeMVC.Controllers
{
    public class DirectorController : Controller
    {
        // GET: Director
        private readonly IServiceDirector _serviceDirector;

        public DirectorController(IServiceDirector serviceDirector)
        {
            _serviceDirector = serviceDirector;


        }
        public ActionResult Director()
        {
            if (Session["account"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            var list = _serviceDirector.GetAll();
            return View(list);
        }

        public PartialViewResult Directors()
        {
            return PartialView("Partial/_Directors", _serviceDirector.GetAll());
        }

        public PartialViewResult DirectorDetail(int id)
        {
            Director director = _serviceDirector.GetById(id);
            director.Movies = _serviceDirector.GetById(id).Movies.ToList();

            return PartialView("Partial/_DirectorDetail", director);
        }

        [HttpPost]
        public ActionResult Edit(Director director, HttpPostedFileBase File)
        {
            if (Session["account"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (File != null)
            {
                File.SaveAs(Server.MapPath("~/DirectorImage/") + File.FileName);
                director.ImagePath = "/DirectorImage/" + File.FileName;
            }

            if (director.Id > 0)
                _serviceDirector.Update(director);
            else
                _serviceDirector.Insert(director);

            return RedirectToAction("Director", "Director");
        }
        public ActionResult Edit(int id)
        {
            if (Session["account"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            Director viewModel = new Director();

            if (id > 0)
            {
                var Director = _serviceDirector.GetById(id);
                viewModel.Name = Director.Name;
                viewModel.Surname = Director.Surname;
                viewModel.ImagePath = Director.ImagePath;
                viewModel.BirthDate = Director.BirthDate;
                viewModel.Movies = Director.Movies;
            }
            else
            {
                viewModel.Id = 0;
            }

            return View("Edit", viewModel);

        }

        public ActionResult Delete(int id)
        {
            if (Session["account"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            var Director = _serviceDirector.GetById(id);
            _serviceDirector.Delete(Director);
            return RedirectToAction("Director", "Director");
        }

        public ActionResult FilmSelect(int id)
        {
            if (Session["account"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            var films= _serviceDirector.GetById(id).Movies.ToList();
            if (films.Count <= 0)
            {
                return RedirectToAction("Director", "Director");
            }
            return View(films);
        }
    }
}