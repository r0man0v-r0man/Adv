using Adv.BLL.DTO;

namespace Adv.API.Models
{
    public class AddressViewModel
    {
        public int Id { get; set; }
        /// <summary>
        /// точный адрес
        /// </summary>
        public string ExactLocation { get; set; }
        
        public int CityId { get; set; }
        public CityViewModel City { get; set; }

        /// <summary>
        /// DTO -> VIEW
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static implicit operator AddressViewModel(AddressDto dto) => new AddressViewModel
        {
            City = dto.City,
            Id = dto.Id,
            CityId = dto.CityId,
            ExactLocation = dto.ExactLocation
        };
        /// <summary>
        /// VIEW -> DTO
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public static implicit operator AddressDto(AddressViewModel view) => new AddressDto
        {
            City = view.City,
            ExactLocation = view.ExactLocation
        };
    }
}