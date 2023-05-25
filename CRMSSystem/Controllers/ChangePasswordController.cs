using CRMSSystem.Core.Contracts;
using CRMSSystem.Core.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRMSSystem.Controllers
{
    public class ChangePasswordController : Controller
    {
        // GET: ChangePassword
        public ActionResult ChangePasswordView()
        {
            return View();
        }
    }
}