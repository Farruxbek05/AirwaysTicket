﻿using Airways.Core.Common;
using System.Net.Sockets;

namespace Airways.Core.Entity
{
    public class Payment:BaseEntity,IAuditedEntity
    {
        public decimal Amount { get; set; }
        public PayStatus payStatus { get; set; }
        public CardType paymentType { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public List<Tickets> Tickets { get; set; }
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

