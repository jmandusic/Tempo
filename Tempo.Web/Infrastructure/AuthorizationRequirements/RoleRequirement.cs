using Microsoft.AspNetCore.Authorization;
using Tempo.Data.Enums;

namespace Tempo.Web.Infrastructure.AuthorizationRequirements
{
    public class RoleRequirement : IAuthorizationRequirement
    {
        public Role Role { get; set; }

        public RoleRequirement(Role role)
        {
            Role = role;
        }
    }
}
