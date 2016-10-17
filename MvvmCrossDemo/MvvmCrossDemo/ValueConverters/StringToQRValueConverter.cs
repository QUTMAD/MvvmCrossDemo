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
using ZXing.QrCode;
using ZXing.Common;

namespace MvvmCrossDemo.Droid.ValueConverters
{
    public class StringToQRValueConverter : MvxValueConverter<string,Bitmap>
    {
        protected override Bitmap Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            //var writer = new BarcodeWriter
            //{
            //    Format = BarcodeFormat.QR_CODE,
            //    Options = new ZXing.Common.EncodingOptions
            //    {
            //        Height = 600,
            //        Width = 600,
            //        PureBarcode = true,
            //        Margin = 20
            //    }
            //};
            Writer writer = new QRCodeWriter();
            const int HEIGHT = 600;
            const int WIDTH = 600;
          
            BitMatrix bm = writer.encode(value, BarcodeFormat.QR_CODE, HEIGHT, WIDTH);
            Bitmap imageBitmap = Bitmap.CreateBitmap(HEIGHT, WIDTH, Bitmap.Config.Argb8888);
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    imageBitmap.SetPixel(i, j, bm[i, j] ? Color.Black : Color.White);
                }
            }
            return imageBitmap;
            
            
        }
    }
}