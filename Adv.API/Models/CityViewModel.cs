using Adv.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adv.API.Models
{
    public class CityViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static implicit operator CityViewModel(CityDto dto) => new CityViewModel()
        {
            Id = dto.Id,
            Name = dto.Name
        };
        public static implicit operator CityDto(CityViewModel view) => new CityDto()
        {
            Name = view.Name
        };
    }
}
