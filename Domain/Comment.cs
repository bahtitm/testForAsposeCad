using Domain.BaseEntities;

namespace Domain
{
    public class Comment : DataBookEntry
    {
        public string? Description { get; set; }
        public virtual Post? Post { get; set; }
        public int PostId { get; set; }
        public virtual ICollection<User>? Users { get; set; }
    }
}
