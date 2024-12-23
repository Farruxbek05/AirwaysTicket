using Airways.Core.Common;

namespace Airways.Core.Entity
{
    public class Tickets:BaseEntity,IAuditedEntity
    {
      
        public double price { get; set; }
        public decimal MaxWeight { get; set; }
        public decimal AdditionalCharge { get; set; }
        DateTime OrderTime { get; set; }
        public int SeatNumber { get; set; }
        Status status { get; set; }
        public Reys Reys { get; set; }
        public User User { get; set; }
        public Class Class { get; set; }
        public PricePolicy PricePolicy { get; set; }
        public List<Order> orders=new List<Order>();
        public string? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

    }
    enum Status
    {
        Available,
        Sold
    }
}
