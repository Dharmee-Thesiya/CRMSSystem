 using CRMSSystem.Core.Contracts;
using CRMSSystem.Core.Models;
using CRMSSystem.Core.View;
using CRMSSystem.Filter;
using Intercom.Core;
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

    [AuditActionFilter]
    public class TicketController : Controller
    {
        ITicketService _ticketService;
        IUserService _userService;
        IHomeService _homeService;
        public TicketController(ITicketService ticketService, IUserService userService, IHomeService homeService)
        {
            _ticketService = ticketService;
            _userService = userService;
            _homeService = homeService;           
        }
        //GET: Ticket
        [CustomActionFilter("TKT", AccessPermission.PermissionOrder.IsView)]
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
        [CustomActionFilter("TKT", AccessPermission.PermissionOrder.IsInsert)]
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
            }
            model.CreatedBy = (Guid)(Session["Id"]);
            model.PriorityDropDown = _ticketService.SetDropDownValues(Constants.ConfigName.Priority);
            model.StatusDropDown = _ticketService.SetDropDownValues(Constants.ConfigName.Status);
            model.TypeDropDown = _ticketService.SetDropDownValues(Constants.ConfigName.Type);
            model.AssignDropDown = _userService.GetUsers().Select(x => new DropDown() { Id = x.Id, Name = x.Name }).ToList();
            var ticket = _ticketService.CreateTicket(model);
            return RedirectToAction("Index", "Ticket");
        }
        [CustomActionFilter("TKT", AccessPermission.PermissionOrder.IsUpdate)]
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
            model.UpdatedBy = (Guid)(Session["Id"]);
            if (file != null)
            {
                model.Image = model.Id + "_" + DateTime.Now.Ticks + Path.GetExtension(file.FileName);
                file.SaveAs(Server.MapPath("//Content//TicketAttachment//") + model.Image);
                model.PriorityDropDown = _ticketService.SetDropDownValues(Constants.ConfigName.Priority);
                model.StatusDropDown = _ticketService.SetDropDownValues(Constants.ConfigName.Status);
                model.TypeDropDown = _ticketService.SetDropDownValues(Constants.ConfigName.Type);
                model.AssignDropDown = _userService.GetUsers().Select(x => new DropDown() { Id = x.Id, Name = x.Name }).ToList();
                
            }
            var deleteIds = Request.Params["hdnAttachmentDeleteId"];
            var ticket = _ticketService.EditTicket(model, deleteIds);
            
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
        public ActionResult StatusFilter()
        {
            var statusFilter = _ticketService.SetDropDownValues(Constants.ConfigName.Status);
            return Json(statusFilter, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Detail(Guid Id)
        {
            TicketViewModel ticket = _ticketService.GetTickets(Id);
            return View(ticket);
        }
    
        public ActionResult Comment(TicketCommentViewModel model)
        {
            model.CreatedBy = (Guid)Session["Id"];
            _ticketService.CommentTicket(model);
            return Content("true");
        }
        public ActionResult IndexComment(Guid Id)
        {
            List<TicketCommentViewModel> commentViewModels = _ticketService.GetCommentList(Id).ToList();
            return PartialView("commentpartialview", commentViewModels);
        }
        public ActionResult CommentEdit(TicketCommentViewModel model)
        {
            _ticketService.EditComment(model);
            return Content("true");

        }
        public ActionResult DeleteComment(Guid Id)
        {
            var commitdelete = _ticketService.UpdateComment(Id);
            _ticketService.DeleteComment(commitdelete);
            return Content("true");
        }
        public ActionResult IndexHistory(Guid Id)
        {
            List<TicketViewModel> ticketViewModels = _ticketService.GetHistoryList(Id).ToList();
            return PartialView("tickethistorystatuspartialview", ticketViewModels);
        }
    }
}