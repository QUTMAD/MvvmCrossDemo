using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
namespace MvvmCrossDemo.Core.Models
{
    public class LocationAutoCompleteResult
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        [JsonProperty("Version")]
        public int WeatherVersion { get; set; }
        public string Key { get; set; }
        public string Type { get; set; }
        public int Rank { get; set; }
        public string LocalizedName { get; set; }
        [JsonProperty("Country")]
        [Ignore]
        public Country Countrie { get; set; }
        [Ignore]
        public AdministrativeAreaT AdministrativeArea { get; set; }
        public class Country
        {
            public string Id { get; set; }
            public string LocalizedName { get; set; }
        }

        public class AdministrativeAreaT
        {
            public string Id { get; set; }
            public string LocalizedName { get; set; }
        }
    }
}
