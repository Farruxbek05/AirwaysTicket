namespace Airways.Application.DTO
{
    public class ReysResponceTicketDto
    {
        public Guid Id { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public DateTime ScheduledDepartureTime { get; set; }
    }
}
