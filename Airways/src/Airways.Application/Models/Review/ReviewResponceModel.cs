using System.ComponentModel.DataAnnotations;

namespace Airways.Application.Models.Review
{
    public class ReviewResponceModel:BaseResponceModel
    {
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
