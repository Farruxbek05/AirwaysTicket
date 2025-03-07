using Airways.DataAccess.Authentication;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Airways.DataAccess
{
    public class UserForCreationDTO
    {
        [Required(ErrorMessage = "Foydalanuvchi nomini kiritish shart.")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Ism uzunligi kamida 2 va maksimal 15 ta belgidan iborat bo'lishi kerak.")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Ism faqat harflar va bo'sh joylardan iborat bo'lishi kerak.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Email manzilini kiritish shart.")]
        [EmailAddress(ErrorMessage = "Email manzil noto'g'ri formatda.")]
        public required string Email { get; set; }

        public required string Address { get; set; }

        
        public required string Password { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TableRole role { get; set; }
        public IFormFile ProfileImage { get; set; }
    }
}
