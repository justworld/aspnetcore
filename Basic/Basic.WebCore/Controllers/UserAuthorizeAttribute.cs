using Basic.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace Basic.Web.Controllers
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class UserAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            if (filterContext.ActionDescriptor.FilterDescriptors.Any(i => i.Filter is UserAnonymousAttribute))
            {
                return;
            }
            var workContext = filterContext.HttpContext.RequestServices.GetService(typeof(IWorkContext)) as IWorkContext;
            var account = workContext.CurrentAccount;
            if (account == null)//登录验证
            {
                var returnUrl = filterContext.HttpContext.Request.Path;
                if (filterContext.HttpContext.Request.IsAjaxRequest())//ajax
                {
                    filterContext.Result = new JsonResult(new { code = 403 });
                    return;
                }
                filterContext.Result = new RedirectResult("/account/login?returnUrl=" + returnUrl);
                return;
            }
        }
    }
}
