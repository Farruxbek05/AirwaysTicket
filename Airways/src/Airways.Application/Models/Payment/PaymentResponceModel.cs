using System.ComponentModel.DataAnnotations;

namespace Airways.Application.Models.Payment
{
    public class PaymentResponceModel:BaseResponceModel
    {
        public decimal Amount { get; set; }
        public PayStatus payStatus { get; set; }
        public CardType paymentType { get; set; }
    }
}
