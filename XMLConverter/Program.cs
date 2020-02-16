using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace XMLConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var path = Environment.CurrentDirectory.ToString();
                var index = path.ToLower().LastIndexOf("xmlconverter");

                var destination = path.Remove(index);

                var files = new DirectoryInfo(destination);
                var file = files.GetFiles("map.osm");

                var doc = XDocument.Load(Path.Combine(destination, @"map.osm"));
                var streets = doc.Root
                    .Elements("way")
                    .Elements("tag")
                        .Where(x => (string)x.Attribute("k") == "name:ru")
                        .Select(tag => JsonConvert.SerializeXNode(tag))
                        .Distinct()
                            .Select(x => JsonConvert.DeserializeXNode(x))
                            .Elements("tag").Attributes("v")
                                .Select(val => new Street { Name = val.Value })
                                    .Where(street => street.Name.Contains("улица") || street.Name.Contains("переулок"))
                            .ToList();
                var city = new City
                {
                    Name = "Несвиж",
                    Streets = streets
                };

                using var fs = File.CreateText(Path.Combine(destination, @"adv.api\ClientApp\src\assets\streets.json"));

                JsonSerializer serializer = new JsonSerializer() ;
                serializer.Formatting = Formatting.Indented;
                serializer.ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() };
                serializer.Serialize(fs, city);
                Console.WriteLine("Parse Done!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            

            Console.ReadKey();


        }
    }
}
