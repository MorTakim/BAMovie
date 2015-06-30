using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectTemplate.Core.Abstractions.Service;
using ProjectTemplate.Core.Entities;

namespace BilgeMVC.Controllers
{
    public class FilmTypeController : BaseController
    {
        private readonly IServiceFilmType _serviceFilmType;


        public FilmTypeController (IServiceFilmType serviceFilmType)
        {
            _serviceFilmType = serviceFilmType;
        }

        public PartialViewResult FilmTypes()
        {
            return PartialView("Partial/_FilmTypes", _serviceFilmType.GetAll());
        }

        public PartialViewResult FilmTypeDetail(int id)
        {
            FilmType flm = new FilmType();
            flm = _serviceFilmType.GetById(id);
            flm.TypeName = flm.TypeName;
            flm.Movies = flm.Movies;

            return PartialView("Partial/_FilmTypeDetail", flm);
        }


        public ActionResult FilmTypeAdd()
        {
            if (Session["account"] != null)
            {
                return View();
            }
            else
                return RedirectToAction("Login", "User");
        }

        [HttpPost]
        public ActionResult FilmTypeAdd(FilmType FilmType)
        {
            if (Session["account"] != null)
            {
                _serviceFilmType.Insert(FilmType);

                return RedirectToAction("FilmTypeListele", "FilmType");
            }
            else
                return RedirectToAction("Login", "User");
        }


        public ActionResult FilmTypeEdit(int id)
        {
            if (Session["account"] != null)
            {
                return View(_serviceFilmType.GetById(id));
            }
            else
                return RedirectToAction("Login", "User");
        }

        [HttpPost]
        public ActionResult FilmTypeEdit(FilmType FilmType)
        {
            if (Session["account"] != null)
            {
                if (ModelState.IsValid)
                {
                    FilmType guncellenenFilmType = _serviceFilmType.GetById(FilmType.Id);
                    guncellenenFilmType.TypeName = FilmType.TypeName;
                    guncellenenFilmType.Movies = FilmType.Movies;

                    _serviceFilmType.Update(guncellenenFilmType);
                }

                return RedirectToAction("FilmTypeListele", "FilmType");
            }
            else
                return RedirectToAction("Login", "User");
        }

        public ActionResult FilmTypeDelete(int id)
        {
            if (Session["account"] != null)
            {
                _serviceFilmType.Delete(_serviceFilmType.GetById(id));
                return RedirectToAction("FilmTypeListele", "FilmType");

            }
            else
                return RedirectToAction("Login", "User");
        }

        public ActionResult FilmTypeListele()
        {
            return View(_serviceFilmType.GetAll());
        }
    }
}