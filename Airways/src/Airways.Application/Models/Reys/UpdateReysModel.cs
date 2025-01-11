using System.ComponentModel.DataAnnotations;

namespace Airways.Application.Models.Reys
{
    public class UpdateReysModel
    {
       
        public int TicketCount { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public DateTime ScheduledDepartureTime { get; set; }
        public DateTime ActualDepartureTime { get; set; }
        public DateTime ScheduledArrivalTime { get; set; }
        public Guid AirlineId { get; set; }
        public Guid AicraftId { get; set; }
    }
    public class UpdateReysResponceModel : BaseResponceModel { }

}
