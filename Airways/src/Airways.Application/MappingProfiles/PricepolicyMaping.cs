using Airways.Application.Models.PricePolycy;
using Airways.Core.Entity;
using AutoMapper;

namespace Airways.Application.MappingProfiles
{
    public class PricepolicyMaping:Profile
    {
        public PricepolicyMaping()
        {
            CreateMap<CreatePricePolicyModel, PricePolicy>();
   

            CreateMap<UpdatePricePolicyModel, PricePolicy>().ReverseMap();

            CreateMap<PricePolicy, PricePolicyResponceModel>();
        }
    }
}
