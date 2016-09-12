using MvvmCross.Core.ViewModels;
using MvvmCrossDemo.Core.Models;
using MvvmCrossDemo.Core.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvvmCrossDemo.Core.ViewModels
{
    public class FirstViewModel
        : MvxViewModel
    {
        private ObservableCollection<LocationAutoCompleteResult> locations;

        public ObservableCollection<LocationAutoCompleteResult> Locations
        {
            get { return locations; }
            set { SetProperty(ref locations, value); }
        }



        private string searchTerm;

        public string SearchTerm
        {
            get { return searchTerm; }
            set { SetProperty(ref searchTerm, value);
                if (searchTerm.Length > 3)
                {
                    SearchLocations(searchTerm);
                }
            }
        }

        public ICommand SelectLocationCommand { get; private set; }

        public FirstViewModel()
        {
            Locations = new ObservableCollection<LocationAutoCompleteResult>();
            SelectLocationCommand = new MvxCommand<LocationAutoCompleteResult>(selectedLocation => ShowViewModel<SecondViewModel>(selectedLocation));
        }


        public async void SearchLocations(string searchTerm)
        {
            WeatherService weatherService = new WeatherService();
            Locations.Clear();
            var locationResults = await weatherService.GetLocations(searchTerm);
            var bestLocationResults = locationResults.Where(location => location.Rank > 80);
            foreach (var item in bestLocationResults)
            {
                Locations.Add(item);
            }
        }
      
    }
}
