namespace Application.Comments.Dtos
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int DocumentId { get; set; }
    }
}
