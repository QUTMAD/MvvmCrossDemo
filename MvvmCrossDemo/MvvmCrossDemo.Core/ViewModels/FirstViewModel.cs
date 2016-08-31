using MvvmCross.Core.ViewModels;
using MvvmCrossDemo.Core.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace MvvmCrossDemo.Core.ViewModels
{
    public class FirstViewModel
        : MvxViewModel
    {

        private ObservableCollection<Unit> unitCodes;
        public ObservableCollection<Unit> UnitCodes
        {
            get { return unitCodes; }
            set { SetProperty(ref unitCodes, value); }
        }
        private string unitCode;
        public string UnitCode
        {
            get { return unitCode; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref unitCode, value); 
                }
            }
        }

        private string unitName;
        public string UnitName
        {
            get { return unitName; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref unitName, value);
                }
            }
        }


        public ICommand ButtonCommand { get; private set; }
        public ICommand SelectUnitCommand { get; private set; }
        public FirstViewModel()
        {
            UnitCodes = new ObservableCollection<Unit>()
        {
            new Unit("IAB330","MobileAppDevelopement") ,
            new Unit() { UnitCode="IAB230",UnitName="UbiquitousComputing"}
        };
            ButtonCommand = new MvxCommand(() =>
            {
                AddUnit(new Unit(UnitCode, UnitName));
                RaisePropertyChanged(()=>UnitCodes);
            });

            SelectUnitCommand = new MvxCommand<Unit>(unit => 
            {
                UnitCode = unit.UnitCode;
                UnitName = unit.UnitName;
            });
        }

        public void AddUnit(Unit unit)
        {
            if (unit.UnitCode != null && unit.UnitName != null)
            {
                if (unit.UnitName.Trim() != string.Empty && unit.UnitCode.Trim() != string.Empty)
                {
                    UnitCodes.Add(unit);
                }
                else
                {
                    UnitName = UnitName.Trim();
                    UnitCode = UnitCode.Trim();
                }
            }
        }
    }
}
