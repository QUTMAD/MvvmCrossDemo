using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCrossDemo.Core.Interfaces;
using MvvmCrossDemo.Core.Models;
using MvvmCrossDemo.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing.Mobile;

namespace MvvmCrossDemo.Core.ViewModels
{
    public class WeatherMapViewModel : MvxViewModel
    {
        private GeoLocation myLocation;
        private IGeoCoder geocoder;
        private Action<GeoLocation,float> moveToLocation;
        private Action<GeoLocation,Forecast> weatherPinFound;
        public GeoLocation MyLocation
        {
            get { return myLocation; }
            set { myLocation = value; }
        }
        public override void Start()
        {
            NewMethod();

            base.Start();
        }

        private async void NewMethod()
        {
            //Prithwi
            IMobileBarcodeScanner scanner;
            var x = Mvx.TryResolve<IMobileBarcodeScanner>(out scanner);
            scanner.ScanContinuously(OnResult);
        }

        public void OnResult (ZXing.Result result)
        {
            var barcode = result.Text;
        }
        public WeatherMapViewModel(IGeoCoder geocoder)
        {
            this.geocoder = geocoder;
           
        }
        public void OnMyLocationChanged(GeoLocation location)
        {
            MyLocation = location;
        }
        public void MapTapped (GeoLocation location)
        {
            GetWeatherInfo(location);
        }

        private async Task GetWeatherInfo(GeoLocation location)
        {
            var weatherService = new WeatherService();
            var city = await geocoder.GetCityFromLocation(location);
            var locationKey = await weatherService.GetLocations(city);
            var bestLocation = locationKey.FirstOrDefault();
            var forecast = await weatherService.GetForecast(bestLocation.Key);
            location.Locality = city;
            weatherPinFound(location, forecast);
        }

        public void OnMapSetup(Action<GeoLocation,float> MoveToLocation, Action<GeoLocation,Forecast> WeatherPinFound)
        {
            moveToLocation = MoveToLocation;
            weatherPinFound = WeatherPinFound; 
        }
    }
}
