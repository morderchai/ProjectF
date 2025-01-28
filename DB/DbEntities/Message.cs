namespace DB.DbModels
{
    public class Message :BaseEntity
    {
        public string Text { get; set; } = string.Empty;
        public DateTime SendTime { get; set; } 
        public Guid AuthorId { get; set; }
        public Guid DestinationId { get; set; }
        public bool IsDeleted { get; set; } 
    }
}
