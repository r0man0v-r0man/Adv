using Adv.BLL.DTO.Enums;
using Adv.DAL.Entities;

namespace Adv.BLL.DTO
{
    public class FlatDTO 
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public City.District District { get; set; }

        /// <summary>
        /// Mapping to DTO model
        /// </summary>
        /// <param name="dalFlat">Data Access Layer flat</param>
        public static implicit operator FlatDTO(Flat dalFlat) => new FlatDTO
        {
            Description = dalFlat.Description,
            District = dalFlat.District,
            Id = dalFlat.Id
        };
    }
}
