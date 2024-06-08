namespace HackathonAPI.Domain.Entities.Common
{
    public class BaseEntity : IBaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
