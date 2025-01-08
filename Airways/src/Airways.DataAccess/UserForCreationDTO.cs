using Airways.DataAccess.Authentication;
using Microsoft.AspNetCore.Http;

namespace Airways.DataAccess
{
    public class UserForCreationDTO
    {
        public required string Name { get; set; }

        public required string Email { get; set; }

        public required string Address { get; set; }

        public required string PassportId { get; set; }
        public required string Password { get; set; }
        public TableRole role { get; set; }
        public IFormFile ProfileImage { get; set; }
    }
}
