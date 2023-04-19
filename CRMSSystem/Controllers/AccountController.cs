using CRMSSystem.Core.Contracts;
using CRMSSystem.Core.Models;
using CRMSSystem.filter;
using CRMSSystem.SQL;
using Intercom.Data;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CRMSSystem.Controllers
{
    
    public class AccountController : Controller
    {

        private ILoginService _loginService;
        

        public AccountController(ILoginService loginService)
        {
            _loginService = loginService;
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
            if (!ModelState.IsValid)
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
                    return RedirectToAction("Index","Admin"); 
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
        
    }
}
        