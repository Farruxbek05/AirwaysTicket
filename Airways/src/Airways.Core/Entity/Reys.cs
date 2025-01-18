using Airways.Core.Common;

namespace Airways.Core.Entity
{
    public class Reys : BaseEntity, IAuditedEntity
    {
        public ClassType ClassType { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public DateTime ScheduledDepartureTime { get; set; }
        public DateTime ActualDepartureTime { get; set; }
        public DateTime ScheduledArrivalTime { get; set; }
        public Guid AirlineId { get; set; }
        public Airline Airline { get; set; }
        public Guid AicraftId { get; set; }
        public Aicraft Aicraft { get; set; }
        public List<User> Users { get; set; }       
        public List<Review> Review = new List<Review>();
        public List<Tickets> Tickets = new List<Tickets>();
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
