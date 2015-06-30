using BilgeMVC.Models;
using ProjectTemplate.Core.Abstractions.Service;
using ProjectTemplate.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BilgeMVC.Controllers;

namespace BilgeMVC.Controllers
{
    public class WriterController : Controller
    {
        // GET: Writer

        private readonly IServiceWriter _serviceWriter;

        public WriterController(IServiceWriter serviceWriter)
        {
            
            _serviceWriter = serviceWriter;
        }

        ModelWriter modelwriter = new ModelWriter();

        public ActionResult Writer()
        {
            if (Session["account"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            var list = _serviceWriter.GetAll();

            return View(list);
        }

        public PartialViewResult Writers()
        {
            return PartialView("Partial/_Writers", _serviceWriter.GetAll());
        }

        public PartialViewResult WriterDetail(int id)
        {
            Writer writer = _serviceWriter.GetById(id);
            writer.Movies = _serviceWriter.GetById(id).Movies.ToList();

            return PartialView("Partial/_WriterDetail", writer);
        }

        [HttpPost]
        public ActionResult Edit(Writer writer, HttpPostedFileBase File)
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
                File.SaveAs(Server.MapPath("~/WriterImage/") + File.FileName);
                writer.ImagePath = "/WriterImage/" + File.FileName;
            }
                      
            if (writer.Id > 0)
                _serviceWriter.Update(writer);
            else
                _serviceWriter.Insert(writer);

            return RedirectToAction("Writer");
        }

        public ActionResult Edit(int id)
        {
            if (Session["account"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            Writer viewModel = new Writer();
            if (ModelState.IsValid)//Validation controlu için
            {
                if (id > 0)
                {
                    var writer = _serviceWriter.GetById(id);

                    viewModel.Name = writer.Name;
                    viewModel.Surname = writer.Surname;
                    viewModel.ImagePath = writer.ImagePath;
                    viewModel.BirthDate = writer.BirthDate;
                    viewModel.Movies = writer.Movies;
                }
                else
                {
                    viewModel.Id = 0;
                }
            }

            return View("Edit", viewModel);
        }

        //[AcceptVerbs(HttpVerbs.Delete)]
        //[AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id)
        {
            if (Session["account"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            Writer writ = _serviceWriter.GetById(id);

            if (writ != null)
            {
                _serviceWriter.Delete(writ);
            }

            return RedirectToAction("Writer");
        }

        public ActionResult WriterSelect(int id)
        {
            if (Session["account"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            modelwriter.Writer = _serviceWriter.GetById(id);
            modelwriter.Films = _serviceWriter.GetById(id).Movies.ToList();
            if (modelwriter.Films.Count() <= 0)
            {
                return RedirectToAction("Writer");
            }
            return View(modelwriter);
        }
    }
}