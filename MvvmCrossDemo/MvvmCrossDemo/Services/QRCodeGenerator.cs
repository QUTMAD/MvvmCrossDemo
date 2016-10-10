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
using MvvmCrossDemo.Core.Interfaces;
using ZXing.Common;
using ZXing;
using ZXing.QrCode;

namespace MvvmCrossDemo.Droid.Services
{
    public class QRCodeGenerator : IQRCodeGenerator
    {
        public byte[] Generate(string barcode)
        {
            try
            {
                var options = new QrCodeEncodingOptions
                {
                    Height = 300,
                    Width = 300,
                    Margin = 0,
                    PureBarcode = true
                };
                var writer = new BarcodeWriter { Format = BarcodeFormat.QR_CODE, Options = options };
                return writer.Write(barcode);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}