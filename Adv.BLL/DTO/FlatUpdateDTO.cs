﻿using Adv.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adv.BLL.DTO
{
    public class FlatUpdateDTO
    {
        public string Description { get; set; }
        public static implicit operator FlatUpdate(FlatUpdateDTO flatUpdateDTO)=> new FlatUpdate
        {
            Description = flatUpdateDTO?.Description
        };
    }
}
