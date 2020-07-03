namespace Adv.DAL.Entities.Address
{
    public class GeoObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BoundedById { get; set; }
        public BoundedBy BoundedBy { get; set; }
        public int MetaDataPropertyId { get; set; }
        public MetaDataProperty MetaDataProperty { get; set; }
        public int PointId { get; set; }
        public Point Point { get; set; }
    }
}