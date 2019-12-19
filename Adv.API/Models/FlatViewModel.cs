using Adv.API.Models.Enums;
using Adv.API.Models.Files;
using Adv.API.Models.Files.Link;
using Adv.BLL.DTO;

namespace Adv.API.Models
{
    public class FlatViewModel : API.Models.Common.AuditableEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public City.District District { get; set; }
        public bool IsActive { get; set; }
        public decimal Price { get; set; }
        public FileModel File { get; set; }
        
        
        /// <summary>
        /// Mapping to FlatViewModel
        /// </summary>
        /// <param name="flat">DTO entity</param>
        public static implicit operator FlatViewModel(FlatDTO flat) => new FlatViewModel
        {
            Id = flat.Id,
            Description = flat.Description,
            District = flat.District,
            IsActive = flat.IsActive,
            Price = flat.Price,
            File = flat.Image
        };
        /// <summary>
        /// Mapping to FlatDTo model
        /// </summary>
        /// <param name="flat"></param>
        public static implicit operator FlatDTO(FlatViewModel flat) =>
            new FlatDTO
            {
                Image = flat.File.LinkProps.Download,
                IsActive = flat.IsActive,
                Price = flat.Price,
                District = flat.District,
                Description = flat.Description,
                Id = flat.Id
            };
    }
}
