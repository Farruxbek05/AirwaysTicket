using System.ComponentModel.DataAnnotations;

namespace Airways.Application.Models.PricePolycy
{
    public class PricePolicyResponceModel:BaseResponceModel
    {
        public decimal DiscountPercentage { get; set; }
        public string Conditions { get; set; }
    }
}
