using Domain.BaseEntities;

namespace Domain
{
    public class Post : DataBookEntry
    {
        public string? Description { get; set; }

        public int? UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
        
    }
}
