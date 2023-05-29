using CRMSSystem.Core.Contracts;
using CRMSSystem.Core.Models;
using CRMSSystem.Core.View;
using CRMSSystem.filter;
using CRMSSystem.SQL;
using Intercom.Data;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace CRMSSystem.Controllers
{
    public class AccountController : Controller
    {
        private ILoginService _loginService;
        private IMRepository<UserRole> _userRoleRepository;
        private IPermissionService _permissionService;

        public AccountController(ILoginService loginService, IMRepository<UserRole> userRoleRepository, IPermissionService permissionService)
        {
            _loginService = loginService;
            _userRoleRepository = userRoleRepository;
            _permissionService = permissionService;
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        public ActionResult Login(AccountViewModel model)
        {
            if (!ModelState.IsValid && model.CurrentPassword != null)
            {
                return View(model);
            }
            else
            {
                var user = _loginService.Login(model);
                if (user != null)
                {
                    Session["Id"] = user.Id;
                    Session["UserName"] = user.UserName;
                    Guid RoleID = _userRoleRepository.Collection().Where(x => x.UserId == user.Id).Select(x => x.RoleId).FirstOrDefault();
                    Session["RoleId"] = RoleID;
                    var permission = _permissionService.GetPermissionList(RoleID).ToList();
                    Session["Permission"] = permission;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", " Email or password Is Incorrect.");
                    return View();
                }
            }
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(AccountViewModel model)
        {
            var user = _loginService.ChangePassword(model);
            if (user != null)
            {
                TempData["AlertMessage"] = "Password Update Successfully";
                return RedirectToAction("Index", "Home");
            }
            else if (model.CurrentPassword == model.NewPassword)
            {
                ModelState.AddModelError("", "New Password And Current Password can't be Same.");
                return View();
            }
            else
            {
                ModelState.AddModelError("", "Password Is Incorrect.");
                return View();
            }  
        }
    }
}

