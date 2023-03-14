using CRMSSystem.Core.Contracts;
using CRMSSystem.Core.Models;
using CRMSSystem.Core.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CRMSSystem.Controllers
{
    public class RoleController : Controller
    {
        IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            List<Role> roles = _roleService.GetRoles().ToList();
            return View(roles);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RoleViewModel model)
        {
            _roleService.CreateRole(model);
            return RedirectToAction("Index");
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
            _roleService.EditRole(model);
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }
        
    }   
}

        
