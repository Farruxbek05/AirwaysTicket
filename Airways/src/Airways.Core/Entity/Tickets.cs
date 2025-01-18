using Airways.Core.Common;

namespace Airways.Core.Entity
{
    public class Tickets:BaseEntity,IAuditedEntity
    {
        public Status Status { get; set; } = Status.Available;
        public string PassengerName { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public DateTime ScheduledDepartureTime { get; set; }
        public Reys Reys { get; set; }
        public Guid ReysId { get; set; }
        public string SeatNumber { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
    public enum Status
    {
        Available,
        Reserved,
        Sold
    }
}
