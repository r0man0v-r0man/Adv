﻿using Adv.DOMAIN.Common;
using Adv.DOMAIN.Enums;
namespace Adv.DOMAIN.Entities
{
    public abstract class Flat : AuditableEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Cities.CityName City { get; set; }
        public bool IsActive { get; set; }
        public decimal Price { get; set; }
        /// <summary>
        /// key - uid/value - url, pairs of images
        /// </summary>
        public string Images { get; set; }
        /// <summary>
        /// Street + house + corpus + subHouse + flat(flatNumber)
        /// </summary>
        public string Address { get; set; }
    }

}
