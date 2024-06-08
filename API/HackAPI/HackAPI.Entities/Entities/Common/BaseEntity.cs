namespace HackAPI.Entities.Entities.Common
{
    public class BaseEntity
    {
        public virtual Guid Id { get; set; }
        public virtual DateTime CreatedAt { get; set; }
    }
}
