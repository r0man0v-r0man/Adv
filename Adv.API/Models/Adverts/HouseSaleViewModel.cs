﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adv.API.Models.Files;

namespace Adv.API.Models.Adverts
{
    public class HouseSaleViewModel
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
        /// Общая площадь
        /// </summary>
        public int HouseArea { get; set; }
        /// <summary>
        /// Жилая площадь
        /// </summary>
        public int HouseLiveArea { get; set; }
        /// <summary>
        /// Площадь кухни
        /// </summary>
        public int KitchenArea { get; set; }
        /// <summary>
        /// Площадь участка
        /// </summary>
        public int HousePlotArea { get; set; }
        /// <summary>
        /// отопление
        /// </summary>
        public bool Heating { get; set; }
        /// <summary>
        /// вода
        /// </summary>
        public bool Water { get; set; }
        /// <summary>
        /// газ
        /// </summary>
        public bool Gas { get; set; }
        /// <summary>
        /// канализация
        /// </summary>
        public bool Sewage { get; set; }
        /// <summary>
        /// Электричество
        /// </summary>
        public bool Electricity { get; set; }
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
        /// телефон
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// описание
        /// </summary>
        public string Description { get; set; }
    }
}
