using Gymify.Data.Enums;
using Microsoft.AspNetCore.Authorization;

namespace Gymify.Web.Infrastructure.AuthorizationRequirements
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
