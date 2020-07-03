using Adv.DAL.Entities.Address;

namespace Adv.BLL.DTO.Address
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
        public int PointId { get; set; }
        public PointDto Point { get; set; }

        /// <summary>
        /// DAL -> DTO
        /// </summary>
        /// <param name="dal"></param>
        /// <returns></returns>
        public static implicit operator GeoObjectDto(GeoObject dal) => new GeoObjectDto
        {
            Id = dal.Id,
            Name = dal.Name,
            Description = dal.Description,
            BoundedById = dal.BoundedById,
            BoundedBy = dal.BoundedBy,
            MetaDataPropertyId = dal.MetaDataPropertyId,
            MetaDataProperty = dal.MetaDataProperty,
            Point = dal.Point,
            PointId = dal.PointId
        };

        /// <summary>
        /// DTO -> DAL
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static implicit operator GeoObject(GeoObjectDto dto) => new GeoObject
        {
            Name = dto.Name,
            Description = dto.Description,
            BoundedBy = dto.BoundedBy,
            MetaDataProperty = dto.MetaDataProperty,
            Point = dto.Point
        };
    }
}