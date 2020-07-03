using System.Collections.Generic;

namespace Adv.DAL.Entities.Address
{
    public class Address
    {
        public int Id { get; set; }
        public string Country_code { get; set; }
        public string Postal_code { get; set; }
        public string Formatted { get; set; }
        public IList<Component> Components { get; set; }
    }
}