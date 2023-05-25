using CRMSSystem.Core.Contracts;
using CRMSSystem.Core.Models;
using CRMSSystem.Core.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CRMSSystem.Service
{
    public class AuditLogService : IAuditLogService
    {
        IAuditLogRepository _auditLogRepository;
        public AuditLogService(IAuditLogRepository auditLogRepository)
        {
            _auditLogRepository = auditLogRepository;
        }
        public string CreateAuditLog(string exception,int statusCode)
        {
            HttpContextBase currentContext = new HttpContextWrapper(HttpContext.Current);
            UrlHelper urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            RouteData routeData = urlHelper.RouteCollection.GetRouteData(currentContext);
            AuditLog audit = new AuditLog()
            {
                Id = Guid.NewGuid(),
                UserId = (Guid)HttpContext.Current.Session["Id"],
                ClientAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1].ToString(),
                Url = currentContext.Request.Url.ToString(),
                ExecutionTime = DateTime.UtcNow,
                ExecutionDuration = DateTime.UtcNow.Millisecond,
                HttpMethod = currentContext.Request.HttpMethod,
                HttpStatusCode = statusCode,  
                BrowserInfo = currentContext.Request.Browser.Browser + "" + HttpContext.Current.Request.Browser.Version,
                Comments = "Controller: " + routeData.Values["controller"].ToString() + " || Action: " + routeData.Values["action"].ToString(),
                Parameters = routeData.Values["id"].ToString(),
                Exception= exception,

            };
            _auditLogRepository.Insert(audit);
            _auditLogRepository.Commit();
            return null;
        }
        public List<AuditLogViewModel> GetAuditLog(bool IsException=false) 
        {
            return _auditLogRepository.GetAuditLogList(IsException).OrderByDescending(x => x.ExecutionTime).ToList(); ;
        }
        public AuditLogViewModel GetAuditById(Guid Id)
        {
            return _auditLogRepository.GetAuditLogById(Id);
        }
    }
} 
