using Airways.Application.Models.Classs;
using Airways.Core.Entity;
using AutoMapper;

namespace Airways.Application.MappingProfiles
{
    public class ClassMaping:Profile
    {
        public ClassMaping()
        {
            CreateMap<CreateCLassModel, Class>();
   
            CreateMap<UpdateClassModel, Class>().ReverseMap();

            CreateMap<Class, ClassResponceModel>();
        }

    }
}
