using Airways.Core.Common;

namespace Airways.Core.Entity
{
    public class Airline:BaseEntity,IAuditedEntity
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public Guid Code { get; set; }
        public ICollection<Aicraft>? aicrafts { get; set; }
        public List<Reys>? reys { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
