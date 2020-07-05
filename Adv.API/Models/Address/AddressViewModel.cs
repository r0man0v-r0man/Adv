using System.Collections.Generic;
using System.Linq;
using Adv.BLL.DTO.Address;

namespace Adv.API.Models.Address
{
    public class AddressViewModel
    {
        public int? Id { get; set; }
        public string Country_code { get; set; }
        public string Postal_code { get; set; }
        public string Formatted { get; set; }
        public IList<ComponentViewModel> Components { get; set; }

        /// <summary>
        /// DTO -> VIEW
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static implicit operator AddressViewModel(AddressDto dto) => new AddressViewModel
        {
            Id = dto.Id,
            Country_code = dto.Country_code,
            Formatted = dto.Formatted,
            Postal_code = dto.Postal_code,
            Components = dto.Components.Select(component => (ComponentViewModel) component).ToList()
        };

        /// <summary>
        /// VIEW -> DTO
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public static implicit operator AddressDto(AddressViewModel view) => new AddressDto
        {
            Country_code = view.Country_code,
            Formatted = view.Formatted,
            Postal_code = view.Postal_code,
            Components = view.Components.Select(component => (ComponentDto) component).ToList()
        };
    }
}