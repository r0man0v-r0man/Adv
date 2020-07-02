namespace Adv.BLL.DTO.Address
{
    public class MetaDataPropertyDto
    {
        public int Id { get; set; }
        public int GeocoderMetaDataId { get; set; }
        public GeocoderMetaDataDto GeocoderMetaData { get; set; }
    }
}