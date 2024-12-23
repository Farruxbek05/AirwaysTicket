using Airways.Core.Common;

namespace Airways.Core.Entity
{
    public class Payment:BaseEntity,IAuditedEntity
    {
        public int ID { get; set; }
        public decimal Amount { get; set; }
        public PayStatus payStatus { get; set; }
        public CardType paymentType { get; set; }
        public virtual User user { get; set; }
        public virtual Order order { get; set; }
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

