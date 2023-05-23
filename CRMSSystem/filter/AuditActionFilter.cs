using CRMSSystem.Core.Contracts;
using CRMSSystem.Core.Models;
using CRMSSystem.Core.View;
using CRMSSystem.SQL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CRMSSystem.Filter
{
    public class AuditActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var auditlogs = DependencyResolver.Current.GetService<IAuditLogService>();
            auditlogs.CreateAuditLog(null, HttpContext.Current.Response.StatusCode);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            var errorauditlog = DependencyResolver.Current.GetService<IAuditLogService>();
            if (filterContext.Exception != null)
            {
                var statusCode = new HttpException(null, filterContext.Exception).GetHttpCode();
                errorauditlog.CreateAuditLog(filterContext.Exception.Message,statusCode);
            }
        }
    }
}