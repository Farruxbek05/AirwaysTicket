using Airways.Core.Common;

namespace Airways.Core.Entity
{
    public sealed class User : BaseEntity, IAuditedEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PassportId { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Salt { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}