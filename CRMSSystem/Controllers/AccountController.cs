using CRMSSystem.Core.Contracts;
using CRMSSystem.Core.Models;
using CRMSSystem.SQL;
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

        private ILoginService _loginService;
        

        public AccountController(ILoginService loginService)
        {
            _loginService = loginService;
        }


        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
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
                    return RedirectToAction("Index");

                }
                else
                {
                    if (user != null)
                    {
                        
                        return RedirectToAction("Index");

                    }
                    else
                    {
                        ModelState.AddModelError("", "You Enter Invalid username or password.");
                        return View();
                    }
                }
            } 
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}
        