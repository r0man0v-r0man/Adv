using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace XMLConverter
{
    public class Street
    {
        public string Name { get; set; }

    }
    public class City
    {
        public string Name { get; set; }
        public List<Street> Streets { get; set; }
        public City()
        {
            Streets = new List<Street>();
        }
    }
}
