using CRMSSystem.filter;
using CRMSSystem.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRMSSystem.Controllers
{
    [CustomAuthentication]
    [AuditActionFilter]
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            string res = TempData["PageSelected"] as string;
            return View();
        }
    }
}