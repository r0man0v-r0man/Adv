using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Adv.BLL.DTO.Address;
using Adv.BLL.DTO.Images;
using Adv.DAL.Entities.Adverts;
using Adv.DAL.Entities.Images;

namespace Adv.BLL.DTO.Adverts
{
    public class HouseRentDto : Common.AuditableEntity
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
        public List<ImageDto> Images { get; set; }
        /// <summary>
        /// адрес объявления
        /// </summary>
        public int AddressId { get; set; }
        public YandexAddressDto Address { get; set; }
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
        ///  DTO -> DAL
        /// </summary>
        /// <param name="dto"></param>
        public static implicit operator HouseRent(HouseRentDto dto) => new HouseRent
        {
            Id = dto.Id,
            IsActive = dto.IsActive,
            AppUserId = dto.UserId,
            Images = dto.Images.Select(img => (Image) img).ToList(),
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
            Description = dto.Description
        };

        /// <summary>
        /// DAL -> DTO
        /// </summary>
        /// <param name="dal"></param>
        public static implicit operator HouseRentDto(HouseRent dal) => new HouseRentDto
        {
            Id = dal.Id,
            IsActive = dal.IsActive,
            UserId = dal.AppUserId,
            Images = dal.Images.Select(img => (ImageDto) img).ToList(),
            Address = dal.Address,
            Rooms = dal.Rooms,
            Furniture = dal.Furniture,
            Refrigerator = dal.Refrigerator,
            MicrowaveOven = dal.MicrowaveOven,
            Internet = dal.Internet,
            WashingMachine = dal.WashingMachine,
            Bathhouse = dal.Bathhouse,
            Garage = dal.Garage,
            Price = dal.Price,
            Duration = dal.Duration,
            Phone = dal.Phone,
            Description = dal.Description,
            Created = dal.Created,
            LastModified = dal.LastModified
        };
    }
}
