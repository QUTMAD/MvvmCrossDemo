using Microsoft.Azure.Mobile.Server;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMobileApp.DataObjects
{
    public class LocationAutoCompleteResult : EntityData
    {
        [JsonProperty("Version")]
        public int WeatherVersion { get; set; }
        public string Key { get; set; }
        public string Type { get; set; }
        public int Rank { get; set; }
        public string LocalizedName { get; set; }
        [JsonProperty("Country.ID")]
        public string CountryId { get; set; }
        [JsonProperty("Country.LocalizedName")]
        public string CountryLocalizedName { get; set; }
        [JsonProperty("AdministrativeArea.ID")]
        public string AdministrativeAreaId{ get; set; }
        [JsonProperty("AdministrativeArea.LocalizedName")]
        public string AdministrativeAreaLocalizedName { get; set; }
    }
}
