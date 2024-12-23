using System.ComponentModel.DataAnnotations;

namespace Airways.Application.Models.Order;

public class CreateOrderModel
{
    
    public decimal TotalPrice { get; set; }
    public Guid User_id { get; set; }
    public Guid Ticked_id { get; set; }
}
public class CreateOrderResponceModel : BaseResponceModel { }
