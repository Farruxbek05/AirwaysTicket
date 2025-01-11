using Airways.DataAccess.Authentication;
using Microsoft.AspNetCore.Http;

namespace Airways.Application.DTO
{
    public class UserDTO
    {
    
        public required string Name { get; set; }

        public required string Email { get; set; }

        public required string Address { get; set; }
        public IFormFile ProfileImageFile { get; set; }
    }
}
