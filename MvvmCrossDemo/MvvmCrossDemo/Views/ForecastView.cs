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
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.FullFragging.Fragments;
using MvvmCross.Binding.Droid.BindingContext;

namespace MvvmCrossDemo.Droid.Views
{
    [MvxFragment(typeof(ParentViewModel), Resource.Id.frameLayout)]
    [Register("mvvmcrossdemo.droid.ForecastView")]
    public class ForecastView : MvxFragment<ForecastViewModel>
    {

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return this.BindingInflate(Resource.Layout.ForecastView, container);
        }
        public override void OnResume()
        {
            //ViewModel.OnResume();
            base.OnResume();
        }

    }
}