using System.Web.Mvc;
using IEP.Services.Auth;
using IEP.Services.Contracts;
using Ninject;

namespace IEP.Controllers
{
    public class BaseController : Controller
    {
        [Inject]
        public IAuthService AuthenticationService { get; set; }

        public ApplicationPrincipal CurrentUser => (ApplicationPrincipal)HttpContext.User;
    }
}