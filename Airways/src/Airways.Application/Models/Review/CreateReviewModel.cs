using System.ComponentModel.DataAnnotations;

namespace Airways.Application.Models.Review;

public class CreateReviewModel
{
    
    public int Rating { get; set; }
    public string Comment { get; set; }
    public Guid User_id { get; set; }
    public Guid Reys_id { get; set; }
}
public class CreateReviewResponceModel : BaseResponceModel { }