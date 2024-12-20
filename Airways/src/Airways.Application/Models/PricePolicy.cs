namespace Airways.Application.Models;

public class PricePolicy
{
    public int ID { get; set; }
    public decimal DiscountPercentage { get; set; }
    public string Conditions { get; set; }
}
