using System.ComponentModel.DataAnnotations;

namespace Airways.Application.Models.Order
{
    public class UpdateOrderModel
    {
      
        public decimal TotalPrice { get; set; }
        public Guid User_id { get; set; }
        public Guid Ticked_id { get; set; }
    }
    public class UpdateOrderResponceModel : BaseResponceModel { }
}
