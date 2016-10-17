using System;
using Android.App;
using Android.OS;
using EstimoteSdk;
using MvvmCross.Droid.Views;
using BeaconsDemo.Core.ViewModels;
using EstimoteSdk.EddystoneSdk;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

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
            edScanId = beaconManager.StartEddystoneScanning();
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);
            vm = this.ViewModel as FirstViewModel;
            beaconManager = new BeaconManager(this);
            beaconManager.Eddystone += BeaconManager_Eddystone;
            beaconManager.Connect(this);
        }

        private void BeaconManager_Eddystone(object sender, BeaconManager.EddystoneEventArgs e)
        {
            vm.EddyStoneList.Clear();
            var eddys = new List<Eddystone>(e.Eddystones);
            var sortedEddys = eddys.OrderBy(ed => ed.Rssi);
            foreach (var stone in sortedEddys)
            {
                vm.EddyStoneList.Add(new Core.Models.EddyStone
                {
                    CalibratedTxPower = stone.CalibratedTxPower,
                    Instance = stone.Instance,
                    MacAddress = stone.MacAddress.ToString(),
                    Namespace = stone.Namespace,
                    Rssi = stone.Rssi,
                    TelemetryLastSeenMillis = Convert.ToInt16(stone.TelemetryLastSeenMillis),
                    Url = stone.Url
                });
            }
        }

        protected override void OnStop()
        {
            base.OnStop();
            if (!isScanning)
            {
                return;
            }
            beaconManager.StopEddystoneScanning(edScanId);
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
            beaconManager.Disconnect();
        }
    }
}
