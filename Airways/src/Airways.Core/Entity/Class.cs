using Airways.Core.Common;

namespace Airways.Core.Entity
{
    public class Class:BaseEntity,IAuditedEntity
    {
        public ClassType ClassType { get; set; }
        public string description { get; set; }
        public List<Tickets> Tickets = new List<Tickets>();
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
    public enum ClassType
    {
        Economy=1000,
        Business=500,
        FirstClass=200
    }
}
