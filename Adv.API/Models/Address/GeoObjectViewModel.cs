using Adv.BLL.DTO.Address;

namespace Adv.API.Models.Address
{
    public class GeoObjectViewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? BoundedById { get; set; }
        public BoundedByViewModel BoundedBy { get; set; }
        public int? MetaDataPropertyId { get; set; }
        public MetaDataPropertyViewModel MetaDataProperty { get; set; }
        public int? PointId { get; set; }
        public PointViewModel Point { get; set; }
        

        /// <summary>
        /// DTO -> VIEW
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static implicit operator GeoObjectViewModel(GeoObjectDto dto) => new GeoObjectViewModel
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description,
            BoundedById = dto.BoundedById,
            BoundedBy = dto.BoundedBy,
            MetaDataPropertyId = dto.MetaDataPropertyId,
            MetaDataProperty = dto.MetaDataProperty,
            Point = dto.Point,
            PointId = dto.PointId
        };

        /// <summary>
        /// VIEW -> DTO
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public static implicit operator GeoObjectDto(GeoObjectViewModel view) => new GeoObjectDto
        {
            Name = view.Name,
            Description = view.Description,
            BoundedBy = view.BoundedBy,
            MetaDataProperty = view.MetaDataProperty,
            Point = view.Point
        };
    }
}