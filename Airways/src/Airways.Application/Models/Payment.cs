namespace Airways.Application.Models;

public class Payment
{
    public int ID { get; set; }
    public decimal Amount { get; set; }
    public PayStatus payStatus { get; set; }
    public CardType paymentType { get; set; }
    public Guid User_id { get; set; }
    public Guid Order_id { get; set; }
}

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
