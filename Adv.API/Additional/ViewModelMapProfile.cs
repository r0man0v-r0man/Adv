using Adv.API.Models;
using Adv.BLL.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adv.API.Additional
{
    public class ViewModelMapProfile : Profile
    {
        public ViewModelMapProfile() => CreateMap<FlatDTO, FlatViewModel>()
                .ForMember(dest => dest.Id, s => s.MapFrom(src => src.Id))
                .ForMember(dest => dest.Description, s => s.MapFrom(src => src.Description))
                .ForMember(dest => dest.District, s => s.MapFrom(src => src.District))
                .ReverseMap();
    }
}
