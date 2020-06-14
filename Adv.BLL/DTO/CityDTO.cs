using Adv.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adv.BLL.DTO
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static implicit operator City(CityDto dto) => new City()
        {
            Id = dto.Id,
            Name = dto.Name
        };
        public static implicit operator CityDto(City dal) => new CityDto()
        {

            Id = dal.Id,
            Name = dal.Name
        };
        
    }
}
