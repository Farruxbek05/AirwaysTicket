using System.ComponentModel.DataAnnotations;

namespace Airways.Application.Models.PricePolycy;

public class CreatePricePolicyModel
{
 
    public decimal DiscountPercentage { get; set; }
    public string Conditions { get; set; }
}
public class CreatePricePolicyResponceModel : BaseResponceModel { }
