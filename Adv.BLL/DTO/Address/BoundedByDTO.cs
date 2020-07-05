using Adv.DAL.Entities.Address;

namespace Adv.BLL.DTO.Address
{
    public class BoundedByDto
    {
        public int? Id { get; set; }
        public int? EnvelopeId { get; set; }
        public EnvelopeDto Envelope { get; set; }

        /// <summary>
        /// DAL -> DTO
        /// </summary>
        /// <param name="dal"></param>
        /// <returns></returns>
        public static implicit operator BoundedByDto(BoundedBy dal) => new BoundedByDto
        {
            Envelope = dal.Envelope ?? new Envelope(),
            Id = dal.Id,
            EnvelopeId = dal.EnvelopeId
        };

        /// <summary>
        /// DTO -> DAL
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static implicit operator BoundedBy(BoundedByDto dto) => new BoundedBy
        {
            Envelope = dto.Envelope
        };
    }
}