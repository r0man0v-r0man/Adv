using Adv.DAL.Entities.Adverts;

namespace Adv.DAL.Entities
{
    public class Address
    {
        public int Id { get; set; }
        /// <summary>
        /// точный адрес
        /// </summary>
        public string ExactLocation { get; set; }
        
        public int CityId { get; set; }
        public City City { get; set; }
        
    }
}