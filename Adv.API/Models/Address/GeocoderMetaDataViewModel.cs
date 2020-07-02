using Adv.BLL.DTO.Address;

namespace Adv.API.Models.Address
{
    public class GeocoderMetaDataViewModel
    {
        public int Id { get; set; }
        public string Kind { get; set; }
        public string Text { get; set; }
        public string Precision { get; set; }
        public int AddressId { get; set; }
        public AddressViewModel Address { get; set; }

        /// <summary>
        /// DTO -> VIEW
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static implicit operator GeocoderMetaDataViewModel(GeocoderMetaDataDto dto) =>
            new GeocoderMetaDataViewModel
            {
                AddressId = dto.AddressId,
                Address = dto.Address,
                Id = dto.Id,
                Kind = dto.Kind,
                Precision = dto.Precision,
                Text = dto.Text
            };

        /// <summary>
        /// VIEW -> DTO
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public static implicit operator GeocoderMetaDataDto(GeocoderMetaDataViewModel view) => 
            new GeocoderMetaDataDto
            {
                Address = view.Address,
                Kind = view.Kind,
                Precision = view.Precision,
                Text = view.Text
            };
    }
}