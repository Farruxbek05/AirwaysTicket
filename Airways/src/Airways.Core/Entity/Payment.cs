using Airways.Core.Common;

namespace Airways.Core.Entity
{
    public class Payment:BaseEntity,IAuditedEntity
    {
      
        public decimal Amount { get; set; }
        public PayStatus payStatus { get; set; }
        public CardType paymentType { get; set; }
        public User User { get; set; }
        public Order Order { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
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

}

