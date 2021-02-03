using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    // Here is where the mapping profiles lives, to translate data from an database entity to a Dto or reverse
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<RealProperty, RealPropertyDto>().ReverseMap();
        }
    }
}