namespace Airways.Application.Models;

public class Order
{
    public int ID { get; set; }
    public decimal TotalPrice { get; set; }
    public Guid User_id { get; set; }
    public Guid Ticked_id { get; set; }
}
