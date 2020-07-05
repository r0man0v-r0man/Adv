using Adv.DAL.Entities.Address;

namespace Adv.BLL.DTO.Address
{
    public class EnvelopeDto
    {
        public int? Id { get; set; }
        public string LowerCorner { get; set; }
        public string UpperCorner { get; set; }

        /// <summary>
        /// DAL -> DTO
        /// </summary>
        /// <param name="dal"></param>
        /// <returns></returns>
        public static implicit operator EnvelopeDto(Envelope dal) => new EnvelopeDto
        {
            Id = dal.Id,
            LowerCorner = dal.LowerCorner,
            UpperCorner = dal.UpperCorner
        };

        /// <summary>
        /// DTO -> DAL
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static implicit operator Envelope(EnvelopeDto dto) => new Envelope
        {
            LowerCorner = dto.LowerCorner,
            UpperCorner = dto.UpperCorner
        };
    }
}