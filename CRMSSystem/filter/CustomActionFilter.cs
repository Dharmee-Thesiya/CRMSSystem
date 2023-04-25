using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CRMSSystem.Filter
{
    public class CustomActionFilter : ActionFilterAttribute
    {
        public CustomActionFilter()
        {
         
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["Permission"]==null || filterContext.HttpContext.Session["RoleId"]==null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"Controller","Home" },
                    {"action","Index" }
                });

                base.OnActionExecuting(filterContext);
            }
        }
    }
}