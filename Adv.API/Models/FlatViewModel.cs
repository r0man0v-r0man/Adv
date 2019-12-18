﻿using Adv.API.Models.Enums;
using Adv.BLL.DTO;

namespace Adv.API.Models
{
    public class FlatViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public City.District District { get; set; }


        public static implicit operator FlatViewModel(FlatDTO flat) => new FlatViewModel
        {
            Id = flat.Id,
            Description = flat.Description,
            District = flat.District
        };
    }
}
