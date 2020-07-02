﻿namespace Adv.BLL.DTO.Address
{
    public class GeoObjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BoundedById { get; set; }
        public BoundedByDto BoundedBy { get; set; }
        public int MetaDataPropertyId { get; set; }
        public MetaDataPropertyDto MetaDataProperty { get; set; }
    }
}