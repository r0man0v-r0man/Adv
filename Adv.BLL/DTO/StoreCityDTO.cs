using Adv.DAL.Entities;

namespace Adv.BLL.DTO
{
    public class StoreCityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static implicit operator StoreCity(StoreCityDto dto) => new StoreCity
        {
            Id = dto.Id,
            Name = dto.Name
        };

        public static implicit operator StoreCityDto(StoreCity dal) => new StoreCityDto
        {
            Id = dal.Id,
            Name = dal.Name
        };
    }
}