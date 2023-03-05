using Domain.BaseEntities;
using Domain.Enums;

namespace Domain
{
    public class Permission : BaseEntity
    {
        public virtual Role? Role { get; set; }
        public int RoleId { get; set; }
        public ClaimType ClaimType { get; set; }
        public ClaimValue ClaimValue { get; set; }
    }
}
