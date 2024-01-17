using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ForumManagmentSystem.Web.Helpers
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class IsAuthenticatedAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var isLogged = context.HttpContext.Session.Keys.Contains("user");

            if (!isLogged)
            {
                context.Result = new RedirectToRouteResult(new { controller = "Users", action = "Login" });
            }
        }
    }
}
