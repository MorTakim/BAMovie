using BilgeMVC.Models;
using ProjectTemplate.Core.Abstractions.Service;
using ProjectTemplate.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilgeMVC.Controllers
{
    public class ProducerController : BaseController
    {
        private readonly IServiceProducer _serviceProducer;

        public ProducerController(IServiceProducer serviceProducer)
        {
            _serviceProducer = serviceProducer;
        }

        //GET: Producer
        public PartialViewResult Producers()
        {
            return PartialView("Partial/_Producers", _serviceProducer.GetAll());
        }

        public PartialViewResult ProducerDetail(int id)
        {

            Producer producer = _serviceProducer.GetById(id);
            producer.Movies = _serviceProducer.GetById(id).Movies.ToList();

            return PartialView("Partial/_ProducerDetail", producer);
        }

        public ActionResult Producer()
        {
            if (Session["account"] == null)
            {
                return RedirectToAction("Login", "User");
            }
          
            return View(_serviceProducer.GetAll().ToList());
        }
        ModelProducer mp = new ModelProducer();

        [HttpPost]
        public ActionResult Add(Producer Model)
        {
            if (Session["account"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            List<Producer> producersWithTheSameName = _serviceProducer.GetAll().Where(x =>
                x.CompanyName == Model.CompanyName).ToList();

            List<Producer> producersWithTheSameAddress = _serviceProducer.GetAll().Where(x =>
                x.CompanyAddress == Model.CompanyAddress).ToList();

            if (producersWithTheSameName.Count != 0)
            {
                ModelState.AddModelError("txtCompanyName", "Aynı adla kayıtlı başka yapımcı vardır.");

                return View();
            }

            if (producersWithTheSameAddress.Count != 0)
            {
                ModelState.AddModelError("txtCompanyAddress", "Aynı adrese kayıtlı başka yapımcı vardır.");

                return View();
            }


            Producer producer = new Producer();

            producer.CompanyName = Model.CompanyName;
            producer.ChairManName = Model.ChairManName;
            producer.CompanyAddress = Model.CompanyAddress;
            producer.FormDate = Model.FormDate;
            producer.WebSite = Model.WebSite;

            _serviceProducer.Insert(producer);

            return RedirectToAction("Producer");
        }

        public ActionResult Add()
        {
            if (Session["account"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            Producer Model = new Producer();
            return View("Add", Model);
        }

        [HttpPost]
        public ActionResult Edit(Producer Model)
        {
            if (Session["account"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            Producer producer = _serviceProducer.GetById(Model.Id);

            producer.CompanyName = Model.CompanyName;
            producer.ChairManName = Model.ChairManName;
            producer.CompanyAddress = Model.CompanyAddress;
            producer.FormDate = Model.FormDate;
            
            producer.WebSite = Model.WebSite;

            _serviceProducer.Update(producer);

            return RedirectToAction("Producer");
        }

        public ActionResult Edit(int id)
        {
            if (Session["account"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            Producer Model = new Producer();
            if (ModelState.IsValid)
            {
                var producer = _serviceProducer.GetById(id);

                Model.CompanyName = producer.CompanyName;
                Model.CompanyAddress = producer.CompanyAddress;
                Model.ChairManName = producer.ChairManName;
                Model.FormDate = producer.FormDate;
                Model.WebSite = producer.WebSite;
                Model.Movies = producer.Movies;
            }

            return View("Edit", Model);
        }

        public ActionResult Delete(int id)
        {
            if (Session["account"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            var prd = _serviceProducer.GetById(id);

            _serviceProducer.Delete(prd);

            return RedirectToAction("Producer");
        }

        public ActionResult FilmSelect(int id)
        {
            if (Session["account"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            mp.Producers = _serviceProducer.GetAll().ToList();
            mp.Films = _serviceProducer.GetById(id).Movies.ToList();
            if (mp.Films.Count <= 0)
            {
                return RedirectToAction("Producer");
            }
            return View(mp);
        }
    }
}