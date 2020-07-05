using Adv.BLL.DTO.Address;

namespace Adv.API.Models.Address
{
    public class EnvelopeViewModel
    {
        public int? Id { get; set; }
        public string LowerCorner { get; set; }
        public string UpperCorner { get; set; }

        /// <summary>
        /// DTO -> VIEW
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static implicit operator EnvelopeViewModel(EnvelopeDto dto) => new EnvelopeViewModel
        {
            Id = dto.Id,
            LowerCorner = dto.LowerCorner,
            UpperCorner = dto.UpperCorner
        };

        /// <summary>
        /// VIEW -> DTO
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public static implicit operator EnvelopeDto(EnvelopeViewModel view) => new EnvelopeDto
        {
            LowerCorner = view.LowerCorner,
            UpperCorner = view.UpperCorner
        };
    }
}