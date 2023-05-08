using CRMSSystem.Core.Contracts;
using CRMSSystem.Core.Models;
using CRMSSystem.Core.View;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.IO;
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
        //GET: Ticket
        public ActionResult Index()
        {
            List<TicketViewModel> ticket = _ticketService.GetTicket().OrderByDescending(x => x.CreatedOn).ToList();
            return View(ticket);
        }
        public ActionResult GetTicket([DataSourceRequest] DataSourceRequest request)
        {
            List<TicketViewModel> ticketViewModels = _ticketService.GetTicket().ToList();
            return Json(ticketViewModels.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
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
        public ActionResult Create(TicketViewModel model,HttpPostedFileBase file)
        {
            if (file != null)
            {
                model.Image = model.Id + "_" + DateTime.Now.Ticks + Path.GetExtension(file.FileName);
                file.SaveAs(Server.MapPath("//Content//TicketAttachment//") + model.Image);
                model.PriorityDropDown = _ticketService.SetDropDownValues(Constants.ConfigName.Priority);
                model.StatusDropDown = _ticketService.SetDropDownValues(Constants.ConfigName.Status);
                model.TypeDropDown = _ticketService.SetDropDownValues(Constants.ConfigName.Type);
                model.AssignDropDown = _userService.GetUsers().Select(x => new DropDown() { Id = x.Id, Name = x.Name }).ToList();
                
            }
            var ticket = _ticketService.CreateTicket(model);
            return RedirectToAction("Index", "Ticket");
        }
        public ActionResult Edit(Guid Id)
        {
            TicketViewModel ticket = _ticketService.GetTickets(Id);
            ticket.PriorityDropDown = _ticketService.SetDropDownValues(Constants.ConfigName.Priority);
            ticket.StatusDropDown = _ticketService.SetDropDownValues(Constants.ConfigName.Status);
            ticket.TypeDropDown = _ticketService.SetDropDownValues(Constants.ConfigName.Type);
            ticket.AssignDropDown = _userService.GetUsers().Select(x => new DropDown() { Id = x.Id, Name = x.Name }).ToList();
            return View(ticket);
        }
        [HttpPost]
        public ActionResult Edit(TicketViewModel model, HttpPostedFileBase file)
        {
            if (file != null)
            {
                model.Image = model.Id + "_" + DateTime.Now.Ticks + Path.GetExtension(file.FileName);
                file.SaveAs(Server.MapPath("//Content//TicketAttachment//") + model.Image);
                model.PriorityDropDown = _ticketService.SetDropDownValues(Constants.ConfigName.Priority);
                model.StatusDropDown = _ticketService.SetDropDownValues(Constants.ConfigName.Status);
                model.TypeDropDown = _ticketService.SetDropDownValues(Constants.ConfigName.Type);
                model.AssignDropDown = _userService.GetUsers().Select(x => new DropDown() { Id = x.Id, Name = x.Name }).ToList();
                
            }
            var ticket = _ticketService.EditTicket(model);
            return RedirectToAction("Index", "Ticket");
        }
        public ActionResult Delete(Guid Id)
        {
            TicketViewModel ticket = _ticketService.GetTickets(Id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(ticket);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(Guid Id)
        {
            _ticketService.DeleteTicket(Id);
            return RedirectToAction("Index", "Ticket");
        }
    }
}