using Domain.BaseEntities;

namespace Domain
{
    public class RolePermission : DataBookEntry
    {
        public virtual Role? Role { get; set; }
        public int RoleId { get; set; }
        public virtual Permission? Permission { get; set; }
        public int PermissionId { get; set; }
    }
}
