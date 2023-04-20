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
    public class FormsController : Controller
    {
        IFormService _formService;
        public FormsController(IFormService formService)
        {
            _formService = formService;
        }
        // GET: Forms
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetForms([DataSourceRequest] DataSourceRequest request)
        {
            List<FormsViewModel> formsViewModels = _formService.GetForm().ToList();
            return Json(formsViewModels.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create()
        {
            FormsViewModel forms = new FormsViewModel();
            forms.ParentIdDropDown = _formService.GetForm().Select(f => new DropDownParentId() { ParentFormID = f.Id, ParentFormName = f.Name }).ToList();
            return View(forms);
        }

        [HttpPost]
        public ActionResult Create(FormsViewModel model)
        {
            var forms = _formService.CreateForms(model);
            if (forms != null)
            {
                ViewBag.Message = forms;
                model.ParentIdDropDown = _formService.GetForm().Select(u => new DropDownParentId() { ParentFormID = u.Id, ParentFormName = u.Name }).ToList();
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Forms");
            }
        }
        public ActionResult Delete(Guid Id)
        {
            FormsViewModel forms = _formService.GetForms(Id);

            if (forms == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(forms);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(Guid Id)
        {
            _formService.DeleteForms(Id);
            return RedirectToAction("Index", "Forms");
        }
        public ActionResult Edit(Guid Id)
        {
            FormsViewModel formsViewModel = _formService.GetForms(Id);
            formsViewModel.ParentIdDropDown = _formService.GetForm().Where(x=> x.Id != Id).Select(u => new DropDownParentId() { ParentFormID = u.Id, ParentFormName = u.Name }).ToList();
            return View(formsViewModel);
        }

        [HttpPost]
        public ActionResult Edit(FormsViewModel model)
        {
            var forms = _formService.EditForms(model);
            if (forms != null)
            {
                ViewBag.Message = forms;
                model.ParentIdDropDown = _formService.GetForm().Select(u => new DropDownParentId() { ParentFormID = u.Id, ParentFormName = u.Name }).ToList();
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Forms");
            }
        }
    }
}