using Airways.Application.Models.Aicraft;
using Airways.Core.Entity;
using AutoMapper;

namespace Airways.Application.MappingProfiles
{
    public class AircraftMaping:Profile
    {
        public AircraftMaping()
        {
            CreateMap<CreateAircraftModel, Aicraft>();
            CreateMap<UpdateAicraftModel, Aicraft>().ReverseMap();

            CreateMap<Aicraft, AicraftResponceModel>();
        }
    }
}
