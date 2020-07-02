using Adv.BLL.DTO.Address;

namespace Adv.API.Models.Address
{
    public class MetaDataPropertyViewModel
    {
        public int Id { get; set; }
        public int GeocoderMetaDataId { get; set; }
        public GeocoderMetaDataViewModel GeocoderMetaData { get; set; }

        /// <summary>
        /// DTO -> VIEW
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static implicit operator MetaDataPropertyViewModel(MetaDataPropertyDto dto) =>
            new MetaDataPropertyViewModel
            {
                Id = dto.Id,
                GeocoderMetaDataId = dto.GeocoderMetaDataId,
                GeocoderMetaData = dto.GeocoderMetaData
            };

        /// <summary>
        /// VIEW -> DTO
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public static implicit operator MetaDataPropertyDto(MetaDataPropertyViewModel view) => new MetaDataPropertyDto
        {
            GeocoderMetaData = view.GeocoderMetaData
        };
    }
}