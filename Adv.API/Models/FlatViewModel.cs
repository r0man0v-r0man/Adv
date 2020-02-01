﻿using Adv.API.Models.Enums;
using Adv.API.Models.Files;
using Adv.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Adv.API.Models
{
    public class FlatViewModel : API.Models.Common.AuditableEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Cities.CityName City { get; set; }
        public bool IsActive { get; set; }
        public decimal Price { get; set; }
        public List<FileModel> Files { get; set; }
        public string Street { get; set; }
        public int NumberOfHouse { get; set; }
        public int NumberOfHouseCourpus { get; set; }
        public int NumberOfSubHouse { get; set; }
        public int NumberOfFlat { get; set; }
        public string UserId { get; set; }

        /// <summary>
        /// Mapping to FlatViewModel
        /// </summary>
        /// <param name="flat">DTO entity</param>
        public static implicit operator FlatViewModel(FlatDTO flat) => new FlatViewModel
        {
            Id = flat.Id,
            Description = flat.Description,
            City = flat.City,
            IsActive = flat.IsActive,
            Price = flat.Price,
            Files = flat.Images
                .Select(kvp => new FileModel
                {
                    Uid = kvp.Key,
                    LinkProps = kvp.Value
                })
                .ToList(),
            Street = flat.Address["street"],
            NumberOfHouse = Convert.ToInt32(flat.Address["house"], CultureInfo.GetCultureInfo(1049)),
            NumberOfHouseCourpus = Convert.ToInt32(flat.Address["corpus"], CultureInfo.GetCultureInfo(1049)),
            NumberOfSubHouse = Convert.ToInt32(flat.Address["subHouse"], CultureInfo.GetCultureInfo(1049)),
            NumberOfFlat = Convert.ToInt32(flat.Address["flat"], CultureInfo.GetCultureInfo(1049)),
            Created = flat.Created
        };
        /// <summary>
        /// Mapping to FlatDTO model
        /// </summary>
        /// <param name="flat"></param>
        public static implicit operator FlatDTO(FlatViewModel flat) => new FlatDTO
        {
            Images = flat?.Files.ToDictionary(x => x.Uid, x => x.LinkProps.Download),
            IsActive = flat.IsActive,
            Price = flat.Price,
            City = flat.City,
            Description = flat.Description,
            Id = flat.Id,
            Address = new Dictionary<string, string>
            {
                ["street"] = flat.Street,
                ["house"] = flat.NumberOfHouse.ToString(CultureInfo.GetCultureInfo(1049)),
                ["corpus"] = flat.NumberOfHouseCourpus.ToString(CultureInfo.GetCultureInfo(1049)),
                ["subHouse"] = flat.NumberOfSubHouse.ToString(CultureInfo.GetCultureInfo(1049)),
                ["flat"] = flat.NumberOfFlat.ToString(CultureInfo.GetCultureInfo(1049))
            },

        };
    }
}
