using Domain.Enums;
using ForAspose.Authorization.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ForAspose.Authorization.Attributes
{
    public class PermissionRequirementAttribute : TypeFilterAttribute
    {
        public PermissionRequirementAttribute(ClaimType claim, ClaimValue permission)
            : base(typeof(PermissionRequirementFilter))
        {
            Arguments = new object[] { claim, permission };
        }
    }
}
