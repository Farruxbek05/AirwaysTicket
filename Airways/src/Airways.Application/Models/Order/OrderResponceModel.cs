using System.ComponentModel.DataAnnotations;

namespace Airways.Application.Models.Order
{
    public class OrderResponceModel:BaseResponceModel
    {
        public decimal TotalPrice { get; set; }
    }
}
