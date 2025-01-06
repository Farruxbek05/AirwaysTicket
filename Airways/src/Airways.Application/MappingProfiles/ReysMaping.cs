using Airways.Application.Models.Reys;
using Airways.Core.Entity;
using AutoMapper;

namespace Airways.Application.MappingProfiles
{
    public class ReysMaping:Profile
    {
        public ReysMaping()
        {
            CreateMap<CreateReysModel, Reys>();
            CreateMap<UpdateReysModel, Reys>().ReverseMap();

            CreateMap<Reys, ReysResponceModel>();
        }

    }
}
