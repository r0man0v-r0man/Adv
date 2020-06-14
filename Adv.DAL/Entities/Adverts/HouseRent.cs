using System;
using System.Collections.Generic;
using System.Text;
using Adv.DAL.Entities.Common;
using Adv.DAL.Entities.Images;

namespace Adv.DAL.Entities.Adverts
{
    public class HouseRent : AuditableEntity
    {
        /// <summary>
        /// уникальный номер объявления
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// создатель объявления
        /// </summary>
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        /// <summary>
        /// активность объявления
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// фотографии объявления
        /// </summary>
        public List<Image> Images { get; set; }
        /// <summary>
        /// адрес объявления
        /// </summary>
        public string Address { get; set; }
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
        /// город
        /// </summary>
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
