using Adv.DAL.Entities.Address;

namespace Adv.BLL.DTO.Address
{
    public class YandexAddressDto
    {
        public int Id { get; set; }
        public int GeoObjectId { get; set; }
        public GeoObjectDto GeoObject { get; set; }

        /// <summary>
        /// DAL -> DTO
        /// </summary>
        /// <param name="dal"></param>
        /// <returns></returns>
        public static implicit operator YandexAddressDto(YandexAddress dal) => new YandexAddressDto
        {
            Id = dal.Id,
            GeoObject = dal.GeoObject,
            GeoObjectId = dal.GeoObjectId
        };
        /// <summary>
        /// DTO -> DAL
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static implicit operator YandexAddress(YandexAddressDto dto) => new YandexAddress
        {
            GeoObject = dto.GeoObject
        };
    }
}