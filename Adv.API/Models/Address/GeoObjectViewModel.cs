namespace Adv.API.Models.Address
{
    public class GeoObjectViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public BoundedByViewModel BoundedBy { get; set; }
        public MetaDataPropertyViewModel MetaDataProperty { get; set; }
    }
}