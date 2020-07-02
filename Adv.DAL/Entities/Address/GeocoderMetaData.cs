namespace Adv.DAL.Entities.Address
{
    public class GeocoderMetaData
    {
        public int Id { get; set; }
        public string Kind { get; set; }
        public string Text { get; set; }
        public string Precision { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}