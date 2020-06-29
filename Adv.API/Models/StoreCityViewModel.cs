using Adv.BLL.DTO;

namespace Adv.API.Models
{
    public class StoreCityViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static implicit operator StoreCityViewModel(StoreCityDto dto) => new StoreCityViewModel()
        {
            Id = dto.Id,
            Name = dto.Name
        };
        public static implicit operator StoreCityDto(StoreCityViewModel view) => new StoreCityDto()
        {
            Id = view.Id,
            Name = view.Name
        };
    }
}