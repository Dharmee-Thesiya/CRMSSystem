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
        ITicketService _ticketService;
        public HomeController(IHomeService homeService, ITicketService ticketService)
        {
            _homeService = homeService;
            _ticketService = ticketService;
        }
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.NewTickets = _homeService.NewTickets();
            ViewBag.PendingTickets = _homeService.PendingTickets();
            ViewBag.AssignedTickets = _homeService.AssignedTickets();
            ViewBag.PendingTickets = _homeService.PendingTickets();
            ViewBag.TotalTickets = _homeService.TotalTickets();
            ViewBag.GetAllCount = _homeService.GetAllCount();
            return View();
        }
        public ActionResult TypeCount()
        {
            List<TypecountTicket> typecountTickets = _homeService.GetTypecountTickets().ToList();
            return PartialView("typecountpartialview", typecountTickets);
        }
        public ActionResult TicketDetail()
        {
            List<TicketViewModel> ticket = _ticketService.GetTicket().OrderByDescending(x => x.CreatedOn).Take(5).ToList();
            return PartialView("ticketdetaillastfivepartialview", ticket);
        }
    }
}