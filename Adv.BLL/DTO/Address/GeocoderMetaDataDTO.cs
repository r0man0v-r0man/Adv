using Adv.DAL.Entities.Address;

namespace Adv.BLL.DTO.Address
{
    public class GeocoderMetaDataDto
    {
        public int Id { get; set; }
        public string Kind { get; set; }
        public string Text { get; set; }
        public string Precision { get; set; }
        public int AddressId { get; set; }
        public AddressDto Address { get; set; }

        /// <summary>
        /// DAL -> DTO
        /// </summary>
        /// <param name="dal"></param>
        /// <returns></returns>
        public static implicit operator GeocoderMetaDataDto(GeocoderMetaData dal) => new GeocoderMetaDataDto
        {
            Id = dal.Id,
            Kind = dal.Kind,
            Text = dal.Text,
            Precision = dal.Precision,
            AddressId = dal.AddressId,
            Address = dal.Address
        };

        /// <summary>
        /// DTO -> DAL
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static implicit operator GeocoderMetaData(GeocoderMetaDataDto dto) => new GeocoderMetaData
        {
            Kind = dto.Kind,
            Text = dto.Text,
            Precision = dto.Precision,
            Address = dto.Address
        };
    }
}