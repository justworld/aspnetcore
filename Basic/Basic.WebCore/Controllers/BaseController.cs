using Basic.Core;
using Microsoft.AspNetCore.Mvc;

namespace Basic.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        public IWorkContext WorkContext
        {
            get
            {
                return HttpContext.RequestServices.GetService(typeof(IWorkContext)) as IWorkContext;
            }
        }

        protected JsonResult Success()
        {
            return Success(0);
        }

        protected JsonResult Success<T>(T data, int count = 0)
        {
            return Json(new { code = 200, isSucc = true, count = count, data = data });
        }

        protected JsonResult Error(string msg = "未通过数据校验", int errorCode = 500)
        {
            return Json(new { code = errorCode, isSucc = false, msg = msg });
        }
    }
}
