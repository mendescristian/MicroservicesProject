namespace MicroservicesProject.Core.Entities.PostgreSQL.Common
{
    public class EntityBase
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
