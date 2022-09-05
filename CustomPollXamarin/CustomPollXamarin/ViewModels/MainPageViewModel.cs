using System;
using System.Windows.Input;
using CustomPollXamarin.Models;
using CustomPollXamarin.Views;
using MvvmHelpers;
using Xamarin.Forms;

namespace CustomPollXamarin.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private double _numerOfSteps;
        private bool _isEntry;
        private bool _isCheck;
        private bool _isPicker;
        private string _selectedColor;
        private double _checkSteps;
        private double _pickerSteps;
        private double _entrySteps;

        public double NumerOfSteps
        {
            get { return _numerOfSteps; }
            set { SetProperty(ref _numerOfSteps, value); }
        }

        public bool IsEntry
        {
            get { return _isEntry; }
            set { SetProperty(ref _isEntry, value); }
        }

        public bool IsCheck
        {
            get { return _isCheck; }
            set { SetProperty(ref _isCheck, value); }
        }

        public bool IsPicker
        {
            get { return _isPicker; }
            set { SetProperty(ref _isPicker, value); }
        }

        public string SelectedColor
        {
            get { return _selectedColor; }
            set { SetProperty(ref _selectedColor, value); }
        }

        public double CheckSteps
        {
            get { return _checkSteps; }
            set { SetProperty(ref _checkSteps, value); }
        }

        public double PickerSteps
        {
            get { return _pickerSteps; }
            set { SetProperty(ref _pickerSteps, value); }
        }

        public double EntrySteps
        {
            get { return _entrySteps; }
            set { SetProperty(ref _entrySteps, value); }
        }

        public ICommand NextCompleteCommand { get; private set; }

        public MainPageViewModel()
        {
            InitCommands();
        }

        private void InitCommands()
        {
            NextCompleteCommand = new Command(NextCompleteCommandExecute);
        }

        private void NextCompleteCommandExecute()
        {
            if(SelectedColor != null)
            {
                ObjInit obInit = new ObjInit
                {
                    ColorTheme = SelectedColor,
                    Steps = Convert.ToInt32(NumerOfSteps)
                };

                if (IsCheck)
                {
                    obInit.CheckCount = Convert.ToInt32(CheckSteps);
                }
                if (IsPicker)
                {
                    obInit.PickeCount = Convert.ToInt32(PickerSteps);
                }
                if (IsEntry)
                {
                    obInit.EntryCount = Convert.ToInt32(EntrySteps);
                }

                App.NavigationServices.PushAsync(new TestPage(obInit));
            }
        }
    }
}
