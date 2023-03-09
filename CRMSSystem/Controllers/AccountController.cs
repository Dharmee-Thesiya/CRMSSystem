using CRMSSystem.SQL;

using IdentityServer3.Core.ViewModels;
using Intercom.Data;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CRMSSystem.Controllers
{
    
    public class AccountController : Controller
    {

        LoginRepository Repository;

        public AccountController()
        {
            Repository = new LoginRepository();
        }


        [AllowAnonymous]
        public ActionResult Login()
        {
            //ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            var users = Repository.SQLRepository(model).Count();

            if (!ModelState.IsValid)
            {
                return View(model);

            }
            else
            {
                if (users > 0)
                {
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    return RedirectToAction("Error");
                }
            }
        }

        public ActionResult Dashboard()
        {
            return View();
        }

    }

}