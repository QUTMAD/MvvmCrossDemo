using MvvmCross.Core.ViewModels;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace MvvmCrossDemo.Core.ViewModels
{
    public class FirstViewModel 
        : MvxViewModel
    {
        private string _hello = "Hello MvvmCross";
        public string Hello
        { 
            get { return _hello; }
            set
            {
                if (value!= null && value!= _hello)
                {
                    _hello = value;
                    RaisePropertyChanged(() => Hello);
                }
            }
        }

        private double sliderValue;

        public double SliderValue
        {
            get { return sliderValue; }
            set
            {
                SetProperty(ref sliderValue, value);
            }
        }

        public ICommand ButtonCommand { get; private set; }

        public FirstViewModel()
        {
            ButtonCommand = new MvxCommand(() =>
            {
                Hello = "Button has been pressed!!!";
            });
        }
    }
}
