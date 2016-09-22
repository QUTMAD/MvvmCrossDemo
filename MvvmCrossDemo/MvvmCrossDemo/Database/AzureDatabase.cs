using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.WindowsAzure.MobileServices;
using MvvmCrossDemo.Core.Interfaces;
using System.IO;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using MvvmCrossDemo.Core.Models;

namespace MvvmCrossDemo.Droid.Database
{
    public class AzureDatabase : IAzureDatabase
    {
        MobileServiceClient azureDatabase;
        public MobileServiceClient GetMobileServiceClient()
        {
            CurrentPlatform.Init();

            azureDatabase = new MobileServiceClient("http://qutmadsem22016wednesday3.azurewebsites.net/");
            InitializeLocal();
            return azureDatabase;
        }
        private void InitializeLocal()
        {
            var sqliteFilename = "LocationSQLite.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }
            var store = new MobileServiceSQLiteStore(path);
            store.DefineTable<Location>();
            azureDatabase.SyncContext.InitializeAsync(store);
        }
    }
}