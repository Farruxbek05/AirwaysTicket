using Airways.Core.Common;

namespace Airways.Core.Entity
{
    public class Airline:BaseEntity,IAuditedEntity
    {
        
        public string Name { get; set; }
        public string Country { get; set; }
        public Guid Code { get; set; }
        public List<Aicraft> aicrafts=new List<Aicraft>();
        public List<Reys> reys=new List<Reys>();
        public string? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}
