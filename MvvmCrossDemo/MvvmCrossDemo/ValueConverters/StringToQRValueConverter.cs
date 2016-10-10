using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Platform.Converters;
using Android.Graphics;
using ZXing;

namespace MvvmCrossDemo.Droid.ValueConverters
{
    public class StringToQRValueConverter : MvxValueConverter<string,Bitmap>
    {
        protected override Bitmap Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new ZXing.Common.EncodingOptions
                {
                    Height = 600,
                    Width = 600,
                    PureBarcode = true,
                    Margin = 20
                }
            };
            var bytes = writer.Write(value);
            return BitmapFactory.DecodeByteArray(bytes,0,bytes.Length);
            
        }
    }
}