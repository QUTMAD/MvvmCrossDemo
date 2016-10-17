using MvvmCross.Core.ViewModels;

namespace BeaconsDemo.Core.ViewModels
{
    public class FirstViewModel 
        : MvxViewModel
    {
        private string beaconStatus;

        public string BeaconStatus
        {
            get { return beaconStatus; }
            set { SetProperty(ref beaconStatus, value); }
        }
        private string eddyStoneStatus;

        public string EddyStoneStatus
        {
            get { return eddyStoneStatus; }
            set { SetProperty(ref eddyStoneStatus, value); }
        }

    }
}
