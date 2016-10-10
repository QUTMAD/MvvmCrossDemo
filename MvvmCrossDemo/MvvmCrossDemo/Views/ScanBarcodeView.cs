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
using ZXing.Mobile;
using MvvmCross.Core.ViewModels;
using MvvmCrossDemo.Core.ViewModels;
using MvvmCross.Droid.Views;

namespace MvvmCrossDemo.Droid.Views
{
    [Activity(Label = "ScanBarcodeView")]
    public class ScanBarcodeView : MvxActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ScanBarcodeLayout);
            MobileBarcodeScanner.Initialize(this.Application);

            // Create your application here
        }
    }
}