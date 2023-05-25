using CRMSSystem.Core.Contracts;
using CRMSSystem.Core.View;
using CRMSSystem.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRMSSystem.Controllers
{
    [AuditActionFilter]
    public class HomeController : Controller
    {
        IHomeService _homeService;
        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.TotalTickets = _homeService.TotalTickets();
            ViewBag.NewTickets = _homeService.NewTickets();
            ViewBag.AssignedTickets = _homeService.AssignedTickets();
            ViewBag.PendingTickets = _homeService.PendingTickets();
            return View();
        }
        
    }
}