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

namespace MvvmCrossDemo.Droid.Database
{
    public class AzureDatabase : IAzureDatabase
    {
        public MobileServiceClient GetMobileServiceClient()
        {
            CurrentPlatform.Init();
            var client = new MobileServiceClient("http://qutmadsem22016wednesday3.azurewebsites.net/");
            return client;
        }
    }
}