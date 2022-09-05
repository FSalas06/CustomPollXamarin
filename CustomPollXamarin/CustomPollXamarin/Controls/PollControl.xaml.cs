using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomPollXamarin.Controls
{
    public partial class PollControl : ContentView
    {
        public static readonly BindableProperty ItemSourcesProperty =
            BindableProperty.Create(nameof(ItemSources), typeof(IEnumerable),
                typeof(PollControl), null, BindingMode.TwoWay, propertyChanged: OnEventItemSourceChange);

        private async static void OnEventItemSourceChange(BindableObject bindable, object oldValue, object newValue)
        {
            var ob = (PollControl)bindable;
            ob.Opacity = 0;
            await ob.FadeTo(1, 2000);
        }

        public IEnumerable ItemSources
        {
            get
            {
                return (IEnumerable)GetValue(ItemSourcesProperty);
            }

            set
            {
                SetValue(ItemSourcesProperty, value);
            }
        }

        public static readonly BindableProperty MainColorProperty =
            BindableProperty.Create(nameof(MainColor), typeof(Color),
                typeof(PollControl), Color.Black, BindingMode.TwoWay);

        public Color MainColor
        {
            get
            {
                return (Color)GetValue(MainColorProperty);
            }

            set
            {
                SetValue(MainColorProperty, value);
            }
        }

        public PollControl()
        {
            InitializeComponent();
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if(propertyName == MainColorProperty.PropertyName)
            {
                Application.Current.Resources["baseColor"] = MainColor;
            }
            if (propertyName == ItemSourcesProperty.PropertyName)
            {
                _questionaryList.ItemsSource = ItemSources;
            }
        }
    }
}
