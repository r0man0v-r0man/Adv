using System;
using System.Collections.Generic;
using System.Text;
using Adv.DAL.Entities.Common;
using Adv.DAL.Entities.Images;

namespace Adv.DAL.Entities.Adverts
{
    public class FlatRent : BaseAdvert
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
