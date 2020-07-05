using Adv.DAL.Entities.Address;

namespace Adv.BLL.DTO.Address
{
    public class PointDto
    {
        public int? Id { get; set; }
        public string Pos { get; set; }

        /// <summary>
        /// DAL -> DTO
        /// </summary>
        /// <param name="dal"></param>
        /// <returns></returns>
        public static implicit operator PointDto(Point dal) => new PointDto
        {
            Pos = dal.Pos,
            Id = dal.Id
        };

        /// <summary>
        /// DTO -> DAL
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static implicit operator Point(PointDto dto) => new Point
        {
            Pos = dto.Pos
        };
    }
}