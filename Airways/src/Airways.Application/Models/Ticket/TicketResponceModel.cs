using Airways.Core.Entity;

namespace Airways.Application.Models.Ticket
{
    public class TicketResponceModel:BaseResponceModel
    {
        public Status Status { get; set; } = Status.Available;
        public string PassengerName { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public string SeatNumber { get; set; }
        public DateTime ScheduledDepartureTime { get; set; }
    }
}
