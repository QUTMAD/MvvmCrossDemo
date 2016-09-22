using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SQLite.Net;
using MvvmCrossDemo.Core.Interfaces;
using MvvmCrossDemo.Core.Models;
using MvvmCross.Platform;
using System.Threading.Tasks;

namespace MvvmCrossDemo.Core.Database
{
    public class LocationsDatabase : ILocationsDatabase
    {
        private SQLiteConnection database;
        public LocationsDatabase()
        {
            var sqlite = Mvx.Resolve<ISqlite>();
            database = sqlite.GetConnection();
            database.CreateTable<Location>();
        }

        public async Task<IEnumerable<Location>> GetLocations()
        {
            return database.Table<Location>().ToList();
        }
    
        public async Task<int> DeleteLocation(object id)
        {
            return database.Delete<Location>(Convert.ToInt16(id));
        }

        public async Task<int> InsertLocation(Location location)
        {
            var num =  database.Insert(location);
            database.Commit();
            return num;
        }

        public async Task<bool> CheckIfExists(Location location)
        {
            var exists =  database.Table<Location>()
                .Any(x => x.LocalizedName == location.LocalizedName
                || x.Key == location.Key);
            return exists;
        }

        public async Task<int> InsertLocation(LocationAutoCompleteResult location)
        {
            return await InsertLocation(new Models.Location(location));
        }

        public async Task<bool> CheckIfExists(LocationAutoCompleteResult location)
        {
            return await CheckIfExists(new Location(location));
        }
    }
}