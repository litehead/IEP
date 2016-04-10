using System.Security.Principal;
using System.Web;
using IEP.BusinessLogic.Entities;

namespace IEP.Services.Contracts
{
    public interface IAuthService
    {
        HttpContext HttpContext { get; set; }

        IPrincipal CurrentUser { get; }

        void RegisterCookies(User user);

        void AcceptCookies(HttpRequest request);

        void LogOut();
    }
}
