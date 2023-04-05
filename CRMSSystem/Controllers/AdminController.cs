using CRMSSystem.filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRMSSystem.Controllers
{
    [CustomAuthentication]
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            string res = TempData["PageSelected"] as string;
            return View();
        }
    }
}