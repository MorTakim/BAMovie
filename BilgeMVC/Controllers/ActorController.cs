using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectTemplate.Core.Abstractions.Service;
using ProjectTemplate.Core.Entities;
using System.IO;
using BilgeMVC.Models;

namespace BilgeMVC.Controllers
{
    public class ActorController : Controller
    {
        // GET: Actor
        private readonly IServiceActor _serviceActor;

       
        ModelActor ModelActor = new ModelActor();

        public ActorController(IServiceActor serviceActor)
        {
            _serviceActor = serviceActor;
        }

        public PartialViewResult Actors()
        {
            return PartialView("Partial/_Actors", _serviceActor.GetAll());
        }

        public PartialViewResult ActorDetail(int id)
        {
            Actor actor = _serviceActor.GetById(id);
            actor.Movies = _serviceActor.GetById(id).Movies.ToList();

            return PartialView("Partial/_ActorDetail", actor);
        }

        public ActionResult Actor()
        {
            if (Session["account"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            ModelActor.Actors = _serviceActor.GetAll().ToList();
            return View(ModelActor);
        }

        [HttpPost]
        public ActionResult Edit(Actor Model, HttpPostedFileBase File)
        {
            if (Session["account"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            if (!ModelState.IsValid)
            {               
                return View();
            }            
            Actor actor = _serviceActor.GetById(Model.Id);          
            if (File != null)
            {
                File.SaveAs(Server.MapPath("~/Images/") + File.FileName);
                actor.ImagePath = "/Images/" + File.FileName;
            }
            else
            {
                ModelState.AddModelError("File", "Resim alanı boş geçilemez.");
            }
            actor.Name = Model.Name;
            actor.Surname = Model.Surname;
            actor.BirthDate = Model.BirthDate;

            if (actor.Id > 0)
                _serviceActor.Update(actor);
           
            return RedirectToAction("Actor","Actor");
        }

        public ActionResult Edit(int id)
        {
            if (Session["account"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            Actor viewModel = new Actor();

            if (id > 0)            {
                var actor = _serviceActor.GetById(id);
                viewModel.Name = actor.Name;
                viewModel.Surname = actor.Surname;
                viewModel.ImagePath = actor.ImagePath;
                viewModel.BirthDate = actor.BirthDate;
                viewModel.Movies = actor.Movies;
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
            var actor = _serviceActor.GetById(id);
            _serviceActor.Delete(actor);
            return RedirectToAction("Actor", "Actor");
        }

        public ActionResult Insert()
        {
            if (Session["account"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Insert(Actor Model, string txtBirthDate, HttpPostedFileBase File)
        {
            if (Session["account"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (String.IsNullOrEmpty(txtBirthDate))
            {                
                ModelState.AddModelError("txtBirthDate", "Doğum tarihi boş bırakılamaz");
                
                return View();
            }
            Actor actor = new Actor();
            if (File != null)
            {
                File.SaveAs(Server.MapPath("~/Images/") + File.FileName);
                actor.ImagePath = "/Images/" + File.FileName;
            }
            else
            {
                ModelState.AddModelError("File", "Resim alanı boş geçilemez.");
            }
            actor.Name = Model.Name;
            actor.Surname = Model.Surname;
            actor.BirthDate =Convert.ToDateTime(txtBirthDate);
            _serviceActor.Insert(actor);

            return RedirectToAction("Actor", "Actor");
        }

        public ActionResult FilmSelect(int id)
        {
            if (Session["account"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            ModelActor.Actors = _serviceActor.GetAll().ToList();
            ModelActor.Films = _serviceActor.GetById(id).Movies.ToList();           
            if (ModelActor.Films.Count <= 0)
            {
                return RedirectToAction("Insert");
            }
            return View(ModelActor);
        }


        
    }
}