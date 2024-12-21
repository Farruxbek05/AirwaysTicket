namespace Airways.Application.Models.PricePolycy
{
    public class PricePolicyResponceModel
    {
        public int ID { get; set; }
        public decimal DiscountPercentage { get; set; }
        public string Conditions { get; set; }
    }
}
