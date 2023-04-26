﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CRMSSystem.Filter
{
    public class CustomActionFilter : ActionFilterAttribute
    {
        public string FormName;
        public readonly AccessPermission.PermissionOrder actionCode;

        public CustomActionFilter(string form, AccessPermission.PermissionOrder action)
        {
            FormName = form;
            actionCode = action;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            bool accessCode = AccessCode.CheckAccess(FormName, actionCode.ToString());
            if (accessCode == false)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"controller", "Home" },
                    {"action", "Index" },
                   
                });
            }
            base.OnActionExecuting(filterContext);
        }
    }
}