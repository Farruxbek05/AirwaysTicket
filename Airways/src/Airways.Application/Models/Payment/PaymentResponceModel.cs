namespace Airways.Application.Models.Payment
{
    public class PaymentResponceModel
    {
        public int ID { get; set; }
        public decimal Amount { get; set; }
        public PayStatus payStatus { get; set; }
        public CardType paymentType { get; set; }
    }
}
