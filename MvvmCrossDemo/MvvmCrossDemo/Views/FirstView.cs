using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;
using System;
using MvvmCross.Core.ViewModels;
using MvvmCrossDemo.Core.ViewModels;

namespace MvvmCrossDemo.Views
{
    [MvxViewFor(typeof(FirstViewModel))]
    [Activity(Label = "View for FirstViewModel")]
    public class FirstView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);
        }
    }
}
