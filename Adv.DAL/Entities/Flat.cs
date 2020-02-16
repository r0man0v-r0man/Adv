using Adv.DAL.Entities.Common;
using Adv.DAL.Entities.Enums;

namespace Adv.DAL.Entities
{
    public class Flat : AuditableEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Cities.CityName City { get; set; }
        public bool IsActive { get; set; }
        public decimal Price { get; set; }
        /// <summary>
        /// key - uid/value - url, pairs of images
        /// </summary>
        public string Images { get; set; }
        /// <summary>
        /// Street + house + corpus + subHouse + flat(flatNumber)
        /// </summary>
        public string Address { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        /// <summary>
        /// Count of room
        /// </summary>
        public byte Rooms { get; set; }
        public bool Furniture { get; set; }
        public bool Refrigerator { get; set; }
        public bool MicrowaveOven { get; set; }
        public bool Internet { get; set; }
        public bool WashingMachine { get; set; }
        /// <summary>
        /// Duration long -0, short -1
        /// </summary>
        public Duration.RentTime Duration { get; set; }
        public int Floor { get; set; }
        public int? AllFloor { get; set; }
        public string Phone { get; set; }

    }

}
