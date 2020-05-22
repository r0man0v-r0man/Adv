using System;
using System.Collections.Generic;
using System.Text;
using Adv.DAL.Entities.Common;
using Adv.DAL.Entities.Images;

namespace Adv.DAL.Entities.Adverts
{
    public class FlatSale : BaseAdvert
    {
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
