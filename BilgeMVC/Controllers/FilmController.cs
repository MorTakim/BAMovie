using ProjectTemplate.Core.Abstractions.Service;
using ProjectTemplate.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilgeMVC.Controllers
{
    public class FilmController : BaseController
    {
        private readonly IServiceFilm _serviceFilm;

        public FilmController(IServiceFilm serviceFilm)
        {
            _serviceFilm = serviceFilm;
        }

        public PartialViewResult Films()
        {
            return PartialView("Partial/_Films", _serviceFilm.GetAll());
        }

        public PartialViewResult FilmDetail(int id)
        {
            Film flm = new Film();
            flm = _serviceFilm.GetById(id);
            flm.Actors = _serviceFilm.GetById(id).Actors.ToList();
            flm.Directors = _serviceFilm.GetById(id).Directors.ToList();
            flm.Writers = _serviceFilm.GetById(id).Writers.ToList();
            flm.Producers = _serviceFilm.GetById(id).Producers.ToList();
            flm.FilmTypes = _serviceFilm.GetById(id).FilmTypes.ToList();

            return PartialView("Partial/_FilmDetail", flm);
        }


        public ActionResult FilmAdd()
        {
            if (Session["account"] != null)
            {
                return View();
            }
            else
                return RedirectToAction("Login", "User");
        }

        [HttpPost]
        public ActionResult FilmAdd(Film film, string txtPublishDate, HttpPostedFileBase File)
        {
            if (Session["account"] != null)
            {
                DateTime dt = Convert.ToDateTime(txtPublishDate);

                film.PublishDate = dt;

                if (File != null)
                {
                    File.SaveAs(Server.MapPath("~/FilmPosters/") + File.FileName);
                    film.PosterImgPath = "/FilmPosters/" + File.FileName;
                }

                _serviceFilm.Insert(film);

                return RedirectToAction("FilmListele", "Film");
            }
            else
                return RedirectToAction("Login", "User");
        }


        public ActionResult FilmEdit(int id)
        {
            if (Session["account"] != null)
            {
                return View(_serviceFilm.GetById(id));
            }
            else
                return RedirectToAction("Login", "User");
        }

        [HttpPost]
        public ActionResult FilmEdit(Film film)
        {
            if (Session["account"] != null)
            {
                if (ModelState.IsValid)
                {
                    Film guncellenenFilm = _serviceFilm.GetById(film.Id);
                    guncellenenFilm.Name = film.Name;
                    guncellenenFilm.PublishDate = film.PublishDate;
                    guncellenenFilm.ImdbPoint = film.ImdbPoint;
                    guncellenenFilm.Website = film.Website;

                    _serviceFilm.Update(guncellenenFilm);
                }

                return RedirectToAction("FilmListele", "Film");
            }
            else
                return RedirectToAction("Login", "User");
        }

        public ActionResult FilmDelete(int id)
        {
            if (Session["account"] != null)
            {
                _serviceFilm.Delete(_serviceFilm.GetById(id));
                return RedirectToAction("FilmListele", "Film");

            }
            else
                return RedirectToAction("Login", "User");
        }

        public ActionResult FilmListele()
        {
            return View(_serviceFilm.GetAll());
        }

    }
}