using Adv.BLL.DTO.Enums;
using Adv.DAL.Entities;
using System;
using System.Collections.Generic;

namespace Adv.BLL.DTO
{
    public class FlatDTO : Common.AuditableEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public City.District District { get; set; }
        public bool IsActive { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public Dictionary<string, string> Address { get; set; }
        /// <summary>
        /// Mapping to DTO model
        /// </summary>
        /// <param name="flat">Data Access Layer flat</param>
        public static implicit operator FlatDTO(Flat flat) => new FlatDTO
        {
            Description = flat.Description,
            District = flat.District,
            Id = flat.Id,
            IsActive = flat.IsActive,
            Price = flat.Price,
            Image = flat.Image
        };
        /// <summary>
        /// Mapping to DAL model
        /// </summary>
        /// <param name="flat"></param>
        public static implicit operator Flat(FlatDTO flat) => new Flat
        {
                Id = flat.Id,
                Image = flat.Image,
                IsActive = flat.IsActive,
                Price = flat.Price,
                Description = flat.Description,
                District = flat.District,
                Address = flat.Address["street"] + "_" + 
                          flat.Address["house"] + "_" + 
                          flat.Address["corpus"] + "_" + 
                          flat.Address["subHouse"] + "_" + 
                          flat.Address["flat"]
        };
    }
}
