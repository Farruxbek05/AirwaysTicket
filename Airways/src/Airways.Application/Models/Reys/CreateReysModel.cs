using System.ComponentModel.DataAnnotations;

namespace Airways.Application.Models.Reys;

public class CreateReysModel
{
   
    public int TicketCount { get; set; }
    public string DepartureCity { get; set; }
    public string ArrivalCity { get; set; }
    public DateTime ScheduledDepartureTime { get; set; }
    public DateTime ActualDepartureTime { get; set; }
    public DateTime ScheduledArrivalTime { get; set; }
    public Guid Airline_id { get; set; }
    public Guid aAircraft_id { get; set; }
}
public class CreateReysResponceModel : BaseResponceModel { }
