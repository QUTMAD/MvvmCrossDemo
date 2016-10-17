using System;
using Android.App;
using Android.OS;
using EstimoteSdk;
using MvvmCross.Droid.Views;
using BeaconsDemo.Core.ViewModels;

namespace BeaconsDemo.Droid.Views
{
    [Activity(Label = "View for FirstViewModel")]
    public class FirstView : MvxActivity, BeaconManager.IServiceReadyCallback
    {
        FirstViewModel vm;
        BeaconManager beaconManager;
        string scanId;
        string edScanId;
        bool isScanning;
        public void OnServiceReady()
        {
            isScanning = true;
            scanId = beaconManager.StartNearableDiscovery();
            edScanId = beaconManager.StartEddystoneScanning();

        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);
            vm = this.ViewModel as FirstViewModel;
            beaconManager = new BeaconManager(this);
            beaconManager.Nearable += BeaconManager_Nearable;
            //beaconManager.Eddystone += BeaconManager_Eddystone;
            beaconManager.Telemetry += BeaconManager_Telemetry;
            beaconManager.Connect(this);
        }

        private void BeaconManager_Telemetry(object sender, BeaconManager.TelemetryEventArgs e)
        {
            vm.BeaconStatus = string.Format("Found {0} eddystones at {1}", e.P0.Count, DateTime.Now);

        }

        //private void BeaconManager_Eddystone(object sender, BeaconManager.EddystoneEventArgs e)
        //{
        //    vm.BeaconStatus = string.Format("Found {0} eddystones at {1}", e.Eddystones.Count, DateTime.Now);
        //}

        private void BeaconManager_Nearable(object sender, BeaconManager.NearableEventArgs e)
        {
            vm.EddyStoneStatus = string.Format("Found {0} nearables at {1}", e.Nearables.Count, DateTime.Now);
        }

        protected override void OnStop()
        {
            base.OnStop();
            if (!isScanning)
            {
                return;
            }
            beaconManager.StopNearableDiscovery(scanId);
            beaconManager.StopEddystoneScanning(edScanId);
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
            beaconManager.Disconnect();
        }
    }
}
