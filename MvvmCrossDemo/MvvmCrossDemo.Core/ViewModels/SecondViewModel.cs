using MvvmCross.Core.ViewModels;
using MvvmCrossDemo.Core.Models.NavigationParams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmCrossDemo.Core.ViewModels
{
    public class SecondViewModel : MvxViewModel
    {
        private string unitCode;

        public string UnitCode
        {
            get { return unitCode; }
            set { SetProperty(ref unitCode, value); }
        }

        private string unitName;

        public string UnitName
        {
            get { return unitName; }
            set { SetProperty(ref unitName, value); }
        }

        public void Init(SecondParameters parameters)
        {
            UnitCode = parameters.SelectedUnitCode;
            UnitName = parameters.SelectedUnitName;
        }
    }
}
