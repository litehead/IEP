using System;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Security;
using IEP.BusinessLogic.Entities;
using IEP.Services.Contracts;

namespace IEP.Services.Auth
{
    public class AuthenticationService : IAuthService
    {
        private const string CookieName = "__AUTH_COOKIE";

        private IPrincipal _currentUser;

        public HttpContext HttpContext { get; set; }

        public IPrincipal CurrentUser
        {
            get
            {
                if (_currentUser == null)
                {
                    try
                    {
                        var authCookie = HttpContext.Request.Cookies.Get(CookieName);
                        if (!string.IsNullOrEmpty(authCookie?.Value))
                        {
                            var ticket = FormsAuthentication.Decrypt(authCookie.Value);
                            var identity = new ApplicationIdentity(0, ticket?.Name, new string[] {});
                            _currentUser = new ApplicationPrincipal(identity);
                        }
                        else
                        {
                            var identity = new ApplicationIdentity(0, null, new string[] { });
                            _currentUser = new ApplicationPrincipal(identity);
                        }
                    }
                    catch (Exception)
                    {
                        var identity = new ApplicationIdentity(0, null, new string[] { });
                        _currentUser = new ApplicationPrincipal(identity);
                    }
                }
                return _currentUser;
            }
        }

        public void RegisterCookies(User user)
        {
            var ticket = new FormsAuthenticationTicket(
              1,
              user.Login,
              DateTime.Now,
              DateTime.Now.Add(FormsAuthentication.Timeout),
              true,
              string.Empty,
              FormsAuthentication.FormsCookiePath);

            // Encrypt the ticket.
            var encTicket = FormsAuthentication.Encrypt(ticket);

            // Create the cookie.
            var authCookie = new HttpCookie(CookieName)
            {
                Value = encTicket,
                Expires = DateTime.Now.Add(FormsAuthentication.Timeout)
            };

            HttpContext.Response.Cookies.Set(authCookie);
        }

        public void AcceptCookies(HttpRequest request)
        {
            var authCookie = request.Cookies[CookieName];

            if (authCookie != null)
            {
                try
                {
                    var formsAuthTicket = FormsAuthentication.Decrypt(authCookie.Value);

                    if (formsAuthTicket == null)
                    {
                        FormsAuthentication.SignOut();
                        return;
                    }

                    //var userData = JsonConvert.DeserializeObject<UserDataModel>(formsAuthTicket.UserData);
                    var roles =/* userData.SecurityGroups ??*/ new string[] { };

                    var identity = new ApplicationIdentity(0, formsAuthTicket.Name, roles);
                    var principal = new ApplicationPrincipal(identity);

                    Thread.CurrentPrincipal = principal;
                    HttpContext.User = principal;
                }
                catch (Exception)
                {
                    FormsAuthentication.SignOut();
                }
            }
        }

        public void LogOut()
        {
            var httpCookie = HttpContext.Response.Cookies[CookieName];
            if (httpCookie != null)
            {
                httpCookie.Value = string.Empty;
            }
        }
    }
}
