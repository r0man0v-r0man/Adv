﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adv.API.Models.Files;

namespace Adv.API.Models.Adverts
{
    public class FlatSaleViewModel
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
    }
}
