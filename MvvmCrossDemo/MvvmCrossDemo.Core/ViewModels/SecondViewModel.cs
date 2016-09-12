using MvvmCross.Core.ViewModels;
using MvvmCrossDemo.Core.Models;
using MvvmCrossDemo.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmCrossDemo.Core.ViewModels
{
    public class SecondViewModel : MvxViewModel
    {
        private LocationAutoCompleteResult selectedLocation;

        private string city;

        public string City
        {
            get { return city; }
            set { SetProperty(ref city, value); }
        }

        private string minimumTemperature;

        public string MinimumTemperature
        {
            get { return minimumTemperature; }
            set { SetProperty(ref minimumTemperature, value); }
        }
        private string maximumTemperature;

        public string MaximumTemperature
        {
            get { return maximumTemperature; }
            set { SetProperty(ref maximumTemperature, value); }
        }

        public void Init(LocationAutoCompleteResult parameters)
        {
            selectedLocation = parameters;

        }
        public override void Start()
        {
            base.Start();
            City = selectedLocation.LocalizedName;
            GetForecast();
        }

        public async void GetForecast()
        {
            var weatherService = new WeatherService();
            var weatherResult = await weatherService.GetForecast(selectedLocation.Key);
            var min = weatherResult.DailyForecasts.FirstOrDefault().Temperature.Minimum.Value;
            var max = weatherResult.DailyForecasts.FirstOrDefault().Temperature.Maximum.Value;
            MinimumTemperature = string.Format("{0} degrees Minimum", min);
            MaximumTemperature = string.Format("{0} degrees Maximum", max);
        }
    }
}
