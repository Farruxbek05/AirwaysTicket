using Airways.Core.Entity;

namespace Airways.Application.Models.Ticket;

public class CreateTicketsModel
{
    public Status Status { get; set; } = Status.Available;
    public string PassengerName { get; set; }
    public string DepartureCity { get; set; }
    public string ArrivalCity { get; set; }
    public DateTime ScheduledDepartureTime { get; set; }
    public string SeatNumber { get; set; }
    public Guid ReysId { get; set; }

}
public class CreateTicketResponceModel : BaseResponceModel { }


