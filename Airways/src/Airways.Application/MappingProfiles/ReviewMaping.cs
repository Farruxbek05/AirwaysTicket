using Airways.Application.Models.Review;
using Airways.Core.Entity;
using AutoMapper;

namespace Airways.Application.MappingProfiles
{
    public class ReviewMaping:Profile
    {
        public ReviewMaping() 
        {
            CreateMap<CreateReviewModel, Review>();
            CreateMap<UpdateReviewModel, Review>().ReverseMap();

            CreateMap<Review, ReviewResponceModel>();
        }

    }
}
