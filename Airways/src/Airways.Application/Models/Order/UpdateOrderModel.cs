using System.ComponentModel.DataAnnotations;

namespace Airways.Application.Models.Order
{
    public class UpdateOrderModel
    {
      
        public decimal TotalPrice { get; set; }
        public Guid UserId { get; set; }
        public Guid TicketsId { get; set; }
    }
    public class UpdateOrderResponceModel : BaseResponceModel { }
}
