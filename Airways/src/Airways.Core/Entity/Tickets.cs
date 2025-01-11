using Airways.Core.Common;

namespace Airways.Core.Entity
{
    public class Tickets:BaseEntity,IAuditedEntity
    {
      
        public double price { get; set; }
        public decimal MaxWeight { get; set; }
        public decimal AdditionalCharge { get; set; }
        public DateTime OrderTime { get; set; }
        public int SeatNumber { get; set; }
        public Status status { get; set; }
        public Reys Reys { get; set; }
        public Guid ReysId { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid ClassId { get; set; }
        public Class Class { get; set; }
        public List<Order> orders=new List<Order>();
        public string? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

    }
    public enum Status
    {
        Available,
        Sold
    }
}
