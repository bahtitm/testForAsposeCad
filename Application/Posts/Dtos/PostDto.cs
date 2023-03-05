namespace Application.Posts.Dtos
{
    public class PostDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; }
    }
}
