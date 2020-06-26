using Adv.DAL.Entities;

namespace Adv.BLL.DTO
{
    public class AddressDto
    {
        public int Id { get; set; }
        /// <summary>
        /// точный адрес
        /// </summary>
        public string ExactLocation { get; set; }
        
        public int CityId { get; set; }
        public CityDto City { get; set; }

        /// <summary>
        /// DTO -> DAL
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static implicit operator Address(AddressDto dto) => new Address
        {
            Id = dto.Id,
            City = dto.City,
            CityId = dto.CityId,
            ExactLocation = dto.ExactLocation
        };
        /// <summary>
        /// DAL -> DTO
        /// </summary>
        /// <param name="dal"></param>
        /// <returns></returns>
        public static implicit operator AddressDto(Address dal) => new AddressDto
        {
            City = dal.City,
            Id = dal.Id,
            CityId = dal.CityId,
            ExactLocation = dal.ExactLocation
        };
    }
}