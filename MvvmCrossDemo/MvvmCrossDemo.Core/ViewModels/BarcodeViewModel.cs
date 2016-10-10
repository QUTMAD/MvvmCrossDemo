using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmCrossDemo.Core.ViewModels
{
    public class BarcodeViewModel : MvxViewModel
    {
        private string qRCode;

        public string QRCode
        {
            get { return qRCode; }
            set { SetProperty(ref qRCode, value); }
        }

        public void Init(string param)
        {
            QRCode = param;
        }
    }
}
