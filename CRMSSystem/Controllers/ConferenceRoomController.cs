using CRMSSystem.Core.Contracts;
using CRMSSystem.Core.Models;
using CRMSSystem.Core.View;
using CRMSSystem.filter;
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
        public ActionResult Index()
        {
            List<ConferenceRoom> conferenceRooms = _conferenceRoomService.GetConferenceRooms().ToList();
            return View(conferenceRooms);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ConferenceRoomViewModel model)
        {
            _conferenceRoomService.CreateConferenceRoom(model);
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }

    }
}
