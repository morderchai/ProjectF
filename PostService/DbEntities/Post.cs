using Common.DbEntities;

namespace PostService.DbEntities
{
    public class Post : BaseEntity
    {
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public Guid AuthorId { get; set; }
        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}
