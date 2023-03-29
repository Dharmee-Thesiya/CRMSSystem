using CRMSSystem.Core.Contracts;
using CRMSSystem.Core.Models;
using CRMSSystem.Core.View;
using CRMSSystem.filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace CRMSSystem.Controllers
{
    [CustomAuthentication]
    
    public class UserController : Controller
    {
        IUserService _userService;
        IRoleService _roleService;
        public UserController(IUserService userService,IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;

        }
        [AllowAnonymous]
        
        public ActionResult Index()
        {
           
            List<UserViewModel> users = _userService.GetUsers().ToList();
            return View(users);
        }

        public ActionResult Create()
        {

            UserViewModel user = new UserViewModel();
            user.RoleDropDown = _roleService.GetRoles().Select(u => new DropDown() { Id = u.Id, Name = u.Name }).ToList();
            return View(user);
        }

        [HttpPost]
        public ActionResult Create(UserViewModel model)
        {
            var User = _userService.CreateUser(model);
            if (User!=null)
            {
                ViewBag.Message= User;
                model.RoleDropDown = _roleService.GetRoles().Select(u => new DropDown() { Id = u.Id, Name = u.Name }).ToList();
                return View(model);
            }
            
            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid Id)
        {
            UserViewModel user = _userService.GetUser(Id);
            user.RoleDropDown = _roleService.GetRoles().Select(u => new DropDown() { Id = u.Id, Name = u.Name }).ToList();
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel model)
        {
            var User = _userService.EditUser(model);
            if (User != null)
            {
                ViewBag.Message = User;
                model.RoleDropDown = _roleService.GetRoles().Select(u => new DropDown() { Id = u.Id, Name = u.Name }).ToList();
                return View(model);
            }

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
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(Guid Id)
        {
            _userService.DeleteUser(Id);
            return RedirectToAction("Index");
        }

    }
}
