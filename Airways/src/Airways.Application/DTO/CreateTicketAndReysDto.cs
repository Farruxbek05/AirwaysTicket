using Airways.Core.Entity;

namespace Airways.Application.DTO
{
    public class CreateTicketAndReysDto
    {
        public ClassType ClassType { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public DateTime ScheduledDepartureTime { get; set; }
        public DateTime ActualDepartureTime { get; set; }
        public DateTime ScheduledArrivalTime { get; set; }
        public double Price { get; set; }
        public decimal MaxCharge { get; set; }
        public decimal AdditionalCharge { get; set; }
        public DateTime OrderTime { get; set; }
        public int SeatNumber { get; set; }
        public Status Status { get; set; }
        public Guid UserId { get; set; }
        public Guid AicraftId { get; set; }
        public Guid AirlineId { get; set; }
    }
}
