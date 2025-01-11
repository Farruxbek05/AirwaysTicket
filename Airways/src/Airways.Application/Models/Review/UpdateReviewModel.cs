using System.ComponentModel.DataAnnotations;

namespace Airways.Application.Models.Review
{
    public class UpdateReviewModel
    {
        
        public int Rating { get; set; }
        public string Comment { get; set; }
        public Guid UserId { get; set; }
        public Guid ReysId { get; set; }
    }
    public class UpdateReviewResponceModel : BaseResponceModel { }
}
