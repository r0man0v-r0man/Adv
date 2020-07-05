using Adv.DAL.Entities.Address;

namespace Adv.BLL.DTO.Address
{
    public class MetaDataPropertyDto
    {
        public int? Id { get; set; }
        public int? GeocoderMetaDataId { get; set; }
        public GeocoderMetaDataDto GeocoderMetaData { get; set; }

        /// <summary>
        /// DAL -> DTO
        /// </summary>
        /// <param name="dal"></param>
        /// <returns></returns>
        public static implicit operator MetaDataPropertyDto(MetaDataProperty dal) => new MetaDataPropertyDto
        {
            Id = dal.Id,
            GeocoderMetaDataId = dal.GeocoderMetaDataId,
            GeocoderMetaData = dal.GeocoderMetaData
        };

        /// <summary>
        /// DTO -> DAL
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static implicit operator MetaDataProperty(MetaDataPropertyDto dto) => new MetaDataProperty
        {
            GeocoderMetaData = dto.GeocoderMetaData
        };
    }
}