using System;
using System.Web.Mvc;

namespace HelloWorld
{
    public class AuthorizeIPAddressAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var ipAddress = filterContext.HttpContext.Request.UserHostAddress;
            if (ipAddress == "127.0.0.1" | ipAddress == "::1")
            {
                throw new Exception();
            }
            base.OnActionExecuting(filterContext);
        }
    }
}