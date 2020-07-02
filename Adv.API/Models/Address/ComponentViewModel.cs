using Adv.BLL.DTO.Address;

namespace Adv.API.Models.Address
{
    public class ComponentViewModel
    {
        public int Id { get; set; }
        public string Kind { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// DTO -> VIEW
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static implicit operator ComponentViewModel(ComponentDto dto) => new ComponentViewModel
        {
            Id = dto.Id,
            Kind = dto.Kind,
            Name = dto.Name
        };
        /// <summary>
        /// VIEW -> DTO
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public static implicit operator ComponentDto(ComponentViewModel view) => new ComponentDto
        {
            Kind = view.Kind,
            Name = view.Name
        };
    }
}