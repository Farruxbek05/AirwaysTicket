namespace Airways.Application.Models.Order;

public class CreateOrderModel
{
    public int ID { get; set; }
    public decimal TotalPrice { get; set; }
    public Guid User_id { get; set; }
    public Guid Ticked_id { get; set; }
}
public class CreateOrderResponceModel : BaseResponceModel { }
