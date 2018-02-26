using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Basic.Web.Controllers
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class UserAnonymousAttribute : Attribute, IFilterMetadata
    {

    }
}
