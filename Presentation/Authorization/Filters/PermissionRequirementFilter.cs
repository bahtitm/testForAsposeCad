using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ForAspose.Authorization.Filters
{
    public class PermissionRequirementFilter : IAuthorizationFilter
    {
        private readonly ClaimType claimType;
        private readonly ClaimValue permission;

        public PermissionRequirementFilter(ClaimType claimType, ClaimValue permission)
        {
            this.claimType = claimType;
            this.permission = permission;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var claims = context.HttpContext.User.FindAll(p => p.Type == claimType.ToString());

            if (!claims.Any())
            {
                context.Result = new ForbidResult();
                return;
            }

            var maxClaimValue = claims.Max(p => Enum.Parse<ClaimValue>(p.Value));

            if (maxClaimValue < permission)
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
