using CRMSSystem.Core.Contracts;
using CRMSSystem.Core.Models;
using CRMSSystem.Core.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRMSSystem.Controllers
{
    public class TicketController : Controller
    {
        ITicketService _ticketService;
        IUserService _userService;
        public TicketController(ITicketService ticketService, IUserService userService)
        {
            _ticketService = ticketService;
            _userService = userService;
        }
        // GET: Ticket
        public ActionResult Index()
        {
            List<TicketViewModel> ticketViewModels = _ticketService.GetTicket().ToList();
            return View(ticketViewModels);
        }
        public ActionResult Create()
        {
            TicketViewModel ticket = new TicketViewModel();
            ticket.PriorityDropDown = _ticketService.SetDropDownValues(Constants.ConfigName.Priority);
            ticket.StatusDropDown = _ticketService.SetDropDownValues(Constants.ConfigName.Status);
            ticket.TypeDropDown = _ticketService.SetDropDownValues(Constants.ConfigName.Type);
            ticket.AssignDropDown = _userService.GetUsers().Select(x => new DropDown() { Id = x.Id, Name = x.Name }).ToList();
            
            return View(ticket);
        }
        [HttpPost]
        public ActionResult Create(TicketViewModel model)
        {
            
            model.PriorityDropDown = _ticketService.SetDropDownValues(Constants.ConfigName.Priority);
            model.StatusDropDown = _ticketService.SetDropDownValues(Constants.ConfigName.Status);
            model.TypeDropDown = _ticketService.SetDropDownValues(Constants.ConfigName.Type);
            model.AssignDropDown = _userService.GetUsers().Select(x => new DropDown() { Id = x.Id, Name = x.Name }).ToList();
            return null;
        }
    }
}