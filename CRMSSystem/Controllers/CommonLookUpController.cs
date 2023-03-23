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
    public class CommonLookUpController : Controller
    {
        ICommonLookUpService _commonLookUpService;
        public CommonLookUpController(ICommonLookUpService commonLookUpService)
        {
            _commonLookUpService = commonLookUpService;
        }
        // GET: CommonLookUp
        [AllowAnonymous]
        public ActionResult Index()

        {
            List<CommonLookUp> commonLookUps = _commonLookUpService.GetCommonLookUp().ToList();
            ViewBag.CommonLookUps = commonLookUps;
            return View();
        }

        //Create Get: CommonLookUp
        public ActionResult Create(Guid? Id = null)
        {
            CommonLookUp commonLookup = new CommonLookUp();
            if (Id == null)
            {
                commonLookup.IsEdit = false;
                return PartialView("PartialView", commonLookup);
            }
            else
            {
                commonLookup = _commonLookUpService.GetCommonLookUp(Id.Value);
                commonLookup.IsEdit = true;
                return PartialView("PartialView", commonLookup);
            }

        }

        [HttpPost]
        public ActionResult Create(CommonLookUp model)
        {
            _commonLookUpService.CreateCommonLookUp(model);
            return RedirectToAction("Index");
        }
        //Edit Get: CommonLookUp
        [HttpPost]
        public ActionResult Edit(CommonLookUp model)
        {
            _commonLookUpService.EditCommonLookUp(model);
            return RedirectToAction("Index");
        }
        [HttpPost]                     
        public ActionResult Delete(Guid Id)
        {
            _commonLookUpService.DeleteCommonLookUp(Id);
            return RedirectToAction("Index");
        }

    }

}
