namespace Airways.Application.Models.PricePolycy;

public class CreatePricePolicyModel
{
    public int ID { get; set; }
    public decimal DiscountPercentage { get; set; }
    public string Conditions { get; set; }
}
public class CreatePricePolicyResponceModel : BaseResponceModel { }
