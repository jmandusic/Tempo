using Microsoft.AspNetCore.Authorization;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Tempo.Data.Enums;

namespace Tempo.Web.Infrastructure.AuthorizationRequirements
{
    public class RoleRequirementHandler : AuthorizationHandler<RoleRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == ClaimsIdentity.DefaultRoleClaimType))
            {
                return Task.CompletedTask;
            }

            var roleString = Convert.ToString(context.User.FindFirstValue(ClaimsIdentity.DefaultRoleClaimType));
            var canParse = Enum.TryParse<Role>(roleString, out var role);

            if (!canParse)
            {
                return Task.CompletedTask;
            }

            if (role == requirement.Role)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
