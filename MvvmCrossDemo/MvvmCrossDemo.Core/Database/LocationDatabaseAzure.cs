using MvvmCrossDemo.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCrossDemo.Core.Models;
using MvvmCross.Platform;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System.Diagnostics;

namespace MvvmCrossDemo.Core.Database
{
    public class LocationDatabaseAzure : ILocationsDatabase
    {
        private MobileServiceClient azureDatabase;
        private IMobileServiceSyncTable<Location> azureSyncTable;
        public LocationDatabaseAzure()
        {
            azureDatabase = Mvx.Resolve<IAzureDatabase>().GetMobileServiceClient();
            azureSyncTable = azureDatabase.GetSyncTable<Location>();
        }
     
        public async Task<bool> CheckIfExists(LocationAutoCompleteResult location)
        {
            var exists = await CheckIfExists(new Location(location));
            return exists;
        }

        public async Task<bool> CheckIfExists(Location location)
        {
            await SyncAsync(true);
            var locations = await azureSyncTable.Where(x => x.LocalizedName == location.LocalizedName || x.Key == location.Key).ToListAsync();
            return locations.Any();
        }

        public async Task<int> DeleteLocation(object id)
        {
            await SyncAsync(true);
            var location = await azureSyncTable.Where(x => x.Id == (string)id).ToListAsync();
            if (location.Any())
            {
                await azureSyncTable.DeleteAsync(location.FirstOrDefault());
                await SyncAsync();
                return 1;
            }
            else
            {
                return 0;

            }
        }

        public async Task<IEnumerable<Location>> GetLocations()
        {
            await SyncAsync(true);
            var locations = await azureSyncTable.ToListAsync();
            return locations;
        }

        public async Task<int> InsertLocation(LocationAutoCompleteResult location)
        {
            return await InsertLocation(new Location(location));
        }

        public async Task<int> InsertLocation(Location location)
        {
            await SyncAsync(true);
            await azureSyncTable.InsertAsync(location);
            await SyncAsync();
            return 1;
        }
        private async Task SyncAsync(bool pullData = false)
        {
            try
            {
                await azureDatabase.SyncContext.PushAsync();

                if (pullData)
                {
                    await azureSyncTable.PullAsync("allLocations", azureSyncTable.CreateQuery()); // query ID is used for incremental sync
                }
            }
          
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}
