namespace Airways.Application.Models.Order;

public class CreateOrderModel
{

    public decimal TotalPrice { get; set; }
    public Guid UserId { get; set; }
    public Guid TicketsId { get; set; }
}
public class CreateOrderResponceModel : BaseResponceModel { }
