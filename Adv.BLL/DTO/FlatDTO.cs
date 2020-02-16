using Adv.DAL.Entities;
using Adv.DAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Adv.BLL.DTO
{
    public class FlatDTO : Common.AuditableEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int City { get; set; }
        public bool IsActive { get; set; }
        public decimal Price { get; set; }
        public Dictionary<string, string> Images { get; set; }
        public Dictionary<string, string> Address { get; set; }
        public string UserId { get; set; }
        public byte Rooms { get; set; }
        public bool Furniture { get; set; }
        public bool Refrigerator { get; set; }
        public bool MicrowaveOven { get; set; }
        public bool Internet { get; set; }
        public bool WashingMachine { get; set; }
        public byte Duration { get; set; }
        public int Floor { get; set; }
        public int? AllFloor { get; set; }
        public string Phone { get; set; }

        /// <summary>
        /// Mapping to DTO model
        /// </summary>
        /// <param name="flat">Data Access Layer flat</param>
        public static implicit operator FlatDTO(Flat flat) => new FlatDTO
        {
            Description = flat?.Description,
            City = (int) flat.City,
            Id = flat.Id,
            IsActive = flat.IsActive,
            Price = flat.Price,
            Images = flat.Images
                .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Split('='))
                .ToDictionary(split => split[0], split => split[1]),
            Address = flat.Address
                .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Split('='))
                .ToDictionary(split => split[0], split => split[1]),
            Created = flat.Created,
            UserId = flat.AppUserId,
            Rooms = flat.Rooms,
            Furniture = flat.Furniture,
            Refrigerator = flat.Refrigerator,
            MicrowaveOven = flat.MicrowaveOven,
            Internet = flat.Internet,
            WashingMachine = flat.WashingMachine,
            Duration = (byte) flat.Duration,
            Floor = flat.Floor,
            AllFloor = flat.AllFloor
        };

        /// <summary>
        /// Mapping to DAL model
        /// </summary>
        /// <param name="flat"></param>
        public static implicit operator Flat(FlatDTO flat) => new Flat
        {
            Id = flat.Id,
            Images = string.Join(";", flat.Images.Select(x => x.Key + "=" + x.Value)),
            IsActive = flat.IsActive,
            Price = flat.Price,
            Description = flat.Description,
            City = (Cities.CityName) flat.City,
            Address = string.Join(";", flat.Address.Select(x => x.Key + "=" + x.Value)),
            AppUserId = flat.UserId,
            Rooms = flat.Rooms,
            Furniture = flat.Furniture,
            Refrigerator = flat.Refrigerator,
            MicrowaveOven = flat.MicrowaveOven,
            Internet = flat.Internet,
            WashingMachine = flat.WashingMachine,
            Duration = (Duration.RentTime) flat.Duration,
            Floor = flat.Floor,
            AllFloor = flat.AllFloor
        };
    }
}
