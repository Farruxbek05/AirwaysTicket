using System.ComponentModel.DataAnnotations;

namespace Airways.Application.Models.Payment
{
    public class UpdatePaymentModel
    {
       
        public decimal Amount { get; set; }
        public PayStatus payStatus { get; set; }
        public CardType paymentType { get; set; }
        public Guid UserId { get; set; }
        public Guid OrderId { get; set; }
    }
    public class UpdatePaymentResponceModel : BaseResponceModel { }
}
