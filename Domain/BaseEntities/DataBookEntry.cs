using Domain.Enums;

namespace Domain.BaseEntities
{
    public abstract class DataBookEntry : BaseEntity
    {
        public string? Name { get; set; }
        public Status Status { get; set; }
    }
}
