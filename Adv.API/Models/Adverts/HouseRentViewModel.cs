using System.Collections.Generic;
using System.Linq;
using Adv.API.Models.Files;
using Adv.BLL.DTO.Adverts;
using Adv.BLL.DTO.Images;

namespace Adv.API.Models.Adverts
{
    public class HouseRentViewModel : API.Models.Common.AuditableEntity
    {
        /// <summary>
        /// номер объявления
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// создатель объявления
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// активность объявления
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// фотографии объявления
        /// </summary>
        public List<FileModel> Images { get; set; }
        /// <summary>
        /// адрес объявления
        /// </summary>
        public AddressViewModel Address { get; set; }
        /// <summary>
        /// количество комнат
        /// </summary>
        public byte Rooms { get; set; }
        /// <summary>
        /// наличие мебели
        /// </summary>
        public bool Furniture { get; set; }
        /// <summary>
        /// наличие холодильника
        /// </summary>
        public bool Refrigerator { get; set; }
        /// <summary>
        /// наличие микроволновой печи
        /// </summary>
        public bool MicrowaveOven { get; set; }
        /// <summary>
        /// наличие интернета
        /// </summary>
        public bool Internet { get; set; }
        /// <summary>
        /// наличие стиральной машины
        /// </summary>
        public bool WashingMachine { get; set; }
        /// <summary>
        /// баня
        /// </summary>
        public bool Bathhouse { get; set; }
        /// <summary>
        /// гараж
        /// </summary>
        public bool Garage { get; set; }
        /// <summary>
        /// цена
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// тип аренды
        /// </summary>
        public byte Duration { get; set; }
        /// <summary>
        /// телефон
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// View -> DAL
        /// </summary>
        /// <param name="view"></param>
        public static implicit operator HouseRentDto(HouseRentViewModel view) => new HouseRentDto
        {
            Id = view.Id,
            IsActive = view.IsActive,
            UserId = view.UserId,
            Images = view.Images.Select(img => (ImageDto) img).ToList(),
            Address = view.Address,
            Rooms = view.Rooms,
            Furniture = view.Furniture,
            Refrigerator = view.Refrigerator,
            MicrowaveOven = view.MicrowaveOven,
            Internet = view.Internet,
            WashingMachine = view.WashingMachine,
            Bathhouse = view.Bathhouse,
            Garage = view.Garage,
            Price = view.Price,
            Duration = view.Duration,
            Phone = view.Phone,
            Description = view.Description
        };
        /// <summary>
        /// DTO -> View
        /// </summary>
        /// <param name="dto"></param>
        public static implicit operator HouseRentViewModel(HouseRentDto dto) => new HouseRentViewModel
        {
            Id = dto.Id,
            IsActive = dto.IsActive,
            UserId = dto.UserId,
            Images = dto.Images.Select(img => (FileModel) img).ToList(),
            Address = dto.Address,
            Rooms = dto.Rooms,
            Furniture = dto.Furniture,
            Refrigerator = dto.Refrigerator,
            MicrowaveOven = dto.MicrowaveOven,
            Internet = dto.Internet,
            WashingMachine = dto.WashingMachine,
            Bathhouse = dto.Bathhouse,
            Garage = dto.Garage,
            Price = dto.Price,
            Duration = dto.Duration,
            Phone = dto.Phone,
            Description = dto.Description,
            Created = dto.Created,
            LastModified = dto.LastModified
        };
    }
}
