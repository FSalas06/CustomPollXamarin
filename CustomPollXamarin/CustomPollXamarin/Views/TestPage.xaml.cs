using System;
using System.Collections.Generic;
using CustomPollXamarin.Models;
using CustomPollXamarin.ViewModels;
using Xamarin.Forms;

namespace CustomPollXamarin.Views
{
    public partial class TestPage : ContentPage
    {
        private ViewModelTest _viewModel;

        public TestPage(ObjInit objInit)
        {
            InitializeComponent();
            BindingContext = _viewModel = new ViewModelTest(objInit);
        }
    }
}
