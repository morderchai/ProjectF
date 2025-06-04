using Common.DbEntities;

namespace PostService.DbEntities
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
    }
}
