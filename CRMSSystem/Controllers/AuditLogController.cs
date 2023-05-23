using CRMSSystem.Core.Contracts;
using CRMSSystem.Core.View;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRMSSystem.Controllers
{
    public class AuditLogController : Controller
    {
        IAuditLogService _auditLogService;
        public AuditLogController(IAuditLogService auditLogService)
        {
            _auditLogService = auditLogService;
        }
        // GET: AuditLog
        public ActionResult Index()
        {
            List<AuditLogViewModel> audits = _auditLogService.GetAuditLog().ToList();
            return View(audits);
        }
        public ActionResult GetAuditLogs([DataSourceRequest] DataSourceRequest request)
        {
            List<AuditLogViewModel> auditLogViewModels = _auditLogService.GetAuditLog().ToList();
            return Json(auditLogViewModels.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Details(Guid Id)
        {
            AuditLogViewModel auditLogViewModel = _auditLogService.GetAuditById(Id);
            return View(auditLogViewModel);
        }
        public ActionResult ErrorIndex(bool IsException=true)
        {
            List<AuditLogViewModel> audits = _auditLogService.GetAuditLog(IsException).ToList();
            return View(audits);
        }
        public ActionResult GetErrorLogs([DataSourceRequest] DataSourceRequest request, bool IsException=true)
        {
            List<AuditLogViewModel> auditLogViewModels = _auditLogService.GetAuditLog(IsException).ToList();
            return Json(auditLogViewModels.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        public ActionResult ErrorDetails(Guid Id)
        {
            AuditLogViewModel auditLogViewModel = _auditLogService.GetAuditById(Id);
            return View(auditLogViewModel);
        }
    }
}