using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace WebApp.Filters
{
    public class MyCustomFilter : System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.Controller as Controller;
            filterContext.Result = new RedirectResult("/Account/Login");

            base.OnActionExecuting(filterContext);
        }
    }
}