using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCrossDemo.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ZXing.Mobile;

namespace MvvmCrossDemo.Core.ViewModels
{
    public class ScanBarcodeViewModel : MvxViewModel
    {

        private ObservableCollection<string> barcodes = new ObservableCollection<string>();

        public ObservableCollection<string> Barcodes
        {
            get { return barcodes; }
            set { SetProperty(ref barcodes, value); }
        }

       

        public ICommand GenerateQRCodeCommand { get; private set; }
        public ICommand ScanOnceCommand { get; private set; }
        public ICommand ScanContinuouslyCommand { get; private set; }
        public IMobileBarcodeScanner scanner;

        public ScanBarcodeViewModel()
        {
            GenerateQRCodeCommand = new MvxCommand<string>(selectedBarcode =>
            {
                ShowViewModel<BarcodeViewModel>(new { param = selectedBarcode });
            });
            ScanOnceCommand = new MvxCommand(ScanOnce);
            ScanContinuouslyCommand = new MvxCommand(ScanContinuously);
        }
        public async void ScanOnce()
        {
            var result = await scanner.Scan();
            OnResult(result);
        }
        public void ScanContinuously()
        {
            var options = new MobileBarcodeScanningOptions();
            options.UseNativeScanning = true;
            scanner.ScanContinuously(OnResult);
        }
        public void OnResult(ZXing.Result result)
        {
            var barcode = result.Text;
            Barcodes.Add(barcode);
            Mvx.Resolve<IToast>().Show(string.Format("Bar code = {0} added to list", barcode));
        }
        public override void Start()
        {
            base.Start();
            var x = Mvx.TryResolve<IMobileBarcodeScanner>(out scanner);
        }
    }
}
