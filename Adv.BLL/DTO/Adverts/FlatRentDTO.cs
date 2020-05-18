﻿using System.Collections.Generic;
using System.Linq;
using Adv.BLL.DTO.Images;
using Adv.DAL.Entities.Adverts;
using Adv.DAL.Entities.Images;

namespace Adv.BLL.DTO.Adverts
{
    public class FlatRentDTO : Common.AuditableEntity
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
        public List<ImageDTO> Images { get; set; }
        /// <summary>
        /// адрес объявления
        /// </summary>
        public string Address { get; set; }
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
        /// наличие балкона
        /// </summary>
        public byte Balcony { get; set; }
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

        public FlatRentDTO()
        {
            Images = new List<ImageDTO>();
        }

        public static implicit operator FlatRent(FlatRentDTO dto) => new FlatRent()
        {
            Id = dto.Id,
            AppUserId = dto.UserId,
            IsActive = dto.IsActive,
            Images = dto.Images.Select(imgDTO => (Image) imgDTO).ToList(),
            Address = dto.Address,
            Floor = dto.Floor,
            AllFloor = dto.AllFloor,
            Rooms = dto.Rooms,
            Balcony = dto.Balcony,
            Furniture = dto.Furniture,
            Refrigerator = dto.Refrigerator,
            MicrowaveOven = dto.MicrowaveOven,
            Internet = dto.Internet,
            WashingMachine = dto.WashingMachine,
            Price = dto.Price,
            Duration = dto.Duration,
            Phone = dto.Phone,
            Description = dto.Description
        };
    }
}
