namespace DB.DbModels
{
    public class Destination : BaseEntity
    {

        public List<string> Participants { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
