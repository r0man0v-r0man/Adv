namespace Adv.DAL.Entities.Address
{
    public class YandexAddress
    {
        public int Id { get; set; }
        public int GeoObjectId { get; set; }
        public GeoObject GeoObject { get; set; }
    }
}