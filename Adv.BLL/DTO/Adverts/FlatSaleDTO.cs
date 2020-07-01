using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Adv.BLL.DTO.Images;
using Adv.DAL.Entities.Adverts;
using Adv.DAL.Entities.Images;

namespace Adv.BLL.DTO.Adverts
{
    public class FlatSaleDto : Common.AuditableEntity
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
        public AddressDto Address { get; set; }
        /// <summary>
        /// этаж 
        /// </summary>
        public int Floor { get; set; }
        /// <summary>
        /// всего этажей
        /// </summary>
        public int AllFloor { get; set; }
        /// <summary>
        /// количество комнат
        /// </summary>
        public byte Rooms { get; set; }
        /// <summary>
        /// Общая площадь
        /// </summary>
        public int FlatArea { get; set; }
        /// <summary>
        /// Жилая площадь
        /// </summary>
        public int FlatLiveArea { get; set; }
        /// <summary>
        /// Площадь кухни
        /// </summary>
        public int KitchenArea { get; set; }
        /// <summary>
        /// наличие балкона
        /// </summary>
        public byte Balcony { get; set; }
        /// <summary>
        /// туалет
        /// </summary>
        public byte Toilet { get; set; }
        /// <summary>
        /// цена
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// телефон
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// описание
        /// </summary>
        public string Description { get; set; }
        public CityDto CityDto { get; set; }


        /// <summary>
        /// DTO -> DAL
        /// </summary>
        /// <param name="dto"></param>
        public static implicit operator FlatSale(FlatSaleDto dto) => new FlatSale
        {
            Id = dto.Id,
            AppUserId = dto.UserId,
            IsActive = dto.IsActive,
            Images = dto.Images.Select(img => (Image) img).ToList(),
            Address = dto.Address,
            Floor = dto.Floor,
            AllFloor = dto.AllFloor,
            Rooms = dto.Rooms,
            FlatArea = dto.FlatArea,
            FlatLiveArea = dto.FlatLiveArea,
            KitchenArea = dto.KitchenArea,
            Balcony = dto.Balcony,
            Toilet = dto.Toilet,
            Price = dto.Price,
            Phone = dto.Phone,
            Description = dto.Description
        };
        /// <summary>
        /// DAL -> DTO
        /// </summary>
        /// <param name="dal"></param>
        public static implicit operator FlatSaleDto(FlatSale dal) => new FlatSaleDto
        {
            Id = dal.Id,
            UserId = dal.AppUserId,
            IsActive = dal.IsActive,
            Images = dal.Images.Select(img => (ImageDto) img).ToList(),
            Address = dal.Address,
            Floor = dal.Floor,
            AllFloor = dal.AllFloor,
            Rooms = dal.Rooms,
            FlatArea = dal.FlatArea,
            FlatLiveArea = dal.FlatLiveArea,
            KitchenArea = dal.KitchenArea,
            Balcony = dal.Balcony,
            Toilet = dal.Toilet,
            Price = dal.Price,
            Phone = dal.Phone,
            Description = dal.Description,
            Created = dal.Created,
            LastModified = dal.LastModified
        };
    }
}
