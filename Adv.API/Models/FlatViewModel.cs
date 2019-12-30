using Adv.API.Models.Enums;
using Adv.API.Models.Files;
using Adv.API.Models.Files.Link;
using Adv.BLL.DTO;
using System.Collections.Generic;
using System.Globalization;

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
        public string Street { get; set; }
        public int NumberOfHouse { get; set; }
        public int NumberOfHouseCourpus { get; set; }
        public int NumberOfSubHouse { get; set; }
        public int NumberOfFlat { get; set; }

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
        /// Mapping to FlatDTO model
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
                Id = flat.Id,
                Address = new Dictionary<string, string>
                {
                    ["street"] = flat.Street,
                    ["house"] = flat.NumberOfHouse.ToString(new CultureInfo("ru-RU")),
                    ["corpus"] = flat.NumberOfHouseCourpus.ToString(new CultureInfo("ru-RU")),
                    ["subHouse"] = flat.NumberOfSubHouse.ToString(new CultureInfo("ru-RU")),
                    ["flat"] = flat.NumberOfFlat.ToString(new CultureInfo("ru-RU"))
                }
            };
    }
}
