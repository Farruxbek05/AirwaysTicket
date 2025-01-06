using Airways.Application.Models.Airline;
using Airways.Core.Entity;
using AutoMapper;

namespace Airways.Application.MappingProfiles
{
    public class AirlineMaping:Profile
    {
        public AirlineMaping()
        {
            CreateMap<CreateAirlineModel, Airline>();

            CreateMap<UpdateAirlineModel, Airline>().ReverseMap();

            CreateMap<Airline, AirlineResponceModel>();
        }
    }
}
