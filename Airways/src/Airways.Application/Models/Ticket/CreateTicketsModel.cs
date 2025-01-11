using System.ComponentModel.DataAnnotations;

namespace Airways.Application.Models.Ticket;

public class CreateTicketsModel
{
   
    public double price { get; set; }
    public decimal MaxWeight { get; set; }
    public decimal AdditionalCharge { get; set; }
    DateTime OrderTime { get; set; }
    public int SeatNumber { get; set; }
    Status status { get; set; }
    public Guid ReysId { get; set; }
    public Guid UserId { get; set; }
    public Guid ClassId { get; set; }
 

}
public class CreateTicketResponceModel : BaseResponceModel { }

enum Status
{
    Available,
    Sold
}
