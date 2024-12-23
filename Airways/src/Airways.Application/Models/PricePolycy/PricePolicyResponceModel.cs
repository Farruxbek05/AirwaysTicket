using System.ComponentModel.DataAnnotations;

namespace Airways.Application.Models.PricePolycy
{
    public class PricePolicyResponceModel
    {
      
        public decimal DiscountPercentage { get; set; }
        public string Conditions { get; set; }
    }
}
