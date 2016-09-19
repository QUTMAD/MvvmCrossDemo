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
using MvvmCrossDemo.Core.Interfaces;
using MvvmCrossDemo.Core.Database;

namespace MvvmCrossDemo.Core.ViewModels
{
    public class LocationSearchViewModel
        : MvxViewModel
    {
        private ISqlite sqlite;
        private IDialogService dialog;
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

        public LocationSearchViewModel(ISqlite sqlite, IDialogService dialog)
        {
            this.sqlite = sqlite;
            this.dialog = dialog;
            Locations = new ObservableCollection<LocationAutoCompleteResult>();
            SelectLocationCommand = new MvxCommand<LocationAutoCompleteResult>(selectedLocation => 
            {
                SelectLocation(selectedLocation);
            });
        }

        public async void SelectLocation(LocationAutoCompleteResult selectedLocation)
        {
            var database = new LocationsDatabase(sqlite);

            if (!database.CheckIfExists(selectedLocation))
            {
                database.InsertLocation(selectedLocation);
                Close(this); 
            }
            else
            {
                if (await dialog.Show("This location has already been added", "Location Exists", "Keep Searching", "Go Back"))
                {
                    SearchTerm = string.Empty;
                    Locations.Clear();
                }
                else
                {
                    Close(this);
                }
            }
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
