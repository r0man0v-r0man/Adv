using Adv.API.Models.Enums;
using Adv.API.Models.Files;
using Adv.API.Models.Files.Link;
using Adv.BLL.DTO;

namespace Adv.API.Models
{
    public class FlatViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public City.District District { get; set; }
        public bool IsActive { get; set; }
        public decimal Price { get; set; }
        public FileModel Image { get; set; }
        /// <summary>
        /// Mapping to ViewModel
        /// </summary>
        /// <param name="flat">DTO entity</param>
        public static implicit operator FlatViewModel(FlatDTO flat) => new FlatViewModel
        {
            Id = flat.Id,
            Description = flat.Description,
            District = flat.District,
            IsActive = flat.IsActive,
            Price = flat.Price,
            Image = flat.Image
        };
    }
}
