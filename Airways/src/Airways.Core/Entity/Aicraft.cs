using Airways.Core.Common;

namespace Airways.Core.Entity
{
    public class Aicraft:BaseEntity,IAuditedEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public int SeatCapacity { get; set; }
        public virtual Airline airline { get; set; }

        public List<Reys> reys = new List<Reys>();
        public string? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}
