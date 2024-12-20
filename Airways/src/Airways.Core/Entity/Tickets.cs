using Airways.Core.Common;

namespace Airways.Core.Entity
{
    public class Tickets:BaseEntity,IAuditedEntity
    {
        public int ID { get; set; }
        public double price { get; set; }
        public decimal MaxWeight { get; set; }
        public decimal AdditionalCharge { get; set; }
        DateTime OrderTime { get; set; }
        public int SeatNumber { get; set; }
        Status status { get; set; }
        public virtual Reys reys { get; set; }
        public virtual User user { get; set; }
        public virtual Class cclass { get; set; }
        public virtual PricePolicy pricePolicy { get; set; }
        public List<Order> orders=new List<Order>();
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

    }
    enum Status
    {
        Available,
        Sold
    }
}
