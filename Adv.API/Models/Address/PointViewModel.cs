using Adv.BLL.DTO.Address;

namespace Adv.API.Models.Address
{
    public class PointViewModel
    {
        public int Id { get; set; }
        public string Pos { get; set; }

        /// <summary>
        /// DTO -> VIEW
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static implicit operator PointViewModel(PointDto dto) => new PointViewModel
        {
            Pos = dto.Pos,
            Id = dto.Id
        };

        /// <summary>
        /// VIEW -> DTO
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public static implicit operator PointDto(PointViewModel view) => new PointDto
        {
            Pos = view.Pos
        };
    }
}