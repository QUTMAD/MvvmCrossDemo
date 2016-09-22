using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCrossDemo.Core.Database;
using MvvmCrossDemo.Core.Interfaces;
using MvvmCrossDemo.Core.Models;
using MvvmCrossDemo.Core.Services;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmCrossDemo.Core.ViewModels
{
    public class ForecastViewModel : MvxViewModel
    {
        List<LocationAutoCompleteResult> locations = new List<LocationAutoCompleteResult>();
        private ObservableCollection<ForecastWrapper> forecasts = new ObservableCollection<ForecastWrapper>();
        private readonly ILocationsDatabase locationsDatabase;

        public ObservableCollection<ForecastWrapper> Forecasts
        {
            get { return forecasts; }
            set { SetProperty(ref forecasts, value); }
        }

        public ICommand AddNewLocationCommand { get; private set; }
        public ForecastViewModel(ILocationsDatabase locationsDatabase)
        {
            this.locationsDatabase = locationsDatabase;
            AddNewLocationCommand = new MvxCommand(() => ShowViewModel<LocationSearchViewModel>());
        }
        public void OnResume()
        {
            GetForecasts();
        }
        public async void GetForecasts()
        {
            var locations = await locationsDatabase.GetLocations();
            var weatherService = new WeatherService();
            Forecasts.Clear();
            foreach (var location in locations)
            {
                var forecast = await weatherService.GetForecast(location.Key);
                if (forecast != null)
                {
                    Forecasts.Add(new ForecastWrapper(forecast, location.LocalizedName)); 
                }
                else
                {
                    locationsDatabase.DeleteLocation(location.Id);
                }
            }
        }
    }
}
