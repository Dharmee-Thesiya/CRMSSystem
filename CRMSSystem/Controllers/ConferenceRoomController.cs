using CRMSSystem.Core.Contracts;
using CRMSSystem.Core.Models;
using CRMSSystem.Core.View;
using CRMSSystem.filter;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRMSSystem.Controllers
{
    [CustomAuthentication]
    public class ConferenceRoomController : Controller
    {
        IConferenceRoomService _conferenceRoomService;
        public ConferenceRoomController(IConferenceRoomService conferenceRoomService)
        {
            _conferenceRoomService = conferenceRoomService;
        }
        // GET: ConferenceRoom
        [AllowAnonymous]
        public ActionResult Index([DataSourceRequest] DataSourceRequest request)
        {
            List<ConferenceRoom> conferenceRooms = _conferenceRoomService.GetConferenceRooms().ToList();
            return PartialView("ConferenceRoomPartial",conferenceRooms.ToDataSourceResult(request));
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ConferenceRoomViewModel model)
        {
            var ConferenceRoom = _conferenceRoomService.CreateConferenceRoom(model);
            if (ConferenceRoom != null)
            {
                ViewBag.Message = ConferenceRoom;
                return View(model);
            }
            else
            {
                TempData["PageSelected"] = "ConferenceRoom";
                return RedirectToAction("Index", "Admin");
            }
        }
        public ActionResult Edit(Guid Id)
        {
            ConferenceRoomViewModel conferenceRoom = _conferenceRoomService.GetConferenceRoom(Id);
            if (conferenceRoom == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(conferenceRoom);
            }
        }

        [HttpPost]
        public ActionResult Edit(ConferenceRoomViewModel model)
        {
            _conferenceRoomService.EditConferenceRoom(model);
            TempData["PageSelected"] = "ConferenceRoom";
            return RedirectToAction("Index", "Admin");
        }
        public ActionResult Delete(Guid Id)
        {
            ConferenceRoomViewModel conferenceRoom = _conferenceRoomService.GetConferenceRoom(Id);
            if (conferenceRoom == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(conferenceRoom);
            }
        }
        [HttpPost]
        public ActionResult Delete(ConferenceRoomViewModel model)
        {
            _conferenceRoomService.DeleteConferenceRoom(model);
            TempData["PageSelected"] = "ConferenceRoom";
            return RedirectToAction("Index", "Admin");
        }
        public ActionResult GetConferenceRoom([DataSourceRequest] DataSourceRequest request)
        {
            List<ConferenceRoomViewModel> conferenceRoomViewModels = _conferenceRoomService.GetConferenceRooms().Select(x => new ConferenceRoomViewModel() { Id = x.Id, Name = x.Name, Capacity = x.Capacity }).ToList();
            return Json(conferenceRoomViewModels.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}
