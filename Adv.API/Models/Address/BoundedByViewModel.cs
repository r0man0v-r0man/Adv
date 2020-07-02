using Adv.BLL.DTO.Address;

namespace Adv.API.Models.Address
{
    public class BoundedByViewModel
    {
        public int Id { get; set; }
        public int EnvelopeId { get; set; }
        public EnvelopeViewModel Envelope { get; set; }

        /// <summary>
        /// DTO -> VIEW
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static implicit operator BoundedByViewModel(BoundedByDto dto) => new BoundedByViewModel
        {
            Id = dto.Id,
            EnvelopeId = dto.Id,
            Envelope = dto.Envelope
        };

        /// <summary>
        /// VIEW -> DTO
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public static implicit operator BoundedByDto(BoundedByViewModel view) => new BoundedByDto
        {
            Envelope = view.Envelope,
        };
    }
}