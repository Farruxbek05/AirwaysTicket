using Airways.Core.Common;
using System.Data;

namespace Airways.Core.Entity
{
    public class User:BaseEntity,IAuditedEntity
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        Role role { get; set; }
        public List<Order> orders=new List<Order>();
        public List<Payment> payment=new List<Payment>();   
        public List<Review> reviews=new List<Review>();
        public List<Tickets> tickets=new List<Tickets>();
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
    enum Role
    {
        admin,
        customer
    }
}
