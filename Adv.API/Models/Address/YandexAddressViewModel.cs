using System.Collections.Generic;
using Adv.BLL.DTO.Address;

namespace Adv.API.Models.Address
{
    public class YandexAddressViewModel
    {
        public int Id { get; set; }
        public int GeoObjectId { get; set; }
        public GeoObjectViewModel GeoObject { get; set; }

        /// <summary>
        /// DTO -> VIEW
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static implicit operator YandexAddressViewModel(YandexAddressDto dto) => new YandexAddressViewModel
        {
            Id = dto.Id,
            GeoObject = dto.GeoObject,
            GeoObjectId = dto.GeoObjectId
        };
        
        /// <summary>
        /// VIEW -> DTO
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public static implicit operator YandexAddressDto(YandexAddressViewModel view) => new YandexAddressDto
        {
            GeoObject = view.GeoObject
        };
    }
}