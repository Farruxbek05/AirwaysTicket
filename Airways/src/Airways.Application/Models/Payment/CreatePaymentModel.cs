using System.ComponentModel.DataAnnotations;

namespace Airways.Application.Models.Payment;

public class CreatePaymentModel
{
  
    public decimal Amount { get; set; }
    public PayStatus payStatus { get; set; }
    public CardType paymentType { get; set; }
    public Guid UserId { get; set; }
    public Guid OrderId { get; set; }
}
public class CreatePaymentResponceModel : BaseResponceModel { }

public enum PayStatus
{
    Paid,
    Pending,
    Failed
}

public enum CardType
{
    Uzcard,
    Humo,
    Visa,
    Mastercard
}
