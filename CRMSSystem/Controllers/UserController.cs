using CRMSSystem.Core.Contracts;
using CRMSSystem.Core.Models;
using CRMSSystem.Core.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRMSSystem.Controllers
{
    public class UserController : Controller
    {
        IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            List<User> users = _userService.GetUsers().ToList();
            return View(users);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserViewModel model)
        {
            _userService.CreateUser(model);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid Id)
        {
            UserViewModel user = _userService.GetUser(Id);
            if (user == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(user);
            }
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel model)
        {
            _userService.EditUser(model);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(Guid Id)
        {
            UserViewModel user = _userService.GetUser(Id);
            if (user == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(user);
            }
        }
        [HttpPost]
        public ActionResult Delete(UserViewModel model)
        {
            _userService.DeleteUser(model);
            return RedirectToAction("Index");
        }

    }
}
