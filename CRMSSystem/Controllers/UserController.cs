using CRMSSystem.Core.Contracts;
using CRMSSystem.Core.Models;
using CRMSSystem.Core.View;
using CRMSSystem.filter;
using CRMSSystem.Filter;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CRMSSystem.Controllers
{
    [CustomAuthentication]
    [CustomActionFilter]
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

        public ActionResult Index([DataSourceRequest] DataSourceRequest request)
        {

            List<UserViewModel> users = _userService.GetUsers().ToList();
            return PartialView("UserPartial",users.ToDataSourceResult(request));
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
            if (User != null)
            {
                ViewBag.Message= User;
                model.RoleDropDown = _roleService.GetRoles().Select(u => new DropDown() { Id = u.Id, Name = u.Name }).ToList();
                return View(model);
            }
            else
            {
                TempData["PageSelected"] = "UserManagement";
                return RedirectToAction("Index", "Admin");
            } 
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
            else
            {
                TempData["PageSelected"] = "UserManagement";
                return RedirectToAction("Index", "Admin");
            }
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
             TempData["PageSelected"] = "UserManagement";
             return RedirectToAction("Index", "Admin");
        }
        public ActionResult GetUsers([DataSourceRequest] DataSourceRequest request)
        {
            List<UserViewModel> userViewModels = _userService.GetUsers().Select(x => new UserViewModel() { Id = x.Id, Name = x.Name, Email = x.Email, Password=x.Password, MobileNumber=x.MobileNumber, Gender=x.Gender, UserName=x.UserName, RoleName=x.RoleName}).ToList();
            return Json(userViewModels.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}
