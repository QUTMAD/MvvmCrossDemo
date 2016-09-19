using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;
using System;
using MvvmCross.Core.ViewModels;
using MvvmCrossDemo.Core.ViewModels;

namespace MvvmCrossDemo.Droid.Views
{
    [Activity(Label = "Location Search")]
    public class LocationSearchView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.LocationSearchView);
        }
    }
}
