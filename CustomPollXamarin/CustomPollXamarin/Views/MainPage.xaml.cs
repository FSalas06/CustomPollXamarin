using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomPollXamarin.ViewModels;
using Xamarin.Forms;

namespace CustomPollXamarin.Views
{
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new MainPageViewModel();
            App.NavigationServices = Navigation;
        }

        private void _slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            _slider.Value = Math.Round(e.NewValue);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            _numberSteps.Opacity = 0;
            _colorSteps.Opacity = 0;
            _questKind.Opacity = 0;
            _buttonStack.Opacity = 0;
            await OnFadeView(_numberSteps);
            await OnFadeView(_colorSteps);
            await OnFadeView(_questKind);
            await OnFadeView(_buttonStack);
        }

        private async Task OnFadeView(View view)
        {
            await view.FadeTo(1, 1000);
        }
    }
}
