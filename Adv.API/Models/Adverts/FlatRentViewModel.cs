using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adv.API.Models.Files;

namespace Adv.API.Models.Adverts
{
    /// <summary>
    /// View Модель объявления - квартира сдать
    /// </summary>
    public class FlatRentViewModel : API.Models.Common.AuditableEntity
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
    }
}
