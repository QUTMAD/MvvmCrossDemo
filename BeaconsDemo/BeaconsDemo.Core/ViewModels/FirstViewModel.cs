using BeaconsDemo.Core.Models;
using MvvmCross.Core.ViewModels;
using System.Collections.ObjectModel;

namespace BeaconsDemo.Core.ViewModels
{
    public class FirstViewModel
        : MvxViewModel
    {
        private ObservableCollection<EddyStone> eddyStoneList = new ObservableCollection<EddyStone>();
        public ObservableCollection<EddyStone> EddyStoneList
        {
            get { return eddyStoneList; }
            set { SetProperty(ref eddyStoneList, value); }
        }

    }
}
