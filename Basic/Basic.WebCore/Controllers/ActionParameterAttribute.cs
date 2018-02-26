using Microsoft.AspNetCore.Mvc.Filters;

namespace Basic.Web.Controllers
{
    /// <summary>
    /// 参数预处理
    /// </summary>
    public class ActionParameterAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
}
