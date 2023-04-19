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
using System.Web.Security;

namespace CRMSSystem.Controllers
{
    [CustomAuthentication]
    public class RoleController : Controller
    {
        IRoleService _roleService;
        IPermissionService _permissionService;
        public RoleController(IRoleService roleService, IPermissionService permissionService)
        {
            _roleService = roleService;
            _permissionService = permissionService;
        }

        [AllowAnonymous]
        public ActionResult Index([DataSourceRequest] DataSourceRequest request)
        {
            List<Role> roles = _roleService.GetRoles().ToList();
            return PartialView("RolePartial", roles.ToDataSourceResult(request));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RoleViewModel model)
        {
            var Role = _roleService.CreateRole(model);
            if (Role != null)
            {
                ViewBag.Message = Role;
                return View(model);
            }
            else
            {
                TempData["PageSelected"] = "RoleManagement";
                return RedirectToAction("Index", "Admin");
            }
        }
        public ActionResult Edit(Guid Id)
        {
            RoleViewModel role = _roleService.GetRole(Id);
            if (role == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(role);
            }
        }

        [HttpPost]
        public ActionResult Edit(RoleViewModel model)
        {
            var Role = _roleService.EditRole(model);
            if (Role != null)
            {
                ViewBag.Message = Role;
                return View(model);
            }
            else
            {
                TempData["PageSelected"] = "RoleManagement";
                return RedirectToAction("Index", "Admin");
            }
        }
        public ActionResult Delete(Guid Id)
        {
            RoleViewModel role = _roleService.GetRole(Id);
            if (role == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(role);
            }
        }
        [HttpPost]
        public ActionResult Delete(RoleViewModel model)
        {
            _roleService.DeleteRole(model);
            TempData["PageSelected"] = "RoleManagement";
            return RedirectToAction("Index", "Admin");
        }
        public ActionResult GetRoles([DataSourceRequest] DataSourceRequest request)
        {
            List<RoleViewModel> roleViewModels = _roleService.GetRoles().Select(x => new RoleViewModel() { Id = x.Id, Name = x.Name, Code = x.Code }).ToList();
            return Json(roleViewModels.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GivePermission(Guid Id)
        {
            ViewBag.RoleId = Id;
            List<PermissionViewModel> permissionViewModels = _permissionService.GetPermissionList(Id).ToList();
            return View();
        }
        public ActionResult GetPermissionJson([DataSourceRequest] DataSourceRequest request, Guid Id)
        {
            List<PermissionViewModel> permissionViewModels = _permissionService.GetPermissionList(Id).ToList();
            return Json(permissionViewModels.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
       
        [HttpPost]
        public ActionResult UpdatePermission(List<Permission> model)
        {
            if (ModelState.IsValid)
            {
                TempData["PageSelected"] = "RoleManagement";
                _permissionService.UpdatePermission(model);
                return Content("true");
            }
            else
            {
                return View(model);
            }

        }
       
    }
}


