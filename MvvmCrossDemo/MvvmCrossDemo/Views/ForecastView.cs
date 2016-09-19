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
using MvvmCross.Droid.Views;
using MvvmCrossDemo.Core.ViewModels;

namespace MvvmCrossDemo.Droid.Views
{
    [Activity(Label = "Forecast")]
    public class ForecastView : MvxActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ForecastView);
            // Create your application here
        }
        protected override void OnResume()
        {
            var vm = (ForecastViewModel)ViewModel;
            vm.OnResume();
            base.OnResume();
        }
    }
}