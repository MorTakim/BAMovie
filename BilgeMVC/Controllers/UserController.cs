using ProjectTemplate.Core.Abstractions.Service;
using ProjectTemplate.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectTemplate.Core.Enums;

namespace BilgeMVC.Controllers
{
    public class UserController : BaseController
    {
        private readonly IServiceUser _serviceUser;

        public UserController(IServiceUser serviceUser)
        {
            _serviceUser = serviceUser;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string eMail, string password)
        {
            var result = _serviceUser.LoginControl(eMail, password);
            if (result != null)
            {
                Session.Add("account", result);
                return RedirectToAction("Admin", "User");
            }
            else
            {
                ViewBag.Message = "Geçersiz kullanıcı adı ya da şifre!";
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session["account"] = null;
            return RedirectToAction("Index", "Base");
        }

        public ActionResult Admin()
        {
            if (Session["account"] != null)
            {
                return View(_serviceUser.GetAll());
            }
            else
                return RedirectToAction("Login", "User");
        }

        public ActionResult Edit(int id)
        {
            if (Session["account"] != null)
            {
                return View(_serviceUser.GetById(id));
            }
            else
                return RedirectToAction("Login", "User");
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (Session["account"] != null)
            {
                if (ModelState.IsValid)
                {
                    User updated = _serviceUser.GetById(user.Id);
                    updated.Name = user.Name;
                    updated.Surname = user.Surname;
                    updated.Email = user.Email;
                    _serviceUser.Update(updated);
                }
                return RedirectToAction("Admin", "User");
            }
            else
                return RedirectToAction("Login", "User");
        }

        public ActionResult Delete(int id)
        {
            if (Session["account"] != null)
            {
                _serviceUser.Delete(_serviceUser.GetById(id));
                return RedirectToAction("Admin", "User");

            }
            else
                return RedirectToAction("Login", "User");
        }

        public ActionResult Add()
        {
            if (Session["account"] != null)
            {
                return View();
            }
            else
                return RedirectToAction("Login", "User");
        }

        [HttpPost]
        public ActionResult Add(User user, string birthdate, HttpPostedFileBase userimg)
        {
            if (Session["account"] != null)
            {
                if (_serviceUser.GetAll().FirstOrDefault(s => s.Email.ToUpper() == user.Email.ToUpper()) != null)
                    return RedirectToAction("Add");

                if (userimg != null)
                {
                    userimg.SaveAs(Server.MapPath("~/img/user/") + userimg.FileName);
                    user.ImagePath = "~/img/user/" + userimg.FileName;
                }

                user.Password = user.Password;
                user.BirthDate = Convert.ToDateTime(birthdate);
                user.Role = Role.User;
                _serviceUser.Insert(user);
                return RedirectToAction("Admin", "User");
            }
            else
                return RedirectToAction("Login", "User");
        }

    }
}