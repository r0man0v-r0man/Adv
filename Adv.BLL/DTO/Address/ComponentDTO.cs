using Adv.DAL.Entities.Address;

namespace Adv.BLL.DTO.Address
{
    public class ComponentDto
    {
        public int? Id { get; set; }
        
        public string Kind { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// DAL -> DTO
        /// </summary>
        /// <param name="dal"></param>
        /// <returns></returns>
        public static implicit operator ComponentDto(Component dal) => new ComponentDto
        {
            Id = dal.Id,
            Kind = dal.Kind,
            Name = dal.Name
        };

        /// <summary>
        /// DTO -> DAL
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static implicit operator Component(ComponentDto dto) => new Component
        {
            Kind = dto.Kind,
            Name = dto.Name
        };
    }
}