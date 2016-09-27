using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmCrossDemo.Core.Services
{
    public static class WeatherApp
    {
        public static string ApiKey = "nPw9SGrOEy51dq15WPaBUjBwBEDAAwW0";

     
        public static string AutoCompleteEndpoint = "http://dataservice.accuweather.com/locations/v1/cities/autocomplete";

        public static string ForecastEndpoint = "http://dataservice.accuweather.com/forecasts/v1/daily/1day/";
    }
}
