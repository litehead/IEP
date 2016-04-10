using System.Security.Principal;

namespace IEP.Services.Auth
{
    public class ApplicationIdentity : IIdentity
    {
        public int UserId { get; }

        public string[] Roles { get; }
        
        public string Name { get; }

        public ApplicationIdentity(int userId, string userName, string[] roles)
        {
            UserId = userId;
            Name = userName;
            Roles = roles;
        }

        public string AuthenticationType => "Forms";

        public bool IsAuthenticated => !string.IsNullOrEmpty(Name);
    }
}
