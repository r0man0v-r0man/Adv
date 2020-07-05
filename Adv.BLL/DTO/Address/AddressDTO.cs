using System.Collections.Generic;
using System.Linq;
using Adv.DAL.Entities.Address;

namespace Adv.BLL.DTO.Address
{
    public class AddressDto
    {
        public int? Id { get; set; }
        public string Country_code { get; set; }
        public string Postal_code { get; set; }
        public string Formatted { get; set; }
        public IList<ComponentDto> Components { get; set; }

        /// <summary>
        /// DAL -> DTO
        /// </summary>
        /// <param name="dal"></param>
        /// <returns></returns>
        public static implicit operator AddressDto(DAL.Entities.Address.Address dal) => new AddressDto
        {
            Id = dal.Id,
            Country_code = dal.Country_code,
            Postal_code = dal.Postal_code,
            Formatted = dal.Formatted,
            Components = dal.Components.Select(component => (ComponentDto) component).ToList()
        };

        /// <summary>
        /// DTO -> DAL
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static implicit operator DAL.Entities.Address.Address(AddressDto dto) => new DAL.Entities.Address.Address
        {
            Country_code = dto.Country_code,
            Postal_code = dto.Postal_code,
            Formatted = dto.Formatted,
            Components = dto.Components.Select(component => (Component) component).ToList()
        };
    }
}