using System;
using System.Linq;
using System.Security.Principal;

namespace IEP.Services.Auth
{
    public class ApplicationPrincipal : IPrincipal
    {
        public ApplicationIdentity Identity { get; }

        IIdentity IPrincipal.Identity => Identity;

        public ApplicationPrincipal(ApplicationIdentity identity)
        {
            Identity = identity;
        }

        public bool IsInRole(string role) => Identity.Roles.Contains(role.Trim(), StringComparer.InvariantCultureIgnoreCase);
    }
}
