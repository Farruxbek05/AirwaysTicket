using System.ComponentModel.DataAnnotations;

namespace Airways.Application.Models.Reys
{
    public class ReysResponceModel
    {
       
        public int TicketCount { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public DateTime ScheduledDepartureTime { get; set; }
        public DateTime ActualDepartureTime { get; set; }
        public DateTime ScheduledArrivalTime { get; set; }
     }

}
