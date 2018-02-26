using Basic.Services.Authentication;
using Basic.Services.Customers;
using Basic.WebCore;
using Microsoft.AspNetCore.Mvc;

namespace Basic.Web.Controllers
{
    [UserAuthorize]
    public class HomeController : BaseController
    {
        #region ctor
        private readonly IAccountService _accountService;
        private readonly IAuthenticationService _authenticationService;
        public HomeController(IAccountService accountService, IAuthenticationService authenticationService)
        {
            _accountService = accountService;
            _authenticationService = authenticationService;
        }
        #endregion

        [UserAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [UserAnonymous]
        public IActionResult Login()
        {
            _authenticationService.SignIn("Test");
            return Success();
        }

        public IActionResult Info()
        {
            ViewBag.UserName = WorkContext.CurrentAccount.ToModel().UserName;
            return View();
        }

        [Permit]
        [UserAnonymous]
        public IActionResult Data()
        {
            return Error();
        }
    }
}
