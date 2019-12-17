using Adv.BLL.DTO;
using Adv.DAL.Entities;
using Adv.DAL.Entities.Enums;
using AutoMapper;

namespace Adv.BLL
{
    public class BllMapProfile : Profile
    {
        public BllMapProfile()
        {
            CreateMap<Flat, FlatDTO>()
                .ForMember(dest => dest.Description, s => s.MapFrom(src => src.Description))
                .ForMember(dest => dest.District, s => s.MapFrom(src => src.District))
                .ForMember(dest => dest.Id, s => s.MapFrom(src => src.Id))
                .ReverseMap();
        }
    }
}
